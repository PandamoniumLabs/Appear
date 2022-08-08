using Appear.Core;
using Appear.Domain;
using Appear.Domain.Enum;
using Appear.Events;
using Appear.Services;
using Appear.Services.Data.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Appear.Controls.Panels.MainView
{
    /// <summary>
    /// Interaction logic for ImageViewPanel.xaml
    /// </summary>
    public partial class ImageViewPanel : ObservableControl
    {
        private bool hasAssets { get; set; } = true;
        public bool HasAssets
        {
            get { return hasAssets; }
            set { hasAssets = value; OnPropertyChanged(); }
        }

        private ObservableCollection<AssetCollection> collection;
        public ObservableCollection<AssetCollection> Collection
        {
            get { return collection; }
            set { collection = value; OnPropertyChanged(); }
        }

        public ImageViewPanel()
        {
            ViewPanel.ViewModeChanged += new EventHandler(ViewModeChangedEventHandler);

            UpdateGrid(ViewMode.FOLDERS);
            InitializeComponent();
        }

        private void ViewModeChangedEventHandler(object sender, EventArgs e)
        {
            ViewModeChangedEventArgs arg = (ViewModeChangedEventArgs)e;

            switch (arg.ViewMode)
            {
                case ViewMode.FOLDERS:
                    HasAssets = true;
                    break;
                case ViewMode.TAGS:
                    HasAssets = TagManager.HasTags();
                    break;
                case ViewMode.EXTENSIONS:
                    HasAssets = true;
                    break;
                case ViewMode.SCENES:
                    HasAssets = SceneManager.HasScenes();
                    break;
            }

            UpdateGrid(arg.ViewMode);
        }

        public static readonly RoutedEvent SelectionChangedEvent =
            EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ImageViewPanel));

        public event RoutedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value); }
            remove { RemoveHandler(SelectionChangedEvent, value); }
        }

        public void OnAssetListSelectionChanged(object sender, RoutedEventArgs e)
        {
            AssetCollection collection = ((sender as ListView).SelectedItem as AssetCollection);
            if (collection != null && collection.Assets != null)
            {
                List<Asset> assets = collection.Assets.ToList();
                RaiseEvent(new SelectedAssetChangedEventArgs(SelectionChangedEvent, assets));
            }
        }    

        public void UpdateGrid(ViewMode viewMode)
        {
            Collection = new ObservableCollection<AssetCollection>(AssetManager.Get(viewMode));
        }
    }
}
