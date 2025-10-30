using DatabaseApp.ViewModels;

namespace DatabaseApp;

public partial class RecentUsersPage : ContentPage
{

    public RecentUsersPage(RecentUsersViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}