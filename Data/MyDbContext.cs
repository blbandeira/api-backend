using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using api_backend.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace api_backend.Data
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidato> Candidato { get; set; }
        public virtual DbSet<Vaga> Vaga { get; set; }
        public virtual DbSet<Vaga_Candidato> Vaga_Candidato { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            /*
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=BRUNO_LOCAL;User Id=SA;Password=Blbb0501");
            */
            }
        

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidato>(entity =>
            {
                
                entity.ToTable("Candidato");

                entity.HasKey(hs => hs.Id);

                entity.HasMany(hm => hm.Vaga_Candidato)
                .WithOne(wo => wo.Candidato)
                .HasPrincipalKey(pk => pk.Id);
                
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Candidat__161CF724C92DB3C7")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Data_Cadastro)
                    .HasColumnName("DATA_CADASTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.File_Foto)
                    .HasColumnName("FILE_FOTO")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vaga>(entity =>
            {
                entity.ToTable("VAGA");

                entity.HasKey(hs => hs.Id);

                entity.HasMany(hm => hm.Vaga_Candidato)
                .WithOne(wo => wo.Vaga)
                .HasPrincipalKey(pk => pk.Id);


                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ativa)
                    .IsRequired()
                    .HasColumnName("ATIVA")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Cargo)
                    .HasColumnName("CARGO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Desc_Vaga)
                    .HasColumnName("DESC_VAGA")
                    .HasColumnType("text");

                entity.Property(e => e.Nome_Vaga)
                    .HasColumnName("NOME_VAGA")
                    .HasMaxLength(50)
                    .IsUnicode(false);


                

            });

            modelBuilder.Entity<Vaga_Candidato>(entity =>
            {
                

                entity.ToTable("VAGA_CANDIDATO");

              //  entity.HasKey(vc => new { vc.Id_Candidato, vc.Id_Vaga });

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Dt_Candidatura)
                    .HasColumnName("DT_CANDIDATURA")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id_Candidato).HasColumnName("ID_CANDIDATO");

                entity.Property(e => e.Id_Vaga).HasColumnName("ID_VAGA");

                entity.HasOne(d => d.Candidato)
                    .WithMany(p => p.Vaga_Candidato)
                    .HasForeignKey(d => d.Id_Candidato)
                    .HasConstraintName("FK_CANDIDATO");

                entity.HasOne(d => d.Vaga)
                    .WithMany(p => p.Vaga_Candidato)
                    .HasForeignKey(d => d.Id_Vaga)
                    .HasConstraintName("FK_VAGA");
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    } 
}
