using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTemplate.ViewModels.Navigation
{

    public interface IHeaderViewModel
    {
    }

    /// <summary>
    /// Empty Header Implementation
    /// When set as ContentViewModel.Header, the header will be hidden.
    /// </summary>
    public class EmptyHeaderViewModel : IHeaderViewModel
    {
        public static IHeaderViewModel Instance = new EmptyHeaderViewModel();

        private EmptyHeaderViewModel() { }

    }

}
