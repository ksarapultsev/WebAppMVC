
using System.Data.Entity;

namespace HomeWork1.Models
{
    public class AppContext : DbContext
    {
        public AppContext() : base("Connection")
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}