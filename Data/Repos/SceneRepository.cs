using Appear.Data.DTO;
using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.Repos
{
    public class SceneRepository
    {
        public int Count()
        {
            using (var db = new AppearContext())
            {
                return db.Scenes.Count();
            }
        }

        public void Add(Scene scene)
        {
            using (var db = new AppearContext())
            {
                db.Scenes.Add(scene.ToDTO());
                db.SaveChanges();
            }
        }

        public List<Scene> Get()
        {
            List<SceneDTO> scenes = new List<SceneDTO>();
            List<Scene> result = new List<Scene>();

            using (var db = new AppearContext())
            {
                scenes.AddRange(db.Scenes);
                foreach (SceneDTO scene in scenes)
                {
                    result.Add(scene.ToScene());
                }
            }

            return result;
        }
    }
}
