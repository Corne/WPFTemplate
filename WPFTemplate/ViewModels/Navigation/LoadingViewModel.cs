using GalaSoft.MvvmLight;

namespace WPFTemplate.ViewModels.Navigation
{
    public class LoadingViewModel : ViewModelBase
    {
        public static readonly LoadingViewModel Default = new LoadingViewModel(string.Empty, string.Empty) { IsLoading = false };

        public LoadingViewModel(string mainMessage, string subMessage)
        {
            this.mainMessage = mainMessage;
            this.subMessage = subMessage;
        }

        private bool isLoading = true;
        public bool IsLoading
        {
            get { return isLoading; }
            set { Set(ref isLoading, value); }
        }

        private string mainMessage;
        public string MainMessage
        {
            get { return mainMessage; }
            set { Set(ref mainMessage, value); }
        }

        private string subMessage;
        public string SubMessage
        {
            get { return subMessage; }
            set { Set(ref subMessage, value); }
        }
    }
}
