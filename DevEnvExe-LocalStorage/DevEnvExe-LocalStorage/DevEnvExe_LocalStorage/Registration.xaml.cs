using System;

using Xamarin.Forms;

namespace DevEnvExe_LocalStorage
{
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
        }
        async void Click_Reg(object sender, EventArgs e)
        {
         
          if (txtuserid.Text != "")
            {
                RegEntity fileexist = App.Database.GetItem(txtuserid.Text);
                if (fileexist == null)
                {
                    if (txtname.Text != "" && txtpassword.Text != "" && txtuserid.Text != "")
                    {
                        RegEntity OReg = new RegEntity();
                        OReg.Name = txtname.Text;
                        OReg.Username = txtuserid.Text;
                        OReg.Password = txtpassword.Text;
                        int i = App.Database.SaveItem(OReg);
                        if (i > 0)
                        {
                            await DisplayAlert("Registrtion", "Registrtion Success ... Login and Edit profile ", "OK");
                            await Navigation.PushModalAsync(new MainPage());
                        }
                        else
                        {
                            await DisplayAlert("Registrtion", "Registrtion Fail .. Please try again ", "OK");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Registrtion Failed", "username already exist .. Please try differnt user name ", "OK");
                    txtuserid.Text = "";
                    txtuserid.Focus();

                }
            }

        }
        async void Click_Login(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}

