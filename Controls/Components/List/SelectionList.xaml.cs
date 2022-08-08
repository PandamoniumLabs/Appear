using Appear.Core;
using Appear.Events;
using Appear.Events.Components;
using Appear.Services;
using Appear.Services.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Appear.Controls.List
{
    /// <summary>
    /// Interaction logic for SelectionList.xaml
    /// </summary>
    public partial class SelectionList : ObservableControl
    {
        #region PROPERTIES

        private bool hasText { get; set; } = false;
        public bool HasText
        {
            get { return hasText; }
            set { hasText = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> itemList;
        public ObservableCollection<string> ItemList
        {
            get { return itemList; }
            set { itemList = value; OnPropertyChanged(); }
        }

        public string SelectedItem
        {
            get { return (string)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                "SelectedItem",
                typeof(string),
                typeof(SelectionList),
                new UIPropertyMetadata(SelectedItemPropertyChangedHandler));

        public List<string> Source
        {
            get { return (List<string>)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register(
                "Source",
                typeof(List<string>),
                typeof(SelectionList),
                new UIPropertyMetadata(SourcePropertyChangedHandler));

        public static void SourcePropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            List<string> value = e.NewValue as List<string>;
            ((SelectionList)sender).Source = value;
            ((SelectionList)sender).ItemList = new ObservableCollection<string>(value);
        }

        public static void SelectedItemPropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            ((SelectionList)sender).SelectedItem = value;
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(SelectionList),
                new UIPropertyMetadata(TextPropertyChangedHandler));

        public static void TextPropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            ((SelectionList)sender).Text = value;
            ((SelectionList)sender).HasText = !string.IsNullOrEmpty(value);
        }

        public string Id
        {
            get { return (string)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public static readonly DependencyProperty IdProperty=
            DependencyProperty.Register(
                "Id",
                typeof(string),
                typeof(SelectionList),
                new UIPropertyMetadata(IdPropertyChangedHandler));

        public static void IdPropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            ((SelectionList)sender).Id = value;
        }
        #endregion

        public SelectionList()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent SelectionChangedEvent =
            EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(SelectionList));

        public event RoutedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value); }
            remove { RemoveHandler(SelectionChangedEvent, value); }
        }

        private void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            SelectedItem = (sender as ComboBox).SelectedValue as string;
            RaiseEvent(new SelectionListChangedEventArgs(SelectionChangedEvent, Id, SelectedItem));
        }
    }
}
