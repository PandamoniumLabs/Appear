using Appear.Controls.Components.Buttons;
using Appear.Events;
using Appear.Events.Components;
using Appear.Views;
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
    /// Interaction logic for OkWindow.xaml
    /// </summary>
    public partial class OkDialog : Window
    {
        public OkDialog(string text)
        {
            Content = new OkDialogView(text);
            InitializeComponent();

            AddHandler(TextButton.TextButtonClickedEvent, new RoutedEventHandler(TextButtonClickedEventHandler));
        }

        private void TextButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            TextButtonClickedEventArgs arg = (TextButtonClickedEventArgs)e;

            switch (arg.Action)
            {
                case "CloseDialog":
                    Close();
                    break;
                default:
                    break;
            }
        }
    }
}
