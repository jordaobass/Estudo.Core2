using System.Collections.Generic;
using System.Linq;
using Alura.WebAPI.Api.Models;
using Alura.WebAPI.DAL.Livros;
using Alura.WebAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Lista = Alura.WebAPI.Model.ListaLeitura;

namespace Alura.WebAPI.Api.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ListasLeituraController : ControllerBase
    {
        private readonly IRepository<Livro> _repo;

        public ListasLeituraController(IRepository<Livro> repository)
        {
            _repo = repository;
        }

        private Lista CriaLista(TipoListaLeitura tipo)
        {
            return new Lista
            {
                Tipo = tipo.ParaString(),
                Livros = _repo.All
                    .Where(l => l.Lista == tipo)
                    .Select(l => l.ToApi())
                    .ToList()
            };
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Recupera as listas de leitura.",
            Tags = new[] {"Listas"},
            Produces = new[] {"application/json", "application/xml"}
        )]
        [ProducesResponseType(200, Type = typeof(List<Lista>))]
        [ProducesResponseType(500, Type = typeof(ErroResponse))]
        public IActionResult TodasListas()
        {
            Lista paraLer = CriaLista(TipoListaLeitura.ParaLer);
            Lista lendo = CriaLista(TipoListaLeitura.Lendo);
            Lista lidos = CriaLista(TipoListaLeitura.Lidos);
            var colecao = new List<Lista> { paraLer, lendo, lidos };
            return Ok(colecao);
        }

        [HttpGet("{tipo}")]
        [SwaggerOperation(
            Summary = "Recupera a lista de leitura identificada por seu {tipo}.",
            Tags = new[] { "Listas" },
            Produces = new[] { "application/json", "application/xml" }
        )]
        [ProducesResponseType(200, Type = typeof(Lista))]
        [ProducesResponseType(500, Type = typeof(ErroResponse))]
        public IActionResult Recuperar(
            [FromRoute] [SwaggerParameter("Tipo da lista a ser obtida.")] TipoListaLeitura tipo)
        {
            var lista = CriaLista(tipo);
            return Ok(lista);
        }
    }
}