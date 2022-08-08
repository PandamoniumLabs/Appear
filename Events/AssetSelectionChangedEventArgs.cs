using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Events
{
    public class AssetSelectionChangedEventArgs : EventArgs
    {
        public List<Asset> Assets { get; set; }
    }
}
