using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Appear.Events.Components
{
    public class CheckBoxToggledEventArgs : RoutedEventArgs
    {
        private bool isChecked { get; set; }
        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }

        private string id { get; set; }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public CheckBoxToggledEventArgs(RoutedEvent e, bool isChecked, string id) : base(e)
        {
            this.id = id;
            this.isChecked = isChecked;
        }
    }
}
