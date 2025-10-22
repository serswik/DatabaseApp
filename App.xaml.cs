using Microsoft.Maui.Controls;

namespace DatabaseApp
{
    public partial class App : Application
    {
        public App(AppShell shell)
        {
            InitializeComponent();

            MainPage = shell;
        }
    }
}
