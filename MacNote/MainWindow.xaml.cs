using MacNote.Controls;
using MacNote.DataSource;
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

namespace MacNote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        PageViewModel pvm = new PageViewModel();

        public MainWindow()
        {
            InitializeComponent();
            //GenerateControls();
            //Button addButton = new Button();
            //addButton = (Button)tabControl.FindName("AddBox");
            //addButton.Click += new RoutedEventHandler(this.CallClick);
        }

        private void CallClick(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            Grid g = (Grid)b.Parent;
            Canvas c = (Canvas)g.Children[0];
            int id = Convert.ToInt32(c.Name.Substring(c.Name.Length - 1, 1));
            Point mousePos = GetMousePos();
            //CreateTextBox(mousePos, c, id);
        }

        private Point GetMousePos()
        {
            return Mouse.GetPosition(Application.Current.MainWindow);
        }

        private void GenerateControls()
        {
            //foreach(MacNote.Models.Page i in pvm.pages)
            //{
            //    TabItem ti = new TabItem();
            //    ti.Header = i.Title;

            //    Grid g = new Grid();
            //    Button bt = new Button();
            //    bt.Name = "AddBox";
            //    bt.Click += new RoutedEventHandler(this.btnClick);
            //    bt.Opacity = 0;
            //    Canvas c = new Canvas();

            //    c.Name = "C"+i.ID;
            //    c.VerticalAlignment = VerticalAlignment.Stretch;
            //    c.HorizontalAlignment = HorizontalAlignment.Stretch;
            //    c.Margin = new Thickness(161, 23, 25, 33);

            //    foreach (PageDetail j in i.pageDetails)
            //    {
            //        CustomTextBox newTextBox = new CustomTextBox();
            //        //TextBox newTextBox = new TextBox();
            //        newTextBox.Name = "TB"+j.ID.ToString();
            //        //newTextBox.Height = 50;
            //        //newTextBox.Width = 200;
            //        newTextBox.SetValue(Canvas.LeftProperty, Convert.ToDouble(j.X));
            //        newTextBox.SetValue(Canvas.TopProperty, Convert.ToDouble(j.Y));

            //        newTextBox.txtBox.Text = j.content;
            //        c.Children.Add(newTextBox);
            //        //c.RegisterName(newTextBox.Name, newTextBox);
            //    }
            //    g.Children.Add(c);
            //    g.Children.Add(bt);
            //    ti.Content = g;

            //TabControl.Items.Add(ti);
            //}
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {

            Button b = (Button)sender;
            Grid g = (Grid)b.Parent;
            Canvas c = (Canvas)g.Children[0];
            int id = Convert.ToInt32(c.Name.Substring(c.Name.Length - 1, 1));
            Point mousePos = GetMousePos();
            //CreateTextBox(mousePos, c, id);
        }

        //private void CreateTextBox(Point pos, Canvas canVas, int id)
        //{
        //    CustomTextBox newTextBox = new CustomTextBox();

        //    newTextBox.Name = "NEW" + id.ToString();
        //    newTextBox.txtBox.Name = "NEW" + id.ToString();


        //    newTextBox.txtBox.Text = "Test";
        //    newTextBox.SetValue(Canvas.LeftProperty, (pos.X - 301));
        //    newTextBox.SetValue(Canvas.TopProperty, (pos.Y - 53));
        //    newTextBox.txtBox.Focusable = true;
        //    newTextBox.txtBox.AcceptsReturn = true;

        //    newTextBox.txtBox.Focus();
        //    newTextBox.LostFocus += new RoutedEventHandler(this.TextBoxClick);
        //    canVas.Children.Add(newTextBox);
        //    canVas.RegisterName(newTextBox.Name, newTextBox);


        //}

        //private void TextBoxClick(object sender, RoutedEventArgs e)
        //{
        //    CustomTextBox t = (CustomTextBox)sender;
        //    PageDetail pd = new PageDetail();
        //    var what = pvm.Pages.Select(y => y.ID).First(x => x == Convert.ToInt32(t.Name.Substring(t.Name.Length - 1, 1)));
        //    int idMatch = Convert.ToInt32(what);
        //    pd.pageID = idMatch;
        //    pd.content = t.txtBox.Text.Trim().ToString();
        //    pd.X = Convert.ToInt32(Canvas.GetLeft(t));
        //    pd.Y = Convert.ToInt32(Canvas.GetTop(t));

        //    DataAccess.InsertIntoPageDetails(pd);
        //}



        //private void MenuChange(Object sender, RoutedEventArgs ags)
        //{
        //    RadioButton rb = sender as RadioButton;
        //    if (rb == null || cxm == null) return;

        //    switch (rb.Name)
        //    {
        //        case "rbCustom":
        //            cxmTextBox.ContextMenu = cxm;
        //            break;
        //        case "rbDefault":
        //            // Clearing the value of the ContextMenu property
        //            // restores the default TextBox context menu.
        //            cxmTextBox.ClearValue(ContextMenuProperty);
        //            break;
        //        case "rbDisabled":
        //            // Setting the ContextMenu propety to 
        //            // null disables the context menu.
        //            cxmTextBox.ContextMenu = null;
        //            break;
        //        default:
        //            break;
        //    }

        //}
        private TextBox tb
        {
            get
            {
                return (TextBox)sbMC.FindName("Test");
            }
        }

        void ClickPaste(Object sender, RoutedEventArgs args) { tb.Paste(); }
        void ClickCopy(Object sender, RoutedEventArgs args) { tb.Copy(); }
        void ClickCut(Object sender, RoutedEventArgs args) { tb.Cut(); }
        void ClickSelectAll(Object sender, RoutedEventArgs args) { tb.SelectAll(); }
        void ClickClear(Object sender, RoutedEventArgs args) { tb.Clear(); }
        void ClickUndo(Object sender, RoutedEventArgs args) { tb.Undo(); }
        void ClickRedo(Object sender, RoutedEventArgs args) { tb.Redo(); }

        //void ClickSelectLine(Object sender, RoutedEventArgs args)
        //{
        //    int lineIndex = cxmTextBox.GetLineIndexFromCharacterIndex(cxmTextBox.CaretIndex);
        //    int lineStartingCharIndex = cxmTextBox.GetCharacterIndexFromLineIndex(lineIndex);
        //    int lineLength = cxmTextBox.GetLineLength(lineIndex);
        //    cxmTextBox.Select(lineStartingCharIndex, lineLength);
        //}

        //void CxmOpened(Object sender, RoutedEventArgs args)
        //{
        //    // Only allow copy/cut if something is selected to copy/cut.
        //    if (cxmTextBox.SelectedText == "")
        //        cxmItemCopy.IsEnabled = cxmItemCut.IsEnabled = false;
        //    else
        //        cxmItemCopy.IsEnabled = cxmItemCut.IsEnabled = true;

        //    // Only allow paste if there is text on the clipboard to paste.
        //    if (Clipboard.ContainsText())
        //        cxmItemPaste.IsEnabled = true;
        //    else
        //        cxmItemPaste.IsEnabled = false;
        //}
    }
}
