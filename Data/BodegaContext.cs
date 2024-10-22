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
        //modelBuilder.Entity<Vino>()
        //    .HasKey(v => v.Id);

        //modelBuilder.Entity<User>()
        //    .HasKey(u => u.Id);

        //modelBuilder.Entity<Cata>()
        //    .HasKey(c => c.Id);

        //modelBuilder.Entity<Invitado>()
        //    .HasKey(i => i.Id);
        base.OnModelCreating(modelBuilder);
        
    }
}