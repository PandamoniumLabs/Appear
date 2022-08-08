using Appear.Data.Repos;
using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Services.Data.Domain
{
    public static class AssetTagManager
    {
        private static AssetTagRepository _repository = null;
        private static AssetTagRepository repository()
        {
            if (_repository == null) _repository = new AssetTagRepository();
            return _repository;
        }

        public static List<AssetTagDTO> GetByAsset(int assetId)
        {
            return repository().GetByAsset(assetId);
        }

        public static List<AssetTagDTO> GetByTag(int tagId)
        {
            return repository().GetByTag(tagId);
        }

        public static void RemoveReferences(Asset asset)
        {
            List<AssetTagDTO> assetTags = GetByAsset(asset.Id);
            if (assetTags != null)
            {
                foreach (AssetTagDTO dto in assetTags)
                {
                    repository().Remove(dto);
                }
            }
        }
    }
}
