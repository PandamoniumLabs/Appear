using Appear.Data.DTO;
using Appear.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Appear.Data.DTO.AppSettingsDTO;

namespace Appear.Data.Repos
{
    public class ApplicationSettingsRepository
    {
        public AppSettings Get()
        {
            AppSettings result = null;
            AppSettingsDTO appSettings = null;

            using(var db = new AppearContext())
            {
                appSettings = db.AppSettings.FirstOrDefault();
            }

            if(appSettings != null)
            {
                result = appSettings.ToAppSettings();
            }

            return result;
        }
    }
}
