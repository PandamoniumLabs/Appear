using Appear.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Events.Windows
{
    public class OpenCreateDialogEventArgs: EventArgs
    {
        public ViewMode ViewMode { get; set; }
    }
}
