using GihanSoft.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;
using System.Security.Cryptography;

namespace GihanSoft.EfCore
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder UseIndexAttribute(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    var index = property.PropertyInfo?.GetCustomAttribute<IndexAttribute>();
                    if (index == null) continue;
                    //if (property.ClrType == typeof (string))
                    //    modelBuilder.Entity (entityType.ClrType)
                    //    .Property (property.Name)
                    //    .HasMaxLength (450);
                    var indexBuilder = modelBuilder.Entity(entityType.ClrType)
                        .HasIndex(property.Name);
                    indexBuilder = indexBuilder.IsUnique(index.IsUnique);
                    if (!string.IsNullOrEmpty(index.Name))
                        indexBuilder.HasName(index.Name);
                }
            }
            return modelBuilder;
        }

        public static ModelBuilder UseCryptography(this ModelBuilder modelBuilder, ICrypto crypto)
        {
            var hash = SHA256.Create();
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var encryptedAttribute = entityType.ClrType.GetCustomAttribute<EncryptedAttribute>();
                if (encryptedAttribute != null && encryptedAttribute.EncryptName)
                    modelBuilder.Entity(entityType.ClrType).ToTable(entityType.Name.Hash(hash).EncodeBase64());
                foreach (var property in entityType.GetProperties())
                {
                    if (property?.PropertyInfo == null)
                        continue;
                    var encryptedAttributeProp = property.PropertyInfo.GetCustomAttribute<EncryptedAttribute>()
                        ?? encryptedAttribute;
                    if (encryptedAttributeProp != null &&
                        property.PropertyInfo.GetCustomAttribute<UnEncryptedAttribute>() is null)
                    {
                        if (encryptedAttributeProp.EncryptName)
                            modelBuilder.Entity(entityType.ClrType).Property(property.Name).
                        HasColumnName(property.Name.Hash(hash).EncodeBase64());
                        var hasSalt = encryptedAttributeProp.UseSalt;
                        var stringToEncryptedConverter =
                            new StringToEncryptedConverter(crypto, hasSalt);
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
            return modelBuilder;
        }
    }
}
