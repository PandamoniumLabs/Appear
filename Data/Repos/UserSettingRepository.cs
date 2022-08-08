using Appear.Data.DO;
using Appear.Domain.Enum;
using Appear.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.Repos
{
    public class UserSettingRepository
    {
        public UserSettings GetUserSettings()
        {
            UserSettings result = null;
            UserSettingsDTO settings = null;

            using (var db = new AppearContext())
            {
                settings = db.UserSettings.FirstOrDefault();
            }

            if(settings != null)
            {
                result = settings.ToUserSettings();
            }

            return result;
        }

        public void Update(UserSettings settings)
        {
            UserSettingsDTO dto = settings.ToDTO();

            using (var db = new AppearContext())
            {
                var rec = db.UserSettings.Single(x => x.Id == settings.Id);
                rec.UpdateOnStart = dto.UpdateOnStart;
                rec.DockPosition = dto.DockPosition;
                rec.MaximizeOnStart = dto.MaximizeOnStart;
                rec.StyleId = dto.StyleId;
                rec.DisplayWidth = dto.DisplayWidth;
                db.SaveChanges();
            }
        }
    }
}
