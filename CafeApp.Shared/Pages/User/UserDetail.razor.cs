using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components.Forms;

namespace CafeApp.Shared.Pages.User
{
    public partial class UserDetail
    {
        private UserDto value = new UserDto();
        private string _password;

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                Title = "ویرایش دسته بندی";
                value = await _unit.Users.GetById(Guid.Parse(Id));
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
                UpdateUserParameter parameter = new UpdateUserParameter()
                {
                    Id = value.Id,
                    PhoneNumber = value.PhoneNumber,
                    Birthday = value.Birthday,
                    FirstName = value.FirstName,
                    LastName = value.LastName,
                    Gender = value.Gender,
                    Image = value.Image,
                    Password=_password,
                    Address = value.Address,
                    Username=value.Username,
                    Email=value.Email,
                    IsActive=value.IsActive
                };
                await _unit.Users.UpdateAsync(parameter);
            }
            else
            {
                CreateUserParameter parameter = new CreateUserParameter
                {
                    PhoneNumber = value.PhoneNumber,
                    Birthday = value.Birthday,
                    FirstName = value.FirstName,
                    LastName = value.LastName,
                    Gender = value.Gender,
                    Image = value.Image,
                    Password = _password,
                    Address = value.Address,
                    Username = value.Username,
                    Email = value.Email,
                    IsActive=value.IsActive
                    
                };
                await _unit.Users.CreateAsync(parameter);
            }
        }
    }
}
