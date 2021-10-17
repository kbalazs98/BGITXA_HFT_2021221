using BGITXA_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Data
{
    public class TelevisionShopDbContext : DbContext
    {
        public virtual DbSet<Television> Televisions { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public TelevisionShopDbContext()
        {
            Database.EnsureCreated();
        }
        public TelevisionShopDbContext(DbContextOptions<TelevisionShopDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\Database.mdf;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Brand samsung = new Brand() { Id = 1, Name = "Samsung" };
            Brand lg = new Brand() { Id = 2, Name = "LG" };
            Brand sony = new Brand() { Id = 3, Name = "Sony" };

            Order order = new Order() { Id = 1, CustomerName = "Vásárló Vilmos" };
            Order order2 = new Order() { Id = 2, CustomerName = "Vásárló Veronika" };

            Television samsung1 = new Television() { Id = 10, BrandId = samsung.Id, Price = 1000, Model = "UE32",OrderId = 1 };
            Television samsung2 = new Television() { Id = 11, BrandId = samsung.Id, Price = 1500, Model = "UE40",OrderId = 1 };
            Television lg1 = new Television() { Id = 20, BrandId = lg.Id, Price = 2000, Model = "OLED40", OrderId = 2 };

            Television lg2 = new Television() { Id = 21, BrandId = lg.Id, Price = 2500, Model = "OLED55", OrderId = 1 };

            Television sony1 = new Television() { Id = 30, BrandId = sony.Id, Price = 1000, Model = "BRAVIA40",OrderId = 1 };
            Television sony2 = new Television() { Id = 31, BrandId = sony.Id, Price = 1700, Model = "BRAVIA50",OrderId = 2 };
            Television sony3 = new Television() { Id = 32, BrandId = sony.Id, Price = 3000, Model = "BRAVIA65",OrderId = 2 };



            modelBuilder.Entity<Television>(entity =>
            {
                entity.HasOne(televison => televison.Brand)
                .WithMany(brand => brand.Televisions)
                .HasForeignKey(television => television.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(televison => televison.Order)
               .WithMany(order => order.Televisions)
               .HasForeignKey(television => television.OrderId)
               .OnDelete(DeleteBehavior.ClientSetNull);
            });


            modelBuilder.Entity<Brand>().HasData(samsung, lg, sony);
            modelBuilder.Entity<Order>().HasData(order, order2);
            modelBuilder.Entity<Television>().HasData(samsung1, samsung2, lg1, lg2, sony1, sony2, sony3);
        }
    }
}
