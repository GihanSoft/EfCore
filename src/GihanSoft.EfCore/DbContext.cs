using GihanSoft.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace GihanSoft.EfCore
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext {
        private readonly ICrypto cryptographer;

        public DbContext (DbContextOptions options, ICrypto cryptographer = null) : base (options) {
            this.cryptographer = cryptographer;
        }
        public DbContext (ICrypto cryptographer = null) : base () {
            this.cryptographer = cryptographer;
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);
            modelBuilder.UseIndexAttribute ();
            if (cryptographer != null)
                modelBuilder.UseCryptography (cryptographer);
        }
    }
}