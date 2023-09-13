using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VehiChoice.Models.Enums;
using VehiChoice.DTO;
using VehiChoice.Models.Entities;

namespace VehiChoice.Data
{
    public class DataContext : DbContext
    {
        //bcos i put my connection string in my Appsettings.json file
        public DataContext(DbContextOptions<DataContext> database) : base(database)
        {

        }
        //public DbSet<CreateCustomerRequestModel> CreateCustomerRequests { get; set; }
        //public DbSet<CreateBranchRequestModel> CreateBranchRequests { get; set; }
        //public DbSet<CreateCarRequestModel> CreateCarRequests { get; set; }
        

       

        public DbSet<Branch> Branchs { get; set;  }
        public DbSet<BranchCars> BranchCars { get; set; }
        public DbSet<BranchHead> BranchHeads { get; set; }
        public DbSet<BranchUsers> BranchUsers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CreateCustomerRequestModel>().HasNoKey();
            //modelBuilder.Entity<CreateBranchRequestModel>().HasNoKey();
            //modelBuilder.Entity<CreateCarRequestModel>().HasNoKey();
            // Other entity configurations go here
            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = "001",
                        FirstName = "Big",
                        LastName = "Boss",
                        Location = (Location)1,
                        Email = "bigboss@gmail.com",
                        PhoneNumber = "+2348155850462",
                        Role = "SuperAdmin",
                        Gender = (Gender)1,
                        WalletType = (WalletType)1,
                        Password = "pass",
                        ImageReferece = "",
                        IsDeleted = false,
                        DateCreated = "7/14/2023",
                    }
                );
            modelBuilder.Entity<Wallet>().HasData(
                    new Wallet
                    {
                        Id = "001",
                        WalletNumber = "WALTID/NBV/001",
                        WalletName = "Big Boss",
                        WalletPin = 1234,
                        WalletType = (WalletType)1,
                        Location = (Location)1,
                        WalletBalance = 0.00,
                        IsDeleted = false,
                        DateCreated = "7/14/2023",
                    }
                );

        }
    }
}
