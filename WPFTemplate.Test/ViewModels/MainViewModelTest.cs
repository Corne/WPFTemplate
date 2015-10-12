using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTemplate.ViewModels;
using WPFTemplate.ViewModels.Navigation;
using Moq;
using NUnit.Framework;

namespace WPFTemplate.Test.ViewModels
{
    [TestFixture]
    public class MainViewModelTest
    {

        [Test]
        public async Task UpdateNavigatesToContent()
        {
            var content = new Mock<IContentViewModel>();
            var viewmodel = new MainViewModel(null);

            await viewmodel.Update(content.Object);

            content.Verify(c => c.OnNavigate());
        }

        [Test]
        public async Task UpdateClosesOldContent()
        {
            var old = new Mock<IContentViewModel>();
            var current = new Mock<IContentViewModel>();

            var viewmodel = new MainViewModel(null);

            await viewmodel.Update(old.Object);
            await viewmodel.Update(current.Object);

            old.Verify(o => o.OnClose());
        }

        [Test]
        public async Task UpdateRaisesChangeEvent()
        {
            var content = new Mock<IContentViewModel>();
            var viewmodel = new MainViewModel(null);

            bool called = false;
            viewmodel.PropertyChanged += (sender, args) =>
            {
                called = true;
                Assert.AreEqual(nameof(viewmodel.Content), args.PropertyName);
            };
            await viewmodel.Update(content.Object);

            Assert.True(called);
        }
    }
}
