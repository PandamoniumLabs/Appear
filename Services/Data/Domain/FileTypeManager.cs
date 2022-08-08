using Appear.Data.Repos;
using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Services.Data.Domain
{
    public static class FileTypeManager
    {
        private static FileTypeRepository _repository = null;
        private static FileTypeRepository repository()
        {
            if (_repository == null) _repository = new FileTypeRepository();
            return _repository;
        }

        public static List<string> GetFileExtensions(MediaType mediaType)
        {
            List<string> extensions = new List<string>();
            var filetypes = repository().GetByMediaType(mediaType.Id);

            foreach (var filetype in filetypes)
            {
                extensions.Add(filetype.Extension);
            }

            return extensions;
        }

        public static FileType GetByExtension(string ext)
        {
            return repository().GetByExtension(ext);
        }
    }
}
