using GihanSoft.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography;
using Xunit;

namespace GihanSoft.EfCore.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder();
            dbContextOptionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Test;Integrated Security=True;");
            var options = dbContextOptionsBuilder.Options;
            var db = new TestDbContext(options, new AesCrypto(new AesCryptoOptions { Password = "pass" }));
            db.Users.RemoveRange(db.Users.ToArray());
            db.Add(new User
            {
                UserName = "chief",
                Email = "m@b.c",
                Nickname = "chief mb",
                Mobile = "09181231212",
                Password = "Br00z".Hash(SHA512.Create()).EncodeBase64()
            });
            db.SaveChanges();
            db.Dispose();

            db = new TestDbContext(options, new AesCrypto(new AesCryptoOptions { Password = "pass" }));
            var users = db.Users.ToArray();
            Assert.Equal("chief", users.Last().UserName);
        }
    }
}
