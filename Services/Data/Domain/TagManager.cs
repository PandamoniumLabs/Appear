using Appear.Data.Repos;
using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Services.Data.Domain
{
    public static class TagManager
    {
        private static TagRepository _repository = null;
        private static TagRepository repository()
        {
            if (_repository == null) _repository = new TagRepository();
            return _repository;
        }

        public static bool HasTags()
        {
            return repository().Count() > 0;
        }

        public static List<Tag> GetTags()
        {
            return repository().GetAll();
        }

        public static List<string> GetTagNames()
        {
            List<Tag> tags = GetTags();
            List<string> tagNames = new List<string>();
            foreach (Tag tag in tags)
            {
                tagNames.Add(tag.Name);
            }
            return tagNames;
        }

        public static void Create(string name)
        {

        }
    }
}
