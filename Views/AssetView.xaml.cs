using Appear.Controls;
using Appear.Controls.Panels.AssetView;
using Appear.Core;
using Appear.Events;
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
    /// Interaction logic for AssetView.xaml
    /// </summary>
    public partial class AssetView : Page
    {
        public AssetFolderListPanel AssetList
        {
            get
            {
                return this.GetChildOfType<AssetFolderListPanel>();
            }
        }

        public AssetView()
        {
            InitializeComponent();
        }
    }
}
