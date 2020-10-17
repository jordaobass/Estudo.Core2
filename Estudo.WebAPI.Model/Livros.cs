using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;

namespace Alura.WebAPI.Model
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Resumo { get; set; }
        public byte[] ImagemCapa { get; set; }
        public string Autor { get; set; }
        public TipoListaLeitura Lista { get; set; }
    }

    [XmlType("Livro")]
    public class LivroApi
    {
        public int Id { get; set; }
        /// <summary>
        /// Título do livro.
        /// </summary>
        public string Titulo { get; set; }
        /// <summary>
        /// Subtítulo do livro.
        /// </summary>
        public string Subtitulo { get; set; }
        /// <summary>
        /// Breve resumo com principais idéias do livro.
        /// </summary>
        public string Resumo { get; set; }
        /// <summary>
        /// URI para a imagem de capa do livro.
        /// </summary>
        public string ImagemCapa { get; set; }
        /// <summary>
        /// Nome do autor.
        /// </summary>
        public string Autor { get; set; }
        /// <summary>
        /// Tipo de lista onde o livro está.
        /// </summary>
        /// <example>ParaLer, Lendo ou Lidos</example>
        public string Lista { get; set; }
    }

    public class LivroUpload
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Autor { get; set; }
        public string Resumo { get; set; }
        public IFormFile Capa { get; set; }
        public TipoListaLeitura Lista { get; set; }
    }
}
