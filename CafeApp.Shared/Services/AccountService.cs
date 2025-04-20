using CafeApp.Business.Helpers.Dtos;
using CafeApp.Shared.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CafeApp.Shared.Services
{
    public class AccountService : IAccountService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "user";

        public UserDto User { get; private set; }

        public AccountService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        )
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<UserDto>(_userKey);
        }

        public async Task Login(Login model)
        {
            User = await _httpService.Post<UserDto>("/users/authenticate", model);
            await _localStorageService.SetItem(_userKey, User);
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem(_userKey);
            _navigationManager.NavigateTo("account/login");
        }

       


        public async Task<UserDto> GetById(string id)
        {
            return await _httpService.Get<UserDto>($"/users/{id}");
        }

    }
}
