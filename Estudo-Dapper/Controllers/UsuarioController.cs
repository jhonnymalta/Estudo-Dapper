
using Estudo_Dapper.Models;
using Estudo_Dapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace Estudo_Dapper.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IRepository_Usuario repository_Usuario;


        public UsuarioController(IRepository_Usuario repository_Usuario)
        {
            this.repository_Usuario = repository_Usuario;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allUser = await repository_Usuario.GetAllUser();
            return View(allUser);
        }
        [HttpGet]
        public async Task<IActionResult> EditarView(int id)
        {
           var user = await repository_Usuario.GetById(id);
           return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateView(UsuarioModel usuario)
        {
            await repository_Usuario.EditarUsuario(usuario);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateView(int id)
        {
            var user = await repository_Usuario.GetById(id);
            return View(user);
        }

     

        [HttpGet]
        public IActionResult CriarView()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CriarView(UsuarioModel usuario)
        {
            
            await repository_Usuario.CriarUsuario(usuario);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeletarView(int id)
        {
            var userToDel = await repository_Usuario.GetById(id);

            return View(userToDel);
        }
        [HttpPost]
        public async Task<IActionResult> DeletarUser(int id)
        {
           await repository_Usuario.DeleteUsuario(id);

            return RedirectToAction("Index");
        }
    }
}
