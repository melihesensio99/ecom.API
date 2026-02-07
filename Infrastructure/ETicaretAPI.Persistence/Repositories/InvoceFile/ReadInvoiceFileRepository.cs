using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.InvoiceFileRepository;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadInvoiceFileRepository : ReadRepository<InvoiceFile> , IReadInvoiceFileRepository
    {
        public ReadInvoiceFileRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
