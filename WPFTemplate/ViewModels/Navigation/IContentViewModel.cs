using System.Threading.Tasks;

namespace WPFTemplate.ViewModels.Navigation
{
    public interface IContentViewModel
    {
        /// <summary>
        /// Header data, which gives the data about the header
        /// If you don't want a header on the current view, use the EmptyHeaderViewModel.Instance.
        /// If you want a simple Title Header, with navigation, use the default HeaderViewModel
        /// For custom header, create your own IHeaderViewModel implemention
        /// Current templates are defined in /Tempates/Headers.xaml
        /// </summary>
        IHeaderViewModel Header { get; }

        /// <summary>
        /// When the LoadMessage is active (not null and IsLoading is true), 
        /// the view will notify the user it is currently busy
        /// </summary>
        LoadingViewModel LoadMessage { get; }

        /// <summary>
        /// Will be called when navigated to this ContentViewModel
        /// You can load necessary data during this period
        /// If its a long running operation, it's good to set an active LoadMessage
        /// </summary>
        /// <returns>Task that will complete when navigation is completed</returns>
        Task OnNavigate();

        /// <summary>
        /// Will be called when this ContentViewModel will be closed.
        /// You can clean up some objects / set tasks inactive on this call,
        /// because the viewmodel will be kept alive on the navigationstack
        /// </summary>
        /// <returns></returns>
        Task OnClose();
    }
}