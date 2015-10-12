using System.Threading.Tasks;

namespace WPFTemplate.ViewModels.Navigation
{
    public interface IContentViewModel
    {
        IHeaderViewModel Header { get; }
        LoadingViewModel LoadMessage { get; }
        Task OnNavigate();

        Task OnClose();
    }
}