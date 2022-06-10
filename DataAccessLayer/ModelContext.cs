using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataAccessLayer
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Library> Libraries { get; set; }
        public virtual DbSet<Magazine> Magazines { get; set; }
        public virtual DbSet<Novel> Novels { get; set; }
        public virtual DbSet<PictureBook> PictureBooks { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Library>(entity =>
            {
                entity.ToTable("tbl_Library");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(128);
                entity.Property(e => e.Location).IsRequired().HasMaxLength(50);

                modelBuilder.Entity<Book>(entity =>
                {
                    entity.ToTable("tbl_Book");
                    entity.Property(e => e.Title).IsRequired().HasMaxLength(255);
                    entity.Property(e => e.Author).IsRequired().HasMaxLength(128);
                    entity.Property(e => e.Year).IsRequired();
                    entity.Property(e => e.Description).IsRequired();
                    entity.Property(e => e.ImageUrl).HasMaxLength(255);
                    entity.Property(e => e.LastModified).HasColumnType("LastModified");
                    entity.HasDiscriminator<int>("BookType")
                        .HasValue<Book>(0)
                        .HasValue<Magazine>(1)
                        .HasValue<PictureBook>(2)
                        .HasValue<Novel>(3);
                    entity.Property(e => e.ISBN).IsRequired().HasMaxLength(13);
                    entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");
                    entity.HasOne(d => d.Library)
                        .WithMany(p => p.Books)
                        .HasForeignKey(d => d.LibraryID)
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Book_Library");
                });

                modelBuilder.Entity<Reservation>(entity =>
                {
                    entity.ToTable("tbl_Reservation");
                    entity.Property(e => e.Date);
                    entity.HasOne(d => d.Customer)
                        .WithMany(p => p.Reservations)
                        .HasForeignKey(d => d.CustomerID)
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Reservation_Customer");
                    entity.HasOne(d => d.Book)
                        .WithMany(p => p.Reservations)
                        .HasForeignKey(d => d.BookID)
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Reservation_Book");
                    entity.HasOne(d => d.Library)
                        .WithMany(p => p.Reservations)
                        .HasForeignKey(d => d.LibraryID)
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Reservation_Library");
                });

                modelBuilder.Entity<Customer>(entity =>
                {
                    entity.ToTable("tbl_Customer");
                    entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
                    entity.Property(e => e.Address).IsRequired().HasMaxLength(128);
                    entity.Property(e => e.Phone).IsRequired().HasMaxLength(255);
                    entity.HasOne(d => d.Library)
                        .WithMany(p => p.Customers)
                        .HasForeignKey(d => d.LibraryID)
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Customer_Library");
                });

                modelBuilder.Entity<Magazine>(entity =>
                {
                    entity.ToTable("tbl_Book");
                    entity.HasDiscriminator<int>("BookType");
                    entity.Property(e => e.IssueDate);
                });

                modelBuilder.Entity<Novel>(entity =>
                {
                    entity.ToTable("tbl_Book");
                    entity.Property(e => e.Pages);
                });


                modelBuilder.Entity<PictureBook>(entity =>
                {
                    entity.ToTable("tbl_Book");
                    entity.Property(e => e.Size);
                });

                OnModelCreatingPartial(modelBuilder);
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}