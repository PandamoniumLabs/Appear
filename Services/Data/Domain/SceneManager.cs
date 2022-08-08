using Appear.Data.Repos;
using Appear.Domain;
using Appear.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Services.Data.Domain
{
    public static class SceneManager
    {
        private static SceneRepository _repository = null;
        private static SceneRepository repository()
        {
            if (_repository == null) _repository = new SceneRepository();
            return _repository;
        }

        public static List<Scene> GetScenes()
        {
            return repository().Get();
        }

        public static List<string> GetSceneNames()
        {
            List<Scene> scenes = GetScenes();
            List<string> sceneNames = new List<string>();
            foreach (Scene scene in scenes)
            {
                sceneNames.Add(scene.Name);
            }
            return sceneNames;
        }

        public static bool HasScenes()
        {
            return repository().Count() > 0;
        }

        public static void Create(string name)
        {
            Scene scene = new Scene()
            {
                Name = name
            };
            repository().Add(scene);
        }
    }
}
