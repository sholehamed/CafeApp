using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Domain.Common;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Helpers.Dtos
{

    public class OrderDto
    {
        public Guid Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public string State { get; set; }
        public string? Customer { get; set; }
        public string Table { get; set; }
        public string TotalPrice { get; set; }
        public string TotalPaid { get; set; }
        public OrderDto()
        {

        }
    }
    public class CreateOrderItemAdditiveParameter
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
    }
    public class CreateOrderItemParameter
    {
        public Guid Id { get; set; }
        public Guid  OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public long TotalPrice { get; set; }
        public bool HasAdditive { get; set; }
        public ICollection<CreateOrderItemAdditiveParameter>? Additives { get; set; }
        public CreateOrderItemParameter()
        {
            Id=Guid.NewGuid();
        }
    }
    public class CreateOrderParameter
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public FactorType Type { get; set; }
        public DateTime Time { get; set; }
        public FactorState State { get; set; }
        public Guid UserId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid TableId { get; set; }
        public ICollection<CreateOrderItemParameter> Items { get; set; }
        public CreateOrderParameter()
        {

        }
    }
    public class UpdateOrderParameter
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid TableId { get; set; }
        public ICollection<CreateOrderItemParameter> Items { get; set; }
        public string? Description { get; set; }

    }
    public class ListOrderParameter : PagingParameter, IGetParameter<OrderEntity>
    {
        public byte? State { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? TableId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public ListOrderParameter()
        {

        }

        public ISpecifications<OrderEntity> GetSpecifications()
        {
            return OrderSpecifications.FromParameter(this);
        }
        public override string ToString()
        {
            string _parameter = $"Page={Page}&PageSize={PageSize}";
            if (State is byte s)
                _parameter += $"$State={State}";
            if (Start is DateTime sd)
                _parameter += $"&Start={sd}";
            if (End is DateTime ed)
                _parameter += $"&End={ed}";
            if (TableId is Guid ti)
                _parameter += $"&TableId={ti}";
            if (CustomerId is Guid ci)
                _parameter += $"&CustomerId={ci}";
            return _parameter;
        }
    }
}
