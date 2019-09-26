using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ReactiveUIXamarin.ViewModel;
using ReactiveUI.XamForms;
using System.Reactive.Disposables;

namespace ReactiveUIXamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer

    public partial class MainPage : ReactiveContentPage<MainPageViewModel>
    {
        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainPageViewModel();

            // Setup the bindings.
            // Note: We have to use WhenActivated here, since we need to dispose the
            // bindings on XAML-based platforms, or else the bindings leak memory.
            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, x => x.UserName, x => x.Username.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.Password, x => x.Password.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.Address, x => x.Address.Text)
                   .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.Phone, x => x.Phone.Text)
                   .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.RegisterCommand, x => x.Register)
                  
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.Result, x => x.Result.Text)
                   .DisposeWith(disposable);
            });
        }
    }
}
