using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MacNote.Controls
{
    /// <summary>
    /// Interaction logic for CustomTextBox.xaml
    /// </summary>
    public partial class CustomTextBox : UserControl
    {
        public CustomTextBox()
        {
            InitializeComponent();
        }

        private Point GetMousePos()
        {
            return Mouse.GetPosition(Application.Current.MainWindow);
        }

        private void TxtBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Point p = GetMousePos();
            TextBox t = (TextBox)sender;
            StackPanel pa = (StackPanel)t.Parent;
            Grid par = (Grid)pa.Parent;
            CustomTextBox ct = (CustomTextBox)par.Parent;
            Popup parent = (Popup)ct.Parent;
            int id = Convert.ToInt32(parent.Uid);
            //MyTabControl.SendToDB(p, ct, id);
        }
    }
}
