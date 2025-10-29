using DatabaseApp.ViewModels;

namespace DatabaseApp;

public partial class UserListPage : ContentPage
{
	private readonly UserListViewModel _vm;
	public UserListPage(UserListViewModel vm)
	{
		InitializeComponent();
		BindingContext = _vm = vm;
    }

	protected override async void OnAppearing()
	{
		base.OnAppearing();
        await _vm.LoadUsersAsync();
    }
}
