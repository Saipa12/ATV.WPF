using ATV.WPF.Core;

namespace ATV.WPF.Windows.BrowseFile
{
    internal partial class BrowseFileViewModel : BaseWindowViewModel<BrowseFileView>
    {
        private string _FilePath;
        public string FilePath
        {
            get => _FilePath;
            set
            {
                if (_FilePath != value)
                {
                    _FilePath = value;
                    RaisePropertyChanged(nameof(FilePath));
                }
            }
        }

        public BrowseFileViewModel(BrowseFileView control) : base(control) { }
    }
}