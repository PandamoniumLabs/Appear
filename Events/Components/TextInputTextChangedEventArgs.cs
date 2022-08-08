using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Events.Components
{
    public class TextInputTextChangedEventArgs: EventArgs
    {
        public string Text { get; set; }
        public string Id { get; set; }
    }
}
