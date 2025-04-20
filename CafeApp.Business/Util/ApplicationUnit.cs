using AutoMapper;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Interfaces;
using CafeApp.Business.Services;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Util
{
    internal class ApplicationUnit:IApplicationUnit
    {

        private readonly IDataUnit _dataUnit;
        private readonly IMapper _mapper;


        private readonly ITablesService? _tableService;
        private readonly IMaterialService? _materialService;
        private readonly IUnitService? _unitService;
        private readonly IAdditiveService? _additiveService;
        private readonly IProductCategoryService? _productCategoryService;
        private readonly IProductService? _productService;
        private readonly ICustomerService? _customerService;
        private readonly IOrderService? _orderService;
        private readonly IInventoryService? _inventoryService;
        private readonly IFactorService? _factorService;
        private readonly IUserService? _userService;

        public ApplicationUnit(IDataUnit dataUnit, IMapper mapper)
        {
            _dataUnit = dataUnit;
            _mapper = mapper;
        }

        public ITablesService Tables => _tableService ?? new TablesService(_dataUnit.Tables, _mapper);
        public IMaterialService Materials => _materialService ?? new MaterialService(_dataUnit.Materials, _mapper);
        public IUnitService Units => _unitService ?? new UnitService(_dataUnit.Units, _mapper);
        public IAdditiveService Additives => _additiveService ?? new AdditiveService(_dataUnit.Additives, _mapper);
        public IProductCategoryService Categories => _productCategoryService ?? new ProductCategoryService(_dataUnit.Categories, _mapper);
        public IProductService Products => _productService ?? new ProductService(_dataUnit.Products, _mapper);
        public IUserService Users => _userService ?? new UserService(_dataUnit.Users, _mapper);
        public ICustomerService Customers => _customerService ?? new CustomerService(_dataUnit.Customers, _mapper);
        public IOrderService Orders => _orderService ?? new OrderService(_dataUnit.Orders, _mapper);
        public IInventoryService Inventories => _inventoryService ?? new InventoryService(_dataUnit.Inventories, _mapper);

        public IFactorService Factors => _factorService ?? new FactorService(_dataUnit.InventoryFactors, _mapper);
    }
}
