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

        public virtual DbSet<BasePlayer> BasePlayer { get; set; }
        public virtual DbSet<LeagueTeam> LeagueTeam { get; set; }
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

            modelBuilder.Entity<BasePlayer>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FanPts).HasColumnName("Fan Pts");

                entity.Property(e => e.FieldGoals019).HasColumnName("FieldGoals0-19");

                entity.Property(e => e.FieldGoals2029).HasColumnName("FieldGoals20-29");

                entity.Property(e => e.FieldGoals3039).HasColumnName("FieldGoals30-39");

                entity.Property(e => e.FieldGoals4049).HasColumnName("FieldGoals40-49");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.LeagueTeamNavigation)
                    .WithMany(p => p.BasePlayer)
                    .HasForeignKey(d => d.LeagueTeam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BasePlayer_ToLeagueTeam");

                entity.HasOne(d => d.TeamNavigation)
                    .WithMany(p => p.BasePlayer)
                    .HasForeignKey(d => d.Team)
                    .HasConstraintName("FK_BasePlayer_ToSportsTeam");
            });

            modelBuilder.Entity<LeagueTeam>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FanPts).HasColumnName("Fan Pts");

                entity.Property(e => e.FieldGoals019).HasColumnName("FieldGoals0-19");

                entity.Property(e => e.FieldGoals2029).HasColumnName("FieldGoals20-29");

                entity.Property(e => e.FieldGoals3039).HasColumnName("FieldGoals30-39");

                entity.Property(e => e.FieldGoals4049).HasColumnName("FieldGoals40-49");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Player)
                    .HasForeignKey<Player>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Player_ToBasePlayer");

                entity.HasOne(d => d.LeagueTeamNavigation)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.LeagueTeam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Player_ToLeagueTeam");

                entity.HasOne(d => d.TeamNavigation)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.Team)
                    .HasConstraintName("FK_Player_ToPSportsTeam");
            });

            modelBuilder.Entity<SportsTeam>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10);
            });
        }
    }
}
