using Core.Entites;
using Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class OMContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public OMContext(DbContextOptions options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "James",
                    LastName = "Bond",
                    ContactNumber = "+381606107301",
                    IsDeleted = false,
                    Email = "firstbond@gmail.com",

                },
                new Customer
                {
                    Id = 2,
                    FirstName = "JamesNew",
                    LastName = "BondNew",
                    ContactNumber = "+38160610730",
                    IsDeleted = false,
                    Email = "secondbond@gmail.com",

                }
            );
            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    CustomerId = 1,
                    AddressLine1 = "Test1",
                    AddressLine2 = "Test2",
                    City = "Novi Sad",
                    State = "Vojvodina",
                    Country = "Serbia",
                },
                new Address
                {
                    Id = 2,
                    CustomerId = 2,
                    AddressLine1 = "Test3",
                    AddressLine2 = "Test4",
                    City = "Belgrade",
                    State = "Srem",
                    Country = "Serbia",
                }
            );
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    CustomerId = 1,
                    OrderDate = new DateTime(2023, 10, 20),
                    Description = "Order 1",
                    TotalAmount = 200,
                    DepositAmount = 10,
                    IsDeleted = false,
                    IsDelivery = false,
                    Status = Status.Pending,
                    OtherNotes = "Something",
                },
                new Order
                {
                    Id = 2,
                    CustomerId = 2,
                    OrderDate = new DateTime(2023, 10, 21),
                    Description = "Order 2",
                    TotalAmount = 300,
                    DepositAmount = 20,
                    IsDeleted = false,
                    IsDelivery = false,
                    Status = Status.Pending,
                    OtherNotes = "Something else",
                }
            );
        }
    }
}