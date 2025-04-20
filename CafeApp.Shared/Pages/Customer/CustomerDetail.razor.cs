using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components.Forms;

namespace CafeApp.Shared.Pages.Customer
{
    public partial class CustomerDetail
    {
        private CustomerDto value = new CustomerDto();

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                Title = "ویرایش دسته بندی";
                value = await _unit.Customers.GetById(Guid.Parse(Id));
            }
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
            if (!string.IsNullOrEmpty(Id))
            {
                UpdateCustomerParameter parameter = new UpdateCustomerParameter()
                {
                    Id = value.Id,
                    PhoneNumber = value.PhoneNumber,
                    Birthday = value.Birthday,
                    FirstName = value.FirstName,
                    LastName = value.LastName,
                    Gender = value.Gender,
                    Image = value.Image,
                    IsActive=value.IsActive
                };
                await _unit.Customers.UpdateAsync(parameter);
            }
            else
            {
                CreateCustomerParameter parameter = new CreateCustomerParameter
                {
                    PhoneNumber = value.PhoneNumber,
                    Birthday = value.Birthday,
                    FirstName = value.FirstName,
                    LastName = value.LastName,
                    Gender = value.Gender,
                    Image = value.Image,
                    Address = value.Address,
                    IsActive=value.IsActive
                    
                };
                await _unit.Customers.CreateAsync(parameter);
            }
        }
    }
}
