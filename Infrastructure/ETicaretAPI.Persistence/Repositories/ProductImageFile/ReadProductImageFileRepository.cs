using ETicaretAPI.Application.Repositories.ProductImageFileRepository;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.ProductImageFile
{
    public class ReadProductImageFileRepository : ReadRepository<ProductImagesFile>, IReadProductImageFileRepostiroy
    {
        public ReadProductImageFileRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
