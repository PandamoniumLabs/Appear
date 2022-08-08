using Appear.Core;
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

namespace Appear.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for OkDialogView.xaml
    /// </summary>
    public partial class OkDialogView : ObservablePage
    {
        private string text { get; set; }
        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged(); } 
        }

        public OkDialogView(string text)
        {
            Text = text;
            InitializeComponent();
        }
    }
}
