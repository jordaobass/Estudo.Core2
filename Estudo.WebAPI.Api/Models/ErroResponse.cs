using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Alura.WebAPI.Api.Models
{
    public class ErroResponse
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        public string[] Detalhes { get; set; }
        public ErroResponse InnerError { get; set; }

        public static ErroResponse From(System.Exception e)
        {
            if (e == null)
            {
                return null;
            }
            return new ErroResponse
            {
                Codigo = e.HResult,
                Mensagem = e.Message,
                InnerError = ErroResponse.From(e.InnerException)
            };
        }

        public static ErroResponse FromModelStateError(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(v => v.Errors);
            return new ErroResponse
            {
                Codigo = 100,
                Mensagem = "Houve erro(s) na validação da requisição",
                Detalhes = errors.Select(e => e.ErrorMessage).ToArray(),
            };
        }
    }
}
