using Appear.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.DTO
{
    [Table("mediatypes")]

    public class MediaTypeDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public MediaType ToMediaType()
        {
            return new MediaType()
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
