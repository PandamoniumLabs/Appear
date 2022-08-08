using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appear.Domain
{
    [Table("assettags")]
    public class AssetTagDTO
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("tagId")]
        public int TagId { get; set; }

        [Column("assetId")]
        public int AssetId { get; set; }
    }
}
