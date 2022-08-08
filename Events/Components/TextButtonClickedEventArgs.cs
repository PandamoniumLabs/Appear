using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Appear.Events.Components
{
    public class TextButtonClickedEventArgs : RoutedEventArgs
    {
        private string action;
        public string Action { get { return action; } }

        public TextButtonClickedEventArgs(RoutedEvent e, string action) : base(e)
        {
            this.action = action;
        }
    }
}
