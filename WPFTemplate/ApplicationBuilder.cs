using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using WPFTemplate.Services.Navigation;
using WPFTemplate.Services.Themes;
using WPFTemplate.ViewModels;
using WPFTemplate.ViewModels.Example;
using WPFTemplate.ViewModels.Navigation;
using WPFTemplate.ViewModels.Settings;

namespace WPFTemplate
{
    public class ApplicationBuilder
    {

        private readonly ContainerBuilder builder;



        public ApplicationBuilder()
        {
            builder = new ContainerBuilder();

            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("ViewModel"))
                .AsSelf();

            //navigation
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<ContentScope>();

            builder.RegisterType<MainViewModel>().SingleInstance().OnActivated(StartNavigation);

            builder.Register(c => new KeyedViewModel(new Incrementer(0), c.Resolve<HeaderViewModel>()))
                .Keyed<KeyedViewModel>(UpdateType.Increment);
            builder.Register(c => new KeyedViewModel(new Decrementer(100), c.Resolve<HeaderViewModel>()))
                .Keyed<KeyedViewModel>(UpdateType.Decrement);

            builder.RegisterType<HeaderViewModel>().AsSelf().AsImplementedInterfaces();

            var controller = new ThemeController();
            controller.Initialize();
            builder.RegisterInstance<IThemeController>(controller);
        }

        private void StartNavigation(IActivatedEventArgs<MainViewModel> args)
        {
            var navigationService = args.Context.Resolve<INavigationService>();
            navigationService.Navigate<HomeViewModel>();
        }

        public IContainer Build()
        {
            return builder.Build();
        }

    }
}
