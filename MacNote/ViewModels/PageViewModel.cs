using MacNote.Controls;
using MacNote.DataSource;
using MacNote.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MacNote.ViewModels
{
    public class PageViewModel : ViewModelBase
    {
        public MyICommand AddCommand { get; set; }
        public MyICommand VisibleCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        private Paged _paged;
        private string _content;

        public string Keys
        {
            get
            {
                return "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            }
        }
        public Paged ViewPage
        {
            get
            {
                if (_paged == null)
                {
                    //_paged = new Paged();
                    //_paged.Content = "NEW";
                    //_paged.ID = Pages.Count + 1;
                    //_paged.Title = "New";
                    _paged = Pages[0];
                }
                return _paged;
            }
            set
            {
                _paged = value;
                SetProperty("ViewPage");
            }
        }

        public string Content
        {
            get => _content;
            set
            {
                ViewPage.Content = value;
                _content = ViewPage.Content;
                SetProperty("Content");
            }
        }

        public PageViewModel()
        {
            LoadPages();
            myVisibility = false;           
            AddCommand = new MyICommand(OnAdd);
            VisibleCommand = new MyICommand(MakeVisible);
            UpdateCommand = new MyICommand(UpdateText);
            DeleteCommand = new MyICommand(DeletePage);
        }

        private void DeletePage()
        {
            int id = ViewPage.ID;
            DataAccess.DeletePage(id);
            Pages.Remove(Pages.First(x => x.ID == id));
        }

        public ObservableCollection<Paged> Pages { get; set; }

        private void LoadPages()
        {
            ObservableCollection<Paged> pages = new ObservableCollection<Paged>();
            pages = DataAccess.GetPages();
            Pages = pages;
        }

        private Paged _page;

        public Paged SelectedPage
        {
            get => _page;
            set
            {
                _page = value;

            }
        }

        private string _newTitle;

        private bool _myVisibility;
        public bool myVisibility
        {
            get => _myVisibility;
            set
            {
                _myVisibility = value;
                SetProperty("myVisibility");
            }
        }
        public string NewTitle
        {
            get => _newTitle;
            set
            {
                _newTitle = value;
                SetProperty("NewTitle");
                OnAdd();
            }
        }

        public void SelectPage(Paged p)
        {
            ViewPage = p;

            SetProperty("ViewPage");
        }

        public void OnAdd()
        {

            Paged p = new Paged();
            p.Content = "NEW";
            p.Title = NewTitle;
            p.ID = Pages.Select(x => x.ID).Last()+1;
            ViewPage = p;

            if (NewTitle != null)
                InsertNew(p, NewTitle);
        }

        private void MakeVisible()
        {
            myVisibility = true;
        }


        private void InsertNew(Paged p, string newTitle)
        {
            DataAccess.InsertIntoPageDetails(p);
            myVisibility = false;
            Pages.Add(p);
        }

        private void UpdateText()
        {
            int id = ViewPage.ID;
            string content = ViewPage.Content;
            DataAccess.UpdatePageDetails(id, content);
        }
    }
}
