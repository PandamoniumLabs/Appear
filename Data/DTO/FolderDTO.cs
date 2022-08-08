using Appear.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.DTO
{
    [Table("folders")]
    public class FolderDTO
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }
        [Column("path")]
        public string Path { get; set; }

        public Folder ToFolder()
        {
            return new Folder()
            {
                Id = Id,
                Path = Path
            };
        }
    }
}
