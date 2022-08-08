using Appear.Data.DTO;
using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.Repos
{
    public class TagRepository
    {
        public int Count()
        {
            using (var db = new AppearContext())
            {
                return db.Tags.Count();
            }
        }

        public List<Tag> GetAll()
        {
            List<Tag> result = new List<Tag>();
            List<TagDTO> tags = new List<TagDTO>();

            using(var db = new AppearContext())
            {
                tags.AddRange(db.Tags);
                foreach (TagDTO tag in tags)
                {
                    result.Add(tag.ToTag());
                }
            }

            return result;
        }
    }
}
