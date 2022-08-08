using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.Repos
{
    public class SceneAssetRepository
    {
        public void Add(SceneAssetDTO dto)
        {
            using(var db = new AppearContext())
            {
                db.SceneAssets.Add(dto);
                db.SaveChanges();
            }
        }

        public void Remove(SceneAssetDTO dto)
        {
            using (var db = new AppearContext())
            {
                db.SceneAssets.Remove(dto);
                db.SaveChanges();
            }
        }

        public List<SceneAssetDTO> GetByAsset(int assetId)
        {
            using (var db = new AppearContext())
            {
                return db.SceneAssets.Where(x => x.AssetId == assetId).ToList();
            }
        }

        public List<SceneAssetDTO> GetByScene(int sceneId)
        {
            using (var db = new AppearContext())
            {
                return db.SceneAssets.Where(x => x.SceneId == sceneId).ToList();
            }
        }
    }
}
