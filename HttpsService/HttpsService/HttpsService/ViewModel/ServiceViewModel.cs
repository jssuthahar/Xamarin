using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HttpsService
{
    public class ServiceViewModel : BaseViewModel
    {
        string _data;
        public string Data
        {
            get { return _data; }
            set { base.SetProperty<string>(ref _data, value, "Data", null); }
        }
        //   public ICommand Refersh { private set; get; }
        ServiceHelper _dataService;

        public ServiceViewModel()
        {

            _dataService = new ServiceHelper();
             
    }

        public async Task GetAsync()
        {
            Data = "Loading...";
            // Artificial delay
            await Task.Delay(1000);
            Data = await _dataService.GetDataAsync();

        }
    }
    }


