using System.Threading.Tasks;
using Alura.WebAPI.Model;
using Alura.WebAPI.WebApp.HttpClients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alura.WebAPI.WebApp.Controllers
{
    [Authorize]
    public class LivroController : Controller
    {
        private readonly LivroApiClient _api;

        public LivroController(LivroApiClient api)
        {
            _api = api;
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View(new LivroUpload());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Novo(LivroUpload model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _api.PostLivroAsync(model);
                }
                catch (System.Exception e)
                {
                    //Logar
                    System.Console.WriteLine($"Erro: {e.Message}");
                    //posso mandar email!
                    //depois continuar o fluxo
                    throw;
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ImagemCapa(int id)
        {
            byte[] img = await _api.GetCapaLivroAsync(id);
            if (img != null)
            {
                return File(img, "image/png");
            }
            return File("~/images/capas/capa-vazia.png", "image/png");
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int id)
        {
            var model = await _api.GetLivroAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model.ToUpload());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Detalhes(LivroUpload model)
        {
            if (ModelState.IsValid)
            {
                await _api.PutLivroAsync(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remover(int id)
        {
            var model = await _api.GetLivroAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            await _api.DeleteLivroAsync(id);
            return RedirectToAction("Index", "Home");
        }
    }
}