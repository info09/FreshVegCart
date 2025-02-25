using CommunityToolkit.Maui.Alerts;
using System.Text.Json;

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

        public static void SaveStorage<TValue>(string key, TValue value)
        {
            var json = JsonSerializer.Serialize(value);
            Preferences.Default.Set(key, json);
        }

        public static TValue GetFromStorage<TValue>(string key, TValue defaultValue)
        {
            if (Preferences.Default.ContainsKey(key))
            {
                var serialize = Preferences.Default.Get<string?>(key, null);
                if (!string.IsNullOrWhiteSpace(serialize))
                {
                    return JsonSerializer.Deserialize<TValue>(serialize)!;
                }
            }
            return defaultValue;
        }

        public static void RemoveFromStorage(string key) => Preferences.Default.Remove(key);
    }
}
