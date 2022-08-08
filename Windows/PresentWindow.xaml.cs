using Appear.Controls;
using Appear.Controls.Components.Buttons;
using Appear.Controls.List;
using Appear.Controls.Panels.PresentView;
using Appear.Domain;
using Appear.Domain.Enum;
using Appear.Events;
using Appear.Events.Components;
using Appear.Views;
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
using System.Windows.Shapes;

namespace Appear.Windows
{
    /// <summary>
    /// Interaction logic for PresentWindow.xaml
    /// </summary>
    public partial class PresentWindow : Window
    {
        public Asset selectedAsset;

        public event EventHandler NextAsset;
        protected void OnNextAsset()
        {
            if (NextAsset != null)
            {
                NextAsset(this, EventArgs.Empty);
                (Content as PresentView).PicturePreview.NextPreview();
            }
        }

        public event EventHandler PreviousAsset;
        protected void OnPreviousAsset()
        {
            if (PreviousAsset != null)
            {
                PreviousAsset(this, EventArgs.Empty);
                (Content as PresentView).PicturePreview.PreviousPreview();
            }
        }

        public event EventHandler SelectedAsset;
        protected void OnSelectedAsset()
        {
            if (SelectedAsset != null)
            {
                SelectedAsset(this, EventArgs.Empty);
                (Content as PresentView).PicturePreview.SelectedAsset(selectedAsset);
            }
        }

        public PresentWindow(List<Asset> assets)
        {
            Content = new PresentView(assets);
            InitializeComponent();

            AddHandler(IconButton.IconButtonClickedEvent, new RoutedEventHandler(IconButtonClickedEventHandler));
            AddHandler(TextButton.TextButtonClickedEvent, new RoutedEventHandler(TextButtonClickedEventHandler));
            AddHandler(AutoPanel.TimerTickEvent, new RoutedEventHandler(TimerTickEventHandler));
            AddHandler(ManualPanel.SelectionChangedEvent, new RoutedEventHandler(AssetSelectionChangedEventHandler));
            AddHandler(SelectionList.SelectionChangedEvent, new RoutedEventHandler(SelectionChangedEventHandler));
            AddHandler(CheckBoxButton.CheckboxToggledEvent, new RoutedEventHandler(CheckboxToggledEventHandler));
        }

        private void CheckboxToggledEventHandler(object sender, RoutedEventArgs e)
        {
            CheckBoxToggledEventArgs args = (CheckBoxToggledEventArgs)e;
            if (args.Id.Equals("StartAuto"))
            {
                (Content as PresentView).AutoPanel.Timer(args.IsChecked);
            }
        }

        private void IconButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            IconButtonClickedEventArgs arg = (IconButtonClickedEventArgs)e;

            switch (arg.Action)
            {
                case IconButtonAction.NextAsset:
                    OnNextAsset();
                    break;
                case IconButtonAction.PreviousAsset:
                    OnPreviousAsset();
                    break;
                case IconButtonAction.CloseDialog:
                    (Content as PresentView).AutoPanel.Timer(false);
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void TextButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            TextButtonClickedEventArgs arg = (TextButtonClickedEventArgs)e;
            
            switch (arg.Action)
            {
                case "SelectedAsset":
                    OnSelectedAsset();
                    break;
                default:
                    break;
            }
        }

        private void AssetSelectionChangedEventHandler(object sender, RoutedEventArgs e)
        {
            SelectedAssetChangedEventArgs arg = (SelectedAssetChangedEventArgs)e;
            selectedAsset = arg.Assets[0];
        }

        private void TimerTickEventHandler(object sender, RoutedEventArgs e)
        {
            this.OnNextAsset();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (IsEnabled)
            {
                base.OnMouseLeftButtonDown(e);
                DragMove();
            }
        }

        private void SelectionChangedEventHandler(object sender, RoutedEventArgs e)
        {
            SelectionListChangedEventArgs arg = (SelectionListChangedEventArgs)e;

            switch (arg.Id)
            {
                case "PresentMode":
                    this.OnModeChanged(arg.Value);
                    break;
                default:
                    break;
            }
        }

        private void OnModeChanged(string value)
        {
            switch (value)
            {
                case "Manual":
                    (Content as PresentView).AutoPanel.Timer(false);
                    (Content as PresentView).IsManualMode = true;
                    break;
                case "Auto":
                    (Content as PresentView).IsManualMode = false;
                    break;
                default: break;
            }
        }
    }
}
