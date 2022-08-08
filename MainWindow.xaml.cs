using Appear.Controls.Components.Buttons;
using Appear.Controls.Components.List;
using Appear.Controls.Panels.MainView;
using Appear.Domain;
using Appear.Domain.Enum;
using Appear.Events;
using Appear.Events.Components;
using Appear.Events.Windows;
using Appear.Services;
using Appear.Services.Data;
using Appear.Services.Data.Domain;
using Appear.Views;
using Appear.Windows;
using Appear.Windows.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Appear
{
    public partial class MainWindow : Window
    {
        List<Asset> SelectedAssets;

        public MainWindow()
        {   
            Content = new MainView();
            InitializeComponent();

            AddHandler(TextButton.TextButtonClickedEvent, new RoutedEventHandler(TextButtonClickedEventHandler));
            AddHandler(IconButton.IconButtonClickedEvent, new RoutedEventHandler(IconButtonClickedEventHandler));
            AddHandler(ImageGrid.SelectionChangedEvent, new RoutedEventHandler(AssetSelectionChangedEventHandler));

            StyleManager.StartUp(this);

            Loaded += OnLoad;
        }

        void OnLoad(object sender, RoutedEventArgs e)
        {
            ViewCreatePanel.OpenCreateDialog += new EventHandler(OnOpenCreateDialog);

            OnWindowWidthChanged(this.Width);
            OnWindowLoaded(this);

            if (SettingsManager.UserSettings().UpdateOnStart)
            {
                OkDialog dialog = new OkDialog("A new version is available.");
                SurrenderFocus(dialog);
            }
        }

        private void OnOpenCreateDialog(object sender, EventArgs e)
        {
            OpenCreateDialogEventArgs args = (OpenCreateDialogEventArgs)e;
            CreateDialog window_create = new CreateDialog(args.ViewMode);
            SurrenderFocus(window_create);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (IsEnabled)
            {
                base.OnMouseLeftButtonDown(e);
                DragMove();
            }
        }

        private void SurrenderFocus(Window window)
        {        
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Closed += new EventHandler(ReturnFocus);
            window.Show();
            IsEnabled = false;
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            string theme = ((ThemeChangedEventArgs)e).Theme;
            StyleManager.SetCurrentStyle(theme);
        }

        private void OnMenuBarChanged(object sender, EventArgs e)
        {
            string position = ((MenuBarChangedEventArgs)e).Position;
            SettingsManager.SetDockPosition((DockPosition)Enum.Parse(typeof(DockPosition), position));
            StyleManager.UpdateStyle();
            (Content as MainView).DockPosition = StyleManager.GetUserSettings().DockPosition.ToString();            
        }

        private void OnDisplayWidthChanged(object sender, EventArgs e)
        {
            string value = ((DisplayWidthChangedEventArgs)e).DisplayWidth;
            DisplayWidth displayWidth = (DisplayWidth)Enum.Parse(typeof(DisplayWidth), value);
            SettingsManager.SetDisplayWidth(displayWidth);
            OnDisplayWidthChanged(value);
        }

        private void OnAssetListChanged(object sender, EventArgs e)
        {
            (Content as MainView).HasAssets = FolderManager.HasFolders();

            if (FolderManager.HasFolders())
            {
                //(Content as MainView).AssetGrid.UpdateGrid();
            }
        }

        private void ReturnFocus(object sender, EventArgs e)
        {
            IsEnabled = true;
        }

        private void IconButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            IconButtonClickedEventArgs arg = (IconButtonClickedEventArgs)e;

            switch (arg.Action)
            {
                case IconButtonAction.MaxMain:
                    if (this.WindowState == WindowState.Maximized)
                    {
                        StyleManager.SetWindowState(this, "Restore");
                        OnWindowWidthChanged(this.Width);
                    }
                    else
                    {
                        StyleManager.SetWindowState(this, "Maximize");
                        OnWindowWidthChanged(this.Width);
                    }
                    break;
                case IconButtonAction.OpenInfo:
                    AboutWindow window_about = new AboutWindow();
                    SurrenderFocus(window_about);
                    break;
                case IconButtonAction.CloseStyles:
                    IsEnabled = true;
                    break;
                case IconButtonAction.CloseMain:
                    Close();
                    break;
                default:
                    break;
            }
        }

        public static event EventHandler WindowWidthChanged;
        protected void OnWindowWidthChanged(double width)
        {
            if (WindowWidthChanged != null)
            {
                WindowWidthChanged(this, new WindowWidthChangedEventArgs() { Width = width });
            }
        }

        public static event EventHandler DisplayWidthChanged;
        protected void OnDisplayWidthChanged(string width)
        {
            if (DisplayWidthChanged != null)
            {
                DisplayWidthChanged(this, new DisplayWidthChangedEventArgs() { DisplayWidth = width });
            }
        }

        public static event EventHandler WindowLoaded;
        protected void OnWindowLoaded(Window window)
        {
            if (WindowLoaded != null)
            {
                WindowLoaded(this, new WindowLoadedEventArgs() { Window = window });
            }
        }

        public static event EventHandler AssetSelectionChanged;
        protected void OnAssetSelectionChanged(List<Asset> assets)
        {
            if (AssetSelectionChanged != null)
            {
                AssetSelectionChanged(this, new AssetSelectionChangedEventArgs() { Assets = assets });
            }
        }

        public static event EventHandler PresentingStateChanged;
        protected void OnPresentingStateChanged(PresentingState state, Window window)
        {
            if (PresentingStateChanged != null)
            {
                PresentingStateChanged(this, new PresentingStateChangedEventArgs() 
                { 
                    PresentingState = state,
                    Window = window
                });
            }
        }

        public static event EventHandler PresentingAssetChanged;
        protected void OnPresentingAssetChangedChanged(PresentingAction action, Asset asset)
        {
            if (PresentingAssetChanged != null)
            {
                PresentingAssetChanged(this, new PresentingAssetChangedEventArgs()
                {
                    Action = action,
                    Asset = asset
                });
            }
        }

        private void TextButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            TextButtonClickedEventArgs arg = (TextButtonClickedEventArgs)e;

            switch (arg.Action)
            {
                case "OpenStyles":
                    StylesWindow window_styles = new StylesWindow();
                    window_styles.ThemeChanged += new EventHandler(OnThemeChanged);
                    window_styles.MenuBarChanged += new EventHandler(OnMenuBarChanged);
                    window_styles.DisplayWidthChanged += new EventHandler(OnDisplayWidthChanged);
                    SurrenderFocus(window_styles);
                    break;
                case "OpenAssets":
                    AssetWindow window_assets = new AssetWindow();
                    window_assets.AssetListChanged += new EventHandler(OnAssetListChanged);
                    SurrenderFocus(window_assets);
                    break;
                case "PresentAsset":              
                    StartPresenting();
                    break;
                case "OpenFilters":
                    break;
                default:
                    break;
            }
        }

        private void StopPresenting(object sender, EventArgs e)
        {
            StyleManager.SetWindowState(this, "StopPresenting");
            OnPresentingStateChanged(PresentingState.STOP, this);
        }

        private void StartPresenting()
        {
            this.Visibility = Visibility.Hidden;
            StyleManager.SetWindowState(this, "Present");
            OnPresentingStateChanged(PresentingState.START, this);
            PresentWindow window_presents = new PresentWindow(SelectedAssets);
            this.Visibility = Visibility.Visible;
            SurrenderFocus(window_presents);
            window_presents.Closed += new EventHandler(StopPresenting);
            window_presents.NextAsset += new EventHandler(NextAsset);
            window_presents.PreviousAsset += new EventHandler(PrevAsset);
            window_presents.SelectedAsset += new EventHandler(SelectedAsset);
        }

        private void SelectedAsset(object sender, EventArgs e)
        {
            OnPresentingAssetChangedChanged(PresentingAction.SELECTED, ((PresentWindow)sender).selectedAsset);
        }

        private void NextAsset(object sender, EventArgs e)
        {
            OnPresentingAssetChangedChanged(PresentingAction.NEXT, null);
        }

        private void PrevAsset(object sender, EventArgs e)
        {
            OnPresentingAssetChangedChanged(PresentingAction.PREVIOUS, null);
        }

        private void AssetSelectionChangedEventHandler(object sender, RoutedEventArgs e)
        {
            SelectedAssetChangedEventArgs arg = (SelectedAssetChangedEventArgs)e;
            OnAssetSelectionChanged(arg.Assets); 
            SelectedAssets = arg.Assets;
        }
    }
}
