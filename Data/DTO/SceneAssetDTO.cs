using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appear.Domain
{
    [Table("sceneassets")]
    public class SceneAssetDTO
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("sceneId")]
        public int SceneId { get; set; }

        [Column("assetId")]
        public int AssetId { get; set; }
    }
}
