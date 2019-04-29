using MacNote.DataSource;
using MacNote.Models;
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
    /// Interaction logic for MyTabControl.xaml
    /// </summary>
    public partial class MyTabControl : UserControl
    {
        public MyTabControl()
        {
            InitializeComponent();
        }

        private Point GetMousePos()
        {
            return Mouse.GetPosition(Application.Current.MainWindow);
        }

        private void AddBox_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            Grid g = (Grid)b.Parent;
            ItemsControl c = (ItemsControl)g.Children[0];
            //Canvas c = (Canvas)g.Children[0];
            int id = Convert.ToInt32(b.Uid);
            Point mousePos = GetMousePos();
            CreateTextBox(mousePos, c, id);
        }

        private void CreateTextBox(Point pos, ItemsControl canVas, int id)
        {
            //CustomOpen.IsOpen = true;
            //CustomOpen.Uid = id.ToString();
            //CustomTextBox newTextBox = new CustomTextBox();

            //newTextBox.Name = "NEW" + id.ToString();
            //newTextBox.txtBox.Name = "NEW" + id.ToString();


            //newTextBox.txtBox.Text = "Test";
            //newTextBox.SetValue(Canvas.LeftProperty, (pos.X - 301));
            //newTextBox.SetValue(Canvas.TopProperty, (pos.Y - 53));
            //newTextBox.txtBox.Focusable = true;
            //newTextBox.txtBox.AcceptsReturn = true;

            //newTextBox.txtBox.Focus();
            //newTextBox.LostFocus += new RoutedEventHandler(this.TextBoxClick);
            //canVas.Resources.Add("New", newTextBox);
            //canVas.Children.Add(newTextBox);
            //canVas.RegisterName(newTextBox.Name, newTextBox);


        }

        private void TextBoxClick(object sender, RoutedEventArgs e)
        {
            CustomTextBox t = (CustomTextBox)sender;
            //PageDetail pd = new PageDetail();
            //var what = pvm.Pages.Select(y => y.ID).First(x => x == Convert.ToInt32(t.Name.Substring(t.Name.Length - 1, 1)));
            //int idMatch = Convert.ToInt32(what);
            //pd.pageID = idMatch;
            //pd.content = t.txtBox.Text.Trim().ToString();
            //pd.X = Convert.ToInt32(Canvas.GetLeft(t));
            //pd.Y = Convert.ToInt32(Canvas.GetTop(t));

            //DataAccess.InsertIntoPageDetails(pd);
        }

        //private void CustomOpen_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    Point mousePos = GetMousePos();
        //    Popup t = (Popup)sender;
        //    PageDetail pd = new PageDetail();
        //    //var what = pvm.Pages.Select(y => y.ID).First(x => x == Convert.ToInt32(t.Name.Substring(t.Name.Length - 1, 1)));
        //    //int idMatch = Convert.ToInt32(what);
        //    pd.pageID = Convert.ToInt32(t.Uid);
        //    CustomTextBox ct = (CustomTextBox)t.Child;
        //    pd.content = ct.txtBox.Text.Trim().ToString();
        //    pd.X = Convert.ToInt32(mousePos.X);
        //    pd.Y = Convert.ToInt32(mousePos.Y);

        //    DataAccess.InsertIntoPageDetails(pd);
        //}

       
    }


}
