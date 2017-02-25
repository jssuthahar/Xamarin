using System;
using Xamarin.Forms;

namespace DevEnvExePages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        void MasterDetails_Click(object sender, EventArgs e)
        {
            App.Current.MainPage = new ExMasterDetailPagecs();

        }
        void TabbedPage_Click(object sender, EventArgs e)
        {
            App.Current.MainPage = new ExTabbedPage();

        }
        void Carousal_Click(object sender, EventArgs e)
        {
            App.Current.MainPage = new ExCarouselPage();

        }
    }
}
