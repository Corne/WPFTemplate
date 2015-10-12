using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using WPFTemplate.ViewModels.Navigation;

namespace WPFTemplate.Services.Navigation
{
    public class ContentScope : IDisposable
    {
        private readonly ILifetimeScope scope;

        public delegate ContentScope Create(Type type, params Parameter[] parameters);
        public delegate ContentScope CreateByKey(Type type, object key, params Parameter[] parameters);

        public ContentScope(Type type, ILifetimeScope parentScope, params Parameter[] parameters)
        {
            scope = parentScope.BeginLifetimeScope();
            Content = scope.Resolve(type, parameters) as IContentViewModel;
        }

        public ContentScope(Type type, object key, ILifetimeScope parentScope, params Parameter[] parameters)
        {
            scope = parentScope.BeginLifetimeScope();
            Content = scope.ResolveKeyed(key, type, parameters) as IContentViewModel;
        }

        public IContentViewModel Content { get; private set; }

        public void Dispose()
        {
            //make sure to set content to null, else the object itself will not be cleaned up
            Content = null;
            scope.Dispose();
        }
    }
}