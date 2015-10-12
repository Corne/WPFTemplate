using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac.Core;
using WPFTemplate.ViewModels;
using WPFTemplate.ViewModels.Navigation;

namespace WPFTemplate.Services.Navigation
{
    public class NavigationService : IDisposable, INavigationService
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly MainViewModel main;
        private readonly Stack<ContentScope> viewmodels;
        private readonly ContentScope.Create createContent;
        private readonly ContentScope.CreateByKey createContentByKey;

        public NavigationService(MainViewModel main,
            ContentScope.Create contentFactory,
            ContentScope.CreateByKey contentKeyFactory)
        {
            this.main = main;
            createContent = contentFactory;
            createContentByKey = contentKeyFactory;
            viewmodels = new Stack<ContentScope>();
        }

        /// <summary>
        /// Navigate to viewmodel of specific type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public async Task<T> Navigate<T>(params Parameter[] parameters) where T : class, IContentViewModel
        {
            log.Info($"Navigation to: {typeof(T).Name}");
            var content = createContent(typeof(T), parameters);
            viewmodels.Push(content);
            await main.Update(content.Content);
            return main.Content as T;
        }

        /// <summary>
        /// Navigate to viewmodel of specific type, based on a registered key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        public async Task<T> NavigateKeyed<T>(object key, params Parameter[] parameters) where T : class, IContentViewModel
        {
            log.Info($"Navigation to: {typeof(T).Name}, with key: {key}");
            var content = createContentByKey(typeof(T), key, parameters);
            viewmodels.Push(content);
            await main.Update(content.Content);
            return main.Content as T;
        }

        public async Task Back()
        {
            if (CanGoBack())
            {
                Pop();
                await main.Update(viewmodels.Peek().Content);
            }
        }

        public async Task Home()
        {
            while (CanGoBack())
            {
                Pop();
            }
            if (viewmodels.Count > 0)
            {
                await main.Update(viewmodels.Peek().Content);
            }
        }

        private void Pop()
        {
            var removed = viewmodels.Pop();
            removed.Dispose();
        }

        public void Dispose()
        {
            while (viewmodels.Count > 0)
            {
                Pop();
            }
        }

        public bool CanGoBack()
        {
            return viewmodels.Count > 1;
        }
    }
}