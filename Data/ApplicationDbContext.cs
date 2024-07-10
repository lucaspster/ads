using Ads.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ads.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AdDetail> AdDetails { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => new { x.LoginProvider, x.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(x => new { x.UserId, x.LoginProvider, x.Name });

            modelBuilder.Entity<Ad>()
                .HasOne(a => a.User)
                .WithMany(u => u.Ads)
                .HasForeignKey(a => a.UserID);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany()
                .HasForeignKey(m => m.ReceiverID)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "1",
                    UserName = "john_doe",
                    NormalizedUserName = "JOHN_DOE",
                    Email = "john@example.com",
                    NormalizedEmail = "JOHN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "hashedpassword",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    FullName = "John Doe",
                    PhoneNumber = "1234567890",
                    PhoneNumberConfirmed = true,
                    ProfileImage = "profile1.jpg",
                    CreatedAt = DateTime.Now
                },
                new User
                {
                    Id = "2",
                    UserName = "jane_doe",
                    NormalizedUserName = "JANE_DOE",
                    Email = "jane@example.com",
                    NormalizedEmail = "JANE@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "hashedpassword",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    FullName = "Jane Doe",
                    PhoneNumber = "0987654321",
                    PhoneNumberConfirmed = true,
                    ProfileImage = "profile2.jpg",
                    CreatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Vehicles", ParentCategoryID = null },
                new Category { CategoryID = 2, CategoryName = "Real Estate", ParentCategoryID = null }
            );

            modelBuilder.Entity<Ad>().HasData(
                new Ad
                {
                    AdID = 1,
                    UserID = "1",
                    CategoryID = 1,
                    Title = "Used Car for Sale",
                    Description = "A well-maintained used car",
                    Price = 5000,
                    Location = "New York",
                    Image = "car.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Ad
                {
                    AdID = 2,
                    UserID = "2",
                    CategoryID = 2,
                    Title = "Apartment for Rent",
                    Description = "2 BHK apartment for rent",
                    Price = 1500,
                    Location = "Los Angeles",
                    Image = "apartment.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<AdDetail>().HasData(
                new AdDetail { AdDetailID = 1, AdID = 1, Key = "Mileage", Value = "20000 miles" },
                new AdDetail { AdDetailID = 2, AdID = 2, Key = "Area", Value = "1200 sqft" }
            );

            modelBuilder.Entity<Message>().HasData(
                new Message
                {
                    MessageID = 1,
                    SenderID = "1",
                    ReceiverID = "2",
                    Messages = "Is the apartment still available?",
                    SentAt = DateTime.Now
                },
                new Message
                {
                    MessageID = 2,
                    SenderID = "2",
                    ReceiverID = "1",
                    Messages = "Yes, it is available.",
                    SentAt = DateTime.Now
                }
            );
        }

        public void SeedDatabase()
        {
            if (!Users.Any())
            {
                Users.AddRange(
                    new User
                    {
                        Id = "1",
                        UserName = "john_doe",
                        NormalizedUserName = "JOHN_DOE",
                        Email = "john@example.com",
                        NormalizedEmail = "JOHN@EXAMPLE.COM",
                        EmailConfirmed = true,
                        PasswordHash = "hashedpassword",
                        SecurityStamp = Guid.NewGuid().ToString("D"),
                        ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                        FullName = "John Doe",
                        PhoneNumber = "1234567890",
                        PhoneNumberConfirmed = true,
                        ProfileImage = "profile1.jpg",
                        CreatedAt = DateTime.Now
                    },
                    new User
                    {
                        Id = "2",
                        UserName = "jane_doe",
                        NormalizedUserName = "JANE_DOE",
                        Email = "jane@example.com",
                        NormalizedEmail = "JANE@EXAMPLE.COM",
                        EmailConfirmed = true,
                        PasswordHash = "hashedpassword",
                        SecurityStamp = Guid.NewGuid().ToString("D"),
                        ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                        FullName = "Jane Doe",
                        PhoneNumber = "0987654321",
                        PhoneNumberConfirmed = true,
                        ProfileImage = "profile2.jpg",
                        CreatedAt = DateTime.Now
                    }
                );
                SaveChanges();
            }

            if (!Categories.Any())
            {
                Categories.AddRange(
                    new Category { CategoryID = 1, CategoryName = "Vehicles", ParentCategoryID = null },
                    new Category { CategoryID = 2, CategoryName = "Real Estate", ParentCategoryID = null }
                );
                SaveChanges();
            }

            if (!Ads.Any())
            {
                Ads.AddRange(
                    new Ad
                    {
                        AdID = 1,
                        UserID = "1",
                        CategoryID = 1,
                        Title = "Used Car for Sale",
                        Description = "A well-maintained used car",
                        Price = 5000,
                        Location = "New York",
                        Image = "car.jpg",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Ad
                    {
                        AdID = 2,
                        UserID = "2",
                        CategoryID = 2,
                        Title = "Apartment for Rent",
                        Description = "2 BHK apartment for rent",
                        Price = 1500,
                        Location = "Los Angeles",
                        Image = "apartment.jpg",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                );
                SaveChanges();
            }

            if (!AdDetails.Any())
            {
                AdDetails.AddRange(
                    new AdDetail { AdDetailID = 1, AdID = 1, Key = "Mileage", Value = "20000 miles" },
                    new AdDetail { AdDetailID = 2, AdID = 2, Key = "Area", Value = "1200 sqft" }
                );
                SaveChanges();
            }

            if (!Messages.Any())
            {
                Messages.AddRange(
                    new Message
                    {
                        MessageID = 1,
                        SenderID = "1",
                        ReceiverID = "2",
                        Messages = "Is the apartment still available?",
                        SentAt = DateTime.Now
                    },
                    new Message
                    {
                        MessageID = 2,
                        SenderID = "2",
                        ReceiverID = "1",
                        Messages = "Yes, it is available.",
                        SentAt = DateTime.Now
                    }
                );
                SaveChanges();
            }
        }
    }
}
