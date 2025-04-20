using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;
using Microsoft.VisualBasic;

namespace CafeApp.Business.Services
{
    internal class TablesService : BaseService<TableEntity, TableDto>, ITablesService
    {
        public TablesService(IRepository<TableEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ICollection<DashboardTableModel>> GetDashboardTables()
        {
            ICollection<DashboardTableModel> tables = _repository.Get(x => x.IsActive)
                            .Select(x => new DashboardTableModel
                            {
                                Number = x.Number,
                                Id = x.Id,
                                Title = x.Title
                            }).OrderBy(x=>x.Number).ToList();
            //foreach (var table in tables)
            //{


            //    OrderEntity? order = _repository.DataUnit.Orders.Get(OrderSpecifications.GetTableState(table.Id)).FirstOrDefault();
            //    if (order is OrderEntity)
            //    {
            //        table.State = TableState.filled;
            //        table.LastState = TableState.filled;
            //    }
            //    else
            //    {
            //        table.State = TableState.empty;
            //        table.LastState = TableState.empty;
            //    }
            //}
            return tables;
        }
        public async Task<DashboardTableModel> GetDashboardTable(Guid id)
        {
            DashboardTableModel table = _repository.Get(x => x.Id == id)
                            .Select(x => new DashboardTableModel
                            {
                                Number = x.Number,
                                Id = x.Id,
                                Title = x.Title
                            }).FirstOrDefault()!;
            if (table is DashboardTableModel)
            {
                OrderEntity? order = _repository.DataUnit.Orders.Get(OrderSpecifications.GetTableState(table.Id)).FirstOrDefault();
                table.Factor = _mapper.Map<DashboardFactorModel>(order);
                if (order is OrderEntity && (order.State == Domain.Common.FactorState.InProgress || order.State == Domain.Common.FactorState.New ||order.State==Domain.Common.FactorState.Completed))
                {
                    table.State = TableState.filled;
                    table.LastState = TableState.filled;
                }
                else
                {
                    table.State = TableState.empty;
                    table.LastState = TableState.empty;
                }

            }

            return await Task.FromResult(table);
        }

        public async Task<DashboardFactorModel> GetTableFactor(Guid tableId)
        {
            OrderSpecifications specs = OrderSpecifications.GetTableOrder(tableId);
            var res = _repository.DataUnit.Orders.Get(specs).ProjectTo<DashboardFactorModel>(_mapper.ConfigurationProvider).FirstOrDefault();
            return await Task.FromResult(res!);
        }

        public async Task<ICollection<DashboardFactorModel>> GetTablesFactor()
        {
            var specs = OrderSpecifications.GetOrdersTable();
            var res=_repository.DataUnit.Orders.Get(specs).ProjectTo<DashboardFactorModel>(_mapper.ConfigurationProvider).ToList();
            return await Task.FromResult(res);
        }
    }
}
