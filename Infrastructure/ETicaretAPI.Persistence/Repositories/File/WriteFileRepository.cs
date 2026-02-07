using ETicaretAPI.Application.Repositories.FileRepository;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = ETicaretAPI.Domain.Entities.File;

namespace ETicaretAPI.Persistence.Repositories
{
    public class WriteFileRepository : WriteRepository<File>, IWriteFileRepository
    {
        public WriteFileRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
