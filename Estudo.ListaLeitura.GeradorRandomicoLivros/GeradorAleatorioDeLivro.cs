using ET.FakeText;
using System;
using System.Linq;
using Alura.WebAPI.Model;

namespace Alura.ListaLeitura.GeradorRandomicoLivros
{
    internal class GeradorAleatorioDeLivro
    {

        private string TituloAleatorio()
        {
            var textGenerator = new TextGenerator();
            textGenerator.MaxSentenceLength = 50;
            return textGenerator.GenerateText(4);
        }

        private string SubTituloAleatorio()
        {
            var textGenerator = new TextGenerator();
            textGenerator.MaxSentenceLength = 75;
            return textGenerator.GenerateText(8);
        }

        private string AutorAleatorio()
        {
            var textGenerator = new TextGenerator(WordTypes.Name);
            textGenerator.MaxSentenceLength = 50;
            return textGenerator.GenerateText(3);
        }

        private string ResumoAleatorio()
        {
            var textGenerator = new TextGenerator();
            textGenerator.MaxSentenceLength = 500;
            return textGenerator.GenerateText(50);
        }

        public Livro LivroAleatorio(TipoListaLeitura tipo) 
        {
            return new Livro
            {
                Titulo = TituloAleatorio(),
                Subtitulo = SubTituloAleatorio(),
                Autor = AutorAleatorio(),
                Resumo = ResumoAleatorio(),
                ImagemCapa = null,
                Lista = tipo
            };
        }
    }
}