using Appear.Controls.Components.Buttons;
using Appear.Core;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Appear.Views.Dialogs
{
    public partial class CreateDialogView : ObservablePage
    {
        private string text { get; set; }
        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged(); }
        }

        public CreateDialogView()
        {
            InitializeComponent();
        }

        public static event EventHandler TextInputTextChanged;
        protected void OnTextInputTextChanged(string input)
        {
            if (TextInputTextChanged != null)
            {
                TextInputTextChanged(this, new TextInputTextChangedEventArgs() { Text = input, Id = "AssetName" });
            }
        }

        private void OnNameBoxTextChanged(object sender, RoutedEventArgs e)
        {
            OnTextInputTextChanged(((TextBox)sender).Text);
        }
    }
}
