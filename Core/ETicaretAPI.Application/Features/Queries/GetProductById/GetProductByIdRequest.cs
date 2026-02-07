using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.GetProductById
{
    public class GetProductByIdRequest : IRequest<GetProductByIdResponse>
    {
        public string id { get; set; }
    }
}
