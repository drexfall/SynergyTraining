using Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Data;

public class EmpTaskContext(DbContextOptions<EmpTaskContext> options) : DbContext(options)
{
    public DbSet<EmpTask> EmpTask { get; set; }
}