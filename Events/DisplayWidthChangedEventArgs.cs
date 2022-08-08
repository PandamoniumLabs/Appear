using Appear.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Events
{
    public class DisplayWidthChangedEventArgs : EventArgs
    {
        public string DisplayWidth { get; set; }
    }
}
