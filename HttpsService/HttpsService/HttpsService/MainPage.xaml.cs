using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HttpsService
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        ServiceViewModel ViewModel => BindingContext as ServiceViewModel;
        public MainPage()
        {
            InitializeComponent();
            FetchData();
        }

        void LoadData(object sender, System.EventArgs e)
        {
            FetchData();
        }

        async void FetchData()
        {
            await ViewModel.GetAsync();
        }
    }
}
