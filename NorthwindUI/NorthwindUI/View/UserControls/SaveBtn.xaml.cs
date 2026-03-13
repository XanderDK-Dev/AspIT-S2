using DataAccess;
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

namespace NorthwindUI.View.UserControls
{
    /// <summary>
    /// Interaction logic for SaveBtn.xaml
    /// </summary>
    public partial class SaveBtn : UserControl
    {
        public SaveBtn()
        {
            InitializeComponent();
        }

        private void txtSave_Click(object sender, RoutedEventArgs e, Employee employee)
        {
            Repository repository = new();
            //TextBox textBox = ()sender;
            //string firstName = textBox.Text;
            repository.UpdateEmployee(employee);
        }
    }
}
