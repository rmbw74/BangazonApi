// Author : Chris Miller


using Microsoft.EntityFrameworkCore;
using BangazonApi.Models;

namespace BangazonApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }


        public DbSet<Computer> Computer { get; set; }
        public DbSet<ComputerEmployee> ComputerEmployee { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeTraining> EmployeeTraining { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductOrder> ProductOrder { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Training> Training { get; set; }
    }
}