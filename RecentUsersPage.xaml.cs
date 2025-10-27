using DatabaseApp.ViewModels;

namespace DatabaseApp;

public partial class RecentUsersPage : ContentPage
{
	private readonly RecentUsersViewModel _vm;

    public RecentUsersPage(RecentUsersViewModel vm)
	{
		InitializeComponent();
		BindingContext = _vm = vm;
	}

	protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.LoadRecentUsersAsync();
    }
}