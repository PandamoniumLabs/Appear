using Appear.Data.DTO;
using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.Repos
{
    public class MediaTypeRepository
    {
        public MediaType Get(int id)
        {
            MediaType result = null;
            MediaTypeDTO mediaType = null;

            using(var db = new AppearContext())
            {
                mediaType = db.MediaTypes.FirstOrDefault(x => x.Id == id);
            }

            if(mediaType != null)
            {
                result = mediaType.ToMediaType();
            }

            return result;
        }

        public MediaType Get(string name)
        {
            MediaType result = null;
            MediaTypeDTO mediaType = null;

            using (var db = new AppearContext())
            {
                mediaType = db.MediaTypes.FirstOrDefault(x => x.Name.Equals(name));
            }

            if (mediaType != null)
            {
                result = mediaType.ToMediaType();
            }

            return result;
        }
    }
}
