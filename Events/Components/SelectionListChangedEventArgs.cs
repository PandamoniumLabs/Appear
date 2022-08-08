using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Appear.Events.Components
{
    public class SelectionListChangedEventArgs : RoutedEventArgs
    {
        private string id { get; set; }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string value { get; set; }
        public string Value 
        { 
            get { return value; } 
            set { this.value = value; }
        }

        public SelectionListChangedEventArgs(RoutedEvent e, string id, string value) : base(e)
        {
            this.id = id;
            this.value = value;
        }
    }
}
