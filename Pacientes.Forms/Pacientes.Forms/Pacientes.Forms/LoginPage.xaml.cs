using Pacientes.Forms.Database;
using Pacientes.Forms.Entities;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Pacientes.Forms
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        private bool AreCredentialsCorrect(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Username))
                return false;

            UserDatabase db = new UserDatabase();
            List<User> result = db.ValidateUser(user.Username.ToLower(), user.Password);

            if (result.Count == 0)
                return false;

            return true;
        }
    }
}