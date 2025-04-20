using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static MudBlazor.CategoryTypes;

namespace CafeApp.Shared.Components
{
    public partial class FactorTable
    {
        [Parameter]
        public DashboardFactorModel Factor{ get; set; }

        public void Show()
        {
            _navigation.NavigateTo("/dashboard/tableOrder/" + Factor.TableId);
        }
    }
}
