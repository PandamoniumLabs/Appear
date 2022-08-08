using Appear.Data.DO;
using Appear.Data.DTO;
using Appear.Domain;
using Appear.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Appear.Data.Repos
{
    public class StyleRepository
    {
        public Style GetCurrentStyle()
        {
            Style result = null;
            StyleDTO style = null;

            using (var db = new AppearContext())
            {
                UserSettingsDTO settings = db.UserSettings.FirstOrDefault();

                if (settings != null)
                {
                    style = db.Styles.Where(x => x.Id == settings.StyleId).SingleOrDefault();
                }
                else
                {
                    style = db.Styles.Where(x => x.Name == "Default").SingleOrDefault();
                }
            }

            if (style != null)
            {
                result = style.ToStyle();
            }

            return result;
        }

        public List<Style> GetAll()
        {
            List<Style> result = new List<Style>();
            List<StyleDTO> styles = null;

            using (var db = new AppearContext())
            {
                styles = db.Styles.ToList();
            }

            foreach (var style in styles)
            {
                result.Add(style.ToStyle());
            }

            return result;
        }

        public Style GetStyleByName(string name)
        {
            Style result = null;
            StyleDTO style = null;

            using(var db = new AppearContext())
            {
                style = db.Styles.Where(x => x.Name.Equals(name)).SingleOrDefault();
            }

            if(style != null)
            {
                result=style.ToStyle();
            }

            return result;
        }
    }
}
