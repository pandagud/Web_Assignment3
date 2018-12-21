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

        public virtual DbSet<Component> component { get; set; }

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
                entity.HasKey(e => e.Category_ComponentTypeId);

                entity.ToTable("Category_ComponentType");

                entity.HasIndex(e => e.Category_ComponentTypeId)
                    .HasName("Category_ComponentTypeId")
                    .IsUnique();

                entity.Property(e => e.CategoryId)
                    .HasColumnName("Category_ComponentTypeId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ComponentTypeId)
                    .HasColumnName("ComponentTypeId")
                    .HasColumnType("int(11)");



            });


            
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

                entity.Property(e => e.Status)
                    .HasColumnName("ComponentStatus")
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


            modelBuilder.Entity<ESImage>(entity =>
            {
                entity.HasKey(e => e.ESImageId);

                entity.ToTable("ESImage");

                entity.HasIndex(e => e.ESImageId)
                    .HasName("ESImage") 
                    .IsUnique();

                entity.Property(e => e.ImageMimeType)
                    .HasColumnName("ComponentNumber")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.Thumbnail)
                    .HasColumnName("Thumbnail")
                    .HasColumnType("varbinary(8000)");

                entity.Property(e => e.ImageData)
                    .HasColumnName("ImageData")
                    .HasColumnType("varbinary(8000)");

            });


            modelBuilder.Entity<Category_ComponentType>(entity =>
            {
                entity.HasKey(e => e.Category_ComponentTypeId);

                entity.ToTable("Category_ComponentType");

                entity.HasIndex(e => e.Category_ComponentTypeId)
                    .HasName("Category_ComponentTypeId")
                    .IsUnique();

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ComponentTypeId)
                    .HasColumnName("ComponentTypeId")
                    .HasColumnType("int(11)");

            });


            modelBuilder.Entity<ComponentType>(entity =>
            {
                entity.HasKey(e => e.ComponentTypeId);

                entity.ToTable("ComponentType");

                entity.HasIndex(e => e.ComponentTypeId)
                    .HasName("ComponentTypeId")
                    .IsUnique();

                entity.Property(e => e.ComponentName)
                    .HasColumnName("ComponentName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ComponentInfo)
                    .HasColumnName("ComponentInfo")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Location)
                    .HasColumnName("Location")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ComponentTypeStatus)
                    .HasColumnName("ComponentTypeStatus")
                    .HasColumnType("varchar(50) ");

                entity.Property(e => e.Datasheet)
                    .HasColumnName("Datasheet")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("ImageUrl")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Manufacturer)
                    .HasColumnName("Manufacturer")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.WikiLink)
                    .HasColumnName("WikiLink")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AdminComment)
                    .HasColumnName("AdminComment")
                    .HasColumnType("varchar(50)");

            });



        }
    }
}
