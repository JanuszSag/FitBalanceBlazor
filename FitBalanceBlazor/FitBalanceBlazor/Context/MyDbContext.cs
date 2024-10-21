using System;
using System.Collections.Generic;
using FitBalanceBlazor.Models;
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

    public virtual DbSet<Adres> Adresy { get; set; }

    public virtual DbSet<Danie> Dania { get; set; }

    public virtual DbSet<Dieta> Diety { get; set; }

    public virtual DbSet<Opinia> Opinie { get; set; }

    public virtual DbSet<PomiarWagi> PomiaryWagi { get; set; }

    public virtual DbSet<Pracownik> Pracownicy { get; set; }

    public virtual DbSet<Produkt> Produkty { get; set; }

    public virtual DbSet<ProduktDanie> ProduktDanie { get; set; }

    public virtual DbSet<Programy> Programy { get; set; }

    public virtual DbSet<PrzypisanaDieta> PrzypisaneDiety { get; set; }

    public virtual DbSet<Raport> Raporty { get; set; }

    public virtual DbSet<Rodzaj> Rodzaje { get; set; }

    public virtual DbSet<Uzytkownik> Uzytkownicy { get; set; }

    public virtual DbSet<WypitaWoda> WypitaWoda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB; Initial Catalog=FitBalance");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adres>(entity =>
        {
            entity.HasKey(e => e.IdAdres).HasName("Adres_pk");

            entity.Property(e => e.IdAdres)
                .ValueGeneratedNever()
                .HasColumnName("id_adres");
            entity.Property(e => e.IdPracownik).HasColumnName("id_pracownik");
            entity.Property(e => e.KodPocztowy)
                .HasColumnType("text")
                .HasColumnName("kod_pocztowy");
            entity.Property(e => e.Miasto)
                .HasColumnType("text")
                .HasColumnName("miasto");
            entity.Property(e => e.NumerMieszkania)
                .HasColumnType("text")
                .HasColumnName("numer_mieszkania");
            entity.Property(e => e.Ulica)
                .HasColumnType("text")
                .HasColumnName("ulica");

            entity.HasOne(d => d.IdPracownikNavigation).WithMany(p => p.Adres)
                .HasForeignKey(d => d.IdPracownik)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Adres_Pracownik");
        });

        modelBuilder.Entity<Danie>(entity =>
        {
            entity.HasKey(e => e.IdDanie).HasName("Danie_pk");

            entity.ToTable("Danie");

            entity.Property(e => e.IdDanie)
                .ValueGeneratedNever()
                .HasColumnName("id_danie");
            entity.Property(e => e.Kalorie).HasColumnName("kalorie");
            entity.Property(e => e.Nazwa)
                .HasColumnType("text")
                .HasColumnName("nazwa");

            entity.HasMany(d => d.DietaIdDieta).WithMany(p => p.DanieIdDanie)
                .UsingEntity<Dictionary<string, object>>(
                    "DietaDanie",
                    r => r.HasOne<Dieta>().WithMany()
                        .HasForeignKey("DietaIdDieta")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Dieta_Danie_Dieta"),
                    l => l.HasOne<Danie>().WithMany()
                        .HasForeignKey("DanieIdDanie")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Dieta_Danie_Danie"),
                    j =>
                    {
                        j.HasKey("DanieIdDanie", "DietaIdDieta").HasName("Dieta_Danie_pk");
                        j.ToTable("Dieta_Danie");
                        j.IndexerProperty<int>("DanieIdDanie").HasColumnName("Danie_id_danie");
                        j.IndexerProperty<int>("DietaIdDieta").HasColumnName("Dieta_id_dieta");
                    });
        });

        modelBuilder.Entity<Dieta>(entity =>
        {
            entity.HasKey(e => e.IdDieta).HasName("Dieta_pk");

            entity.Property(e => e.IdDieta)
                .ValueGeneratedNever()
                .HasColumnName("id_dieta");
            entity.Property(e => e.Autor).HasColumnName("autor");
            entity.Property(e => e.Kalorycznosc).HasColumnName("kalorycznosc");
            entity.Property(e => e.Nazwa)
                .HasColumnType("text")
                .HasColumnName("nazwa");
            entity.Property(e => e.Opis)
                .HasColumnType("text")
                .HasColumnName("opis");
            entity.Property(e => e.Rodzaj).HasColumnName("rodzaj");

            entity.HasOne(d => d.AutorNavigation).WithMany(p => p.Dieta)
                .HasForeignKey(d => d.Autor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Dieta_Pracownik");

            entity.HasOne(d => d.RodzajNavigation).WithMany(p => p.Dieta)
                .HasForeignKey(d => d.Rodzaj)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Dieta_Rodzaj");

            entity.HasMany(d => d.IdProdukt).WithMany(p => p.IdDieta)
                .UsingEntity<Dictionary<string, object>>(
                    "ProduktDietum",
                    r => r.HasOne<Produkt>().WithMany()
                        .HasForeignKey("IdProdukt")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Table_17_Produkt"),
                    l => l.HasOne<Dieta>().WithMany()
                        .HasForeignKey("IdDieta")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Table_17_Dieta"),
                    j =>
                    {
                        j.HasKey("IdDieta", "IdProdukt").HasName("Produkt_Dieta_pk");
                        j.ToTable("Produkt_Dieta");
                        j.IndexerProperty<int>("IdDieta").HasColumnName("id_dieta");
                        j.IndexerProperty<int>("IdProdukt").HasColumnName("id_produkt");
                    });
        });

        modelBuilder.Entity<Opinia>(entity =>
        {
            entity.HasKey(e => e.IdOpinia).HasName("Opinia_pk");

            entity.Property(e => e.IdOpinia)
                .ValueGeneratedNever()
                .HasColumnName("id_opinia");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.IdDieta).HasColumnName("id_dieta");
            entity.Property(e => e.IdUzytkownik).HasColumnName("id_uzytkownik");
            entity.Property(e => e.Ocena).HasColumnName("ocena");
            entity.Property(e => e.Zawartosc)
                .HasColumnType("text")
                .HasColumnName("zawartosc");

            entity.HasOne(d => d.IdDietaNavigation).WithMany(p => p.Opinia)
                .HasForeignKey(d => d.IdDieta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Opinia_Dieta");

            entity.HasOne(d => d.IdUzytkownikNavigation).WithMany(p => p.Opinia)
                .HasForeignKey(d => d.IdUzytkownik)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Opinia_Uzytkownik");
        });

        modelBuilder.Entity<PomiarWagi>(entity =>
        {
            entity.HasKey(e => e.IdPomiar).HasName("Pomiar_wagi_pk");

            entity.ToTable("Pomiar_wagi");

            entity.Property(e => e.IdPomiar)
                .ValueGeneratedNever()
                .HasColumnName("id_pomiar");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.IdUzytkownik).HasColumnName("id_uzytkownik");
            entity.Property(e => e.Waga).HasColumnName("waga");

            entity.HasOne(d => d.IdUzytkownikNavigation).WithMany(p => p.PomiarWagi)
                .HasForeignKey(d => d.IdUzytkownik)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Pomiar_Wagi_Uzytkownik");
        });

        modelBuilder.Entity<Pracownik>(entity =>
        {
            entity.HasKey(e => e.IdPracownik).HasName("Pracownik_pk");

            entity.ToTable("Pracownik");

            entity.Property(e => e.IdPracownik)
                .ValueGeneratedNever()
                .HasColumnName("id_pracownik");
            entity.Property(e => e.DataUrodzenia).HasColumnName("data_urodzenia");
            entity.Property(e => e.IdUzytkownik).HasColumnName("id_uzytkownik");
            entity.Property(e => e.Imie)
                .HasColumnType("text")
                .HasColumnName("imie");
            entity.Property(e => e.Nazwisko)
                .HasColumnType("text")
                .HasColumnName("nazwisko");
            entity.Property(e => e.NumerTelefonu)
                .HasColumnType("text")
                .HasColumnName("numer_telefonu");
            entity.Property(e => e.Stanowisko)
                .HasColumnType("text")
                .HasColumnName("stanowisko");

            entity.HasOne(d => d.IdUzytkownikNavigation).WithMany(p => p.Pracownicy)
                .HasForeignKey(d => d.IdUzytkownik)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Pracownik_Uzytkownik");
        });

        modelBuilder.Entity<Produkt>(entity =>
        {
            entity.HasKey(e => e.IdProdukt).HasName("Produkt_pk");

            entity.ToTable("Produkt");

            entity.Property(e => e.IdProdukt)
                .ValueGeneratedNever()
                .HasColumnName("id_produkt");
            entity.Property(e => e.Nazwa)
                .HasColumnType("text")
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<ProduktDanie>(entity =>
        {
            entity.HasKey(e => new { e.IdProdukt, e.IdDanie }).HasName("Produkt_Danie_pk");

            entity.ToTable("Produkt_Danie");

            entity.Property(e => e.IdProdukt).HasColumnName("id_produkt");
            entity.Property(e => e.IdDanie).HasColumnName("id_danie");
            entity.Property(e => e.Ilosc).HasColumnName("ilosc");

            entity.HasOne(d => d.IdDanieNavigation).WithMany(p => p.ProduktDanie)
                .HasForeignKey(d => d.IdDanie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Table_19_Danie");

            entity.HasOne(d => d.IdProduktNavigation).WithMany(p => p.ProduktDanie)
                .HasForeignKey(d => d.IdProdukt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Table_19_Produkt");
        });

        modelBuilder.Entity<Programy>(entity =>
        {
            entity.HasKey(e => e.IdProgram).HasName("Program_pk");

            entity.ToTable("Program");

            entity.Property(e => e.IdProgram)
                .ValueGeneratedNever()
                .HasColumnName("id_program");
            entity.Property(e => e.Nazwa)
                .HasColumnType("text")
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<PrzypisanaDieta>(entity =>
        {
            entity.HasKey(e => e.IdPrzypisanaDieta).HasName("Przypisana_dieta_pk");

            entity.ToTable("Przypisana_dieta");

            entity.Property(e => e.IdPrzypisanaDieta)
                .ValueGeneratedNever()
                .HasColumnName("id_przypisana_dieta");
            entity.Property(e => e.IdDieta).HasColumnName("id_dieta");
            entity.Property(e => e.IdProgram).HasColumnName("id_program");
            entity.Property(e => e.IdUzytkownik).HasColumnName("id_uzytkownik");

            entity.HasOne(d => d.IdDietaNavigation).WithMany(p => p.PrzypisanaDieta)
                .HasForeignKey(d => d.IdDieta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Przypisana_dieta_Dieta");

            entity.HasOne(d => d.IdProgramyNavigation).WithMany(p => p.PrzypisanaDieta)
                .HasForeignKey(d => d.IdProgram)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Przypisana_dieta_Program");

            entity.HasOne(d => d.IdUzytkownikNavigation).WithMany(p => p.PrzypisanaDieta)
                .HasForeignKey(d => d.IdUzytkownik)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Przypisana_dieta_Uzytkownik");

            entity.HasMany(d => d.IdDanie).WithMany(p => p.IdPrzypisanaDieta)
                .UsingEntity<Dictionary<string, object>>(
                    "PrzypisanaDietaDanie",
                    r => r.HasOne<Danie>().WithMany()
                        .HasForeignKey("IdDanie")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Table_18_Danie"),
                    l => l.HasOne<PrzypisanaDieta>().WithMany()
                        .HasForeignKey("IdPrzypisanaDieta")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Table_18_Przypisana_dieta"),
                    j =>
                    {
                        j.HasKey("IdPrzypisanaDieta", "IdDanie").HasName("Przypisana_dieta_Danie_pk");
                        j.ToTable("Przypisana_dieta_Danie");
                        j.IndexerProperty<int>("IdPrzypisanaDieta").HasColumnName("id_przypisana_dieta");
                        j.IndexerProperty<int>("IdDanie").HasColumnName("id_danie");
                    });
        });

        modelBuilder.Entity<Raport>(entity =>
        {
            entity.HasKey(e => e.IdRaport).HasName("Raport_pk");

            entity.ToTable("Raport");

            entity.Property(e => e.IdRaport)
                .ValueGeneratedNever()
                .HasColumnName("id_raport");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Dieta).HasColumnName("dieta");
            entity.Property(e => e.Uzytkownik).HasColumnName("uzytkownik");

            entity.HasOne(d => d.DietaNavigation).WithMany(p => p.Raporty)
                .HasForeignKey(d => d.Dieta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Raport_Dieta");

            entity.HasOne(d => d.UzytkownikNavigation).WithMany(p => p.Raporty)
                .HasForeignKey(d => d.Uzytkownik)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Raport_Uzytkownik");
        });

        modelBuilder.Entity<Rodzaj>(entity =>
        {
            entity.HasKey(e => e.IdRodzaj).HasName("Rodzaj_pk");

            entity.ToTable("Rodzaj");

            entity.Property(e => e.IdRodzaj)
                .ValueGeneratedNever()
                .HasColumnName("id_rodzaj");
            entity.Property(e => e.Nazwa)
                .HasColumnType("text")
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<Uzytkownik>(entity =>
        {
            entity.HasKey(e => e.IdUzytkownik).HasName("Uzytkownik_pk");

            entity.ToTable("Uzytkownik");

            entity.Property(e => e.IdUzytkownik)
                .ValueGeneratedNever()
                .HasColumnName("id_uzytkownik");
            entity.Property(e => e.DataUrodzenia).HasColumnName("data_urodzenia");
            entity.Property(e => e.Email)
                .HasColumnType("text")
                .HasColumnName("email");
            entity.Property(e => e.HasloHashed)
                .HasColumnType("text")
                .HasColumnName("haslo_hashed");
            entity.Property(e => e.HasloSalt)
                .HasColumnType("text")
                .HasColumnName("haslo_salt");
            entity.Property(e => e.Plec)
                .HasColumnType("text")
                .HasColumnName("plec");
            entity.Property(e => e.Pseudonim)
                .HasColumnType("text")
                .HasColumnName("pseudonim");
            entity.Property(e => e.Waga).HasColumnName("waga");
            entity.Property(e => e.Wzrost).HasColumnName("wzrost");
            entity.Property(e => e.ZapotrzebowanieKaloryczne).HasColumnName("zapotrzebowanie_kaloryczne");
        });

        modelBuilder.Entity<WypitaWoda>(entity =>
        {
            entity.HasKey(e => e.IdWypitaWoda).HasName("Wypita_woda_pk");

            entity.ToTable("Wypita_woda");

            entity.Property(e => e.IdWypitaWoda)
                .ValueGeneratedNever()
                .HasColumnName("id_wypita_woda");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.IdUzytkownik).HasColumnName("id_uzytkownik");
            entity.Property(e => e.Ilosc).HasColumnName("ilosc");

            entity.HasOne(d => d.IdUzytkownikNavigation).WithMany(p => p.WypitaWoda)
                .HasForeignKey(d => d.IdUzytkownik)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Wypita_Woda_Uzytkownik");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
