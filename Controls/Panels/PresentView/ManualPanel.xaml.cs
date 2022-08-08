using Appear.Core;
using Appear.Domain;
using Appear.Events;
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

namespace Appear.Controls.Panels.PresentView
{
    /// <summary>
    /// Interaction logic for ManualPanel.xaml
    /// </summary>
    public partial class ManualPanel : ObservableControl
    {
        public ManualPanel()
        {
            InitializeComponent();
        }

        private bool hasSelection { get; set; } = false;
        public bool HasSelection
        {
            get { return hasSelection; }
            set { hasSelection = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Asset> Assets
        {
            get { return (ObservableCollection<Asset>)GetValue(AssetsProperty); }
            set { SetValue(AssetsProperty, value); }
        }

        public static readonly DependencyProperty AssetsProperty =
           DependencyProperty.Register(
           "Assets",
           typeof(ObservableCollection<Asset>),
           typeof(ManualPanel),
           new UIPropertyMetadata(AssetPropertyChangedHandler)
        );

        public static void AssetPropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as ManualPanel).OnPropertyChanged("Assets");
        }

        public static readonly RoutedEvent SelectionChangedEvent =
            EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ManualPanel));

        public event RoutedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value); }
            remove { RemoveHandler(SelectionChangedEvent, value); }
        }

        public void OnAssetSelectionChanged(object sender, RoutedEventArgs e)
        {
            HasSelection = true;
            List<Asset> assets = new List<Asset>() { (sender as ListView).SelectedItem as Asset };
            RaiseEvent(new SelectedAssetChangedEventArgs(SelectionChangedEvent, assets));
        }
    }
}
