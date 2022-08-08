using Appear.Domain.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.DTO
{
    [Table("appsettings")]
    public class AppSettingsDTO
    {
        [Key]
        [Column("version")]
        public string Version { get; set; }

        [Column("release")]
        public string Release { get; set; }

        public AppSettings ToAppSettings()
        {
            return new AppSettings()
            {
                Release = Release,
                Version = Version
            };
        }
    }
}
