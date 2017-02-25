using System;
using Xamarin.Forms;

namespace DevEnvExePages
{
    public partial class ExMasterDetailPagecs : MasterDetailPage
    {
        public ExMasterDetailPagecs()
        {
            InitializeComponent();
            hamburgermenuitem.ListView.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Hamburgermenu;

            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.Navigation));
                
                hamburgermenuitem.ListView.SelectedItem = null;
                IsPresented = false;
                
            }
        }
    }
}
