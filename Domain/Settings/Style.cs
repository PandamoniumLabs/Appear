using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Appear.Domain.Settings
{
    public class Style
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Tuple<string, Color> BackgroundColor { get; set; }
        public Tuple<string, Color> BarBackgroundColor { get; set; }
        public Tuple<string, Color> ButtonColor { get; set; }
        public Tuple<string, Color> ButtonHighLighColor { get; set; }
        public Tuple<string, Color> ComboBoxColor { get; set; }   
        
        public Dictionary<string, Color> ColorPairs { 
            get{
                return new Dictionary<string, Color>()
                {
                    { BackgroundColor.Item1, BackgroundColor.Item2},
                    { BarBackgroundColor.Item1, BarBackgroundColor.Item2},
                    { ButtonColor.Item1, ButtonColor.Item2},
                    { ButtonHighLighColor.Item1, ButtonHighLighColor.Item2},
                    { ComboBoxColor.Item1, ComboBoxColor.Item2}
                };
            } 
        }
    }
}
