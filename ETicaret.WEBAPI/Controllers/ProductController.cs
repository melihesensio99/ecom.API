using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Features.Commands.Product.CreateProduct;
using ETicaretAPI.Application.Features.Commands.Product.RemoveProduct;
using ETicaretAPI.Application.Features.Commands.Product.UpdateProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetAllProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetByIdProduct;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        public ProductController(IMediator mediator, IStorage storage)
        {
            _mediator = mediator;
            _storage = storage;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProdutQueryRequest)
        {
            var response = await _mediator.Send(getAllProdutQueryRequest);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            var response = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response);
        }

        [HttpPost]
  
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {
            var response = await _mediator.Send(createProductCommandRequest);
            return Ok(HttpStatusCode.Created);

        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductCommandRequest updateProductCommandRequest)
        {
            var result = await _mediator.Send(updateProductCommandRequest);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]RemoveProductCommandRequest removeProductCommandRequest)
        {
            await _mediator.Send(removeProductCommandRequest);
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
