using Appear.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Domain
{
    public  class Folder
    {
        public string Path { get; set; }
        public int Id { get; set; }

        public FolderDTO ToDTO()
        {
            FolderDTO dto = new FolderDTO();
            dto.Path = Path;
            return dto;
        }
    }
}
