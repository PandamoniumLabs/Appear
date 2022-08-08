using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Events
{
    public class PresentingAssetChangedEventArgs : EventArgs
    {
        public Asset Asset { get; set; }
        public PresentingAction Action { get; set; }
    }

    public enum PresentingAction
    {
        NEXT,
        PREVIOUS,
        SELECTED
    }
}
