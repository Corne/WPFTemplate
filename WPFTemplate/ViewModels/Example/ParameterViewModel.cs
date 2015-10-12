using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTemplate.ViewModels.Navigation;

namespace WPFTemplate.ViewModels.Example
{
    public class ParameterViewModel : IContentViewModel
    {

        public ParameterViewModel(HeaderViewModel header, int parameter)
        {
            header.Title = "Parameter example";
            Header = header;
            Parameter = parameter;
        }

        public IHeaderViewModel Header { get; }

        public LoadingViewModel LoadMessage { get { return LoadingViewModel.Default; } }

        public int Parameter { get; }

        public Task OnClose()
        {
            return Task.FromResult(0);
        }

        public Task OnNavigate()
        {
            return Task.FromResult(0);
        }
    }
}
