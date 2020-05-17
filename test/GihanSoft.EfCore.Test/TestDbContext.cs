using GihanSoft.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GihanSoft.EfCore.Test
{
    public class AppBuilder : IDesignTimeDbContextFactory<TestDbContext>
    {

        public TestDbContext CreateDbContext(string[] args)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder();
            dbContextOptionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Test;Integrated Security=True;");
            var options = dbContextOptionsBuilder.Options;
            return new TestDbContext(options, new AesCrypto(new AesCryptoOptions { Password = "pass" }));
        }
    }

    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options, ICrypto cryptographer = null) : base(options, cryptographer)
        {
        }

        public DbSet<User> Users { get; set; }
    }

    [Encrypted(UseSalt = false)]
    public class User : EntityBase
    {
        [Encrypted(UseSalt = true)]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Mobile { get; set; }

        [UnEncrypted]
        public string Password { get; set; }

    }
}
