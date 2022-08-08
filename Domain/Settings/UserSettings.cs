using Appear.Data.DO;
using Appear.Domain.Enum;
using Appear.Domain.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Domain.Settings
{
    public class UserSettings
    {
        public int Id { get; set; }
        public DockPosition DockPosition { get; set; }
        public DisplayWidth DisplayWidth { get; set; }
        public bool MaximizeOnStart { get; set; }
        public bool UpdateOnStart { get; set; }

        public int StyleId { get; set; }

        public UserSettingsDTO ToDTO() => new UserSettingsDTO()
        {
            Id = Id,
            DockPosition = System.Enum.GetName(typeof(DockPosition), DockPosition),
            DisplayWidth = System.Enum.GetName(typeof(DisplayWidth), DisplayWidth),
            StyleId = StyleId,
            MaximizeOnStart = Convert.ToInt32(MaximizeOnStart),
            UpdateOnStart = Convert.ToInt32(UpdateOnStart),
        };
    }
}
