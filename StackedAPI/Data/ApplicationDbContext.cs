using Microsoft.EntityFrameworkCore;
using StackedAPI.Models;

namespace StackedAPI.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
}