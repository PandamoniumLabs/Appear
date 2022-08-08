using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Domain
{
    public class AssetCollection
    {
        public ObservableCollection<Asset> Assets { get; set; }
        public string Path { get; set; }
    }
}
