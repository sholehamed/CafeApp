using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace CafeApp.Business.Helpers.Dtos
{
    public class TableDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetTableParameter : IGetParameter<TableEntity>
    {
        public Guid Id { get; set; }

        public GetTableParameter(Guid id)
        {
            Id = id;
        }

        public ISpecifications<TableEntity> GetSpecifications()
        {
            return TableSpecification.Get(Id);
        }
    }

    public class ListTableParameter : PagingParameter,IGetParameter<TableEntity>
    {
        public string? Title { get; set; }
        public bool? IsActive { get; set; }
        public ISpecifications<TableEntity> GetSpecifications()
        {
            return TableSpecification.FromParameter(this);
        }
        public override string ToString()
        {
            string _parameter = $"Page={Page}&PageSize={PageSize}";
            if (!string.IsNullOrEmpty(Title))
                _parameter += $"Title={Title}";
            if (IsActive is bool ia)
                _parameter += $"IsActive={ia}";
            return _parameter;
        }
    }

    public class CreateTableParameter
    {
        public string Title { get; set; }
        public int Number { get; set; }

        public bool IsActive { get; set; }
    }
    public class UpdateTableParameter : CreateTableParameter
    {
        public Guid Id { get; set; }
    }
}
