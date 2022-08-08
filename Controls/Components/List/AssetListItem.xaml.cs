using Appear.Events;
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

namespace Appear.Controls.Components.List
{
    /// <summary>
    /// Interaction logic for AssetListItem.xaml
    /// </summary>
    public partial class AssetListItem : UserControl
    {
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
            "Text",
            typeof(string),
            typeof(AssetListItem),
            new UIPropertyMetadata("")
        );

        public AssetListItem()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent RemoveAssetEvent =
            EventManager.RegisterRoutedEvent("RemoveAssetClicked", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(AssetListItem));

        public event RoutedEventHandler RemoveAssetClicked
        {
            add { AddHandler(RemoveAssetEvent, value); }
            remove { RemoveHandler(RemoveAssetEvent, value); }
        }

        private void RemoveAsset(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new UpdateFoldersEventArgs(RemoveAssetEvent, Text, UpdateFoldersEventArgs.ActionType.REMOVE));
        }
    }
}
