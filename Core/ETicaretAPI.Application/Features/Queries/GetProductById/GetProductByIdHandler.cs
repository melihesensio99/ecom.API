using ETicaretAPI.Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        private readonly IReadProductRepository _repository;

        public GetProductByIdHandler(IReadProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var data =await _repository.GetByIdAsync(request.id);
            return new()
            {
                 Name = data.Name,
                  Price = data.Price,
                   Stock = data.Stock,
                   
            };
        }
    }
}
