using Appear.Controls.Components.Buttons;
using Appear.Domain.Enum;
using Appear.Events.Components;
using Appear.Services.Data.Domain;
using Appear.Views.Dialogs;
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
using System.Windows.Shapes;

namespace Appear.Windows.Dialogs
{
    /// <summary>
    /// Interaction logic for CreateDialog.xaml
    /// </summary>
    public partial class CreateDialog : Window
    {
        private ViewMode viewMode { get; set; }
        private string name { get; set; }

        public CreateDialog(ViewMode viewMode)
        {
            Content = new CreateDialogView();

            Loaded += OnLoad;
            Unloaded += OnUnLoad;

            InitializeComponent();
            this.viewMode = viewMode;
        }

        private void OnUnLoad(object sender, RoutedEventArgs e)
        {
            RemoveHandler(IconButton.IconButtonClickedEvent, new RoutedEventHandler(IconButtonClickedEventHandler));
            RemoveHandler(TextButton.TextButtonClickedEvent, new RoutedEventHandler(TextButtonClickedEventHandler));
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            AddHandler(IconButton.IconButtonClickedEvent, new RoutedEventHandler(IconButtonClickedEventHandler));
            AddHandler(TextButton.TextButtonClickedEvent, new RoutedEventHandler(TextButtonClickedEventHandler));

            CreateDialogView.TextInputTextChanged += new EventHandler(OnTextInputTextChanged);
        }

        private void OnTextInputTextChanged(object sender, EventArgs e)
        {
            TextInputTextChangedEventArgs arg = (TextInputTextChangedEventArgs)e;

            switch (arg.Id)
            {
                case "AssetName":
                    name = arg.Text;
                    break;
            }
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

        private void TextButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            TextButtonClickedEventArgs arg = (TextButtonClickedEventArgs)e;

            switch (arg.Action)
            {
                case "CreateAction":
                    Create();
                    break;
            }
        }

        private void Create()
        {
            switch (viewMode)
            {
                case ViewMode.SCENES:
                    SceneManager.Create(name);
                    break;
                case ViewMode.TAGS:
                    TagManager.Create(name);
                    break;
            }
        }
    }
}
