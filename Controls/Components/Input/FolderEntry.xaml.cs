using Appear.Controls.Components.Buttons;
using Appear.Events;
using Appear.Events.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Appear.Controls.Components.Input
{
    /// <summary>
    /// Interaction logic for FolderDialog.xaml
    /// </summary>
    public partial class FolderEntry : System.Windows.Controls.UserControl
    {
        public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(FolderEntry), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public static DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(FolderEntry), new PropertyMetadata(null));

        public string Text { get { return GetValue(TextProperty) as string; } set { SetValue(TextProperty, value); } }
        public string Description { get { return GetValue(DescriptionProperty) as string; } set { SetValue(DescriptionProperty, value); } }

        public FolderEntry() 
        {
            InitializeComponent();
            AddHandler(TextButton.TextButtonClickedEvent, new RoutedEventHandler(TextButtonClickedEventHandler));
        }

        private void TextButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            TextButtonClickedEventArgs arg = (TextButtonClickedEventArgs)e;

            switch (arg.Action)
            {
                case "AddAsset":
                    RaiseEvent(new UpdateFoldersEventArgs(UpdateAssetsEvent, Text, UpdateFoldersEventArgs.ActionType.ADD));
                    break;
                default:
                    break;
            }
        }

        public static readonly RoutedEvent UpdateAssetsEvent=
            EventManager.RegisterRoutedEvent("UpdateAssets", RoutingStrategy.Bubble,
                typeof(RoutedEventHandlerInfo), typeof(FolderEntry));

        public event RoutedEventHandler UpdateAssets
        {
            add { AddHandler(UpdateAssetsEvent, value); }
            remove { RemoveHandler(UpdateAssetsEvent, value); }
        }

        private void BrowseFolder(object sender, RoutedEventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = Description;
                dlg.SelectedPath = Text;
                dlg.ShowNewFolderButton = true;
                DialogResult result = dlg.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Text = dlg.SelectedPath;
                    RaiseEvent(new UpdateFoldersEventArgs(UpdateAssetsEvent, Text, UpdateFoldersEventArgs.ActionType.ADD));
                }
            }
        }
    }
}
