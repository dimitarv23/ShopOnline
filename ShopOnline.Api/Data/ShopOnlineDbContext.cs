using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Entities;

namespace ShopOnline.Api.Data
{
    public class ShopOnlineDbContext : DbContext
    {
        public ShopOnlineDbContext()
        {
        }
        public ShopOnlineDbContext(DbContextOptions<ShopOnlineDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder options)
    //=> options.UseSqlServer("Server=DESKTOP-C09VDVU\\SQLEXPRESS;Database=ShopOnline;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 1,
                Name = "Glossier - Beauty Kit",
                Description = "A kit provided by Glossier, containing skin care, hair care and makeup products",
                ImageURL = "/Images/Beauty/Beauty1.png",
                Price = 100,
                Quantity = 100,
                CategoryID = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 2,
                Name = "Curology - Skin Care Kit",
                Description = "A kit provided by Curology, containing skin care products",
                ImageURL = "/Images/Beauty/Beauty2.png",
                Price = 50,
                Quantity = 45,
                CategoryID = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 3,
                Name = "Cocooil - Organic Coconut Oil",
                Description = "A kit provided by Curology, containing skin care products",
                ImageURL = "/Images/Beauty/Beauty3.png",
                Price = 20,
                Quantity = 30,
                CategoryID = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 4,
                Name = "Schwarzkopf - Hair Care and Skin Care Kit",
                Description = "A kit provided by Schwarzkopf, containing skin care and hair care products",
                ImageURL = "/Images/Beauty/Beauty4.png",
                Price = 50,
                Quantity = 60,
                CategoryID = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 5,
                Name = "Skin Care Kit",
                Description = "Skin Care Kit, containing skin care and hair care products",
                ImageURL = "/Images/Beauty/Beauty5.png",
                Price = 30,
                Quantity = 85,
                CategoryID = 1
            });

            //Electronics Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 6,
                Name = "Air Pods",
                Description = "Air Pods - in-ear wireless headphones",
                ImageURL = "/Images/Electronic/Electronics1.png",
                Price = 100,
                Quantity = 120,
                CategoryID = 3
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 7,
                Name = "On-ear Golden Headphones",
                Description = "On-ear Golden Headphones - these headphones are not wireless",
                ImageURL = "/Images/Electronic/Electronics2.png",
                Price = 40,
                Quantity = 200,
                CategoryID = 3
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 8,
                Name = "On-ear Black Headphones",
                Description = "On-ear Black Headphones - these headphones are not wireless",
                ImageURL = "/Images/Electronic/Electronics3.png",
                Price = 40,
                Quantity = 300,
                CategoryID = 3
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 9,
                Name = "Sennheiser Digital Camera with Tripod",
                Description = "Sennheiser Digital Camera - High quality digital camera provided by Sennheiser - includes tripod",
                ImageURL = "/Images/Electronic/Electronic4.png",
                Price = 600,
                Quantity = 20,
                CategoryID = 3
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 10,
                Name = "Canon Digital Camera",
                Description = "Canon Digital Camera - High quality digital camera provided by Canon",
                ImageURL = "/Images/Electronic/Electronic5.png",
                Price = 500,
                Quantity = 15,
                CategoryID = 3
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 11,
                Name = "Nintendo Gameboy",
                Description = "Gameboy - Provided by Nintendo",
                ImageURL = "/Images/Electronic/technology6.png",
                Price = 100,
                Quantity = 60,
                CategoryID = 3
            });

            //Furniture Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 12,
                Name = "Black Leather Office Chair",
                Description = "Very comfortable black leather office chair",
                ImageURL = "/Images/Furniture/Furniture1.png",
                Price = 50,
                Quantity = 212,
                CategoryID = 2
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 13,
                Name = "Pink Leather Office Chair",
                Description = "Very comfortable pink leather office chair",
                ImageURL = "/Images/Furniture/Furniture2.png",
                Price = 50,
                Quantity = 112,
                CategoryID = 2
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 14,
                Name = "Lounge Chair",
                Description = "Very comfortable lounge chair",
                ImageURL = "/Images/Furniture/Furniture3.png",
                Price = 70,
                Quantity = 90,
                CategoryID = 2
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 15,
                Name = "Silver Lounge Chair",
                Description = "Very comfortable Silver lounge chair",
                ImageURL = "/Images/Furniture/Furniture4.png",
                Price = 120,
                Quantity = 95,
                CategoryID = 2
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 16,
                Name = "Porcelain Table Lamp",
                Description = "White and blue Porcelain Table Lamp",
                ImageURL = "/Images/Furniture/Furniture6.png",
                Price = 15,
                Quantity = 100,
                CategoryID = 2
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 17,
                Name = "Office Table Lamp",
                Description = "Office Table Lamp",
                ImageURL = "/Images/Furniture/Furniture7.png",
                Price = 20,
                Quantity = 73,
                CategoryID = 2
            });

            //Shoes Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 18,
                Name = "Puma Sneakers",
                Description = "Comfortable Puma Sneakers in most sizes",
                ImageURL = "/Images/Shoes/Shoes1.png",
                Price = 100,
                Quantity = 50,
                CategoryID = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 19,
                Name = "Colorful Trainers",
                Description = "Colorful trainsers - available in most sizes",
                ImageURL = "/Images/Shoes/Shoes2.png",
                Price = 150,
                Quantity = 60,
                CategoryID = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 20,
                Name = "Blue Nike Trainers",
                Description = "Blue Nike Trainers - available in most sizes",
                ImageURL = "/Images/Shoes/Shoes3.png",
                Price = 200,
                Quantity = 70,
                CategoryID = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 21,
                Name = "Colorful Hummel Trainers",
                Description = "Colorful Hummel Trainers - available in most sizes",
                ImageURL = "/Images/Shoes/Shoes4.png",
                Price = 120,
                Quantity = 120,
                CategoryID = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 22,
                Name = "Red Nike Trainers",
                Description = "Red Nike Trainers - available in most sizes",
                ImageURL = "/Images/Shoes/Shoes5.png",
                Price = 200,
                Quantity = 100,
                CategoryID = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 23,
                Name = "Birkenstock Sandles",
                Description = "Birkenstock Sandles - available in most sizes",
                ImageURL = "/Images/Shoes/Shoes6.png",
                Price = 50,
                Quantity = 150,
                CategoryID = 4
            });

            //Add users
            modelBuilder.Entity<User>().HasData(new User
            {
                ID = 1,
                UserName = "Bob"
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                ID = 2,
                UserName = "Sarah"
            });

            //Create Shopping Cart for Users
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                ID = 1,
                UserID = 1
            });
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                ID = 2,
                UserID = 2
            });

            //Add Product Categories
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                ID = 1,
                Name = "Beauty",
                IconCSS = "fas fa-spa"
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                ID = 2,
                Name = "Furniture",
                IconCSS = "fas fa-couch"
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                ID = 3,
                Name = "Electronics",
                IconCSS = "fas fa-headphones"
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                ID = 4,
                Name = "Shoes",
                IconCSS = "fas fa-shoe-prints"
            });
        }
    }
}
