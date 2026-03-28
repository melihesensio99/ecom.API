using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using ETicaretAPI.Application.Abstractions.Storage.AWS;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.Storage.AWS
{
    public class AWSStorage : Storage, IAWSStorage
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public AWSStorage(IConfiguration configuration)
        {
            var awsSettings = configuration.GetSection("Storage:AWS");
            _s3Client = new AmazonS3Client(
                awsSettings["AccessKey"],
                awsSettings["SecretKey"],
                RegionEndpoint.GetBySystemName(awsSettings["Region"])
            );
            _bucketName = awsSettings["BucketName"];
        }

        public async Task DeleteAsync(string pathOrContainerName, string fileName)
        {
            var deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = !string.IsNullOrEmpty(pathOrContainerName) ? $"{pathOrContainerName}/{fileName}" : fileName
            };
            await _s3Client.DeleteObjectAsync(deleteObjectRequest);
        }

        public List<string> GetFiles(string pathOrContainerName)
        {
            ListObjectsV2Request request = new ListObjectsV2Request
            {
                BucketName = _bucketName,
                Prefix = pathOrContainerName
            };

            var response = _s3Client.ListObjectsV2Async(request).Result;
            return response.S3Objects.Select(s => s.Key).ToList();
        }

        public bool HasFile(string pathOrContainerName, string fileName)
        {
            try
            {
                var request = new GetObjectMetadataRequest
                {
                    BucketName = _bucketName,
                    Key = !string.IsNullOrEmpty(pathOrContainerName) ? $"{pathOrContainerName}/{fileName}" : fileName
                };
                var response = _s3Client.GetObjectMetadataAsync(request).Result;
                return true;
            }
            catch (AmazonS3Exception ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return false;
                throw;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        {
            List<(string fileName, string pathOrContainerName)> datas = new();
            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(pathOrContainerName, file.FileName, HasFile);

                using var newStream = new MemoryStream();
                await file.CopyToAsync(newStream);
                
                var uploadRequest = new TransferUtilityUploadRequest
                {
                    InputStream = newStream,
                    Key = !string.IsNullOrEmpty(pathOrContainerName) ? $"{pathOrContainerName}/{fileNewName}" : fileNewName,
                    BucketName = _bucketName
                };

                using var fileTransferUtility = new TransferUtility(_s3Client);
                await fileTransferUtility.UploadAsync(uploadRequest);

                datas.Add((fileNewName, pathOrContainerName));
            }
            return datas;
        }
    }
}
