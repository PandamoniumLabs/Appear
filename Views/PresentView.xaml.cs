using Appear.Controls.Panels.MainView;
using Appear.Controls.Panels.PresentView;
using Appear.Core;
using Appear.Domain;
using Appear.Domain.Enum;
using Appear.Services.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PresentView.xaml
    /// </summary>
    public partial class PresentView: ObservablePage
    {
        private ObservableCollection<Asset> assets { get; set; }
        public ObservableCollection<Asset> Assets
        {
            get { return assets; }
            set { assets = value; OnPropertyChanged(); }
        }

        private List<string> modes { get; set; } = Enum.GetNames(typeof(PresentMode)).ToList();
        public List<string> Modes
        {
            get { return modes; }
            set { modes = value; OnPropertyChanged(); }
        }

        private bool isManualMode { get; set; } = true;
        public bool IsManualMode
        {
            get { return isManualMode; }
            set { isManualMode = value; OnPropertyChanged(); }
        }

        private string presentMode { get; set; } = SettingsManager.DefaultPresentMode.ToString();

        public string PresentMode
        {
            get { return presentMode; }
            set { presentMode = value; OnPropertyChanged(); }
        }

        public PicturePreviewPanel PicturePreview
        {
            get
            {
                return this.GetChildOfType<PicturePreviewPanel>();
            }
        }

        public AutoPanel AutoPanel
        {
            get
            {
                return this.GetChildOfType<AutoPanel>();
            }
        }

        public PresentView(List<Asset> assets)
        {
            Assets = new ObservableCollection<Asset>(assets);
            InitializeComponent();
        }
    }
}
