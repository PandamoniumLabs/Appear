using Appear.Core;
using Appear.Domain;
using Appear.Events;
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

namespace Appear.Controls.Panels.MainView
{
    /// <summary>
    /// Interaction logic for ControlPanel.xaml
    /// </summary>
    public partial class ControlPanel : ObservableControl
    {
        private string assetName { get; set; }
        public string AssetName
        {
            get { return assetName; }
            set { assetName = value; OnPropertyChanged(); }
        }

        private Asset selectedAsset { get; set; }
        public Asset SelectedAsset
        {
            get { return selectedAsset; }

            set
            {
                selectedAsset = value;
                AssetName = value == null ? null : value.Name;
            }
        } 

        public ControlPanel()
        {
            Loaded += OnLoad;
            Unloaded += OnUnLoad;

            InitializeComponent();
        }

        private void OnUnLoad(object sender, RoutedEventArgs e)
        {
            MainWindow.AssetSelectionChanged -= new EventHandler(OnAssetSelectionChanged);
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            MainWindow.AssetSelectionChanged += new EventHandler(OnAssetSelectionChanged);
        }

        private void OnAssetSelectionChanged(object sender, EventArgs e)
        {
            AssetSelectionChangedEventArgs arg = (AssetSelectionChangedEventArgs)e;
            SelectedAsset = arg.Assets[0];
        }
    }
}
