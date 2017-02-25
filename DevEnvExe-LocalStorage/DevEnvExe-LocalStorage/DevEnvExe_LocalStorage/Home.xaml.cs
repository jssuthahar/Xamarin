using System;

using Xamarin.Forms;

namespace DevEnvExe_LocalStorage
{
    public partial class Home : ContentPage
    {
        public Home(string userId)
        {
            InitializeComponent();
            GetUserDetail(userId);


        }
        RegEntity userDetail;
        public void GetUserDetail(string userId)
        {
            userDetail = App.Database.GetItem(userId);
            txtname.Text = userDetail.Name;
            txtuserid.Text = userDetail.Username;
            txtpassword.Text = userDetail.Password;
        }
        async void Click_UpdateProfile(object sender, EventArgs e)
        {
            int i = -1;
            if (txtname.Text != "" && txtpassword.Text != "" && txtuserid.Text != "")
            {
                userDetail.Name = txtname.Text;
                userDetail.Username = txtuserid.Text;
                userDetail.Password = txtpassword.Text;
                 i = App.Database.SaveItem(userDetail);
            }


            if (i < 0)
            {
                await DisplayAlert("Update Profile", "Update Fail .. Please try again ", "OK");
            }
            else
            {
                await DisplayAlert("Update Profile", "Profile update Success . ", "OK");
            }
        }
        
        async void Click_Login(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}
