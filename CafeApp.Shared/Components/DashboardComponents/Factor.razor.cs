using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CafeApp.Shared.Components.DashboardComponents
{
    public partial class Factor
    {
        [Parameter]
        public CategoryItemsSection ItemsSection { get; set; }


        [Parameter]
        public EventCallback Pay { get; set; }
        [CascadingParameter]
        public TablesPanel TablesPanel { get; set; }

        private long _livePaidAmount = 0;

        [Parameter]
        public DashboardTableModel Table { get; set; }

        public long LivePaidAmount { get; set; }

        private IJSObjectReference _module;
        private bool _dongi = false;
        public Factor()
        {
            Table = new DashboardTableModel();
        }
        public void SetCustomer(CustomerDto value)
        {
            Table.Factor.CustomerId = value.Id;
        }
        public void Add(DashboardProductModel dashboardProduct)
        {
            DashboardFactorItemModel item = Table.Factor.Items.FirstOrDefault(x => x.ProductId == dashboardProduct.Id);
            if (item == null)
            {
                item = new DashboardFactorItemModel() { ProductId = dashboardProduct.Id, CategoryId = dashboardProduct.CategoryId, ProductTitle = dashboardProduct.Title, TotalAmount = dashboardProduct.Amount, UnitPrice = dashboardProduct.Price };
                Table.Factor.Items.Add(item);
            }
            else
                item.TotalAmount = item.TotalAmount + 1;

            StateHasChanged();
        }
        public void Minus(DashboardProductModel dashboardProduct)
        {
            DashboardFactorItemModel item = Table.Factor.Items.FirstOrDefault(x => x.ProductId == dashboardProduct.Id);
            if (item != null)
            {
                if (item.TotalAmount == 1)
                    Table.Factor.Items.Remove(item);
                else
                {
                    if (item.TotalAmount != 0)
                        item.TotalAmount--;

                }
            }
            StateHasChanged();
        }
        public async void EnableDongi()
        {
            await _module.InvokeVoidAsync("enableDongi", _dongi);
            if (_dongi)
            {
                if (Table.Factor.Id == Guid.Empty)
                {
                    _notification.Error("فاکتور هنوز ثبت نشده است");
                    return;
                }
                foreach (var item in Table.Factor.Items)
                {
                    item.SubmitDongi();
                    await _unit.Orders.PayOrderItem(Table.Factor.Id, item.Id, item.PaidAmount);
                }
                Table.Factor.Paid = Table.Factor.Paid + _livePaidAmount;
                _livePaidAmount = 0;
                StateHasChanged();
                await _unit.Orders.PayOrder(Table.Factor.Id, Table.Factor.Paid);

            }
            _dongi = !_dongi;
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _module = await _js.InvokeAsync<IJSObjectReference>("import", "/_content/CafeApp.Shared/scripts/Item.js");
            }
        }
        //private CustomerDto _selectedCustomer=new CustomerDto();
        //private async Task<IEnumerable<CustomerDto>> SearchCustomer(string text,CancellationToken cancellationToken = default)
        //{
        //    ListCustomerParameter parameter = new ListCustomerParameter();

        //   return await _unit.Customers.GetAll(CustomerSpecifications.FromParameter(parameter));
        //}

        protected override async void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                //_selectedCustomer=await _unit.Customers.GetById(Item.CustomerId);
            }
        }
        public void AddPrice(long unitPrice)
        {
            _livePaidAmount += unitPrice;
            InvokeAsync(StateHasChanged);

        }
        public void MinusPrice(long unitPrice)
        {
            _livePaidAmount -= unitPrice;
            InvokeAsync(StateHasChanged);
        }

        public async Task ApplyDeliver(DashboardFactorItemModel item)
        {
            if (Table.Factor.Id != Guid.Empty)
                await _unit.Orders.ApplyDeliver(item, Table.Factor.Id);
        }
        public async Task ChangeTable()
        {
            if (!TablesPanel.ChangeTable)
            {
                TablesPanel.EnableTableChange(Table.Id, Table.Factor);
                _notification.NotifySuccess("میز موردنظر را انتخاب کنید");
            }
            else
                TablesPanel.DisableTableChange();
        }

        public async Task EnableEdit()
        {
            ItemsSection.EnableEdit();
            await InvokeAsync(StateHasChanged);

        }

        public async Task UpdateOrder()
        {
            await EnableEdit();
            //try
            //{
            //   

            //}
            //catch (Exception e)
            //{

            //    throw;
            //}
        }
        public async Task DeleteOrder()
        {
            try
            {
                var res = await _dialogService.ShowMessageBox("تایید", "آیا اطمینان دارید", "تایید", null, "لغو");
                if (res.Value)
                {
                    await _unit.Orders.DeleteAsync(Table.Factor.Id);
                    _notification.NotifySuccess();
                    _navigation.NavigateTo("dashboard/factors");
                    await TablesPanel.ReloadTables();
                }
            }
            catch (Exception e)
            {
                _notification.Error(e.Message);
            }



        }
    }
}
