using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models
{
    public partial class bachelordbContext : DbContext
    {
        public bachelordbContext()
        {
        }

        public bachelordbContext(DbContextOptions<bachelordbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> admin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=35.228.62.48;Database=webdb;user=admin;pwd=123456;");
               
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("admin");

                entity.HasIndex(e => e.IdAdmin)
                    .HasName("id_admin_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdAdmin)
                    .HasColumnName("id_admin")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.IsAdmin)
                    .HasColumnName("isadmin")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(45)");
            });
            
        }
    }
}
