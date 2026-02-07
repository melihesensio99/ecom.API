using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Dtos.Products;
using ETicaretAPI.Application.Features.Command.Product.CreateProduct;
using ETicaretAPI.Application.Features.Command.Product.DeleteProduct;
using ETicaretAPI.Application.Features.Command.Product.UpdateProduct;
using ETicaretAPI.Application.Features.Queries.GetAllProduct;
using ETicaretAPI.Application.Features.Queries.GetProductById;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.FileRepository;
using ETicaretAPI.Application.Repositories.InvoiceFileRepository;
using ETicaretAPI.Application.Repositories.OrderRepository;
using ETicaretAPI.Application.Repositories.ProductRepository;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ETicaret.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IStorage _storage;
        private readonly IMediator _mediator;
        public ProductController(IWriteProductRepository productRepository, IReadProductRepository readProductRepository, IWebHostEnvironment webHostEnvironment, IWriteFileRepository writeFileRepository, IWriteInvoiceFileRepository writeInvoiceFileRepository, IWriteProductImageFileRepository writeProductImageFileRepository, IMediator mediator, IStorage storage)
        {
            _mediator = mediator;
            _storage = storage;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProdutQueryRequest)
        {
            var response = await _mediator.Send(getAllProdutQueryRequest);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]GetProductByIdRequest getProductById)
        {
            var response = await _mediator.Send(getProductById);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {
            var response = await _mediator.Send(createProductCommandRequest);
            return Ok(HttpStatusCode.Created);

        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductRequest updateProductRequest)
        {
            var result = await _mediator.Send(updateProductRequest);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(DeleteProductRequest deleteProductRequest)
        {
            await _mediator.Send(deleteProductRequest);
            return Ok();
        }

        //[HttpPost("[action]")]
        //public async Task<IActionResult> Upload()
        //{

        //    var datas = await _storage.fileUploadAsync("resource/product-images", Request.Form.Files);
        //    var newImages = datas.Select(d => new ProductImagesFile()
        //    {
        //        FileName = d.fileName,
        //        Path = d.pathOrContainerName,
        //        Storage = "LocalStorage"
        //    }).ToList();
        //    await _writeProductImageFileRepository.AddRangeAsync(newImages);
        //    await _writeProductImageFileRepository.SaveAsync();
        //    return Ok();
        //}



    }
}
