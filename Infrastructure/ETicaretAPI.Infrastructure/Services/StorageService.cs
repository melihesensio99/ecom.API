using ETicaretAPI.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services
{
    public class StorageService : IStorageService
    {
        private readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public async Task DeleteAsync(string pathOrContainer, string fileName)
        {
            await _storage.DeleteAsync(pathOrContainer, fileName);
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> fileUploadAsync(string pathOrContainerName, IFormFileCollection files)
        {
            return await _storage.fileUploadAsync(pathOrContainerName, files);
        }

        public List<string> GetFiles(string pathOrContainerName)
        {
           return _storage.GetFiles(pathOrContainerName);
        }

        public bool HasFile(string pathOrContainerName, string fileName)
        {
            return _storage.HasFile(pathOrContainerName, fileName);
        }
    }
}
