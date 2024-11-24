using System;
using System.Collections.Generic;
using FitBalanceBlazor;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adres> Adres { get; set; }

    public virtual DbSet<Danie> Danie { get; set; }

    public virtual DbSet<Dieta> Dieta { get; set; }

    public virtual DbSet<Opinia> Opinia { get; set; }

    public virtual DbSet<Pomiar_wagi> Pomiar_wagi { get; set; }

    public virtual DbSet<Pracownik> Pracownik { get; set; }

    public virtual DbSet<Produkt> Produkt { get; set; }

    public virtual DbSet<Produkt_Danie> Produkt_Danie { get; set; }

    public virtual DbSet<Programy> Programy { get; set; }

    public virtual DbSet<Przypisana_dieta> Przypisana_dieta { get; set; }

    public virtual DbSet<Raport> Raport { get; set; }

    public virtual DbSet<Rodzaj> Rodzaj { get; set; }

    public virtual DbSet<Uzytkownik> Uzytkownik { get; set; }

    public virtual DbSet<Wypita_woda> Wypita_woda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB; Initial Catalog=FitBalance");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adres>(entity =>
        {
            entity.HasKey(e => e.id_adres).HasName("Adres_pk");

            entity.Property(e => e.id_adres).ValueGeneratedNever();

            entity.HasOne(d => d.id_pracownikNavigation).WithMany(p => p.Adres)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Adres_Pracownik");
        });

        modelBuilder.Entity<Danie>(entity =>
        {
            entity.HasKey(e => e.id_danie).HasName("Danie_pk");

            entity.Property(e => e.id_danie).ValueGeneratedNever();

            entity.HasMany(d => d.Dieta_id_dieta).WithMany(p => p.Danie_id_danie)
                .UsingEntity<Dictionary<string, object>>(
                    "Dieta_Danie",
                    r => r.HasOne<Dieta>().WithMany()
                        .HasForeignKey("Dieta_id_dieta")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Dieta_Danie_Dieta"),
                    l => l.HasOne<Danie>().WithMany()
                        .HasForeignKey("Danie_id_danie")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Dieta_Danie_Danie"),
                    j =>
                    {
                        j.HasKey("Danie_id_danie", "Dieta_id_dieta").HasName("Dieta_Danie_pk");
                    });
        });

        modelBuilder.Entity<Dieta>(entity =>
        {
            entity.HasKey(e => e.id_dieta).HasName("Dieta_pk");

            entity.Property(e => e.id_dieta).ValueGeneratedNever();

            entity.HasOne(d => d.autorNavigation).WithMany(p => p.Dieta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Dieta_Pracownik");

            entity.HasOne(d => d.rodzajNavigation).WithMany(p => p.Dieta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Dieta_Rodzaj");

            entity.HasMany(d => d.id_produkt).WithMany(p => p.id_dieta)
                .UsingEntity<Dictionary<string, object>>(
                    "Produkt_Dieta",
                    r => r.HasOne<Produkt>().WithMany()
                        .HasForeignKey("id_produkt")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Table_17_Produkt"),
                    l => l.HasOne<Dieta>().WithMany()
                        .HasForeignKey("id_dieta")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Table_17_Dieta"),
                    j =>
                    {
                        j.HasKey("id_dieta", "id_produkt").HasName("Produkt_Dieta_pk");
                    });
        });

        modelBuilder.Entity<Opinia>(entity =>
        {
            entity.HasKey(e => e.id_opinia).HasName("Opinia_pk");

            entity.Property(e => e.id_opinia).ValueGeneratedNever();

            entity.HasOne(d => d.id_dietaNavigation).WithMany(p => p.Opinia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Opinia_Dieta");

            entity.HasOne(d => d.id_uzytkownikNavigation).WithMany(p => p.Opinia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Opinia_Uzytkownik");
        });

        modelBuilder.Entity<Pomiar_wagi>(entity =>
        {
            entity.HasKey(e => e.id_pomiar).HasName("Pomiar_wagi_pk");

            entity.Property(e => e.id_pomiar).ValueGeneratedNever();

            entity.HasOne(d => d.id_uzytkownikNavigation).WithMany(p => p.Pomiar_wagi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Pomiar_Wagi_Uzytkownik");
        });

        modelBuilder.Entity<Pracownik>(entity =>
        {
            entity.HasKey(e => e.id_pracownik).HasName("Pracownik_pk");

            entity.Property(e => e.id_pracownik).ValueGeneratedNever();

            entity.HasOne(d => d.id_uzytkownikNavigation).WithMany(p => p.Pracownik)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Pracownik_Uzytkownik");
        });

        modelBuilder.Entity<Produkt>(entity =>
        {
            entity.HasKey(e => e.id_produkt).HasName("Produkt_pk");

            entity.Property(e => e.id_produkt).ValueGeneratedNever();
        });

        modelBuilder.Entity<Produkt_Danie>(entity =>
        {
            entity.HasKey(e => new { e.id_produkt, e.id_danie }).HasName("Produkt_Danie_pk");

            entity.HasOne(d => d.id_danieNavigation).WithMany(p => p.Produkt_Danie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Table_19_Danie");

            entity.HasOne(d => d.id_produktNavigation).WithMany(p => p.Produkt_Danie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Table_19_Produkt");
        });

        modelBuilder.Entity<Programy>(entity =>
        {
            entity.HasKey(e => e.id_program).HasName("Program_pk");

            entity.Property(e => e.id_program).ValueGeneratedNever();
        });

        modelBuilder.Entity<Przypisana_dieta>(entity =>
        {
            entity.HasKey(e => e.id_przypisana_dieta).HasName("Przypisana_dieta_pk");

            entity.Property(e => e.id_przypisana_dieta).ValueGeneratedNever();

            entity.HasOne(d => d.id_dietaNavigation).WithMany(p => p.Przypisana_dieta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Przypisana_dieta_Dieta");

            entity.HasOne(d => d.id_programNavigation).WithMany(p => p.Przypisana_dieta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Przypisana_dieta_Program");

            entity.HasOne(d => d.id_uzytkownikNavigation).WithMany(p => p.Przypisana_dieta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Przypisana_dieta_Uzytkownik");

            entity.HasMany(d => d.id_danie).WithMany(p => p.id_przypisana_dieta)
                .UsingEntity<Dictionary<string, object>>(
                    "Przypisana_dieta_Danie",
                    r => r.HasOne<Danie>().WithMany()
                        .HasForeignKey("id_danie")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Table_18_Danie"),
                    l => l.HasOne<Przypisana_dieta>().WithMany()
                        .HasForeignKey("id_przypisana_dieta")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Table_18_Przypisana_dieta"),
                    j =>
                    {
                        j.HasKey("id_przypisana_dieta", "id_danie").HasName("Przypisana_dieta_Danie_pk");
                    });
        });

        modelBuilder.Entity<Raport>(entity =>
        {
            entity.HasKey(e => e.id_raport).HasName("Raport_pk");

            entity.Property(e => e.id_raport).ValueGeneratedNever();

            entity.HasOne(d => d.dietaNavigation).WithMany(p => p.Raport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Raport_Dieta");

            entity.HasOne(d => d.uzytkownikNavigation).WithMany(p => p.Raport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Raport_Uzytkownik");
        });

        modelBuilder.Entity<Rodzaj>(entity =>
        {
            entity.HasKey(e => e.id_rodzaj).HasName("Rodzaj_pk");

            entity.Property(e => e.id_rodzaj).ValueGeneratedNever();
        });

        modelBuilder.Entity<Uzytkownik>(entity =>
        {
            entity.HasKey(e => e.id_uzytkownik).HasName("Uzytkownik_pk");

            entity.Property(e => e.id_uzytkownik).ValueGeneratedNever();
        });

        modelBuilder.Entity<Wypita_woda>(entity =>
        {
            entity.HasKey(e => e.id_wypita_woda).HasName("Wypita_woda_pk");

            entity.Property(e => e.id_wypita_woda).ValueGeneratedNever();

            entity.HasOne(d => d.id_uzytkownikNavigation).WithMany(p => p.Wypita_woda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Wypita_Woda_Uzytkownik");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
