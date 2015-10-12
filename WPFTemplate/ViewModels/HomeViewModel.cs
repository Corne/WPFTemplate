using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using WPFTemplate.Services.Navigation;
using WPFTemplate.ViewModels.Example;
using WPFTemplate.ViewModels.Navigation;
using GalaSoft.MvvmLight.CommandWpf;

namespace WPFTemplate.ViewModels
{
    public class HomeViewModel : IContentViewModel
    {
        private readonly INavigationService navigationService;

        public HomeViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            Parameters = new[] { 1, 2, 3, 4, 5 }.Select(i => new SimpleParameterViewModel(i, this.navigationService)).ToArray();
        }

        public string Title { get { return $"Welcome {Environment.UserName}!"; } }

        public LoadingViewModel LoadMessage { get { return LoadingViewModel.Default; } }

        public Task OnClose()
        {
            return Task.FromResult(0);
        }

        public Task OnNavigate()
        {
            return Task.FromResult(0);
        }

        public ICommand NavigateExample { get { return new RelayCommand(() => navigationService.Navigate<LoadingExampleViewModel>()); } }

        public ICommand NavigateIncrement { get { return new RelayCommand(() => navigationService.NavigateKeyed<KeyedViewModel>(UpdateType.Increment)); } }
        public ICommand NavigateDecrement { get { return new RelayCommand(() => navigationService.NavigateKeyed<KeyedViewModel>(UpdateType.Decrement)); } }

        public IEnumerable<SimpleParameterViewModel> Parameters { get; }

        public IHeaderViewModel Header { get { return EmptyHeaderViewModel.Instance; } }
    }

    public class SimpleParameterViewModel
    {

        private readonly INavigationService navigationService;
        public SimpleParameterViewModel(int parameter, INavigationService navigationService)
        {
            Parameter = parameter;
            this.navigationService = navigationService;
        }

        public int Parameter { get; }
        public ICommand Open
        {
            get
            {
                return new RelayCommand(() => navigationService.Navigate<ParameterViewModel>(new TypedParameter(typeof(int), Parameter)));
            }
        }
    }
}
