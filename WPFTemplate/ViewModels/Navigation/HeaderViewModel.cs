using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFTemplate.Services.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace WPFTemplate.ViewModels.Navigation
{
    public class HeaderViewModel : ViewModelBase, IHeaderViewModel
    {

        private readonly INavigationService navigationService;

        public HeaderViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            GoBack = new RelayCommand(async () => await this.navigationService.Back(), this.navigationService.CanGoBack);
        }

        public HeaderViewModel(INavigationService navigationService, string title)
            : this(navigationService)
        {
            Title = title;
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { Set(ref _title, value); }
        }

        public ICommand GoBack { get; }

        public bool CanGoBack { get { return navigationService.CanGoBack(); } }
    }
}
