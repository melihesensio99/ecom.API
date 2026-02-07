using ETicaretAPI.Application.Repositories.ProductRepository;
using ETicaretAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Command.Product.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IWriteProductRepository _repository;
        private readonly IReadProductRepository _repository2;

        public UpdateProductHandler(IWriteProductRepository repository, IReadProductRepository repository2)
        {
            _repository = repository;
            _repository2 = repository2;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository2.GetByIdAsync(request.id);
            data.Name = request.Name;
            data.Price = request.Price;
            data.Stock = request.Stock;
            await _repository.SaveAsync();

            return new UpdateProductResponse();

        }
    }
}
