using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Appear.Events.Windows
{
    public class WindowLoadedEventArgs : EventArgs
    {
        public Window Window { get; set; }
    }
}
