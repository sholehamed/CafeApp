using CafeApp.Business.Helpers.Dtos;

namespace CafeApp.Shared.Pages.Material
{
    public partial class MaterialDetail
    {
        private MaterialDetailModel value = new MaterialDetailModel();

        protected override Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                Title = "ویرایش واحد";
                GetMaterialParameter parameter = new GetMaterialParameter(Guid.Parse(Id));
                value = _unit.Materials.GetBy(parameter.GetSpecifications());
                GetUnitParameter unitParameter = new GetUnitParameter(value.UnitId);
                var parent =  _unit.Units.GetBy(unitParameter.GetSpecifications());
                _parent = new UnitDto { Id = parent.Id, Title = parent.Title, IsActive = parent.IsActive, Relation = parent.Relation };
            }
            return base.OnInitializedAsync();
        }

        private bool IsUpdate = false;


        private async Task Submit()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                UpdateMaterialParameter parameter = new UpdateMaterialParameter()
                {
                    Id = value.Id,
                    Title = value.Title,
                    IsActive = value.IsActive,
                    UnitPrice = value.UnitPrice,
                    UnitId = _parent.Id
                };
                await _unit.Materials.UpdateAsync(parameter);
            }
            else
            {
                CreateMaterialParameter parameter = new CreateMaterialParameter
                {
                    Title = value.Title,
                    IsActive = value.IsActive,
                    UnitPrice = value.UnitPrice,
                    UnitId = _parent.Id
                };
                await _unit.Materials.CreateAsync(parameter);
            }
        }
    }
}
