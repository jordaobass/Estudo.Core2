using System.Linq;
using System.Linq.Dynamic.Core;
using Alura.WebAPI.Model;

namespace Alura.WebAPI.Api.Models
{
    public static class LivroOrdemExtensions
    {
        public static IQueryable<Livro> AplicaOrdenacao(this IQueryable<Livro> query, LivroOrdem ordem)
        {
            if ((ordem != null)&&(!string.IsNullOrEmpty(ordem.OrdenarPor)))
            {
                query = query.OrderBy(ordem.OrdenarPor);
            }
            return query;
        }
    }

    public class LivroOrdem
    {
        public string OrdenarPor { get; set; }
    }
}
