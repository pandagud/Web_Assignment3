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
        public virtual DbSet<Category> category { get; set; }

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


            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("Category");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("CategoryId")
                    .IsUnique();

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("CategoryName")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Category_ComponentType>(entity =>
            {
                //entity.HasKey(e => e.CategoryId);

                entity.ToTable("Category_ComponentType");

                //entity.HasIndex(e => e.CategoryId)
                //    .HasName("CategoryId")
                //    .IsUnique();

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ComponentTypeId)
                    .HasColumnName("ComponentTypeId")
                    .HasColumnType("int(11)");

            });


            //Ikke færdig
            modelBuilder.Entity<Component>(entity =>
            {
                entity.HasKey(e => e.ComponentId);

                entity.ToTable("Component");

                entity.HasIndex(e => e.ComponentId)
                    .HasName("ComponentId")
                    .IsUnique();

                entity.Property(e => e.ComponentNumber)
                    .HasColumnName("ComponentNumber")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SerialNo)
                    .HasColumnName("SerialNo")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AdminComment)
                    .HasColumnName("AdminComment")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.UserComment)
                    .HasColumnName("UserComment")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CurrentLoanInformationId)
                    .HasColumnName("CurrentLoanInformationId")
                    .HasColumnType("bigint(20)");

            });





        }
    }
}
