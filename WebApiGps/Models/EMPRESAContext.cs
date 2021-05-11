using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApiGps.Models
{
    public partial class EMPRESAContext : DbContext
    {
        public EMPRESAContext()
        {
        }

        public EMPRESAContext(DbContextOptions<EMPRESAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cacamba> Cacambas { get; set; }
        public virtual DbSet<Localizacao> Localizacaos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-5A8O62Q; Database=EMPRESA; User ID=app;Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cacamba>(entity =>
            {
                entity.ToTable("CACAMBA");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Nome).HasColumnName("NOME");
            });

            modelBuilder.Entity<Localizacao>(entity =>
            {
                entity.ToTable("LOCALIZACAO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodCacamba).HasColumnName("COD_CACAMBA");

                entity.Property(e => e.Coordenadas)
                    .IsRequired()
                    .HasColumnName("COORDENADAS");

                entity.Property(e => e.CriadoEm)
                    .HasColumnType("datetime")
                    .HasColumnName("CRIADO_EM")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CodCacambaNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.CodCacamba)
                    .HasConstraintName("FK_LOCACAO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
