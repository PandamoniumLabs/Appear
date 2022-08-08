using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Events
{
    public class ThemeChangedEventArgs : EventArgs
    {
        public string Theme { get; set; }
    }
}
