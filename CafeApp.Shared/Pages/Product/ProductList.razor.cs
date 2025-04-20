using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;
using MudBlazor;

namespace CafeApp.Shared.Pages.Product
{
    public partial class ProductList
    {
        private ProductDetail _panel;
        private ListProductParameter _filter=new();
        private async Task<GridData<ProductDto>> LoadData(GridState<ProductDto> gridState)
        {
            _filter.Page = gridState.Page + 1;
            _filter.PageSize = gridState.PageSize;
            var res = await _unit.Products.GetPaged(_filter.GetSpecifications(), _filter);
            if (res.Items is null)
                res = new PagedList<ProductDto>(new List<ProductDto>(), res.TotalItems);
            return new GridData<ProductDto> { Items = res.Items, TotalItems = res.TotalItems };
        }
        private async Task Delete(Guid id)
        {
            var res = await _dialogService.ShowMessageBox("تایید", "آیا اطمینان دارید", "تایید", null, "لغو");
            if (res.Value)
            {
                await _unit.Products.DeleteAsync(id);
                _notification.NotifySuccess();
                await _dataGrid.ReloadServerData();
            }
        }
        private string? GetNewIcon(bool isnew)
        {
            if (isnew)
                return Icons.Material.Filled.NewReleases;
            else
                return string.Empty;
        }
        public async Task Sync()
        {
            try
            {
                ICollection<ProductEntity> dbEntities = await _unit.Products.GetAllForSync();
                
                foreach (ProductEntity dbEntity in dbEntities)
                {
                    dbEntity.ClearRelations();
                    await _restUnit.Products.WriteSync(dbEntity);
                }
                await _restUnit.Products.Apply();
                ICollection<ProductEntity> _apiEntities = await _restUnit.Products.Sync();

                foreach (ProductEntity dbEntity in _apiEntities)
                {
                    dbEntity.ClearRelations();
                    await _unit.Products.WriteSync(dbEntity);
                }
                await _unit.Products.Apply();
                _notification.NotifySuccess();
                await _dataGrid.ReloadServerData();
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
