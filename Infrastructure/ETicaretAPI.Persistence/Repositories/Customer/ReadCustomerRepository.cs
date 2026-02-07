using ETicaretAPI.Application.Repositories.CustomerRepository;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadCustomerRepository : ReadRepository<Customer>, IReadCustomerRepository
    {
        public ReadCustomerRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
