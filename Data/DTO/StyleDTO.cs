using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Appear.Data.DTO
{
    [Table("styles")]
    public class StyleDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("backgroundcolorId")]
        public int BG_ColorId { get; set; }

        [Column("barcolorId")]
        public int Bar_ColorId { get; set; }

        [Column("buttoncolorId")]
        public int Button_ColorId { get; set; }

        [Column("buttonhighlightcolorId")]
        public int Button_HL_ColorId { get; set; }

        [Column("comboboxcolorId")]
        public int CBBox_ColorId { get; set; }

        public Domain.Settings.Style ToStyle()
        {
            using (var db = new AppearContext())
            {
                return new Domain.Settings.Style()
                {
                    Id = Id,
                    Name = Name,
                    BackgroundColor = new Tuple<string, Color>(
                        "Background", (db.Colors.Where(x => x.Id == BG_ColorId).SingleOrDefault()).ToColor()),
                    BarBackgroundColor = new Tuple<string, Color>(
                        "Background_Bar", db.Colors.Where(x => x.Id == Bar_ColorId).SingleOrDefault().ToColor()),
                    ButtonColor = new Tuple<string, Color>(
                        "Button_Base", db.Colors.Where(x => x.Id == Button_ColorId).SingleOrDefault().ToColor()),
                    ButtonHighLighColor = new Tuple<string, Color>(
                        "Button_HighLight", db.Colors.Where(x => x.Id == Button_HL_ColorId).SingleOrDefault().ToColor()),
                    ComboBoxColor = new Tuple<string, Color>(
                        "ComboBoxNormalBorderBrush", db.Colors.Where(x => x.Id == CBBox_ColorId).SingleOrDefault().ToColor()),
                };
            }
        }

    }
}
