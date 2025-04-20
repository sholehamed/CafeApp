using CafeApp.Domain.Common;
using CafeApp.Shared.RestClient.Interfaces;
using CafeApp.Shared.RestClient.Repositories;

namespace CafeApp.Shared.RestClient.Util
{
    internal class RestUnit : IRestUnit
    {
        private readonly HttpClient _httpClient;
        private ITableClient? _tablesClient;
        private IMaterialsClient? _materialsClient;
        private IUnitsClient? _unitsClient;
        private IAdditivesClient? _additivesClient;
        private ICategoriesClient? _categoriesClient;
        private IProductClient? _productsClient;
        private IUsersClient? _usersClient;
        private ICustomersClient? _customersClient;
        private IOrdersClient? _ordersClient;
        private IInventoriesClient? _inventories;
        private IFactorsClient? _factors;

        public RestUnit(ServerOptions serverOptions)
        {
            _httpClient = new HttpClient() { BaseAddress=new Uri( serverOptions.Url)};
        }

        public ITableClient Tables => _tablesClient ?? new TableClient(_httpClient, "tables");

        public IMaterialsClient Materials => _materialsClient ?? new MaterialsClient(_httpClient, "Materials");

        public IUnitsClient Units => _unitsClient ?? new UnitsClient(_httpClient, "units");

        public IAdditivesClient Additives => _additivesClient ?? new AdditivesClient(_httpClient, "Additives");

        public ICategoriesClient Categories => _categoriesClient ?? new CategoriesClient(_httpClient, "ProductCategories");

        public IProductClient Products => _productsClient ??new ProductsClient(_httpClient, "products");

        public IUsersClient Users => _usersClient??new UsersClient(_httpClient,"users");

        public ICustomersClient Customers => _customersClient ?? new CustomersClient(_httpClient, "customers");

        public IOrdersClient Orders =>  _ordersClient??new OrdersClient(_httpClient, "orders");

        public IInventoriesClient Inventories => _inventories ?? new InventoriesClient(_httpClient, "Inventories");

        public IFactorsClient Factors => _factors ?? new FactorsClient(_httpClient, "factors");
    }
}
