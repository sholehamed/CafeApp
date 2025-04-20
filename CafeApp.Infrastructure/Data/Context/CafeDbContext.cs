using CafeApp.Domain.Entities;
using CafeApp.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
namespace CafeApp.Infrastructure.Data.Context
{
    internal class CafeDbContext : DbContext
    {
        public CafeDbContext(DbContextOptions options) : base(options)
        {
            
            //this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

        }
        public CafeDbContext()
        {

        }

        public DbSet<AttendanceEntity> Attendances { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<OrderDetailEntity> OrderDetails { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<InventoryEntity> Inventories { get; set; }
        public DbSet<InventoryLogEntity> InventoryLogs { get; set; }
        public DbSet<MaterialEntity> Materials { get; set; }
        public DbSet<MaterialPriceLogEntity> MaterialPriceLogs { get; set; }
        public DbSet<PayoutEntity> Payouts { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductMaterialEntity> ProductMaterials { get; set; }
        public DbSet<ProductPriceLogEntity> ProductPriceLogs { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<TableEntity> Tables { get; set; }
        public DbSet<UnitEntity> Units { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfigurations).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}




