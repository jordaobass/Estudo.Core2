using System.Linq;
using Alura.WebAPI.Model;

namespace Alura.WebAPI.Api.Models
{
    public static class LivroFiltroExtensions
    {
        public static IQueryable<Livro> AplicaFiltro(this IQueryable<Livro> query, LivroFiltro filtro)
        {
            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.Titulo))
                {
                    query = query.Where(l => l.Titulo.Contains(filtro.Titulo));
                }
                if (!string.IsNullOrEmpty(filtro.Subtitulo))
                {
                    query = query.Where(l => l.Subtitulo.Contains(filtro.Subtitulo));
                }
                if (!string.IsNullOrEmpty(filtro.Resumo))
                {
                    query = query.Where(l => l.Resumo.Contains(filtro.Resumo));
                }
                if (!string.IsNullOrEmpty(filtro.Autor))
                {
                    query = query.Where(l => l.Autor.Contains(filtro.Autor));
                }
                if (!string.IsNullOrEmpty(filtro.Lista))
                {
                    query = query.Where(l => l.Lista.ParaString() == filtro.Lista);
                }
            }
            return query;
        }
    }

    public class LivroFiltro
    {
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Resumo { get; set; }
        public string Autor { get; set; }
        public string Lista { get; set; }
    }
}
