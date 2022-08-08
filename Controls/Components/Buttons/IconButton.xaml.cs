using Appear.Domain.Enum;
using Appear.Events;
using Appear.Events.Components;
using Appear.Services;
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

namespace Appear.Controls.Components.Buttons
{
    /// <summary>
    /// Interaction logic for IconButton.xaml
    /// </summary>
    public partial class IconButton : UserControl
    {
        public string Action
        {
            get { return (string)GetValue(ActionProperty); }
            set { SetValue(ActionProperty, value); }
        }

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set
            {
                SetValue(IconProperty, value);
            }
        }

        public static readonly DependencyProperty ActionProperty =
            DependencyProperty.Register(
                "Action",
                typeof(string),
                typeof(IconButton),
                new UIPropertyMetadata(ActionPropertyChangedHandler)
        );

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(
            "Icon",
            typeof(string),
            typeof(IconButton),
            new UIPropertyMetadata(IconPropertyChangedHandler)
        );

        public static void IconPropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
        }

        public static void ActionPropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
        }

        public IconButton()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent IconButtonClickedEvent = 
            EventManager.RegisterRoutedEvent("IconButtonClicked", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(IconButton));

        public event RoutedEventHandler IconButtonClicked
        {
            add { AddHandler(IconButtonClickedEvent, value); }
            remove { RemoveHandler(IconButtonClickedEvent, value); }
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new IconButtonClickedEventArgs(IconButtonClickedEvent, (IconButtonAction)Enum.Parse(typeof(IconButtonAction), Action)));
        }
    }
}
