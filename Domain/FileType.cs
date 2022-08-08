using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appear.Domain
{
    public class FileType
    {
        public int Id { get; set; }
        public string Extension { get; set; }
        public MediaType MediaType { get; set; }
    }
}
