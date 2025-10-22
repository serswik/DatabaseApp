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
        private ObservableCollection<User> users = new ObservableCollection<User>();

        public UserListViewModel(DatabaseService dbService)
        {
            _dbService = dbService;
            LoadUsersCommand.Execute(null);
            WeakReferenceMessenger.Default.Register<UserAddedMessage>(this, (r, m) =>
            {
                Users.Add(m.User);
            });
        }

        [RelayCommand]
        public async Task LoadUsersAsync()
        {
            var list = await _dbService.GetUsersAsync();

            foreach (var user in list)
            {
                if (!Users.Any(u => u.Id == user.Id))
                {
                    Users.Add(user);
                }
            }
        }
    }
}
