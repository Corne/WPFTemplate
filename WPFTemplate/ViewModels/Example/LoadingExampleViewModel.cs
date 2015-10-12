using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFTemplate.Services.Navigation;
using WPFTemplate.ViewModels.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace WPFTemplate.ViewModels.Example
{
    public class LoadingExampleViewModel : ViewModelBase, IContentViewModel
    {

        public LoadingExampleViewModel(HeaderViewModel header)
        {
            header.Title = "Loading example";
            Header = header;
        }


        private LoadingViewModel _loadMessage = LoadingViewModel.Default;
        public LoadingViewModel LoadMessage
        {
            get { return _loadMessage; }
            set { Set(ref _loadMessage, value); }
        }

        public IHeaderViewModel Header { get; }

        public Task OnClose()
        {
            return Task.FromResult(0);
        }

        //todo build in cancellation token
        public async Task OnNavigate()
        {
            Text.Clear();
            LoadMessage = new LoadingViewModel("Load message example", "10 Second delay");

            Text.Add("Often you need to execute a process that takes some time to complete.");
            await Task.Delay(1000);
            Text.Add("For example: Database or Hardware calls.");
            await Task.Delay(1000);
            Text.Add("During this period, you want to show some feedback to the user.");
            await Task.Delay(1000);
            Text.Add("Thats why we show a loading bar/message on the left.");
            await Task.Delay(1000);
            Text.Add("It's important to note, that we don't block the UI.");
            await Task.Delay(1000);
            Text.Add("So the user can use, all available functionality.");
            await Task.Delay(1000);
            Text.Add("For example our back button is clickable during this period.");
            await Task.Delay(4000);
            LoadMessage.IsLoading = false;
        }

        public ObservableCollection<string> Text { get; } = new ObservableCollection<string>();
    }
}
