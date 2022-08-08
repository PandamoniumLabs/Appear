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
    [Table("scenes")]
    public class SceneDTO
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public Scene ToScene()
        {
            return new Scene()
            {
                Id = Id,
                Name = Name,
            };
        }
    }
}
