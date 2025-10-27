namespace DatabaseApp
{
    public partial class AppShell : Shell
    {
        public AppShell(MainPage mainPage, UserListPage usersListPage)
        {
            InitializeComponent();

            Routing.RegisterRoute("main-page", typeof(MainPage));
            Routing.RegisterRoute("users", typeof(UserListPage));

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
