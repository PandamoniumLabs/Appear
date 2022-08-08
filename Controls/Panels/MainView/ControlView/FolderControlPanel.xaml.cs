using Appear.Core;
using Appear.Services.Data.Domain;
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

namespace Appear.Controls.Panels.MainView.ControlView
{
    public partial class FolderControlPanel : ObservableControl
    {
        private bool hasScenes { get; set; } = SceneManager.HasScenes();
        private bool hasTags { get; set; } = TagManager.HasTags();

        public bool HasTags
        {
            get { return hasTags; }
            set { hasTags = value; OnPropertyChanged(); }
        }

        public bool HasScenes
        {
            get { return hasScenes; }
            set { hasScenes = value; OnPropertyChanged(); }
        }

        private List<string> tags { get; set; } = TagManager.GetTagNames();
        public List<string> Tags
        {
            get { return tags; }
            set { tags = value; OnPropertyChanged(); }
        }

        private List<string> scenes { get; set; } = SceneManager.GetSceneNames();
        public List<string> Scenes
        {
            get { return scenes; }
            set { scenes = value; OnPropertyChanged(); }
        }

        private string selectedScene { get; set; }
        public string SelectedScene
        {
            get { return selectedScene; }
            set { selectedScene = value; OnPropertyChanged(); }
        }

        private string selectedTag { get; set; }
        public string SelectedTag
        {
            get { return selectedTag; }
            set { selectedTag = value; OnPropertyChanged(); }
        }

        public FolderControlPanel()
        {
            if(scenes.Count != 0) SelectedScene = scenes[0];
            if(tags.Count != 0) SelectedTag = tags[0];

            InitializeComponent();
        }
    }
}
