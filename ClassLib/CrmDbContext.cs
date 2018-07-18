using Microsoft.EntityFrameworkCore;

namespace ClassLib
{
    public class CrmDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        private readonly string _connectionString;

        private const string Host = "localhost";
        private const string Port = "1234";
        private const string DatabaseName = "docker";
        private const string Username = "admin";
        private const string Password = "12345";
        private const string Pooling = "false";
        private const string Timeout = "300"; // Connection timeout : 300s
        private const string CommandTimeout = "0"; // Command timeout : no timeout

        public CrmDbContext()
        {
            _connectionString = $"Host={Host};" +
                                $"Port={Port};" +
                                $"Database={DatabaseName};" +
                                $"Username={Username};" +
                                $"Password={Password};" +
                                $"Pooling={Pooling};" +
                                $"Timeout={Timeout};" +
                                $"CommandTimeout={CommandTimeout}";
        }

        public CrmDbContext(string port)
        {
            _connectionString = $"Host={Host};" +
                                $"Port={port};" +
                                $"Database={DatabaseName};" +
                                $"Username={Username};" +
                                $"Password={Password};" +
                                $"Pooling={Pooling};" +
                                $"Timeout={Timeout};" +
                                $"CommandTimeout={CommandTimeout}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var customerId = 1;

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = customerId++,
                Name = "Sam",
                Age = 18
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = customerId++,
                Name = "Kevin",
                Age = 19
            });
            
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = customerId++,
                Name = "John",
                Age = 20
            });
        }
    }
}