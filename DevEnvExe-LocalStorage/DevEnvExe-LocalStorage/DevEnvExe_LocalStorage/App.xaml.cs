
using Xamarin.Forms;

namespace DevEnvExe_LocalStorage
{
    public partial class App : Application
    {
        static SqlHelper database;
        public App()
        {
            InitializeComponent();

            MainPage = new DevEnvExe_LocalStorage.MainPage();
        }

        public static SqlHelper Database
        {
            get
            {
                if (database == null)
                {
                    database = new SqlHelper();
                }
                return database;
            }
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
