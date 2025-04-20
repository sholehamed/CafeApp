using CafeApp.Business.Helpers.Dtos;

namespace CafeApp.Shared.Pages.Additive
{
    public partial class AdditiveDetail
    {
        private AdditiveDetailModel value = new AdditiveDetailModel();



        protected override Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                Title = "ویرایش مواد اولیه";
                GetAdditiveParameter parameter=new GetAdditiveParameter(Guid.Parse(Id));
                value =  _unit.Additives.GetBy(parameter.GetSpecifications());
                if (value.MaterialId is Guid mi )
                {
                    GetMaterialParameter materialParameter=new GetMaterialParameter(mi);
                    var parent =  _unit.Materials.GetBy(materialParameter.GetSpecifications());
                    _parent = new MaterialDto { Id = parent.Id, Title = parent.Title, IsActive = parent.IsActive, UnitPrice = parent.UnitPrice.ToString("#,#"), Unit = parent.UnitId.ToString() };
                }
            }
            return base.OnInitializedAsync();
        }

        private async Task Submit()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                UpdateAdditiveParameter parameter = new UpdateAdditiveParameter()
                {
                    Id = value.Id,
                    Title = value.Title,
                    IsActive = value.IsActive,
                    Amount = value.Amount,
                    MaterialId = _parent.Id,
                    Price = value.Price
                };
                await _unit.Additives.UpdateAsync( parameter);
            }
            else
            {
                CreateAdditiveParameter parameter = new CreateAdditiveParameter
                {
                    Title = value.Title,
                    Price= value.Price,
                    IsActive = value.IsActive,
                    Amount = value.Amount,
                    MaterialId = _parent.Id
                };
                await _unit.Additives.CreateAsync(parameter);
            }
            value = new AdditiveDetailModel();
        }
    }
}
