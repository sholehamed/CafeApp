using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace CafeApp.Shared.Pages.Product
{
    public partial class ProductDetail
    {
        private ProductDetailModel value = new ProductDetailModel();


        private bool IsUpdate = false;
        ProductCategoryDto _category;
        private ICollection<MaterialSelectModel> _materials = new List<MaterialSelectModel>();
        private ICollection<AdditiveSelectModel> _additives = new List<AdditiveSelectModel>();


        protected override Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                IsUpdate = true;
                Title = "ویرایش  محصولات";
                GetProductParameter parameter = new GetProductParameter(Guid.Parse(Id));
                value = _unit.Products.GetBy(parameter.GetSpecifications());
                if (value.CategoryId is Guid ci)
                {
                    GetCategoryParameter categoryParameter = new GetCategoryParameter(ci);
                    _category = _unit.Categories.GetBy(categoryParameter.GetSpecifications());
                }
                _materials = value.Materials;
                _additives = value.Additives;
            }
            return base.OnInitializedAsync();
        }
        private async void UploadFiles(IBrowserFile? browserFile)
        {
            if (browserFile != null)
            {

                value.Image = await ConvertToBase64(browserFile.OpenReadStream(maxAllowedSize: int.MaxValue));
            }
            StateHasChanged();
        }
        private async Task<string> ConvertToBase64(Stream stream)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                await stream.CopyToAsync(ms);
                byte[] byteArray = ms.ToArray();
                return Convert.ToBase64String(byteArray);
            }

        }
        private async Task Submit()
        {
            if (IsUpdate)
            {
                UpdateProductParameter parameter = new UpdateProductParameter
                    (
                    value.Id, value.Order, _category.Id, value.Title, value.Image, value.Price, value.Description, value.IsNew, value.IsActive, _materials.Select(x => new CreateProductMaterialParameter(x.Id,x.UnitId, x.Amount)).ToList(), _additives.Select(x => x.Id).ToList()
                    );
                await _unit.Products.UpdateAsync(parameter);
                _notification.NotifySuccess();

            }
            else
            {
                CreateProductParameter parameter = new CreateProductParameter
                    (
                        value.Order, _category.Id, value.Title, value.Image, value.Price, value.Description, value.IsNew, value.IsActive, _materials.Select(x => new CreateProductMaterialParameter(x.Id,x.UnitId, x.Amount)).ToList(), _additives.Select(x => x.Id).ToList()
                    );

                await _unit.Products.CreateAsync(parameter);
                _notification.NotifySuccess();
            }
            value = new ProductDetailModel();
            Cancel();
        }

        private async Task<IEnumerable<AdditiveDto>> SearchAdditives(string text, CancellationToken cancellationToken = default)
        {
            List<AdditiveDto> res = new List<AdditiveDto>();
            
                ListAdditiveParameter additiveParameter = new ListAdditiveParameter();
                additiveParameter.Title = text;
                var t = await _unit.Additives.GetPaged(additiveParameter.GetSpecifications(),additiveParameter);
                res = t.Items.Where(x => !_additives.Select(x => x.Title).ToList().Contains(x.Title)).ToList();
            
            return res;
        }
        private async Task<IEnumerable<MaterialDto>> SearchMaterials(string text, CancellationToken cancellationToken = default)
        {
            List<MaterialDto> res = new List<MaterialDto>();
            
                ListMaterialParameter materialParameter = new ListMaterialParameter();
                materialParameter.Title = text;
                var t = await _unit.Materials.GetPaged(materialParameter.GetSpecifications(),materialParameter);
                res = t.Items.Where(x => !_materials.Select(x => x.Title).ToList().Contains(x.Title)).ToList();
            
            return res;
        }
        private string AdditiveToString(AdditiveDto model)
        {
            if (model == null)
                return string.Empty;
            else
                return model.Title;
        }
        private string MaterialToString(MaterialDto model)
        {
            if (model == null)
                return string.Empty;
            else
                return model.Title;
        }
        MudAutocomplete<MaterialDto> _materialSelect;
        MudAutocomplete<AdditiveDto> _additiveSelect;

        private void MaterialChanged(MaterialDto material)
        {
            _materials.Add(new MaterialSelectModel(material.Id, material.Title,material.UnitId, material.Unit, 0));
            _materialSelect.ClearAsync();
            StateHasChanged();
        }
        private void AdditiveChanged(AdditiveDto additive)
        {
            _additives.Add(new AdditiveSelectModel(additive.Id, additive.Title));

            _additiveSelect.ClearAsync();
            StateHasChanged();
        }
        private void CancelMaterial(Guid id)
        {
            _materials.Remove(_materials.First(x => x.Id == id));
            StateHasChanged();
        }
        private void CancelAdditive(Guid id)
        {
            _additives.Remove(_additives.First(x => x.Id == id));
            StateHasChanged();
        }
        private void AddUpdateMaterialAmount(Guid id, long amount)
        {
            MaterialSelectModel? materialParameter = _materials.Where(x => x.Id == id).FirstOrDefault();
            if (materialParameter is MaterialSelectModel)
            {
                _materials.First(x => x.Id == id).Amount = amount;
            }


        }
        public void Cancel()
        {
            _navigation.NavigateTo("/dashboard/products");
        }
        private async Task<IEnumerable<ProductCategoryDto>> SearchCategory(string text,CancellationToken cancellationToken=default)
        {
            ListProductCategoryParameter categoryParameter = new ListProductCategoryParameter();
            categoryParameter.Title = text;
            var res = await _unit.Categories.GetPaged(categoryParameter.GetSpecifications(),categoryParameter);
            return res.Items;
        }
    }
}
