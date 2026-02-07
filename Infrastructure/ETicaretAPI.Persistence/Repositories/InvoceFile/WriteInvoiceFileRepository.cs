using ETicaretAPI.Application.Repositories.InvoiceFileRepository;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.InvoceFile
{
    public class WriteInvoiceFileRepository : WriteRepository<InvoiceFile>, IWriteInvoiceFileRepository
    {
        public WriteInvoiceFileRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
