using ATV.WPF.Core;
using Microsoft.Win32;

namespace ATV.WPF.Windows.BrowseFile
{
    internal partial class BrowseFileViewModel
    {
        public DelegateCommand BrowseExcelFileCommand => new DelegateCommand(BrowseExcelFile);
        
        public void BrowseExcelFile()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files | *.xls;*.xlsm;*.xlsx;*.csv;*.xlsb",
                Title = "Import Usarius"
            };
            openFileDialog.ShowDialog();

            FilePath = openFileDialog.FileName;
        }
    }
}