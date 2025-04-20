using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Interfaces
{
    public interface ITablesService:IBaseService<TableEntity,TableDto>
    {
        Task<DashboardTableModel> GetDashboardTable(Guid id);
        Task<DashboardFactorModel> GetTableFactor(Guid tableId); 
        Task<ICollection<DashboardTableModel>> GetDashboardTables();
        Task<ICollection<DashboardFactorModel>> GetTablesFactor();
    }
}
