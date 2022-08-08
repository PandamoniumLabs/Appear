using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appear.Domain
{
    public class MediaType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
