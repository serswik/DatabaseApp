using DatabaseApp.Constants;

namespace DatabaseApp
{
    public partial class AppShell : Shell
    {
        public AppShell(MainPage mainPage, UserListPage usersListPage)
        {
            InitializeComponent();

            Routing.RegisterRoute(AppRoutes.MainPage, typeof(MainPage));
            Routing.RegisterRoute(AppRoutes.UsersListPage, typeof(UserListPage));
            Routing.RegisterRoute(AppRoutes.RecentUsersPage, typeof(RecentUsersPage));

            Items.Add(new TabBar
            {
                Items =
                {
                    new ShellContent 
                    { 
                        Title = "Add User", 
                        Content = mainPage,
                        Route = "main-page"
                    },
                    new ShellContent 
                    { 
                        Title = "Users List", 
                        Content = usersListPage,
                        Route = "users"
                    }
                }
            });
        }
    }
}
