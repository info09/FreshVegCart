using FreshVegCart.Shared.Dto;

namespace FreshVegCart.Services
{
    public class AuthState
    {
        private const string UserData = "user";
        public string RedirectUrlFromLogin { get; set; } = "/";
        public LoggedInUser? User { get; set; }
        public bool IsLoggedIn { get; set; }

        public AuthState()
        {
            var loggedUser = MauiInterop.GetFromStorage<LoggedInUser>(UserData, null);
            if (loggedUser != null)
            {
                User = loggedUser;
                IsLoggedIn = true;
            }
        }

        public void Login(LoggedInUser user)
        {
            MauiInterop.SaveStorage(UserData, user);
            User = user;
            IsLoggedIn = true;
        }

        public void Logout()
        {
            User = null;
            IsLoggedIn = false;
            MauiInterop.RemoveFromStorage(UserData);
        }
    }
}
