using Microsoft.EntityFrameworkCore;

namespace AgreementManagement.Web.Data
{
    public partial class AgreementManagementContext : DbContext
    {
        public AgreementManagementContext()
        {
        }

        public AgreementManagementContext(DbContextOptions<AgreementManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agreement> Agreement { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductGroup> ProductGroup { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=WL047139\\SQLEXPRESS2014;Database=AgreementManagement;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Agreement>(entity =>
            {
                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.NewPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.ProductGroup)
                    .WithMany(p => p.Agreement)
                    .HasForeignKey(d => d.ProductGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agreement_ToTable_1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Agreement)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agreement_ToTable_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Agreement)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agreement_ToTable");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductDescription).IsRequired();

                entity.Property(e => e.ProductNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.ProductGroup)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductGroupId)
                    .HasConstraintName("FK_Product_ToTable");
            });

            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.HasIndex(e => e.GroupCode)
                    .HasName("UQ__ProductG__3B97438005806C46")
                    .IsUnique();

                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.GroupCode)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.GroupDescription).IsRequired();
            });
        }
    }
}
