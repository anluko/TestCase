using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using TestProject.Models;
using TestProject.Windows;
using TestProject.Pages;

namespace TestProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployeesWindow.xaml
    /// </summary>
    public partial class EmployeesWindow : Window
    {
        private readonly AppDbContext _context;
        public static EmployeesWindow Instance { get; set; }

        public EmployeesWindow()
        {
            InitializeComponent();

            Instance = this;
            MainFrame.Navigate(new EmployeesPage());
        }



        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EmployeesPage.Instance != null) EmployeesPage.Instance.loadAndFilterData();
        }

        private void DepartmentsCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeesPage.Instance != null) EmployeesPage.Instance.loadAndFilterData();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchTb.Visibility = Visibility.Visible;
            DepartmentsCb.Visibility = Visibility.Visible;

            BackBtn.Visibility = Visibility.Collapsed;
            InfoTbk.Visibility = Visibility.Collapsed;

            BackBtn.Visibility = Visibility.Collapsed;
            StatsLoadGrid.Visibility = Visibility.Collapsed;

            MainFrame.Navigate(new EmployeesPage());
        }

        private void ShowStatsBtn_Click(object sender, RoutedEventArgs e)
        {
            StatsPage.Instance.SelectFileSp.Visibility = Visibility.Collapsed;
            StatsPage.Instance.StartLoadSp.Visibility = Visibility.Collapsed;

            StatsPage.Instance.StatFilters.Visibility = Visibility.Visible;
            StatsPage.Instance.EmployeesDg.Visibility = Visibility.Visible;
            StatsPage.Instance.StatsSp.Visibility = Visibility.Visible;
        }

        private void ShowLoadBtn_Click(object sender, RoutedEventArgs e)
        {
            StatsPage.Instance.StatFilters.Visibility = Visibility.Collapsed;
            StatsPage.Instance.EmployeesDg.Visibility = Visibility.Collapsed;
            StatsPage.Instance.StatsSp.Visibility = Visibility.Collapsed;
            StatsPage.Instance.StartLoadSp.Visibility = Visibility.Collapsed;

            StatsPage.Instance.SelectFileSp.Visibility = Visibility.Visible;
        }
    }
}
