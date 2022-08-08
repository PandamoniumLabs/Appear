using Appear.Core;
using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Appear.Controls.Panels.PresentView
{
    /// <summary>
    /// Interaction logic for PicturePreview.xaml
    /// </summary>
    public partial class PicturePreviewPanel : ObservableControl
    {
        private int previewIndex = 0;

        private string previousPath { get; set; }
        private string currentPath { get; set; }
        private string nextPath { get; set; }

        public string PreviousPath
        {
            get { return previousPath; }
            set { previousPath = value; OnPropertyChanged(); }
        }

        public string CurrentPath
        {
            get { return currentPath; }
            set { currentPath = value; OnPropertyChanged(); }
        }

        public string NextPath
        {
            get { return nextPath; }
            set { nextPath = value; OnPropertyChanged(); }
        }   

        public void NextPreview()
        {
            UpdateIndex(1);
            UpdatePreviews();
        }

        public void PreviousPreview()
        {
            UpdateIndex(-1);
            UpdatePreviews();
        }

        public ObservableCollection<Asset> Assets
        {
            get { return (ObservableCollection<Asset>)GetValue(AssetsProperty);}
            set { SetValue(AssetsProperty, value); }
        }

        public static readonly DependencyProperty AssetsProperty =
            DependencyProperty.Register(
            "Assets",
            typeof(ObservableCollection<Asset>),
            typeof(PicturePreviewPanel),
            new UIPropertyMetadata(AssetPropertyChangedHandler)
        );

        public static void AssetPropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as PicturePreviewPanel).UpdatePreviews();
        }

        public PicturePreviewPanel()
        {
            //Assets = new ObservableCollection<Asset>();
            InitializeComponent();
        }

        private void UpdateIndex(int dir)
        {
            previewIndex += dir;
            if(previewIndex > Assets.Count - 1)
            {
                previewIndex = 0;
            }
            else if(previewIndex < 0)
            {
                previewIndex = Assets.Count - 1;
            }
        }

        private void UpdatePreviews()
        {
            if(Assets != null && Assets.Count > 0)
            {
                CurrentPath = Assets[previewIndex].Path;
                NextPath = GetNextPath();
                PreviousPath = GetPreviousPath();
            }
        }

        private string GetNextPath()
        {
            string value = "";

            if(Assets != null && Assets.Count > 1)
            {
                if(previewIndex == Assets.Count - 1)
                {
                    value = Assets[0].Path;
                }
                else
                {
                    value = Assets[previewIndex+1].Path;
                }
            }

            return value;
        }

        private string GetPreviousPath()
        {
            string value = "";

            if(Assets != null  && Assets.Count > 1)
            {
                if(previewIndex == 0)
                {
                    value = Assets[Assets.Count - 1].Path;
                }
                else
                {
                    value = Assets[previewIndex -1].Path;
                }
            }

            return value;
        }

        public void SelectedAsset(Asset asset)
        {
            previewIndex = Assets.IndexOf(asset);
            UpdatePreviews();
        }
    }
}
