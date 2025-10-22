using DatabaseApp.ViewModels;

namespace DatabaseApp;

public partial class UserListPage : ContentPage
{
	public UserListPage(UserListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}