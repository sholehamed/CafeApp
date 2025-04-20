using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components;

namespace CafeApp.Shared.Components
{
    public partial class FactorTableItem
    {

        [Parameter]
        public DashboardFactorItemModel Item { get; set; }
        public FactorTableItem()
        {
            Item = new DashboardFactorItemModel();
        }

       
        

      
    }
}
