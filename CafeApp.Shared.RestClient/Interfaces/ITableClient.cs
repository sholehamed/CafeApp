using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Shared.RestClient.Interfaces
{
    public interface ITableClient:IBaseClient<TableEntity>
    {
        Task<ICollection<DashboardTableModel>> GetDashboardTables();

    }
}
