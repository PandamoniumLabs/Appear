using Appear.Data.DTO;
using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.Repos
{
    public class FolderRepository
    {
        public void Remove(Folder folder)
        {
            using (var db = new AppearContext())
            {
                var obj = db.Folders.Where(x => x.Id == folder.Id).Single();

                db.Folders.Remove(obj);
                db.SaveChanges();
            }
        }

        public Folder Get(string path) 
        {
            FolderDTO folder = null;
            Folder result = null;

            using (var db = new AppearContext())
            {
                folder = db.Folders.Where(x => x.Path.Equals(path)).SingleOrDefault();
                if(folder != null)
                {
                    result = folder.ToFolder();
                }
            }

            return result;
        }

        public Folder Get(int id)
        {
            FolderDTO folder = null;
            Folder result = null;

            using (var db = new AppearContext())
            {
                folder = db.Folders.Where(x => x.Id == id).SingleOrDefault();
                if (folder != null)
                {
                    result = folder.ToFolder();
                }
            }

            return result;
        }

        public void Add(Folder folder)
        {
            using (var db = new AppearContext())
            {
                db.Folders.Add(folder.ToDTO());
                db.SaveChanges();
            }
        }

        public int Count()
        {
            using (var db = new AppearContext())
            {
                return db.Folders.Count();
            }
        }

        public List<Folder> GetAll()
        {
            List<FolderDTO> folders = new List<FolderDTO>();
            List<Folder> result = new List<Folder>();

            using(var db = new AppearContext())
            {
                folders.AddRange(db.Folders);
                foreach(FolderDTO folder in folders)
                {
                    result.Add(folder.ToFolder());
                }
            }

            return result;
        }
    }
}
