using System.Threading.Tasks;
using Autofac.Core;
using WPFTemplate.ViewModels.Navigation;

namespace WPFTemplate.Services.Navigation
{
    public interface INavigationService
    {
        /// <summary>
        /// return to the previous viewmodel
        /// </summary>
        /// <returns></returns>
        Task Back();

        /// <summary>
        /// Checks if the service is able to return a previous viewmodel
        /// </summary>
        /// <returns>true when more then 1 viewmodel is on the stack, else false</returns>
        bool CanGoBack();

        /// <summary>
        /// return to the first active viewmodel
        /// </summary>
        /// <returns></returns>
        Task Home();

        /// <summary>
        /// Navigate to a viewmodel
        /// </summary>
        /// <typeparam name="T">Viewmodel type, where will be navigated to</typeparam>
        /// <param name="parameters">possible parameters needed to initialize the viewmodel (ex: a selected item)</param>
        /// <returns>a task that will return the initialized viewmodel</returns>
        Task<T> Navigate<T>(params Parameter[] parameters) where T : class, IContentViewModel;

        /// <summary>
        /// Navigate to a viewmodel based on a registered key (ex: enum value)
        /// </summary>
        /// <typeparam name="T">Viewmodel type, where will be navigated to</typeparam>
        /// <param name="key">Key where viewmodel is registered by</param>
        /// <param name="parameters">possible parameters needed to initialize the viewmodel (ex: a selected item)</param>
        /// <returns>a task that will return the initialized viewmodel</returns>
        Task<T> NavigateKeyed<T>(object key, params Parameter[] parameters) where T : class, IContentViewModel;
    }
}