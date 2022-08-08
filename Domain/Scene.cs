using Appear.Data.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Domain
{
    public class Scene
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SceneDTO ToDTO()
        {
            return new SceneDTO()
            {
                Name = Name,
                Id = Id
            };
        } 
    }
}
