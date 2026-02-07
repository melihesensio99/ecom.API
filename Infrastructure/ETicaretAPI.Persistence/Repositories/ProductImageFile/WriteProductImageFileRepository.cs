using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.ProductImageFile
{
    public class WriteProductImageFileRepository : WriteRepository<ProductImagesFile>, IWriteProductImageFileRepository
    {
        public WriteProductImageFileRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
