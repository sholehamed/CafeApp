using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Domain.Common;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Helpers.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string? Description { get; set; }
        public bool IsNew { get; set; }
        public bool IsActive { get; set; }
        public bool OutOfStock { get; set; }
    }
    public class ProductDetailModel
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public string Image { get; set; }
        public long Price { get; set; }
        public string? Description { get; set; }
        public bool IsNew { get; set; }
        public bool IsActive { get; set; }
        public ICollection<AdditiveSelectModel> Additives { get; set; }
        public ICollection<MaterialSelectModel> Materials { get; set; }
    }
    public class ProductAdditiveModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class ProductMaterialModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public long Amount { get; set; }
    }
    public class CreateProductParameter
    {
        public CreateProductParameter(int order, Guid categoryId, string title, string image, long price, string? description, bool isNew, bool isActive, ICollection<CreateProductMaterialParameter>? materials, ICollection<Guid>? additives)
        {
            Order = order;
            CategoryId = categoryId;
            Title = title;
            Image = image;
            Price = price;
            Description = description;
            IsNew = isNew;
            IsActive = isActive;
            Materials = materials;
            Additives = additives;
        }

        public int Order { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public long Price { get; set; }
        public string? Description { get; set; }
        public bool IsNew { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CreateProductMaterialParameter>? Materials { get; set; }
        public ICollection<Guid>? Additives { get; set; }
    }
    public class UpdateProductParameter
    {
        public UpdateProductParameter(Guid id, int order, Guid categoryId, string title, string image, long price, string? description, bool isNew, bool isActive, ICollection<CreateProductMaterialParameter>? materials, ICollection<Guid>? additives)
        {
            Id = id;
            Order = order;
            CategoryId = categoryId;
            Title = title;
            Image = image;
            Price = price;
            Description = description;
            IsNew = isNew;
            IsActive = isActive;
            Materials = materials;
            Additives = additives;
        }

        public Guid Id { get; set; }
        public int Order { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public long Price { get; set; }
        public string? Description { get; set; }
        public bool IsNew { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CreateProductMaterialParameter>? Materials { get; set; }
        public ICollection<Guid>? Additives { get; set; }
    }
    public class CreateProductMaterialParameter
    {
        public CreateProductMaterialParameter(Guid materialId,Guid unitId, long amount)
        {
            MaterialId = materialId;
            UnitId = unitId;
            Amount = amount;
        }
        public Guid UnitId { get; set; }
        public Guid MaterialId { get; set; }
        public long Amount { get; set; }
    }

    public class UpdateProductsOrderCollection
    {
        public ICollection<UpdateProductOrderParameter> Items { get; set; }
    }
    public class UpdateProductOrderParameter
    {
        public Guid ProductId { get; set; }
        public int Order { get; set; }
    }

    public class GetProductParameter:IGetParameter<ProductEntity>
    {
        public Guid Id { get; set; }

        public GetProductParameter(Guid id)
        {
            Id = id;
        }

        public ISpecifications<ProductEntity> GetSpecifications()
        {
            return ProductSpecifications.Get(this);
        }
    }
    public class ListProductParameter : PagingParameter,IGetParameter<ProductEntity>
    {
        public Guid? CategoryId { get; set; }
        public string? Title { get; set; }
        public long? Price { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsNew { get; set; }

        public ISpecifications<ProductEntity> GetSpecifications()
        {
            ProductSpecifications productSpecifications = new ProductSpecifications();
            productSpecifications.AddFilters(this);
            productSpecifications.IncludeCategory();
            return productSpecifications;
        }
        public override string ToString()
        {
            string _parameter = $"Page={Page}&PageSize={PageSize}";
            if (!string.IsNullOrEmpty(Title))
                _parameter += $"Title={Title}";
            if (CategoryId is Guid ci)
                _parameter += $"CategoryId={ci}";
            if (Price is long p)
                _parameter += $"Price={p}";
            if (IsActive is bool ia)
                _parameter += $"IsActive={ia}";
            if (IsNew is bool inew)
                _parameter += $"IsNew={inew}";
            return _parameter;
        }
    }
    public class UpdateProductPriceParameter
    {
        public UpdateProductPriceParameter()
        {

        }
        private Guid Id { get; }
        public long Price { get; set; }
        public UpdateProductPriceParameter(Guid id, long price)
        {
            Id = id;
            Price = price;
        }
        public Guid GetId()
        {
            return Id;
        }
    }
    public class MenuProductModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsNew { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }
        public long Price { get; set; }
        public bool OutOfStock { get; set; }
        public ICollection<MenuAdditiveDto>? Additives { get; set; }
    }

}
