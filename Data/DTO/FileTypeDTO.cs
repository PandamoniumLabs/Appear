using Appear.Data.Repos;
using Appear.Domain;
using Appear.Services.Data.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.DTO
{
    [Table("fileTypes")]

    public class FileTypeDTO
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("extension")]
        public string Extension { get; set; }

        [Column("mediaTypeId")]
        public int MediaTypeId { get; set; }

        public FileType ToFileType()
        {
            return new FileType()
            {
                Id = Id,
                Extension = Extension,
                MediaType = MediaTypeManager.Get(MediaTypeId)
            };
        }
    }
}
