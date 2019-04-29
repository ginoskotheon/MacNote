using MacNote.Models;
using MacNote.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// Interaction logic for SidebarMenuControl.xaml
    /// </summary>
    public partial class SidebarMenuControl : UserControl
    {
        PageViewModel p;
        public SidebarMenuControl()
        {
            InitializeComponent();
            p = new PageViewModel();
            this.DataContext = p;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            p.SelectPage((Paged)item.SelectedItem);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewTitle.Visibility = Visibility.Hidden;

        }

        private void OpenTitleModal(object sender, RoutedEventArgs e)
        {
            NewTitle.Visibility = Visibility.Visible;
            txtBox.Text = "Add a title";
        }
    }
}
