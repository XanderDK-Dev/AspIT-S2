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
    /// Interaction logic for InfoShower.xaml
    /// </summary>
    public partial class InfoShower : UserControl
    {
        public InfoShower()
        {
            InitializeComponent();
        }

        public void SetType(string type)
        {
            txtType.Text = type;
        }

        public void SetText(string text)
        {
            txtInfo.Text = text;
        }
    }
}
