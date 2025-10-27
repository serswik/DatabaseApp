using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DatabaseApp.Models;
using DatabaseApp.Services;
using System.Collections.ObjectModel;
using DatabaseApp.Interfaces;
using DatabaseApp.Constants;

namespace DatabaseApp.ViewModels
{
    public partial class UserListViewModel : ObservableObject
    {
        private readonly DatabaseService _dbService;
        private readonly INavigationService _navService;

        [ObservableProperty]
        private ObservableCollection<User> users = new();

        [ObservableProperty]
        private string filterName;

        [ObservableProperty]
        private int? filterMinAge;

        [ObservableProperty]
        private int? filterMaxAge;

        public UserListViewModel(DatabaseService dbService, INavigationService navService)
        {
            _dbService = dbService;
            _navService = navService;
            LoadUsersCommand.Execute(null);
        }

        [RelayCommand]
        public async Task LoadUsersAsync()
        {
            var list = await _dbService.GetUsersAsync();

            Users = new ObservableCollection<User>(list);
         }

        [RelayCommand]
        public async Task DeleteUserAsync(User user)
        {
            bool confirm = await Shell.Current.DisplayAlert(
                "Confirm Delete",
                $"Are you sure you want to delete {user.Name}?",
                "Yes", "No");

            if (!confirm) return;

            await _dbService.DeleteUserAsync(user);
            Users.Remove(user);
        }

        [RelayCommand]
        public async Task EditUserAsync(User user)
        {
            var navParams = new Dictionary<string, object>
            {
                { "UserToEdit", user }
            };

            await _navService.GoToAsync(AppRoutes.MainPage, navParams);

            await LoadUsersAsync();
        }

        [RelayCommand]
        public async Task ApplyFilterAsync()
        {
            var filtered = await _dbService.FilterUsersAsync(FilterName, FilterMinAge, FilterMaxAge);
            Users = new ObservableCollection<User>(filtered);
        }

        [RelayCommand]
        public async Task ClearFilterAsync()
        {
            FilterName = string.Empty;
            FilterMinAge = null;
            FilterMaxAge = null;

            await LoadUsersAsync();
        }
    }
}
