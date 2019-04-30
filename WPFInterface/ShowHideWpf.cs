using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Code snippet from https://www.technical-recipes.com/2015/showing-and-hiding-controls-in-wpf-xaml/

namespace ShowHideWpf
{
    public class MainWindowViewModel
    {
        public bool ShowMenu { get; set; }

        public MainWindowViewModel()
        {
            ShowMenu = true;
        }
    }
}
