using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DevEnvExePages
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new DevEnvExePages.ExCarouselPage();
            // MainPage = new DevEnvExePages.ExMasterDetailPagecs();
            //MainPage = new DevEnvExePages.ExTabbedPage();
            MainPage = new DevEnvExePages.MainPage();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
