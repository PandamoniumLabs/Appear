using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Events
{
    public class MenuBarChangedEventArgs : EventArgs
    {
        public string Position { get; set; }
    }
}
