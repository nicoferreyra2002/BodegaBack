using Bodega.Entities;
using Microsoft.EntityFrameworkCore;

public class BodegaContext : DbContext
{
    public BodegaContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Vino> Vinos { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Cata> Catas { get; set; }
    public DbSet<Invitado> Invitados { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
        base.OnModelCreating(modelBuilder);
        
    }
}