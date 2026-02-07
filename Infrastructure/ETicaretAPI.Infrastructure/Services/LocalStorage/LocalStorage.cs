using ETicaretAPI.Application.Abstractions.LocalStorage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.LocalStorage
{
    public class LocalStorage : ILocalStorage
    {
        private readonly IWebHostEnvironment _webHost;
        public LocalStorage(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        public async Task DeleteAsync(string pathOrContainer, string fileName)
        {
           File.Delete($"{pathOrContainer}\\{fileName}");
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> fileUploadAsync(string path, IFormFileCollection files)
        {
            var uploadPath = Path.Combine(_webHost.WebRootPath, path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            List<(string fileName, string path)> datas = new();
            List<bool> results = new();
            foreach (IFormFile file in files)
            {
               
                var result = await CopyFileAsync($"{uploadPath}\\{file.Name}", file);
                datas.Add((file.Name, $"{path}\\{file.Name}"));
                results.Add(result);

            }
            if (results.TrueForAll(x => x.Equals(true)))
                return datas;
            return null;
        }

        public List<string> GetFiles(string pathOrContainerName)
        {
           DirectoryInfo directory = new DirectoryInfo(pathOrContainerName);
            return directory.GetFiles().Select(d=> d.Name).ToList();
        }

        public bool HasFile(string pathOrContainerName, string fileName)
        {
           return File.Exists($"{pathOrContainerName}/{fileName}");

        }
        private async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }


        }


    }
}
