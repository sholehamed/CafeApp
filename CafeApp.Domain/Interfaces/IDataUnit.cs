using CafeApp.Domain.Entities;

namespace CafeApp.Domain.Interfaces
{
    public interface IDataUnit
    {
        //ISignInManager SignInManager { get; }
        //IUserManager UserManager { get; }
        ISql Sql { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        IRepository<TableEntity> Tables { get; }
        IRepository<MaterialEntity> Materials { get; }
        IRepository<UnitEntity> Units { get; }
        IRepository<AdditiveEntity> Additives { get; }
        IRepository<ProductCategoryEntity> Categories { get; }
        IRepository<ProductEntity> Products { get; }
        IRepository<ProductAdditiveEntity> ProductAdditives { get; }
        IRepository<ProductMaterialEntity> ProductMaterials { get; }
        IRepository<AdditivePriceLogEntity> AdditivePriceLogs { get; }
        IRepository<MaterialPriceLogEntity> MaterialPriceLogs { get; }
        IRepository<ProductPriceLogEntity> ProductPriceLogs { get; }
        IRepository<CustomerEntity> Customers { get; }
        IRepository<InventoryEntity> Inventories { get; }
        IRepository<InventoryLogEntity> InventoryLogs { get; }
        IRepository<OrderEntity> Orders { get; }
        IRepository<OrderDetailEntity> OrderItems { get; }
        IRepository<OrderItemAdditiveEntity> OrderItemAdditives { get; }
        IRepository<UserEntity> Users { get; }
        IRepository<InventoryFactorEntity> InventoryFactors { get; }
        IAuth Auth { get; }

    }
}
