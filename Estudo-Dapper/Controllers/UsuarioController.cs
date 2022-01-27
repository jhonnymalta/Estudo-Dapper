
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
    }
}
