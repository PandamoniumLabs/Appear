using Appear.Core;
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

namespace Appear.Controls.Components.Buttons
{
    /// <summary>
    /// Interaction logic for CheckBoxButton.xaml
    /// </summary>
    public partial class CheckBoxButton : ObservableControl
    {
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string Id
        {
            get { return (string)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(CheckBoxButton),
                new UIPropertyMetadata(""));

        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register(
                "Id",
                typeof(string),
                typeof(CheckBoxButton),
                new UIPropertyMetadata(IdPropertyChangedHandler));

        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register(
                "IsChecked",
                typeof(bool),
                typeof(CheckBoxButton),
                new UIPropertyMetadata(IsCheckedPropertyChangedHandler));

        public static void IsCheckedPropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((CheckBoxButton)sender).IsChecked = (bool)e.NewValue;
        }


        public static void IdPropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((CheckBoxButton)sender).Id = (string)e.NewValue;
        }

        public CheckBoxButton()
        {         
            InitializeComponent();
            
        }

        private void HandleChecked(object sender, RoutedEventArgs e)
        {
            HandleCheckboxToggle(true);
        }

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {
            HandleCheckboxToggle(false);
        }

        private void HandleCheckboxToggle(bool isChecked)
        {
            RaiseEvent(new CheckBoxToggledEventArgs(CheckboxToggledEvent, isChecked, Id));
        }

        public static readonly RoutedEvent CheckboxToggledEvent =
            EventManager.RegisterRoutedEvent("CheckboxToggled", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(CheckBoxButton));

        public event RoutedEventHandler CheckboxToggled
        {
            add { AddHandler(CheckboxToggledEvent, value); }
            remove { RemoveHandler(CheckboxToggledEvent, value); }
        }
    }
}
