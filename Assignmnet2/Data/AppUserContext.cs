using Microsoft.EntityFrameworkCore;
using Assignment2.Models;
namespace Assignment2.Data;


    public class AppUserContext(DbContextOptions<AppUserContext> options) : DbContext(options)
    {
    public DbSet<AppUser> AppUser { get; set; } = default!;
}