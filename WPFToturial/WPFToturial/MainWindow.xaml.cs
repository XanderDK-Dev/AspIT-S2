using Microsoft.Win32;
using System.Windows;

namespace WPFToturial
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lvEntries.Items.Add("a");
            lvEntries.Items.Add("a1");
            lvEntries.Items.Add("a2");
            lvEntries.Items.Add("a3");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            lvEntries.Items.Add(txtEntry.Text);
            txtEntry.Clear();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = lvEntries.SelectedIndex;
            lvEntries.Items.RemoveAt(index);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lvEntries.Items.Clear();
        }
    }
}