
using Microsoft.EntityFrameworkCore;
using Assignment2.Models;

namespace Assignment2.Data
{
    public class EmployeeContext(DbContextOptions<EmployeeContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employee { get; set; } = default!;
    }
}
