using GihanSoft;
using GihanSoft.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Cryptography;

namespace Gihan.EfCore
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly ICrypto cryptographer;

        public DbContext(DbContextOptions options, ICrypto cryptographer = null)
            : base(options)
        {
            this.cryptographer = cryptographer;
        }
        public DbContext(ICrypto cryptographer = null)
        {
            this.cryptographer = cryptographer;
        }

        private static void UseIndexAttr(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    var index = property.PropertyInfo?.GetCustomAttribute<IndexAttribute>();
                    if (index == null) continue;
                    if (property.ClrType == typeof(string))
                        modelBuilder.Entity(entityType.ClrType)
                            .Property(property.Name)
                            .HasMaxLength(450);
                    var indexBuilder = modelBuilder.Entity(entityType.ClrType)
                        .HasIndex(property.Name);
                    if (index.IsUnique)
                        indexBuilder.IsUnique();
                }
            }
        }

        private static void UseEncryptionAttr(ModelBuilder builder, ICrypto cryptographer)
        {
            var hash = SHA256.Create();
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var encryptedAttribute = entityType.ClrType.GetCustomAttribute<EncryptedAttribute>();
                if (encryptedAttribute != null && encryptedAttribute.EncryptName)
                    builder.Entity(entityType.ClrType).ToTable(entityType.Name.Hash(hash).EncodeBase64());
                foreach (var property in entityType.GetProperties())
                {
                    encryptedAttribute = property.PropertyInfo.GetCustomAttribute<EncryptedAttribute>()
                        ?? encryptedAttribute;
                    if (encryptedAttribute != null
                        && property.PropertyInfo.GetCustomAttribute<UnEncryptedAttribute>() is null)
                    {
                        if (encryptedAttribute.EncryptName)
                            builder.Entity(entityType.ClrType).Property(property.Name).
                                HasColumnName(property.Name.Hash(hash).EncodeBase64());
                        var hasSalt = encryptedAttribute.UseSalt;
                        var stringToEncryptedConverter =
                            new StringToEncryptedConverter(cryptographer, hasSalt);
                        if (property.ClrType == typeof(string))
                            property.SetValueConverter(stringToEncryptedConverter);
                        else
                            property.SetValueConverter(
                                new ValueToStringConverter(property.ClrType)
                                    .ComposeWith(stringToEncryptedConverter));
                    }
                }
            }
            hash.Dispose();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UseIndexAttr(modelBuilder);
            if(cryptographer != null)
                UseEncryptionAttr(modelBuilder, cryptographer);
            base.OnModelCreating(modelBuilder);
        }
    }
}
