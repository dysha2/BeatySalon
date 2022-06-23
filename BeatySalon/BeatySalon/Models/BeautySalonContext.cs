using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BeatySalon.Models
{
    public partial class BeautySalonContext : DbContext
    {
        public BeautySalonContext()
        {
        }

        public BeautySalonContext(DbContextOptions<BeautySalonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttachedProduct> AttachedProducts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientService> ClientServices { get; set; }
        public virtual DbSet<DocumentByService> DocumentByServices { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhotos { get; set; }
        public virtual DbSet<ProductSale> ProductSales { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServicePhoto> ServicePhotos { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagOfClient> TagOfClients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                optionsBuilder.UseSqlServer("Server = DESKTOP-GPBN6TO;Database = Saloon;Integrated Security = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<AttachedProduct>(entity =>
            {
                entity.HasKey(e => new { e.MainProductId, e.AttachedProductId });

                entity.ToTable("AttachedProduct");

                entity.Property(e => e.MainProductId).HasColumnName("MainProductID");

                entity.Property(e => e.AttachedProductId).HasColumnName("AttachedProductID");

                entity.HasOne(d => d.AttachedProductNavigation)
                    .WithMany(p => p.AttachedProductAttachedProductNavigations)
                    .HasForeignKey(d => d.AttachedProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttachedProduct_Product1");

                entity.HasOne(d => d.MainProduct)
                    .WithMany(p => p.AttachedProductMainProducts)
                    .HasForeignKey(d => d.MainProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttachedProduct_Product");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GenderCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhotoPath).HasMaxLength(1000);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.HasOne(d => d.GenderCodeNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.GenderCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Gender");
            });

            modelBuilder.Entity<ClientService>(entity =>
            {
                entity.ToTable("ClientService");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientServices)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientService_Client");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ClientServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientService_Service");
            });

            modelBuilder.Entity<DocumentByService>(entity =>
            {
                entity.ToTable("DocumentByService");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientServiceId).HasColumnName("ClientServiceID");

                entity.Property(e => e.DocumentPath)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.ClientService)
                    .WithMany(p => p.DocumentByServices)
                    .HasForeignKey(d => d.ClientServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentByService_ClientService");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Gender");

                entity.Property(e => e.Code)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("Manufacturer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.MainImagePath).HasMaxLength(1000);

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_Product_Manufacturer");
            });

            modelBuilder.Entity<ProductPhoto>(entity =>
            {
                entity.ToTable("ProductPhoto");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PhotoPath)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPhotos)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPhoto_Product");
            });

            modelBuilder.Entity<ProductSale>(entity =>
            {
                entity.ToTable("ProductSale");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientServiceId).HasColumnName("ClientServiceID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SaleDate).HasColumnType("datetime");

                entity.HasOne(d => d.ClientService)
                    .WithMany(p => p.ProductSales)
                    .HasForeignKey(d => d.ClientServiceId)
                    .HasConstraintName("FK_ProductSale_ClientService");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSales)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductSale_Product");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.MainImagePath).HasMaxLength(1000);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ServicePhoto>(entity =>
            {
                entity.ToTable("ServicePhoto");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PhotoPath)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServicePhotos)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicePhoto_Service");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TagOfClient>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.TagId });

                entity.ToTable("TagOfClient");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TagOfClients)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagOfClient_Client");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TagOfClients)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagOfClient_Tag");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
