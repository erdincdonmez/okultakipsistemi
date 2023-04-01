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
            modelBuilder.Entity<Ogrenci>().Property(o => o.OgrenciId).HasColumnType("int").HasMaxLength(5).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Adi).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyadi).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.AdSoyad).HasColumnType("varchar").HasMaxLength(30);
            modelBuilder.Entity<Ogrenci>().Property(o => o.TC).HasColumnType("varchar").HasMaxLength(11);
            modelBuilder.Entity<Ogrenci>().Property(o => o.Sinifi).HasColumnType("varchar").HasMaxLength(11);
            
            modelBuilder.Entity<Ogretmen>().ToTable("tblOgretmenler");
            modelBuilder.Entity<Ogretmen>().Property(o => o.Ogretmenid).HasColumnType("int").HasMaxLength(5).IsRequired();
            modelBuilder.Entity<Ogretmen>().Property(o => o.Adi).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogretmen>().Property(o => o.Soyadi).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogretmen>().Property(o => o.AdSoyad).HasColumnType("varchar").HasMaxLength(30);
            modelBuilder.Entity<Ogretmen>().Property(o => o.Brans).HasColumnType("varchar").HasMaxLength(11);
        }
    }
}
