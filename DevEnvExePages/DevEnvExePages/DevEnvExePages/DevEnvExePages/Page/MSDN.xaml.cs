using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DevEnvExePages
{
    public partial class MSDN : ContentPage
    {
        public MSDN()
        {
            InitializeComponent();
            Title = "MSDN Profile";

         
        }
        public void ss()
        {
            Application.Current.Properties["id1"] = "jssuthahar@gmail.com";
        }
    }
}
