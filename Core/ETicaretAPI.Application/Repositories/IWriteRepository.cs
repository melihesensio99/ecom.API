using ETicaretAPI.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entity);
        bool Update(T entity);
        Task<bool> RemoveAsync(string id);
        bool Remove(T Entity);
        bool RemoveRange(List<T> entities);
        Task<int> SaveAsync();

    }
}
