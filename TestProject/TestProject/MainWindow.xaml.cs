using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using TestProject.Classes;
using TestProject.Models;
using TestProject.Windows;
using OfficeOpenXml;

namespace TestProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
        }


        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                Title = "Выберите файл"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                var context = new AppDbContext();
                var importer = new ImportData(context);
                importer.ImportFromExcel(filePath);
                MessageBox.Show("Импорт завершен успешно!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}