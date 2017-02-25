using System;
using Xamarin.Forms;

namespace DevEnvExe_LocalStorage
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void Click_Reg(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Registration());
        }

        async void Click_Login(object sender, EventArgs e)
        {
            RegEntity userDetail = App.Database.GetItem(txtuserid.Text, txtpassword.Text);

            if (userDetail != null)
            {
                if (txtuserid.Text != userDetail.Username && txtpassword.Text != userDetail.Password)
                {
                    await DisplayAlert("Login", "Login failed .. Please try again ", "OK");
                }
                else
                {
                    await DisplayAlert("Registrtion", "Login Success ... Now Edit your profile ", "OK");
                    await Navigation.PushModalAsync(new Home(txtuserid.Text));
                }
            }
            else
            {
                await DisplayAlert("Login", "Login failed .. Please try again ", "OK");
            }


        }

    }
}
