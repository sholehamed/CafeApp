using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Helpers.Dtos
{
    public class AdditiveDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Material { get; set; }
        public string Amount { get; set; }
        public string Price { get; set; }
        public bool IsActive { get; set; }
    }
    public class AdditiveSelectModel
    {
        public AdditiveSelectModel()
        {

        }
        public AdditiveSelectModel(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
    }
    public class AdditiveDetailModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid MaterialId { get; set; }
        public long Amount { get; set; }
        public long Price { get; set; }
        public bool IsActive { get; set; }
    }
    public class CreateAdditiveParameter
    {
        public string Title { get; set; }
        public Guid MaterialId { get; set; }
        public long Amount { get; set; }
        public long Price { get; set; }
        public bool IsActive { get; set; }
    }
    public class UpdateAdditiveParameter:CreateAdditiveParameter
    {
        public Guid Id { get; set; }
    }
    public class GetAdditiveParameter : PagingParameter,IGetParameter<AdditiveEntity>
    {
        public Guid Id { get; set; }

        public GetAdditiveParameter(Guid id)
        {
            Id = id;
        }

        public ISpecifications<AdditiveEntity> GetSpecifications()
        {
            return AdditiveSpecifications.Get(this);
        }
       

    }
    public class ListAdditiveParameter : PagingParameter, IGetParameter<AdditiveEntity>
    {
        public string? Title { get; set; }
        public int? MaterialId { get; set; }
        public bool? IsActive { get; set; }

        public ISpecifications<AdditiveEntity> GetSpecifications()
        {
            var specs = new AdditiveSpecifications().AddFilter(this);
            specs.AddIncludes();
            return specs;
        }

        public override string ToString()
        {
            string? route = string.Empty;
            if (!string.IsNullOrEmpty(Title))
                route = string.Format(string.Format("{0}={1}", nameof(Title), Title));
            if (IsActive.HasValue)
                route = route + "&" + string.Format("{0}={1}", nameof(IsActive), IsActive);
            if (MaterialId.HasValue)
                route = route + "&" + string.Format("{0}={1}", nameof(MaterialId), MaterialId);
            return route + base.ToString();
        }
    }
}
