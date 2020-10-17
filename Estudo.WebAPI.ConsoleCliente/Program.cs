using Alura.ListaLeitura.Modelos;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Lista = Alura.ListaLeitura.Modelos.ListaLeitura;

namespace Alura.WebAPI.ConsoleCliente
{
    class Program
    {
        static async Task<Lista> GetListaLeitura(TipoListaLeitura tipo)
        {
            var authToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZG1pbiIsImp0aSI6IjVmYWE2ZWRlLTEwNTYtNDBkMC04MGViLTljN2E2OGEyZTE0MyIsImV4cCI6MTUzODc3MzM1NywiaXNzIjoiQWx1cmEuV2ViQXBwIiwiYXVkIjoiUG9zdG1hbiJ9.BFEcW9zvwqd4zkB0eTdliPRPa2RHNew7fKXjVgj8VjI";
            var url = "http://localhost:6000/api/listasleitura/";
            var request = new HttpClient();
            request.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");
            var response = await request.GetAsync(url);
            response.EnsureSuccessStatusCode();
            //return await response.Content.ReadAsStringAsync();
            //problema é que com ReadAsStringAsync eu terei que desserializar o Json...
            //existe uma maneira mais simples. Um método de extensão para 

            //ReadAsAsync não existe originalmente. É preciso instalar o pacote Microsoft.AspNet.WebApi.Client
            return await response.Content.ReadAsAsync<Lista>();

        }

        static void Main(string[] args)
        {
            Task.Run(
                async () =>
                {
                    var lista = await GetListaLeitura(TipoListaLeitura.ParaLer);

                    //lista de leitura para ler
                    foreach (var livro in lista.Livros)
                    {
                        Console.WriteLine($"{livro.Titulo} - {livro.Autor}");
                    }
                    //lista de leitura lendo
                    //lista de leitura lidos
                })
                    .GetAwaiter()
                    .GetResult();
            );
        }
    }
}
