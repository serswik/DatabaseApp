using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DatabaseApp.Interfaces;
using DatabaseApp.Models;
using DatabaseApp.Services;
using System.Collections.ObjectModel;

namespace DatabaseApp.ViewModels
{
    public partial class RecentUsersViewModel : ObservableObject
    {
        private readonly DatabaseService _dbService;
        private readonly INavigationService _navService;

        [ObservableProperty]
        private ObservableCollection<User> users = new();

        public RecentUsersViewModel(DatabaseService dbService, INavigationService navService)
        {
            _dbService = dbService;
            _navService = navService;
            LoadRecentUsersCommand.Execute(null);
        }

        [RelayCommand]
        public async Task LoadRecentUsersAsync()
        {
            var recent = await _dbService.GetRecentUsersAsync();
            Users = new ObservableCollection<User>(recent);
        }

        [RelayCommand]
        public async Task GoBack()
        {
            _navService.GoBackAsync();
        }
    }
}
