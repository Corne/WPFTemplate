using System.Threading.Tasks;
using Autofac;
using WPFTemplate.Services.Navigation;
using WPFTemplate.ViewModels;
using WPFTemplate.ViewModels.Navigation;
using Moq;
using NUnit.Framework;

namespace WPFTemplate.Test.Services.Navigation
{
    [TestFixture]
    public class NavigationServiceTest
    {
        private enum Keys
        {
            Value1,
            Value2
        }

        private class DummyClass : IContentViewModel
        {
            public Task OnNavigate()
            {
                return Task.FromResult(0);
            }

            public Task OnClose()
            {
                return Task.FromResult(0);
            }

            public IHeaderViewModel Header { get { return EmptyHeaderViewModel.Instance; } }
            public LoadingViewModel LoadMessage { get { return LoadingViewModel.Default; } }
        }

        private class TestClass : IContentViewModel
        {
            public TestClass()
            {

            }

            public TestClass(string paramater)
            {
                Parameter = paramater;
            }

            public string Parameter { get; }

            public Task OnNavigate()
            {
                return Task.FromResult(0);
            }

            public Task OnClose()
            {
                return Task.FromResult(0);
            }

            public IHeaderViewModel Header { get { return EmptyHeaderViewModel.Instance; } }
            public LoadingViewModel LoadMessage { get { return LoadingViewModel.Default; } }
        }

        private MainViewModel main;
        private IContainer container;

        [SetUp]
        public void Setup()
        {

            var builder = new ContainerBuilder();
            builder.RegisterInstance(new MainViewModel(null));

            builder.RegisterType<NavigationService>().AsSelf().As<INavigationService>();

            builder.RegisterType<DummyClass>().AsSelf().Keyed<IContentViewModel>(Keys.Value1);
            builder.RegisterType<TestClass>().AsSelf().Keyed<IContentViewModel>(Keys.Value2);

            builder.RegisterType<ContentScope>();

            container = builder.Build();

            main = container.Resolve<MainViewModel>();
        }

        [TearDown]
        public void TearDown()
        {
            container.Dispose();
        }

        [Test]
        public async Task NavigateUpdatesMainContent()
        {
            var input = new Mock<IContentViewModel>();

            using (var service = container.Resolve<NavigationService>())
            {
                await service.Navigate<TestClass>();

                Assert.IsInstanceOf<TestClass>(main.Content);
            }
        }

        [Test]
        public async Task BackSetsPreviousViewModel()
        {
            var dummy = new Mock<IContentViewModel>();
            using (var service = container.Resolve<NavigationService>())
            {
                await service.Navigate<DummyClass>();
                await service.Navigate<TestClass>();
                await service.Back();

                Assert.IsInstanceOf<DummyClass>(main.Content);
            }
        }

        [Test]
        public async Task BackWontActOnHome()
        {
            using (var service = container.Resolve<NavigationService>())
            {
                await service.Navigate<DummyClass>();
                await service.Back();
                Assert.IsInstanceOf<DummyClass>(main.Content);
            }
        }

        [Test]
        public async Task HomeWillSetContentToHomeViewModel()
        {
            using (var service = container.Resolve<NavigationService>())
            {
                await service.Navigate<DummyClass>();
                await service.Navigate<TestClass>();
                await service.Navigate<TestClass>();
                await service.Navigate<TestClass>();

                await service.Home();
                Assert.IsInstanceOf<DummyClass>(main.Content);
            }
        }

        [Test]
        public async Task NavigateKeyedResolvesBasedOnRegisteredKey()
        {
            using (var service = container.Resolve<NavigationService>())
            {
                await service.NavigateKeyed<IContentViewModel>(Keys.Value2);
                Assert.IsInstanceOf<TestClass>(main.Content);
            }
        }

        [Test]
        public async Task ParametersWillBeInjectedOnNavigate()
        {
            using (var service = container.Resolve<NavigationService>())
            {
                string input = "Hello Parameter";
                var result = await service.Navigate<TestClass>(new TypedParameter(typeof(string), input));

                Assert.AreEqual(input, result.Parameter);
            }
        }
    }
}