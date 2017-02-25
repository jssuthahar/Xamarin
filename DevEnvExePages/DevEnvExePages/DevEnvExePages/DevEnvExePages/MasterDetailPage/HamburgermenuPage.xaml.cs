using System.Collections.Generic;
using Xamarin.Forms;
namespace DevEnvExePages
{
    public partial class HamburgermenuPage : ContentPage
    {
        public ListView ListView { get { return lstmenu; } }
        public HamburgermenuPage()
        {
            InitializeComponent();
            GetMenuItem();
        }
       public void GetMenuItem()
        {
            var hamburgermenuItems = new List<Hamburgermenu>() { new Hamburgermenu("MSDN","",typeof(MSDN)),
                new Hamburgermenu("C# Corner","", typeof(CSharp)),
                new Hamburgermenu("Blogs","", typeof(Blogs)),
                new Hamburgermenu("About Me","", typeof(AboutMe))
            };
            lstmenu.ItemsSource = hamburgermenuItems;
        }
    }
}
