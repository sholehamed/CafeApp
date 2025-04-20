using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components;

namespace CafeApp.Shared.Components.MenuComponents
{
    public partial class ProductItem
    {
        [Parameter]
        public MenuProductModel Item { get; set; }


        private string IsNew()
        {
            if (Item.IsNew)
                return "new-badge";
            else
                return "hide";
        }

        private string HasStock()
        {
            if (Item.OutOfStock)
                return "out";
            else
                return "hide";

        }
    }
}
