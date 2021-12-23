using Microsoft.EntityFrameworkCore;

namespace DbMove.Models
{
    public class MoveContext : DbContext
    {
        const string connectionString = "SERVER=.\\SQL2019;DATABASE=Move;Integrated Security=true";

        public MoveContext() : base() { }

        public MoveContext(DbContextOptions<MoveContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Move>().Property(e => e.Longitude).HasPrecision(12, 9);
            modelBuilder.Entity<Move>().Property(e => e.Latitude).HasPrecision(12, 9);
            modelBuilder.Entity<MoveMover>().Property(e => e.ReadOnly).HasDefaultValue(true);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Media> Medias { get; set; }

        public DbSet<Move> Moves { get; set; }

        public DbSet<MoveMover> MoveMovers { get; set; }

        public DbSet<Mover> Movers { get; set; }

        public DbSet<Sport> Sports { get; set; }
    }
}