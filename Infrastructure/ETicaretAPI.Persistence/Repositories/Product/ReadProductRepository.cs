using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.ProductRepository;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadProductRepository : ReadRepository<Product>, IReadProductRepository
    {
        public ReadProductRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
