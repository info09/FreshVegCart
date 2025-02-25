using CommunityToolkit.Maui.Alerts;

namespace FreshVegCart.Services
{
    public static class MauiInterop
    {
        private static readonly Page _page = App.Current!.Windows[0].Page!;
        public static async Task ToastAsync(string message)
        {
            await Toast.Make(message).Show();
        }

        public static async Task AlertAsync(string title, string message) => await _page.DisplayAlert(title, message, "OK");

        public static async Task<bool> ConfirmAsync(string title, string message) => await _page.DisplayAlert(title, message, "OK", "Cancel");
    }
}
