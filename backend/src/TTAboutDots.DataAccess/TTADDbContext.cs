using Microsoft.EntityFrameworkCore;
using TTAboutDots.Domain;

namespace TTAboutDots.DataAccess
{
    public class TTADDbContext : DbContext
    {
        public TTADDbContext(DbContextOptions<TTADDbContext> options) : base (options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Dot> Dots { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dot>()
                .HasMany(t => t.Comments)
                .WithOne(x => x.Dot)
                .HasForeignKey(y => y.DotId);

            modelBuilder.Entity<Dot>().HasData(
                new() {Id = 1, LocationX = 30, LocationY = 30, Color = "red", Radius = 12}, 
                new() {Id = 2, LocationX = 50, LocationY = 50, Color = "green", Radius = 6}
            );

            modelBuilder.Entity<Comment>().HasData(
                new() {Id = 1, Color = "yellow", Text = "It's a first comment!",DotId = 1}, 
                new() {Id = 2, Color = "yellow", Text = "It's a second comment!", DotId = 1}, 
                new() {Id = 3, Color = "yellow", Text = "It's a first/third comment!", DotId = 2}
            );
        }
    }
}
