using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopBuy7.Models;

namespace ShopBuy7.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Authentication> Authentications { get; set; }
        public DbSet<BankDetail> BankDetails { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ContactUs> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EmailSubscriber> EmailSubscribers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<Tree> Trees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<TransactionHistory> Transactions { get; set; }
        public DbSet<AuthenticationLog> UserLogs { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Deal> Deals { get; set; }
    }
}