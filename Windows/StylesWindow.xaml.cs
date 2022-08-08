using Appear.Controls.Components.Buttons;
using Appear.Controls.List;
using Appear.Domain.Enum;
using Appear.Events;
using Appear.Events.Components;
using Appear.Services.Data;
using Appear.Views;
using System;
using System.Windows;

namespace Appear.Windows
{
    /// <summary>
    /// Interaction logic for StylesWindow.xaml
    /// </summary>
    public partial class StylesWindow : Window
    {
        public event EventHandler ThemeChanged;
        protected void OnThemeChanged(string theme)
        {
            if(ThemeChanged != null)
            {
                ThemeChanged(this, new ThemeChangedEventArgs() { Theme = theme});
            }
        }

        public event EventHandler DisplayWidthChanged;
        protected void OnDisplayWidthChanged(string displayWidth)
        {
            if (DisplayWidthChanged != null)
            {
                DisplayWidthChanged(this, new DisplayWidthChangedEventArgs() { DisplayWidth = displayWidth });
            }
        }

        public event EventHandler MenuBarChanged;
        protected void OnMenuBarChanged(string position)
        {
            if (MenuBarChanged != null)
            {
                MenuBarChanged(this, new MenuBarChangedEventArgs() { Position = position });
            }
        }

        public StylesWindow()
        {
            Content = new StylesView();
            InitializeComponent();

            AddHandler(IconButton.IconButtonClickedEvent, new RoutedEventHandler(IconButtonClickedEventHandler));
            AddHandler(SelectionList.SelectionChangedEvent, new RoutedEventHandler(SelectionChangedEventHandler));
            AddHandler(CheckBoxButton.CheckboxToggledEvent, new RoutedEventHandler(CheckBoxToggledEventHandler));
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

        private void SelectionChangedEventHandler(object sender, RoutedEventArgs e)
        {
            SelectionListChangedEventArgs arg = (SelectionListChangedEventArgs)e;

            switch (arg.Id)
            {
                case "Style":
                    this.OnThemeChanged(arg.Value);
                    break;
                case "DockPosition":
                    this.OnMenuBarChanged(arg.Value);
                    break;
                case "DisplayWidth":
                    this.OnDisplayWidthChanged(arg.Value);
                    break;
                default:
                    break;
            }               
        }

        private void CheckBoxToggledEventHandler(object sender, RoutedEventArgs e)
        {
            CheckBoxToggledEventArgs arg = (CheckBoxToggledEventArgs)e;

            switch (arg.Id)
            {
                case "StartUpMax":
                    SettingsManager.SetMaxOnStart(arg.IsChecked);
                    break;
                case "StartUpUpdate":
                    SettingsManager.SetUpdateOnStart(arg.IsChecked);
                    break;
                default:
                    break;
            }
        }

    }
}