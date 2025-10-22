using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DatabaseApp.Messages;
using DatabaseApp.Models;
using DatabaseApp.Services;
using System.Collections.ObjectModel;

namespace DatabaseApp.ViewModels
{
    public partial class UserListViewModel : ObservableObject
    {
        private readonly DatabaseService _dbService;

        [ObservableProperty]
        private ObservableCollection<User> users = new();

        public UserListViewModel(DatabaseService dbService)
        {
            _dbService = dbService;
            LoadUsersCommand.Execute(null);
        }

        [RelayCommand]
        public async Task LoadUsersAsync()
        {
            var list = await _dbService.GetUsersAsync();

            Users.Clear();
            foreach (var user in list)
            {
                if (!Users.Any(u => u.Id == user.Id))
                {
                    Users.Add(user);
                }
            }
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
            await Shell.Current.GoToAsync("///main-page", navParams);

            await LoadUsersAsync();
        }
    }
}
