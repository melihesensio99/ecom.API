using ETicaretAPI.Application.Repositories.ProductRepository;
using ETicaretAPI.Application.RequestParameters;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProdutQueryResponse>
    {
        private readonly IReadProductRepository _readProductRepository;
        public GetAllProductQueryHandler(IReadProductRepository readProductRepository)
        {
            _readProductRepository = readProductRepository;
        }

        public async Task<GetAllProdutQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = await _readProductRepository.GetAll(false).CountAsync();
            var products = _readProductRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).ToList();
            return (new GetAllProdutQueryResponse()
            {
                 Products = products,
                  TotalCount= totalCount
                
            });
        }   
    }
}
