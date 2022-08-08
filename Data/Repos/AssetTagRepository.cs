using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.Repos
{
    public class AssetTagRepository
    {
        public void Add(AssetTagDTO dto)
        {
            using (var db = new AppearContext())
            {
                db.AssetTags.Add(dto);
                db.SaveChanges();
            }
        }

        public void Remove(AssetTagDTO dto)
        {
            using (var db = new AppearContext())
            {
                db.AssetTags.Remove(dto);
                db.SaveChanges();
            }
        }

        public List<AssetTagDTO> GetByAsset(int assetId)
        {
            using (var db = new AppearContext())
            {
                return db.AssetTags.Where(x => x.AssetId == assetId).ToList();
            }
        }

        public List<AssetTagDTO> GetByTag(int tagId)
        {
            using (var db = new AppearContext())
            {
                return db.AssetTags.Where(x => x.TagId == tagId).ToList();
            }
        }
    }
}
