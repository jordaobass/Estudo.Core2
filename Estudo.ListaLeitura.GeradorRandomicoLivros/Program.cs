using System;
using System.Collections.Generic;
using Alura.WebAPI.DAL.Livros;
using Alura.WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace Alura.ListaLeitura.GeradorRandomicoLivros
{
    class Program
    {
        static void Main(string[] args)
        {
            //gerar uma lista de 1000 livros randomicamente...
            var gerador = new GeradorAleatorioDeLivro();
            var livros = new List<Livro>();

            Console.WriteLine("Gerando os livros aleatórios...");
            for (int i = 0; i < 250; i++)
            {
                livros.Add(gerador.LivroAleatorio(TipoListaLeitura.ParaLer));
            }

            //foreach (var livro in livros)
            //{
            //    Console.WriteLine($"Título: {livro.Titulo}\nSubtítulo: {livro.Subtitulo}\nAutor: {livro.Autor}\nResumo: {livro.Resumo}\n\n");
            //}

            //... e depois persistir essa lista
            Console.WriteLine("Persistindo a lista...");
            var optionsBuilder = new DbContextOptionsBuilder<LeituraContext>();
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AluraListaLeitura;Trusted_Connection=True;MultipleActiveResultSets=true");

            using (LeituraContext ctx = new LeituraContext(optionsBuilder.Options))
            {
                ctx.Livros.AddRange(livros);
                ctx.SaveChanges();
            }
            
        }
    }
}
