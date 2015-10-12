using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFTemplate.ViewModels.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace WPFTemplate.ViewModels.Example
{
    public class KeyedViewModel : ViewModelBase, IContentViewModel
    {

        private readonly IUpdate updater;

        public KeyedViewModel(IUpdate updater, HeaderViewModel header)
        {
            this.updater = updater;
            header.Title = "Keyed example";
            Header = header;
        }

        private int _value;
        public int Value
        {
            get { return _value; }
            set { Set(ref _value, value); }
        }

        public ICommand Update
        {
            get { return new RelayCommand(() => Value = updater.Update()); }
        }

        public LoadingViewModel LoadMessage { get { return LoadingViewModel.Default; } }

        public IHeaderViewModel Header { get; }

        public Task OnClose()
        {
            return Task.FromResult(0);
        }

        public Task OnNavigate()
        {
            return Task.FromResult(0);
        }
    }

    public enum UpdateType
    {
        Increment,
        Decrement
    }

    public interface IUpdate
    {
        int Update();
    }

    public class Incrementer : IUpdate
    {
        private int value;

        public Incrementer(int startValue)
        {
            value = startValue;
        }


        public int Update()
        {
            return ++value;
        }
    }

    public class Decrementer : IUpdate
    {
        private int value;

        public Decrementer(int startValue)
        {
            value = startValue;
        }

        public int Update()
        {
            return --value;
        }
    }
}
