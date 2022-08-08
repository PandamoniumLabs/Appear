using Appear.Controls.Components.Buttons;
using Appear.Core;
using Appear.Domain.Enum;
using Appear.Events;
using Appear.Events.Components;
using Appear.Events.Windows;
using System;
using System.Windows;

namespace Appear.Controls.Panels.MainView
{
    public partial class ViewCreatePanel : ObservableControl
    {
        private string text { get; set; }
        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged(); }
        }

        private ViewMode currentViewMode { get; set; }

        public ViewCreatePanel()
        {
            Loaded += OnLoad;
            Unloaded += OnUnLoad;

            InitializeComponent();
        }

        private void OnUnLoad(object sender, RoutedEventArgs e)
        {
            ViewPanel.ViewModeChanged -= new EventHandler(ViewModeChangedEventHandler);

            RemoveHandler(TextButton.TextButtonClickedEvent, new RoutedEventHandler(TextButtonClickedEventHandler));
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            ViewPanel.ViewModeChanged += new EventHandler(ViewModeChangedEventHandler);
    
            AddHandler(TextButton.TextButtonClickedEvent, new RoutedEventHandler(TextButtonClickedEventHandler));
        }

        private void TextButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            TextButtonClickedEventArgs args = (TextButtonClickedEventArgs)e;

            switch (args.Action)
            {
                case "CreateView":
                    OnOpenCreateDialog(currentViewMode);
                    break;
            }
        }

        public static event EventHandler OpenCreateDialog;
        protected void OnOpenCreateDialog(ViewMode viewMode)
        {
            if (OpenCreateDialog != null)
            {
                OpenCreateDialog(this, new OpenCreateDialogEventArgs() { ViewMode = viewMode });
            }
        }

        private void ViewModeChangedEventHandler(object sender, EventArgs e)
        {
            ViewModeChangedEventArgs arg = (ViewModeChangedEventArgs)e;
            SetMode(arg.ViewMode);
        }

        private void SetMode(ViewMode viewMode)
        {
            currentViewMode = viewMode;
            Text = String.Format("No {0} found. Click to add.", viewMode.ToString());
        }
    }
}
