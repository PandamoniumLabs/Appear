using Appear.Core;
using Appear.Services.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Appear.Views
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class AboutView : ObservablePage
    {
        private string version { get; set; }
        public string Version
        {
            get { return version; }
            set { version = value; OnPropertyChanged(); }
        }


        public AboutView()
        {
            Version = $"v {SettingsManager.AppSettings().Version} - {SettingsManager.AppSettings().Release}";
            InitializeComponent();
        }

        
    }
}
