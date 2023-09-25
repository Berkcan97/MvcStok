﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace MvcStok.Entity;

public partial class MvcDbStokContext : DbContext
{
    public MvcDbStokContext()
    {
    }

    public MvcDbStokContext(DbContextOptions<MvcDbStokContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tblkategoriler> Tblkategorilers { get; set; }

    public virtual DbSet<Tblmusteriler> Tblmusterilers { get; set; }

    public virtual DbSet<Tblsatislar> Tblsatislars { get; set; }

    public virtual DbSet<Tblurunler> Tblurunlers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ÜMITPC;Database=MvcDbStok;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tblkategoriler>(entity =>
        {
            entity.HasKey(e => e.Kategorid);

            entity.ToTable("TBLKATEGORILER");

            entity.Property(e => e.Kategorid).HasColumnName("KATEGORID");
            entity.Property(e => e.Kategoriad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("KATEGORIAD");
        });

        modelBuilder.Entity<Tblmusteriler>(entity =>
        {
            entity.HasKey(e => e.Musteriid);

            entity.ToTable("TBLMUSTERILER");

            entity.Property(e => e.Musteriid).HasColumnName("MUSTERIID");
            entity.Property(e => e.Musteriad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MUSTERIAD");
            entity.Property(e => e.Musterisoyad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MUSTERISOYAD");
        });

        modelBuilder.Entity<Tblsatislar>(entity =>
        {
            entity.HasKey(e => e.Satisid);

            entity.ToTable("TBLSATISLAR");

            entity.Property(e => e.Satisid).HasColumnName("SATISID");
            entity.Property(e => e.Adet).HasColumnName("ADET");
            entity.Property(e => e.Fİyat)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("FİYAT");
            entity.Property(e => e.Musteri).HasColumnName("MUSTERI");
            entity.Property(e => e.Urun).HasColumnName("URUN");

            entity.HasOne(d => d.MusteriNavigation).WithMany(p => p.Tblsatislars)
                .HasForeignKey(d => d.Musteri)
                .HasConstraintName("FK_TBLSATISLAR_TBLMUSTERILER");

            entity.HasOne(d => d.UrunNavigation).WithMany(p => p.Tblsatislars)
                .HasForeignKey(d => d.Urun)
                .HasConstraintName("FK_TBLSATISLAR_TBLURUNLER");
        });

        modelBuilder.Entity<Tblurunler>(entity =>
        {
            entity.HasKey(e => e.Urunid);

            entity.ToTable("TBLURUNLER");

            entity.Property(e => e.Urunid).HasColumnName("URUNID");
            entity.Property(e => e.Fİyat)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("FİYAT");
            entity.Property(e => e.Marka)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MARKA");
            entity.Property(e => e.Stok).HasColumnName("STOK");
            entity.Property(e => e.Urunad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("URUNAD");
            entity.Property(e => e.Urunkategori).HasColumnName("URUNKATEGORI");

            entity.HasOne(d => d.UrunkategoriNavigation).WithMany(p => p.Tblurunlers)
                .HasForeignKey(d => d.Urunkategori)
                .HasConstraintName("FK_TBLURUNLER_TBLKATEGORILER");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
