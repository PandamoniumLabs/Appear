using Appear.Controls.Components.Buttons;
using Appear.Core;
using Appear.Domain.Enum;
using Appear.Events;
using Appear.Events.Components;
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
    public partial class ViewPanel : ObservableControl
    {
        private bool isScenesMode { get; set; } = false;
        public bool IsScenesMode
        {
            get { return isScenesMode; }
            set { isScenesMode = value; OnPropertyChanged(); }
        }
        private bool isExtensionsMode { get; set; } = false;
        public bool IsExtensionsMode
        {
            get { return isExtensionsMode; }
            set { isExtensionsMode = value; OnPropertyChanged(); }
        }
        private bool isFoldersMode { get; set; } = true;
        public bool IsFoldersMode
        {
            get { return isFoldersMode; }
            set
            {
                isFoldersMode = value;
                OnPropertyChanged();
            }
        }
        private bool isTagsMode { get; set; } = false;
        public bool IsTagsMode
        {
            get { return isTagsMode; }
            set
            {
                isTagsMode = value;
                OnPropertyChanged();
            }
        }

        public ViewPanel()
        {
            AddHandler(TextButton.TextButtonClickedEvent, new RoutedEventHandler(TextButtonClickedEventHandler));

            InitializeComponent();
        }

        private void TextButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            TextButtonClickedEventArgs arg = (TextButtonClickedEventArgs)e;

            switch (arg.Action)
            {
                case "SwitchView":
                    SetMode((ViewMode)Enum.Parse(typeof(ViewMode), ((TextButton)arg.OriginalSource).Text));
                    break;
            }
        }

        public static event EventHandler ViewModeChanged;
        protected void OnViewModeChanged(ViewMode viewMode)
        {
            if (ViewModeChanged != null)
            {
                ViewModeChanged(this, new ViewModeChangedEventArgs() { ViewMode = viewMode });
            }
        }

        public void SetMode(ViewMode viewMode)
        {
            IsFoldersMode = false;
            IsTagsMode = false;
            IsExtensionsMode = false;
            IsScenesMode = false;

            switch (viewMode)
            {
                case ViewMode.FOLDERS:
                    IsFoldersMode = true;
                    break;
                case ViewMode.SCENES:
                    IsScenesMode = true;
                    break;
                case ViewMode.EXTENSIONS:
                    IsExtensionsMode = true;
                    break;
                case ViewMode.TAGS:
                    IsTagsMode = true;
                    break;
            }

            OnViewModeChanged(viewMode);
        }
    }
}
