using Entities;
using System;
using System.Collections.Generic;
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
using DataAccess;

namespace NorthwindUI.View.UserControls
{
    /// <summary>
    /// Interaction logic for EmployeeList.xaml
    /// </summary>
    public partial class EmployeeList : UserControl
    {
        public event Action<Employee> EmployeeSelected;
        public EmployeeList()
        {
            InitializeComponent();
            Repository repository = new();
            List<Employee> employees = repository.GetEmployees();
            foreach (var employee in employees)
            {
                lvEmployees.Items.Add(employee);
            }
        }

        private void lvEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee selected = (Employee)lvEmployees.SelectedItem;
            EmployeeSelected?.Invoke(selected);
        }
    }
}
