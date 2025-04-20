using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components;

namespace CafeApp.Shared.Components.DashboardComponents
{
    public partial class FactorItem
    {

        [Parameter]
        public Factor Factor { get; set; }

        [Parameter]
        public DashboardFactorItemModel Item { get; set; }
        public FactorItem()
        {
            Item = new DashboardFactorItemModel();
        }

        public void Add()
        {
            if (Item.PaidAmount < Item.TotalAmount)
            {
                
                Item.PaidAmount++;
                Factor.AddPrice(Item.UnitPrice);
            }
        }
        public void Minus()
        {

            if (Item.PaidAmount > Item.SubmittedDongi)
            {
                
                Item.PaidAmount--;
                Factor.MinusPrice(Item.UnitPrice);
            }
        }
        public void SubmitDongi() => Item.SubmittedDongi = Item.PaidAmount;

        public void ApplyDeliver(DashboardFactorItemModel item,object v)
        {
            item.StateChecked = (bool)v;
           Task.Run(async()=> await Factor.ApplyDeliver(item));
        }
    }
}
