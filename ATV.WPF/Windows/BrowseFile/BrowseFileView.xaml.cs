using ATV.WPF.Class;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Excel = Microsoft.Office.Interop.Excel;

namespace ATV.WPF.Windows.BrowseFile
{
    internal partial class BrowseFileView : Window
    {
        internal readonly BrowseFileViewModel ViewModel;

        private readonly PackIcon packIconMaximize = new PackIcon();
        private readonly PackIcon packIconRestore = new PackIcon();

        public BrowseFileView()
        {
            InitializeComponent();

            ViewModel = new BrowseFileViewModel(this);
            DataContext = ViewModel;

            packIconMaximize.Kind = PackIconKind.WindowMaximize;
            packIconRestore.Kind = PackIconKind.WindowRestore;
        }

        private void GridControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void CloseApplicationButton_Click(object sender, RoutedEventArgs e) => Close();

        private void MinimizeWindowButton_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void BrowseDataToList(string FilePath)
        {
            List<Total> list = new List<Total>();
            Excel.Application ex = new Microsoft.Office.Interop.Excel.Application();
            ex.Workbooks.Open(@"C:\Users\Myuser\Documents\Excel.xlsx");
            ex.Visible = true;
            Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(3);
            //Excel.Application ex = new Microsoft.Office.Interop.Excel.Application();
            ////Отобразить Excel
            //ex.Visible = true;
            ////Количество листов в рабочей книге
            //ex.SheetsInNewWorkbook = 2;
            ////Добавить рабочую книгу
            //Excel.Workbook workBook = ex.Workbooks.Add(Type.Missing);
            ////Отключить отображение окон с сообщениями
            //ex.DisplayAlerts = false;
            ////Получаем первый лист документа (счет начинается с 1)
            //Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);
            ////Название листа (вкладки снизу)
            //sheet.Name = "Отчет за 13.12.2017";
            ////Пример заполнения ячеек
            //for (int i = 1; i <= 9; i++)
            //{
            //    for (int j = 1; j < 9; j++)
            //        sheet.Cells[i, j] = String.Format("Boom {0} {1}", i, j);
            //}
            ////Захватываем диапазон ячеек
            //Excel.Range range1 = sheet.get_Range(sheet.Cells[1, 1], sheet.Cells[9, 9]);
            ////Шрифт для диапазона
            //range1.Cells.Font.Name = "Tahoma";
            ////Размер шрифта для диапазона
            //range1.Cells.Font.Size = 10;
            ////Захватываем другой диапазон ячеек
            //Excel.Range range2 = sheet.get_Range(sheet.Cells[1, 1], sheet.Cells[9, 2]);
            //range2.Cells.Font.Name = "Times New Roman";
            ////Задаем цвет этого диапазона. Необходимо подключить System.Drawing
            //range2.Cells.Font.Color = ColorTranslator.ToOle(Color.Green);
            ////Фоновый цвет
            //range2.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(0xFF, 0xFF, 0xCC));
        }
    }
}