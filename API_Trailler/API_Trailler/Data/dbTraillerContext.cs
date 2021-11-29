using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using API_Trailler.Models;
#nullable disable

namespace API_Trailler.Data
{
    public partial class dbTraillerContext : DbContext
    {
        public dbTraillerContext()
        {
        }

        public dbTraillerContext(DbContextOptions<dbTraillerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<LoginAdmin> LoginAdmins { get; set; }
        public virtual DbSet<Trailler> Traillers { get; set; }
        public virtual DbSet<TraillerActor> TraillerActors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-KKC17UP; Database=dbTrailler; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

           

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("Actor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.NameActor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_actor");
            });

            modelBuilder.Entity<LoginAdmin>(entity =>
            {
                entity.ToTable("Login_Admin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Pass)
                    .HasMaxLength(212)
                    .IsUnicode(false)
                    .HasColumnName("pass");
            });

            modelBuilder.Entity<Trailler>(entity =>
            {
                entity.ToTable("Trailler");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cover)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cover");

                entity.Property(e => e.Director)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("director");

                entity.Property(e => e.Link)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("link");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Review)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("review");

                entity.Property(e => e.Title)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.YearTrailer)
                    .HasColumnType("date")
                    .HasColumnName("year_trailer");
            });

            modelBuilder.Entity<TraillerActor>(entity =>
            {
                entity.ToTable("Trailler_Actor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdActor).HasColumnName("id_actor");

                entity.Property(e => e.IdTrailler).HasColumnName("id_trailler");

                entity.HasOne(d => d.IdActorNavigation)
                    .WithMany(p => p.TraillerActors)
                    .HasForeignKey(d => d.IdActor)
                    .HasConstraintName("FK__Trailler___id_ac__2B3F6F97");

                entity.HasOne(d => d.IdTraillerNavigation)
                    .WithMany(p => p.TraillerActors)
                    .HasForeignKey(d => d.IdTrailler)
                    .HasConstraintName("FK__Trailler___id_tr__2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
