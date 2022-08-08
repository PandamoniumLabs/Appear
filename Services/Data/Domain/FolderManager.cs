using Appear.Data.Repos;
using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Services.Data.Domain
{
    public static class FolderManager
    {
        private static FolderRepository _repository = null;
        private static FolderRepository repository()
        {
            if (_repository == null) _repository = new FolderRepository();
            return _repository;
        }

        public static bool HasFolders()
        {
            return repository().Count() > 0 ;
        }

        public static List<string> GetFolderPaths()
        {
            List<string> paths = new List<string>();
            List<Folder> folders = repository().GetAll();

            foreach (Folder folder in folders)
            {
                paths.Add(folder.Path);
            }

            return paths;
        }

        public static List<Folder> GetFolders()
        {
            return repository().GetAll();
        }

        public static Folder GetOrCreate(string folderPath)
        {
            Folder folder = repository().Get(folderPath);
            if (folder == null)
            {
                folder = CreateFolder(folderPath);
            }
            return folder;
        }

        public static void Add(string path)
        {
            repository().Add(new Folder() { Path = path });
        }

        private static Folder CreateFolder(string folderPath)
        {
            Add(folderPath);
            return repository().Get(folderPath);
        }

        public static void Remove(string path)
        {
            Folder folder = repository().Get(path);
            repository().Remove(folder);
        }

        public static Folder Get(int id)
        {
            return repository().Get(id);
        }
    }
}
