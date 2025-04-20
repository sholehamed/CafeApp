using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Interfaces;

namespace CafeApp.Shared.RestClient.Interfaces
{
    public interface IRestUnit
    {
        ITableClient Tables { get; }
        IMaterialsClient Materials { get; }
        IUnitsClient Units { get; }
        IAdditivesClient Additives { get; }
        ICategoriesClient Categories { get; }
        IProductClient Products { get; }
        IUsersClient Users { get; }
        ICustomersClient Customers { get; }
        IOrdersClient Orders { get; }
        IInventoriesClient Inventories { get; }
        IFactorsClient Factors { get; }
    }
}
