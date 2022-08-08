using Appear.Data.DO;
using Appear.Data.DTO;
using Appear.Domain;
using Appear.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data
{
    public class AppearContext : DbContext
    {
        public AppearContext() : base(new SQLiteConnection()
        {
            ConnectionString = new SQLiteConnectionStringBuilder()
            {
                DataSource = "C:\\Users\\joryj\\Desktop\\appeardb.db",
                ForeignKeys = true
            }.ConnectionString
        }, true)
        {
            
        }

        public DbSet<AssetDTO> Assets { get; set; }
        public DbSet<FolderDTO> Folders { get; set; }
        public DbSet<FileTypeDTO> FileTypes { get; set; }
        public DbSet<MediaTypeDTO> MediaTypes { get; set; }
        public DbSet<SceneDTO> Scenes { get; set; }
        public DbSet<TagDTO> Tags { get; set; }

        public DbSet<SceneAssetDTO> SceneAssets { get; set; }
        public DbSet<AssetTagDTO> AssetTags { get; set; }


        public DbSet<ColorDTO> Colors { get; set; }
        public DbSet<StyleDTO> Styles { get; set; }

        public DbSet<UserSettingsDTO> UserSettings { get; set; }
        public DbSet<AppSettingsDTO> AppSettings { get; set; }
    }
}
