using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Helpers.Dtos
{
    public class ProductCategoryDto
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }
    }

    public class CreateProductCategoryParameter
    {
        public int Order { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }
    }
    public class UpdateProductCategoryParameter
    {
        public UpdateProductCategoryParameter(Guid id, int order, string title, bool isActive, string image, string? description)
        {
            Id = id;
            Order = order;
            Title = title;
            IsActive = isActive;
            Image = image;
            Description = description;
        }

        public Guid Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }

    }
    public class UpdateCategoryOrderParameter
    {
        public Guid CategoryId { get; set; }
        public int Order { get; set; }
    }
    public class UpdateCategoryOrderParameterCollection
    {
        public ICollection<UpdateCategoryOrderParameter> Items { get; set; }
    }

    

    public class ListProductCategoryParameter : PagingParameter, IGetParameter<ProductCategoryEntity>
    {
        public string? Title { get; set; }
        public bool? IsActive { get; set; }

        public ISpecifications<ProductCategoryEntity> GetSpecifications()
        {
            return ProductCategorySpecifications.FromParameter(this);
        }

        public override string ToString()
        {
            string? route = string.Empty;
            if (!string.IsNullOrEmpty(Title))
                route = string.Format(string.Format("{0}={1}", nameof(Title), Title));
            if (IsActive is bool ia)
                route = route + "&" + string.Format("{0}={1}", nameof(IsActive), ia);
            return route + base.ToString();
        }
    }
    public class MenuCategoryModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<MenuProductModel> Products { get; set; }
    }
}
