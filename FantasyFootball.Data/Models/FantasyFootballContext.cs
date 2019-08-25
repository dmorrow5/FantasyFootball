using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FantasyFootball.Data.Models
{
    public partial class FantasyFootballContext : DbContext
    {
        public FantasyFootballContext()
        {
        }

        public FantasyFootballContext(DbContextOptions<FantasyFootballContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<SportsTeam> SportsTeam { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FantasyFootball;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FanPts).HasColumnName("Fan Pts");

                entity.Property(e => e.Gp).HasColumnName("GP");

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.HasOne(d => d.TeamNavigation)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.Team)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Player_ToPSportsTeam");
            });

            modelBuilder.Entity<SportsTeam>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(10);
            });
        }
    }
}
