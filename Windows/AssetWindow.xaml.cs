using Appear.Controls;
using Appear.Controls.Components;
using Appear.Controls.Components.Buttons;
using Appear.Controls.Components.Input;
using Appear.Controls.Components.List;
using Appear.Domain.Enum;
using Appear.Events;
using Appear.Events.Components;
using Appear.Services;
using Appear.Services.Data.Domain;
using Appear.Views;
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
using System.Windows.Shapes;

namespace Appear.Windows
{
    /// <summary>
    /// Interaction logic for AssetWindow.xaml
    /// </summary>
    public partial class AssetWindow : Window
    {
        public event EventHandler AssetListChanged;
        protected void OnAssetListChanged()
        {
            if (AssetListChanged != null)
            {
                AssetListChanged(this, EventArgs.Empty);
            }
        }

        public AssetWindow()
        {
            Content = new AssetView();

            InitializeComponent();

            AddHandler(IconButton.IconButtonClickedEvent, new RoutedEventHandler(IconButtonClickedEventHandler));
            AddHandler(FolderEntry.UpdateAssetsEvent, new RoutedEventHandler(UpdateFoldersEventHandler));
            AddHandler(AssetListItem.RemoveAssetEvent, new RoutedEventHandler(UpdateFoldersEventHandler));
        }

        private void IconButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            IconButtonClickedEventArgs arg = (IconButtonClickedEventArgs)e;

            switch (arg.Action)
            {
                case IconButtonAction.CloseDialog:
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void UpdateFoldersEventHandler(object sender, RoutedEventArgs e)
        {
            UpdateFoldersEventArgs args = (UpdateFoldersEventArgs)e;
            if (args.Action == UpdateFoldersEventArgs.ActionType.ADD)
            {
                FolderManager.Add(args.Path);
                AssetManager.AddFromFolder(args.Path);
            }
            else if (args.Action == UpdateFoldersEventArgs.ActionType.REMOVE)
            {
                FolderManager.Remove(args.Path);
            }

            (Content as AssetView).AssetList.UpdateFoldersventHandler();

            this.OnAssetListChanged();
        }
    }
}
