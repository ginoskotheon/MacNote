using MacNote.Controls;
using MacNote.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MacNote.ViewModels
{
    public class TextBoxViewModel : ViewModelBase
    {
        private Paged _page;
       
        public Paged page
        {
            get => _page;
            set
            {
                _page = value;
                
            }

        } 
        
        public TextBoxViewModel()
        {
           


        }
        public TextBoxViewModel(Paged p)
        {
            page = p;
               
        }
    }
}
