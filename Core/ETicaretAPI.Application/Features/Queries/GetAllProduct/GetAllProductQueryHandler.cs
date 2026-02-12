using ETicaretAPI.Application.Repositories.ProductRepository;
using ETicaretAPI.Application.RequestParameters;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<GetAllProductQueryHandler> _logger;

        public GetAllProductQueryHandler(IReadProductRepository readProductRepository , ILogger<GetAllProductQueryHandler> logger)
        {
            _readProductRepository = readProductRepository;
            _logger = logger;
        }

        public async Task<GetAllProdutQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("getall");

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
