using Appear.Core;
using Appear.Domain;
using Appear.Domain.Enum;
using Appear.Events;
using Appear.Services.Data;
using Appear.Services.Data.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Appear.Controls.Components.List
{
    public partial class ImageGrid : ObservableControl
    {
        private ObservableCollection<Asset> assets;
        public ObservableCollection<Asset> Assets
        {
            get { return assets; }
            set { assets = value; OnPropertyChanged(); }
        }

        private int columnCount { get; set; }
        public int ColumnCount
        {
            get { return columnCount; }
            set { columnCount = value; OnPropertyChanged(); }
        }

        private double viewWidth { get; set; }
        public double ViewWidth
        {
            get { return viewWidth; }
            set { viewWidth = value; OnPropertyChanged(); }
        }

        private DisplayWidth displayWidth { get; set; }
        public DisplayWidth DisplayWidth
        {
            get { return displayWidth; }
            set 
            { 
                displayWidth = value;
                ColumnCount = (int)Math.Floor(ViewWidth / DisplayWidth.ToDouble()); 
                OnPropertyChanged(); 
            }
        }

        public ObservableCollection<Asset> Source
        {
            get { return (ObservableCollection<Asset>)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register(
            "Source",
            typeof(ObservableCollection<Asset>),
            typeof(ImageGrid),
            new UIPropertyMetadata(SourcePropertyChangedHandler)
        );

        public static void SourcePropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((ImageGrid)sender).Assets = e.NewValue as ObservableCollection<Asset>;
        }

        public ImageGrid()
        {
            MainWindow.WindowWidthChanged += new EventHandler(WindowWidthChangedEventHandler);
            MainWindow.DisplayWidthChanged += new EventHandler(DisplayWidthChangedEventHandler);

            InitializeComponent();
        }

        public void SetWidth(Window window)
        {
            ViewWidth = window.Width - 500;
            DisplayWidth = SettingsManager.UserSettings().DisplayWidth;
        }

        public static readonly RoutedEvent SelectionChangedEvent =
            EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ImageGrid));

        public event RoutedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value); }
            remove { RemoveHandler(SelectionChangedEvent, value); }
        }

        public void OnAssetSelectionChanged(object sender, RoutedEventArgs e)
        {
            List<Asset> assets = new List<Asset>() { (sender as ListView).SelectedItem as Asset };
            RaiseEvent(new SelectedAssetChangedEventArgs(SelectionChangedEvent, assets));
        }

        private void WindowWidthChangedEventHandler(object sender, EventArgs e)
        {
            WindowWidthChangedEventArgs arg = (WindowWidthChangedEventArgs)e;
            ViewWidth = arg.Width - 500;
            DisplayWidth = SettingsManager.UserSettings().DisplayWidth;
        }

        private void DisplayWidthChangedEventHandler(object sender, EventArgs e)
        {
            DisplayWidth = SettingsManager.UserSettings().DisplayWidth;
        }
    }
}
