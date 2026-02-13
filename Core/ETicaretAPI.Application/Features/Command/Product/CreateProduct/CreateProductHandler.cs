using ETicaretAPI.Application.Abstractions.Hubs;
using ETicaretAPI.Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Command.Product.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IWriteProductRepository _writeProductRepository;
        private readonly IProductHubService _productHubService;

        public CreateProductHandler(IWriteProductRepository writeProductRepository, IProductHubService productHubService)
        {
            _writeProductRepository = writeProductRepository;
            _productHubService = productHubService;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
           var product =  await _writeProductRepository.AddAsync(new()
            {
                 Name = request.Name,
                  Price = request.Price,
                   Stock = request.Stock,
            });

            await _writeProductRepository.SaveAsync();
            await _productHubService.ProductAddedMessageAsync($"{request.Name} isminde ürün eklenmiştir.");

            return new();
        }
    }
}
