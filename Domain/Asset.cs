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
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int FolderId { get; set; }
        public int FileTypeId { get; set; }

        public AssetDTO ToDTO()
        {
            return new AssetDTO()
            {
                FileTypeId = this.FileTypeId,
                Id = this.Id,
                Name = this.Name,
                FolderId = this.FolderId
            };
        }
    }
}
