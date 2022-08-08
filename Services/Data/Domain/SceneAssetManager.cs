using Appear.Data.Repos;
using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Services.Data.Domain
{
    public static class SceneAssetManager
    {
        private static SceneAssetRepository _repository = null;
        private static SceneAssetRepository repository()
        {
            if (_repository == null) _repository = new SceneAssetRepository();
            return _repository;
        }

        public static List<SceneAssetDTO> GetByAsset(int assetId)
        {
            return repository().GetByAsset(assetId);
        }

        public static List<SceneAssetDTO> GetByScene(int sceneId)
        {
            return repository().GetByScene(sceneId);
        }

        public static void AddReference(SceneAssetDTO sceneAsset)
        {
            repository().Add(sceneAsset);
        }

        public static void RemoveReferences(Asset asset)
        {
            List<SceneAssetDTO> sceneAssets = repository().GetByAsset(asset.Id);
            if (sceneAssets != null)
            {
                foreach (SceneAssetDTO dto in sceneAssets)
                {
                    repository().Remove(dto);
                }
            }
        }
    }
}
