using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BACKEND_PROJEKT.Models;

namespace BACKEND_PROJEKT.DATA
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<ServiceFeature> ServiceFeatures { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Slider>().HasData(
                new Slider
                {
                    Id = 1,
                    Subtitle = "Best Selling!",
                    Title = "Top Collection",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",
                    Image = "slider-1.jpg"
                },
                new Slider
                {
                    Id = 2,
                    Subtitle = "Best Selling!",
                    Title = "Top Collection",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",
                    Image = "slider-2.jpg"
                }
            );

            modelBuilder.Entity<ServiceFeature>().HasData(
                new ServiceFeature
                {
                    Id = 1,
                    Title = "FREE SHIPPING",
                    SubTitle = "Free shipping on all order",
                    Icon = "policy-1.png"
                },
                new ServiceFeature
                {
                    Id = 2,
                    Title = "ONLINE SUPPORT",
                    SubTitle = "Online support 24 hours a day",
                    Icon = "policy-2.png"
                },
                new ServiceFeature
                {
                    Id = 3,
                    Title = "MONEY RETURN",
                    SubTitle = "Back guarantee under 5 days",
                    Icon = "policy-3.png"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Flowers Red & Green Shoe",
                    Price = 80.00m,
                    OldPrice = 100.00m,
                    Image = "product-1.jpg",
                    Category = "Men",
                    Rating = 5
                },
                new Product
                {
                    Id = 2,
                    Name = "Simple Blue & White Shoe",
                    Price = 70.00m,
                    OldPrice = 90.00m,
                    Image = "product-2.jpg",
                    Category = "Men",
                    Rating = 5
                },
                new Product
                {
                    Id = 3,
                    Name = "Red Leather Sport Shoe",
                    Price = 60.00m,
                    OldPrice = 85.00m,
                    Image = "product-3.jpg",
                    Category = "Women",
                    Rating = 4
                },
                new Product
                {
                    Id = 4,
                    Name = "Primitive Knost Sport Shoe",
                    Price = 95.00m,
                    OldPrice = 110.00m,
                    Image = "product-4.jpg",
                    Category = "Sports",
                    Rating = 5
                }
            );
        }
    }
}
