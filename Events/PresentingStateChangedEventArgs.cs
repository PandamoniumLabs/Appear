using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Appear.Events
{
    public class PresentingStateChangedEventArgs : EventArgs
    {
        public PresentingState PresentingState { get; set; }
        public Window Window { get; set; }
    }

    public enum PresentingState
    {
        START,
        STOP
    }
}
