using Alura.WebAPI.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alura.WebAPI.Api.Filtros
{
    public class ErroResponseExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(ErroResponse.From(context.Exception)) { StatusCode = 500 };
        }
    }
}
