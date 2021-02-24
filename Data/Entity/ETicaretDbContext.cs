using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_PostgreSQL.Data.Entity
{
    public class ETicaretDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Eticaret;Username=postgres;Password=123");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Kullanici> Kullanicis { get; set; }
        public DbSet<Sepet> Sepets { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<SiparisDetay> SiparisDetays { get; set; }
        public DbSet<Adres> Adres { get; set; }

    }
}
