using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarDekho.Models
{
    public partial class CarDekhoDBContext : DbContext
    {
        public CarDekhoDBContext()
        {
        }

        public CarDekhoDBContext(DbContextOptions<CarDekhoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buyer> Buyers { get; set; } = null!;
        public virtual DbSet<NewCar> NewCars { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<ProviderDetailsforBuyer> ProviderDetailsforBuyers { get; set; } = null!;
        public virtual DbSet<Seller> Sellers { get; set; } = null!;
        public virtual DbSet<SellerDetailsforBuyer> SellerDetailsforBuyers { get; set; } = null!;
        public virtual DbSet<UsedCar> UsedCars { get; set; } = null!;
        public virtual DbSet<WebsiteHistory> WebsiteHistories { get; set; } = null!;
        public virtual DbSet<WishList> WishLists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ANIKETPATIL-VD3;Initial Catalog=CarDekhoDB;Persist Security Info=True;User ID=sa;Password=cybage@123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.ToTable("Buyer");

                entity.HasIndex(e => e.BuyerEmail, "UQ__Buyer__C654510F51A80FE0")
                    .IsUnique();

                entity.Property(e => e.BuyerAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BuyerCity)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.BuyerEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BuyerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BuyerPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NewCar>(entity =>
            {
                entity.ToTable("NewCar");

                entity.Property(e => e.BookingStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('UnApproved')");

                entity.Property(e => e.CarManufacturedate).HasColumnType("date");

                entity.Property(e => e.CarType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NcarCost)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("NCarCost");

                entity.Property(e => e.NcarInsuranceType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NCarInsuranceType");

                entity.Property(e => e.NcarMileage).HasColumnName("NCarMileage");

                entity.Property(e => e.NcarName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NCarName");

                entity.Property(e => e.NcarStatus).HasColumnName("NCarStatus");

                entity.Property(e => e.NcarTransmission)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NCarTransmission")
                    .HasDefaultValueSql("('MANUAL')");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.NewCars)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__NewCar__Provider__2F10007B");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("Provider");

                entity.HasIndex(e => e.ProviderEmail, "UQ__Provider__D9C300DEA28CBA56")
                    .IsUnique();

                entity.Property(e => e.ProviderAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderPassword)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProviderDetailsforBuyer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProviderDetailsforBuyer");

                entity.HasOne(d => d.Buyer)
                    .WithMany()
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ProviderD__Buyer__3C69FB99");

                entity.HasOne(d => d.NewCar)
                    .WithMany()
                    .HasForeignKey(d => d.NewCarId)
                    .HasConstraintName("FK__ProviderD__NewCa__3A81B327");

                entity.HasOne(d => d.Provider)
                    .WithMany()
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK__ProviderD__Provi__3B75D760");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("Seller");

                entity.HasIndex(e => e.SellerEmail, "UQ__Seller__55F828C0CE73BF45")
                    .IsUnique();

                entity.Property(e => e.SellerAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SellerCity)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SellerEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SellerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SellerPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SellerDetailsforBuyer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SellerDetailsforBuyer");

                entity.HasOne(d => d.Buyer)
                    .WithMany()
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__SellerDet__Buyer__403A8C7D");

                entity.HasOne(d => d.Provider)
                    .WithMany()
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK__SellerDet__Provi__3F466844");

                entity.HasOne(d => d.UserCar)
                    .WithMany()
                    .HasForeignKey(d => d.UserCarId)
                    .HasConstraintName("FK__SellerDet__UserC__3E52440B");
            });

            modelBuilder.Entity<UsedCar>(entity =>
            {
                entity.ToTable("UsedCar");

                entity.Property(e => e.BookingStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('UnApproved')");

                entity.Property(e => e.CarPurchaseDate).HasColumnType("date");

                entity.Property(e => e.CarType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UcarCost)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("UCarCost");

                entity.Property(e => e.UcarDriven).HasColumnName("UCarDriven");

                entity.Property(e => e.UcarInsuranceType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UCarInsuranceType");

                entity.Property(e => e.UcarMileage).HasColumnName("UCarMileage");

                entity.Property(e => e.UcarName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UCarName");

                entity.Property(e => e.UcarNoOfPrevOwner).HasColumnName("UCarNoOfPrevOwner");

                entity.Property(e => e.UcarRto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UCarRTO");

                entity.Property(e => e.UcarStatus).HasColumnName("UCarStatus");

                entity.Property(e => e.UcarTransmission)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UCarTransmission")
                    .HasDefaultValueSql("('MANUAL')");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.UsedCars)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__UsedCar__SellerI__33D4B598");
            });

            modelBuilder.Entity<WebsiteHistory>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__WebsiteH__55433A6BEE3EA4A0");

                entity.ToTable("WebsiteHistory");

                entity.Property(e => e.TransactionDateTime).HasColumnType("datetime");

                entity.Property(e => e.TransactionDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.ToTable("WishList");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.WishLists)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__WishList__BuyerI__38996AB5");

                entity.HasOne(d => d.NewCar)
                    .WithMany(p => p.WishLists)
                    .HasForeignKey(d => d.NewCarId)
                    .HasConstraintName("FK__WishList__NewCar__36B12243");

                entity.HasOne(d => d.UsedCar)
                    .WithMany(p => p.WishLists)
                    .HasForeignKey(d => d.UsedCarId)
                    .HasConstraintName("FK__WishList__UsedCa__37A5467C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
