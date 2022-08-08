using Appear.Controls.Components.List;
using Appear.Controls.Panels.MainView;
using Appear.Core;
using Appear.Events;
using Appear.Services;
using Appear.Services.Data.Domain;
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

namespace Appear.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : ObservablePage
    {
        private string dockPosition { get; set; } = StyleManager.GetUserSettings().DockPosition.ToString();
        public string DockPosition
        {
            get { return dockPosition; }
            set { dockPosition = value; OnPropertyChanged(); }
        }

        private bool hasAssets { get; set; } = FolderManager.HasFolders();
        public bool HasAssets
        {
            get { return hasAssets; }
            set { hasAssets = value; OnPropertyChanged(); }
        }

        private bool isPresenting { get; set; } = false;
        public bool IsPresenting
        {
            get { return isPresenting; }
            set { isPresenting = value; OnPropertyChanged(); }
        }

        public MainView()
        {
            Loaded += OnLoad;
            InitializeComponent();
            Unloaded += OnUnLoad;
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            MainWindow.PresentingStateChanged += new EventHandler(OnPresentingStateChanged);
        }

        private void OnUnLoad(object sender, RoutedEventArgs e)
        {
            MainWindow.PresentingStateChanged -= new EventHandler(OnPresentingStateChanged);
        }

        private void OnPresentingStateChanged(object sender, EventArgs e)
        {
            PresentingStateChangedEventArgs arg = (PresentingStateChangedEventArgs)e;
            switch (arg.PresentingState)
            {
                case PresentingState.START:
                    IsPresenting = true;
                    break;
                case PresentingState.STOP:
                    IsPresenting = false;
                    break;
            }
        }
    }
}
