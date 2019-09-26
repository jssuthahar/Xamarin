using System;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace ReactiveUIXamarin.ViewModel
{
    public class MainPageViewModel: ReactiveObject
    {
        private string _result;
        public string Result
        {
            get => _result;
            set => this.RaiseAndSetIfChanged(ref _result, value);
        }
        private string _username;
        public string UserName
        {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }
        private string _password;
        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }
        private string _address;
        public string Address
        {
            get => _address;
            set => this.RaiseAndSetIfChanged(ref _address, value);
        }
        private string _phone;
        public string Phone
        {
            get => _phone;
            set => this.RaiseAndSetIfChanged(ref _phone, value);
        }
        public ReactiveCommand<Unit, Unit> RegisterCommand { get; }

        public MainPageViewModel()
        {
            RegisterCommand = ReactiveCommand
                .CreateFromObservable(ExecuteRegisterCommand);
        }

        private IObservable<Unit> ExecuteRegisterCommand()
        {
            Result = "Hello" + UserName + " Registration Success";
            return Observable.Return(Unit.Default);
        }
    }
  
}

