using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentACarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RentACar;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        //veritabanı tablosundaki bilgiler ile class bilgilerini eşleştiriyoruz
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<Car>().Property(c => c.CarId).HasColumnName("CarId");
            modelBuilder.Entity<Car>().Property(c => c.BrandId).HasColumnName("BrandId");
            modelBuilder.Entity<Car>().Property(c => c.ColorId).HasColumnName("ColorId");
            modelBuilder.Entity<Car>().Property(c => c.DailyPrice).HasColumnName("DailyPrice");
            modelBuilder.Entity<Car>().Property(c => c.Description).HasColumnName("Description");
            modelBuilder.Entity<Car>().Property(c => c.ModelYear).HasColumnName("ModelYear");

            modelBuilder.Entity<Brand>().ToTable("Brands");
            modelBuilder.Entity<Brand>().Property(b => b.BrandId).HasColumnName("BrandId");
            modelBuilder.Entity<Brand>().Property(b => b.BrandName).HasColumnName("BrandName");

            modelBuilder.Entity<Color>().ToTable("Colors");
            modelBuilder.Entity<Color>().Property(c => c.ColorId).HasColumnName("ColorId");
            modelBuilder.Entity<Color>().Property(c => c.ColorName).HasColumnName("ColorName");
        }
    }
}
