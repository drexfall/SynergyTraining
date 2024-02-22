using Microsoft.EntityFrameworkCore;
using Assignment2.Models;
namespace Assignment2.Data;


    public class UserContext(DbContextOptions<UserContext> options) : DbContext(options)
    {
        public DbSet<User> User { get; set; } = default!;
    }