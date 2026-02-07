using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Any())
                  .Select(e => new
                  {
                        Key = e.Key,
                      Value = e.Value.Errors.Select(x => x.ErrorMessage).ToArray()
                  })
                    .ToList(); 

                context.Result = new BadRequestObjectResult(errors);
                return;
            }
            await next();
        }
    }
}
