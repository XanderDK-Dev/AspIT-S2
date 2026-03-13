using Entities;
using NorthwindUI.View.UserControls;
using System.Runtime.ConstrainedExecution;
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

namespace NorthwindUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            listEmployees.EmployeeSelected += GetEmployee;

            infoFirstName.SetType("Firstname:");
            infoLastName.SetType("Lastname:");

            string firstName = infoFirstName.ToString();
            string lastName = infoLastName.ToString();
        }

        private void GetEmployee(Employee employee)
        {
            infoFirstName.SetText(employee.Firstname);
            infoLastName.SetText(employee.Lastname);
        }


    }
}