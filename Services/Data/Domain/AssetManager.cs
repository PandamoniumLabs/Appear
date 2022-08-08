using Appear.Data.Repos;
using Appear.Domain;
using Appear.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Services.Data.Domain
{
    public static class AssetManager
    {
        private static AssetRepository _repository = null;
        private static AssetRepository repository()
        {
            if( _repository == null ) _repository = new AssetRepository();
            return _repository;
        }

        public static void AddAsset(string name, string folderPath)
        {
            Folder folder = FolderManager.GetOrCreate(folderPath);
            repository().Add(new Asset()
            {
                Path = folderPath + "/" + name,
                FolderId = folder.Id,
                Name = name,
                FileTypeId = FileTypeManager.GetByExtension(name.Split('.').Last()).Id
            });
        }     

        public static void RemoveAsset(Asset asset)
        {
            SceneAssetManager.RemoveReferences(asset);
            AssetTagManager.RemoveReferences(asset);
            repository().Remove(asset);
        }

        public static bool HasAssets()
        {
            return repository().HasAssets();
        }

        public static void AddFromFolder(string folder)
        {
            List<string> extensions = FileTypeManager.GetFileExtensions(MediaTypeManager.GetByType(MediaTypeDesc.Image));

            foreach (string path in Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories)
                    .Where(s => extensions.Any(ext => ext == Path.GetExtension(s))))
            {
                AddAsset(path.Split('\\').Last(), folder);
            }

        }

        public static List<AssetCollection> Get(ViewMode viewMode)
        {
            List<AssetCollection> assets = new List<AssetCollection>();

            //foreach (string folder in FolderManager.GetFolderPaths())
            //{
            //    List<string> extensions = FileTypeManager.GetFileExtensions(MediaTypeManager.GetByType(MediaTypeDesc.Image));

            //    AssetCollection collection = new AssetCollection();
            //    collection.Path = folder;
            //    collection.Assets = new ObservableCollection<Asset>();

            //    foreach (string path in Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories)
            //            .Where(s => extensions.Any(ext => ext == Path.GetExtension(s))))
            //    {
            //        collection.Assets.Add(new Asset
            //        {
            //            Path = path,
            //            Name = path.Split('\\').Last()
            //        });
            //    }

            //    assets.Add(collection);
            //}

            switch (viewMode)
            {
                case ViewMode.FOLDERS:
                    return GetByFolder();
                case ViewMode.SCENES:
                    return GetByScene();
                case ViewMode.TAGS:
                    break;
                case ViewMode.EXTENSIONS:
                    break;
            }

            return assets;
        }

        private static List<AssetCollection> GetByExtension()
        {
            return null;
        }

        private static List<AssetCollection> GetByFolder()
        {
            List<Folder> folders = FolderManager.GetFolders();
            List<AssetCollection> result = new List<AssetCollection>();
            foreach (Folder folder in folders)
            {
                AssetCollection collection = new AssetCollection();
                collection.Path = folder.Path;
                collection.Assets= new ObservableCollection<Asset>(repository().GetByFolder(folder.Id));

                result.Add(collection);
            }

            return result;
        }

        private static List<AssetCollection> GetByScene()
        {
            List<Scene> scenes = SceneManager.GetScenes();
            List<AssetCollection> result = new List<AssetCollection>();
            foreach (Scene scene in scenes)
            {
                AssetCollection collection = new AssetCollection();
                collection.Path = scene.Name;
                collection.Assets = new ObservableCollection<Asset>(repository().GetByScene(scene.Id));

                result.Add(collection);
            }

            return result;
        }

        private static List<AssetCollection> GetByTag()
        {
            List<Tag> tags = TagManager.GetTags();
            List<AssetCollection> result = new List<AssetCollection>();
            foreach (Tag tag in tags)
            {
                AssetCollection collection = new AssetCollection();
                collection.Path = tag.Name;
                collection.Assets = new ObservableCollection<Asset>(repository().GetByTag(tag.Id));

                result.Add(collection);
            }

            return result;
        }
    }
}
