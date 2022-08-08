using Appear.Core;
using Appear.Services.Data.Domain;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Appear.Controls.Panels.AssetView
{
    public partial class AssetFolderListPanel : ObservableControl
    {
        private ObservableCollection<string> folders { get; set; }
        public ObservableCollection<string> Folders
        {
            get { return folders; }
            set { folders = value; OnPropertyChanged(); }
        }

        public AssetFolderListPanel()
        {
            SetFolderList();
            InitializeComponent();
        }

        private void SetFolderList()
        {
            if (FolderManager.HasFolders())
            {
                Folders = new ObservableCollection<string>(FolderManager.GetFolderPaths());
            }
            else
            {
                Folders = new ObservableCollection<string>();
            }
        }

        public void UpdateFoldersventHandler()
        {
            SetFolderList();
        }
    }
}