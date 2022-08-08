using Appear.Data.DTO;
using Appear.Domain;
using Appear.Services.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.Repos
{
    public class AssetRepository
    {
        public bool HasAssets()
        {
            bool result = false;

            using(var db = new AppearContext())
            {
                result = (db.Assets.Count() > 0);
            }

            return result;
        }

        public void Add(Asset asset)
        {
            using (var db = new AppearContext())
            {
                db.Assets.Add(asset.ToDTO());
                db.SaveChanges();
            }
        }

        public void Remove(Asset asset)
        {
            using (var db = new AppearContext())
            {
                db.Assets.Remove(asset.ToDTO());
                db.SaveChanges();
            }
        }

        public List<Asset> GetByFolder(int folderId)
        {
            List<Asset> result = new List<Asset>();
            List<AssetDTO> assets = new List<AssetDTO>();

            using(var db = new AppearContext())
            {
                assets.AddRange(db.Assets.Where(x => x.FolderId == folderId));
                foreach (AssetDTO asset in assets)
                {
                    result.Add(asset.ToAsset());
                }
            }

            return result;
        }

        public Asset Get(int assetId)
        {
            Asset result = null;
            AssetDTO asset = null;

            using (var db = new AppearContext())
            {
                asset = db.Assets.Where(x => x.Id == assetId).FirstOrDefault();
            }

            if(asset != null)
            {
                result = asset.ToAsset();
            }

            return result;
        }

        public List<Asset> GetByScene(int sceneId)
        {
            List<Asset> result = new List<Asset>();
            List<SceneAssetDTO> coupling = SceneAssetManager.GetByScene(sceneId);

            using (var db = new AppearContext())
            {         
                foreach (var couple in coupling)
                {
                    result.Add(Get(couple.AssetId));
                }
            }

            return result;
        }

        public List<Asset> GetByTag(int tagId)
        {
            List<Asset> result = new List<Asset>();
            List<AssetTagDTO> coupling = AssetTagManager.GetByTag(tagId);

            using (var db = new AppearContext())
            {
                foreach (var couple in coupling)
                {
                    result.Add(Get(couple.AssetId));
                }
            }

            return result;
        }
    }
}
