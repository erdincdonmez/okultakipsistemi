using Microsoft.EntityFrameworkCore;

namespace WebApplication2MVC.Models


{
    public class OkulDbContext : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ogretmen> Ogretmenler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbAyarlari)
        {
            base.OnConfiguring(dbAyarlari);
            dbAyarlari.UseSqlServer("Data Source=.;Integrated Security=true;Initial Catalog=OkulDbMVC");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            //modelBuilder.Entity<Ogrenci>().Property(o => o.OgrenciId).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.AdSoyad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
        }
    }
}
