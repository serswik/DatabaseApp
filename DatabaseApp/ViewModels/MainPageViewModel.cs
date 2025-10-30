using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DatabaseApp.Interfaces;
using DatabaseApp.Constants;
using DatabaseApp.Models;
using DatabaseApp.Services;
using DatabaseApp.Resources.Locales;

namespace DatabaseApp.ViewModels
{
    [QueryProperty(nameof(UserToEdit), "UserToEdit")]
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly DatabaseService _dbService;
        private readonly INavigationService _navService;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private int age;

        [ObservableProperty]
        private string statusMessage;

        [ObservableProperty]
        private User userToEdit;

        public MainPageViewModel(DatabaseService dbService, INavigationService navService)
        {
            _dbService = dbService;
            _navService = navService;
        }

        public string ShowUsersButtonText => AppResources.show_users_button;

        partial void OnUserToEditChanged(User value)
        {
            if (value != null)
            {
                Name = value.Name;
                Age = value.Age;
            }
        }

        [RelayCommand]
        private async Task SaveAsync()
        {
            if (!ValidateInput()) return;

            if (UserToEdit == null)
            {
                await _dbService.AddUserAsync(new User
                {
                    Name = Name,
                    Age = Age
                });
                StatusMessage = $"User '{Name}' added successfully";
            }
            else
            {
                UserToEdit.Name = Name;
                UserToEdit.Age = Age;
                await _dbService.UpdateUserAsync(UserToEdit);
                StatusMessage = $"User '{Name}' updated successfully";
            }

            ClearInputs();
        }

        [RelayCommand]
        public async Task ShowRecentUsersAsync()
        {
            await _navService.GoToAsync(AppRoutes.RecentUsersPage);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                StatusMessage = "Enter name";
                return false;
            }

            if (Age <= 0 || Age >= 105)
            {
                StatusMessage = "Enter valid age";
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            Name = string.Empty;
            Age = 0;
        }
    }
}
