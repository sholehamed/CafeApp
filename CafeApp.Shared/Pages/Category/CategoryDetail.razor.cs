using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components.Forms;

namespace CafeApp.Shared.Pages.Category
{
    public partial class CategoryDetail
    {
        private ProductCategoryDto value = new ProductCategoryDto();


        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                Title = "ویرایش دسته بندی";
                value = await _unit.Categories.GetById(Guid.Parse(Id));
            }
        }

        public void Cancel()
        {
            _navigation.NavigateTo("/dashboard/categories");
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
                UpdateProductCategoryParameter parameter = new UpdateProductCategoryParameter
                    (
                    value.Id, value.Order, value.Title, value.IsActive, value.Image, value.Description
                    );
                await _unit.Categories.UpdateAsync(parameter);
                _notification.NotifySuccess();
            }
            else
            {
                CreateProductCategoryParameter parameter = new CreateProductCategoryParameter
                {
                    Description = value.Description,
                    Image = value.Image,
                    IsActive = value.IsActive,
                    Order = value.Order,
                    Title = value.Title
                };
                await _unit.Categories.CreateAsync(parameter);
                _notification.NotifySuccess();
            }
            Cancel();
        }
    }
}
