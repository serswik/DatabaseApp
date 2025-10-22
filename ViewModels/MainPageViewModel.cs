using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DatabaseApp.Models;
using DatabaseApp.Services;

namespace DatabaseApp.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly DatabaseService _dbService;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private int age;

        [ObservableProperty]
        private string statusMessage;

        public MainPageViewModel(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        [RelayCommand]
        private async Task SaveAsync()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                StatusMessage = "Please enter a name";
                return;
            }

            if (Age <= 0 || Age >= 105)
            {
                StatusMessage = "Please enter a valid age";
                return;
            }

            await _dbService.AddUserAsync(new User { Name = Name, Age = Age });
            StatusMessage = $"User '{Name}' added successfully";

            Name = string.Empty;
            Age = 0;
        }
    }
}
