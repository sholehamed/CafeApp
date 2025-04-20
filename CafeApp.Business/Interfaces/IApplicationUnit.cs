using CafeApp.Business.Helpers.Dtos;

namespace CafeApp.Business.Interfaces
{
    public interface IApplicationUnit
    {

        ITablesService Tables { get; }
        IMaterialService Materials { get; }
        IUnitService Units { get; }
        IAdditiveService Additives { get; }
        IProductCategoryService Categories { get; }
        IProductService Products { get; }
        IUserService Users { get; }
        ICustomerService Customers { get; }
        IOrderService Orders { get; }
        IInventoryService Inventories { get; }
        IFactorService Factors { get; }

    }
}
