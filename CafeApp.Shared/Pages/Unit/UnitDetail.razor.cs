using CafeApp.Business.Helpers.Dtos;

namespace CafeApp.Shared.Pages.Unit
{
    public partial class UnitDetail
    {
        private UnitDetailModel value = new UnitDetailModel();


        protected async override Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                Title = "ویرایش واحد";
                GetUnitParameter getUnitParameter = new GetUnitParameter(Guid.Parse(Id));
                value = _unit.Units.GetBy(getUnitParameter.GetSpecifications());
                if (value.ParentId is Guid pi)
                {
                    var parent = await _unit.Units.GetById(pi);
                    _parent = new UnitDto { Id = pi, Title = parent.Title, IsActive = parent.IsActive, Relation = parent.Relation };
                }
            }
        }

       

        private async Task Submit()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                UpdateUnitParameter parameter = new UpdateUnitParameter
                    (
                    value.Id, value.Title, value.ParentId, value.Relation, value.IsActive
                    );
                await _unit.Units.UpdateAsync(parameter);
            }
            else
            {
                CreateUnitParameter parameter = new CreateUnitParameter
                {
                    Title = value.Title,
                    IsActive = value.IsActive,
                    Relation = value.Relation,
                };
                if(_parent.Id is Guid pi && pi!=Guid.Empty)
                    parameter.ParentId = pi;
                await _unit.Units.CreateAsync(parameter);
            }
        }
    }

}
