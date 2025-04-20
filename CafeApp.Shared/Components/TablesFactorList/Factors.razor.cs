
using CafeApp.Business.Helpers.Dtos;

namespace CafeApp.Shared.Components.TablesFactorList
{

    public partial class Factors
    {
        ICollection<DashboardFactorModel> factors=new List<DashboardFactorModel>();
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                factors = await _unit.Tables.GetTablesFactor();
              await  InvokeAsync(StateHasChanged);
            }
        }
    }
}
