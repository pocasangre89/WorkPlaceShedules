using Microsoft.EntityFrameworkCore;
using WorkPlaceShedules.Domain.Entities;

namespace WorkPlaceShedules.Infraestructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersEntity>()
                .Property(p => p.UserCode)
                .HasColumnType("varchar(50)");
            modelBuilder.Entity<UsersEntity>()
                .Property(p => p.FullName)
                .HasColumnType("varchar(200)");
            modelBuilder.Entity<UsersEntity>()
                            .Property(p => p.Email)
                            .HasColumnType("varchar(100)");
            modelBuilder.Entity<WorkGroupsEntity>()
                            .Property(p => p.GroupDescription)
                            .HasColumnType("varchar(500)");
            modelBuilder.Entity<WorkGroupsEntity>()
                            .Property(p => p.GroupName)
                            .HasColumnType("varchar(250)");
            modelBuilder.Entity<WorkPlacesEntity>()
                            .Property(p => p.WorkPlaceCode)
                            .HasColumnType("varchar(50)");
            modelBuilder.Entity<WorkPlacesEntity>()
                            .Property(p => p.WorkPlaceName)
                            .HasColumnType("varchar(500)");
            modelBuilder.Entity<WorkPlacesEntity>()
                            .Property(p => p.WorkPlaceNumber)
                            .HasColumnType("int");

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasColumnType("DateTime");
                    }
                    if (property.Name == "Creator" || property.Name == "Modifier")
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasColumnType("varchar(50)");
                    }
                }
            }

            // Agrega configuraciones similares para otras propiedades según sea necesario

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UsersEntity> Users { get; set; }
        public DbSet<UserWorkPlaceShedulesEntity> WorkPlaceShedules { get; set; }
        public DbSet<WorkGroupsEntity> WorkGroups { get; set; }
        public DbSet<WorkPlacesEntity> WorkPlaces { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
    }
}
