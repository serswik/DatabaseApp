using DatabaseApp.Interfaces;
namespace DatabaseApp.Services
{
    public class ShellNavigationService : INavigationService
    {
        public async Task GoToAsync(string route, IDictionary<string, object>? parameters = null)
        {
            if (parameters != null)
            {
                await Shell.Current.GoToAsync(route, parameters);
            }
            else
            {
                await Shell.Current.GoToAsync(route);
            }
        }

        public async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
