using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;
using System.Linq.Expressions;

namespace CafeApp.Business.Helpers.Specifications
{
    public class ProductSpecifications : BaseSpecification<ProductEntity>
    {
        public static ProductSpecifications Get(GetProductParameter parameter)
        {
            ProductSpecifications specs = new ProductSpecifications();
            specs.SetFilterCondition(x=>x.Id==parameter.Id);
            specs.IncludeAdditives();
            specs.IncludeCategory();
            specs.IncludeMaterials();
            specs.ApplyOrderBy(x => x.Order);
            return specs;

        }
        public ProductSpecifications AddFilters(ListProductParameter parameter)
        {
            if (!string.IsNullOrEmpty(parameter.Title))
                SetFilterCondition(x => x.Title.Contains(parameter.Title));
           
            if (parameter.Price.HasValue && parameter.Price.Value > 0)
                SetFilterCondition(x => x.Price == parameter.Price);
            if (parameter.IsNew.HasValue)
                SetFilterCondition(x => x.IsNew == parameter.IsNew);
            if (parameter.IsActive.HasValue)
                SetFilterCondition(x => x.IsActive == parameter.IsActive);
            return this;
        }
        public ProductSpecifications AddFilter(Expression<Func<ProductEntity,bool>> expression)
        {
            base.SetFilterCondition(expression);
            return this;
        }
        public ProductSpecifications IncludeCategory()
        {
            AddInclude(nameof(ProductEntity.Category));
            return this;
        }
        public ProductSpecifications IncludeMaterials()
        {
            AddInclude("Materials.Material.Unit");
            return this;
        }
        public ProductSpecifications IncludeAdditives()
        {
            AddInclude("Additives.Additive");
            return this;
        }
    }
}
