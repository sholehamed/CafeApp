using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Helpers.Dtos
{
    public class UnitDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Parent { get; set; }
        public long? Relation { get; set; }
        public bool IsActive { get; set; }
    }
    public class UnitDetailModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? ParentId { get; set; }
        public long? Relation { get; set; }
        public bool IsActive { get; set; }
    }
    public class CreateUnitParameter
    {
        public string Title { get; set; }
        public Guid? ParentId { get; set; }
        public long? Relation { get; set; }
        public bool IsActive { get; set; }
    }
    public class UpdateUnitParameter
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? ParentId { get; set; }
        public long? Relation { get; set; }
        public bool IsActive { get; set; }

        public UpdateUnitParameter(Guid id, string title, Guid? parentId, long? relation, bool isActive)
        {
            Id = id;
            Title = title;
            ParentId = parentId;
            Relation = relation;
            IsActive = isActive;
        }
    }

    public class GetUnitParameter : IGetParameter<UnitEntity>
    {
        public GetUnitParameter(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public ISpecifications<UnitEntity> GetSpecifications()
        {
            return UnitSpecifications.Get(Id);
        }
    }

    public class ListUnitParameter : PagingParameter, IGetParameter<UnitEntity>
    {
        public string? Title { get; set; }
        public Guid? ParentId { get; set; }
        public bool? IsActive { get; set; }

        public ISpecifications<UnitEntity> GetSpecifications()
        {
            return UnitSpecifications.FromParameter(this);
        }

        public override string ToString()
        {
            string? route = string.Empty;
            if (!string.IsNullOrEmpty(Title))
                route = string.Format(string.Format("{0}={1}", nameof(Title), Title));
            if (IsActive is bool ia)
                route = route + "&" + string.Format("{0}={1}", nameof(IsActive), ia);
            if (ParentId is Guid pi)
                route = route + "&" + string.Format("{0}={1}", nameof(ParentId), pi);
            return route + base.ToString();
        }
    }
}
