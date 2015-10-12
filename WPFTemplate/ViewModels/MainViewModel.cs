using System.Threading.Tasks;
using System.Windows.Input;
using WPFTemplate.Services.Navigation;
using WPFTemplate.ViewModels.Navigation;
using WPFTemplate.ViewModels.Settings;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace WPFTemplate.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel(SettingsViewModel settingsViewModel)
        {
            Settings = settingsViewModel;
        }

        public SettingsViewModel Settings { get; }

        private IContentViewModel _content;
        public IContentViewModel Content
        {
            get { return _content; }
        }

        public async Task Update(IContentViewModel value)
        {
            var current = _content;
            if (Set(ref _content, value, nameof(Content)))
            {
                if (current != null)
                {
                    await current.OnClose();
                }
                await _content.OnNavigate();
            }
        }

    }
}
