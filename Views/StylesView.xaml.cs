using Appear.Core;
using Appear.Domain.Enum;
using Appear.Services;
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

namespace Appear.Views
{
    /// <summary>
    /// Interaction logic for StylesView.xaml
    /// </summary>
    public partial class StylesView : ObservablePage
    {
        private bool maxOnStartUp { get; set; } = StyleManager.GetUserSettings().MaximizeOnStart;
        public bool MaxOnStartUp
        {
            get { return maxOnStartUp; }
            set { maxOnStartUp = value; OnPropertyChanged(); }
        }

        private bool updateOnStartUp { get; set; } = StyleManager.GetUserSettings().UpdateOnStart;
        public bool UpdateOnStartUp
        {
            get { return updateOnStartUp; }
            set { updateOnStartUp = value; OnPropertyChanged(); }
        }

        private string currentDockPosition { get; set; } = StyleManager.GetUserSettings().DockPosition.ToString();
        public string CurrentDockPosition
        {
            get { return currentDockPosition; }
            set { currentDockPosition = value; OnPropertyChanged(); }
        }

        private string currentDisplayWidth { get; set; } = StyleManager.GetUserSettings().DisplayWidth.ToString();
        public string CurrentDisplayWidth
        {
            get { return currentDisplayWidth; }
            set { currentDisplayWidth = value; OnPropertyChanged(); }
        }

        private string currentStyle { get; set; } = StyleManager.CurrentStyle().Name;
        public string CurrentStyle
        {
            get { return currentStyle; }
            set { currentStyle = value; OnPropertyChanged(); }
        }

        private List<string> dockPositions { get; set; } = Enum.GetNames(typeof(DockPosition)).ToList();
        public List<string> DockPositions
        {
            get { return dockPositions; }
            set { dockPositions = value; OnPropertyChanged(); }
        }

        private List<string> displayWidths { get; set; } = Enum.GetNames(typeof(DisplayWidth)).ToList();
        public List<string> DisplayWidths
        {
            get { return displayWidths; }
            set { displayWidths = value; OnPropertyChanged(); }
        }

        private List<string> styles { get; set; } = StyleManager.GetStyleNames();
        public List<string> Styles
        {
            get { return styles; }
            set { styles = value; OnPropertyChanged(); }
        }

        public StylesView()
        {
            InitializeComponent();
        }
    }
}
