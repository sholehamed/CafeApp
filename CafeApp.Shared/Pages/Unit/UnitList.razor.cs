using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;
using MudBlazor;

namespace CafeApp.Shared.Pages.Unit
{
    public partial class UnitList
    {
        private UnitDetail _panel;
        private ListUnitParameter _filter = new();
        private async Task<GridData<UnitDto>> LoadData(GridState<UnitDto> gridState)
        {
            _filter.PageSize=gridState.PageSize;
            _filter.Page=gridState.Page+1;
            var res = await _unit.Units.GetPaged(_filter.GetSpecifications(), _filter);
            if (res.Items is null)
                res = new PagedList<UnitDto>(new List<UnitDto>(), res.TotalItems);
            return new GridData<UnitDto> { Items = res.Items, TotalItems = res.TotalItems };
        }
        private async Task Delete(Guid id)
        {
            var res = await _dialogService.ShowMessageBox("تایید", "آیا اطمینان دارید", "تایید", null, "لغو");
            if (res.Value)
            {
                await _unit.Units.DeleteAsync(id);
                _notification.NotifySuccess();
                await _dataGrid.ReloadServerData();
            }
        }
        public async Task Sync()
        {
            try
            {
                ICollection<UnitEntity> dbEntities = await _unit.Units.GetAllForSync();

                foreach (UnitEntity dbEntity in dbEntities)
                {
                    dbEntity.ClearRelations();
                    await _restUnit.Units.WriteSync(dbEntity);
                }
                await _restUnit.Products.Apply();
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
