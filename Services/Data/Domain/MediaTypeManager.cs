using Appear.Data.Repos;
using Appear.Domain;
using Appear.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Services.Data.Domain
{
    public static class MediaTypeManager
    {
        private static MediaTypeRepository _repository = null;
        private static MediaTypeRepository repository()
        {
            if (_repository == null) _repository = new MediaTypeRepository();
            return _repository;
        }

        public static MediaType GetByType(MediaTypeDesc type)
        {
            return repository().Get(type.ToString());
        }

        public static MediaType Get(int mediaTypeId)
        {
            return repository().Get(mediaTypeId);
        }
    }
}
