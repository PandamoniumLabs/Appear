using Appear.Core;
using Appear.Domain;
using Appear.Events;
using Appear.Events.Windows;
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
    public partial class PresenterControlPanel : ObservableControl
    {
        private string path;
        public string Path
        {
            get { return path; }
            set { path = value; OnPropertyChanged(); }
        }

        private double imageHeight;
        public double ImageHeight
        {
            get { return imageHeight; }
            set { imageHeight = value; OnPropertyChanged(); }
        }

        private double imageWidth;
        public double ImageWidth
        {
            get { return imageWidth; }
            set { imageWidth = value; OnPropertyChanged(); }
        }

        private List<Asset> assets;
        public List<Asset> Assets
        {
            get { return assets; }
            set { 
                assets = value;
                OnPropertyChanged();
                Path = (assets != null && assets[selectedIndex] != null) ? assets[selectedIndex].Path : "";
            }
        }

        public int selectedIndex = 0;

        public PresenterControlPanel()
        {          
            Loaded += OnLoad;
            Unloaded += Unload;
            InitializeComponent();
        }

        private void Unload(object sender, RoutedEventArgs e)
        {
            MainWindow.WindowLoaded -= new EventHandler(OnWindowLoaded);
            MainWindow.PresentingStateChanged -= new EventHandler(OnPresentingStateChanged);
            MainWindow.PresentingAssetChanged -= new EventHandler(OnPresentingAssetChanged);
            MainWindow.AssetSelectionChanged -= new EventHandler(OnAssetSelectionChanged);
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            MainWindow.WindowLoaded += new EventHandler(OnWindowLoaded);
            MainWindow.PresentingStateChanged += new EventHandler(OnPresentingStateChanged);
            MainWindow.PresentingAssetChanged += new EventHandler(OnPresentingAssetChanged);
            MainWindow.AssetSelectionChanged += new EventHandler(OnAssetSelectionChanged);
        }

        private void OnAssetSelectionChanged(object sender, EventArgs e)
        {
            AssetSelectionChangedEventArgs arg = (AssetSelectionChangedEventArgs)e;
            Assets = arg.Assets;
        }

        private void OnPresentingAssetChanged(object sender, EventArgs e)
        {
            PresentingAssetChangedEventArgs arg = (PresentingAssetChangedEventArgs)e;
            switch (arg.Action)
            {
                case PresentingAction.NEXT:
                    Next();
                    break;
                case PresentingAction.PREVIOUS:
                    Previous();
                    break;
                case PresentingAction.SELECTED:
                    Present(arg.Asset);
                    break;
            }
        }

        private void OnPresentingStateChanged(object sender, EventArgs e)
        {
            PresentingStateChangedEventArgs arg = (PresentingStateChangedEventArgs)e;
            switch (arg.PresentingState)
            {
                case PresentingState.START:
                    SetDimensions(arg.Window);
                    break;
                case PresentingState.STOP:
                    selectedIndex = 0;
                    break;
            }
        }

        private void OnWindowLoaded(object sender, EventArgs e)
        {
            WindowLoadedEventArgs arg = (WindowLoadedEventArgs)e;
            SetDimensions(arg.Window);
        }

        private void SetDimensions(Window window)
        {
            ImageHeight = window.Height;
            ImageWidth = window.Width;
        }

        private void SetAssets(List<Asset> assets)
        {
            Assets = assets;
        }

        private void Next()
        {
            selectedIndex = selectedIndex < assets.Count-1 ? selectedIndex+1 : 0;
            Path = assets[selectedIndex].Path;
        }

        private void Previous()
        {
            selectedIndex = selectedIndex > 0 ? selectedIndex - 1 : assets.Count - 1;
            Path = assets[selectedIndex].Path;
        }

        private void Present(Asset asset)
        {
            if (Assets.Contains(asset))
            {
                selectedIndex = Assets.IndexOf(asset);
                Path = asset.Path;
            }
        }
    }
}
