using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Appear.Data.DTO
{
    [Table("colors")]
    public class ColorDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("R")]
        public int R { get; set; }

        [Column("G")]
        public int G { get; set; }

        [Column("B")]
        public int B { get; set; }

        public Color ToColor()
        {
            return Color.FromRgb((byte)R, (byte)G, (byte)B);
        }
    }
}
