using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace WPFTemplate.ViewModels
{
    public class ViewModelLocator : IDisposable
    {
        private readonly IContainer container;

        public ViewModelLocator()
        {
            var builder = new ApplicationBuilder();
            container = builder.Build();
            MainViewModel = container.Resolve<MainViewModel>();
        }


        public MainViewModel MainViewModel { get; }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}
