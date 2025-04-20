using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Interfaces
{
    public interface IOrderService:IBaseService<OrderEntity,OrderDto,DashboardFactorModel>
    {
        Task ChangeState(Guid orderId, short state);
        Task ApplyDeliver(DashboardFactorItemModel item, Guid orderId);
        Task PayOrder(Guid orderId, long paidValue);
        Task PayOrderItem(Guid orderId, Guid orderItemId, int amount);
        Task ChangeTable(Guid orderId, Guid tableId);
    }
}
