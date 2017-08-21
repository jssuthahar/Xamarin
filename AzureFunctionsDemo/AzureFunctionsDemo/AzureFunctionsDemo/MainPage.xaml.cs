using System;

using Xamarin.Forms;

namespace AzureFunctionsDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void OnButtonClicked(object sender, EventArgs args)
        {
            //Show Wait indicator
            waitindicator.IsVisible = true;
            waitindicator.IsRunning = true;
            //Calling Azure Function
             AzureFunctionHelper oazurehelper = new AzureFunctionHelper();
            var value = await oazurehelper.GetAsync<string>(txtname.Text);
            //print azure fucntion return value
            lblname.Text = value.ToString();
            //Disable wait Indicator after loading output 
            waitindicator.IsVisible = false;
            waitindicator.IsRunning = false;

        }
    }
}
