using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Appear.Events
{
    public class SelectedAssetChangedEventArgs: RoutedEventArgs
    {
        private List<Asset> assets { get; set; }
        public List<Asset> Assets 
        { 
            get { return assets; } 
            set { assets = value; }
        }

        public SelectedAssetChangedEventArgs(RoutedEvent e, List<Asset> assets) : base(e)
        {
            this.assets = assets;
        }
    }
}
