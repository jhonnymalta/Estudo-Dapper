using Estudo_Dapper_Two_Tables.Services;
using Microsoft.AspNetCore.Mvc;

namespace Estudo_Dapper_Two_Tables.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IRepository_Usuario repository_Usuario;

        public UsuarioController(IRepository_Usuario repository_Usuario)
        {
            this.repository_Usuario = repository_Usuario;
        }
        public async Task<IActionResult> Index()
        {
            var allUser = await repository_Usuario.GetAllUser();
            return View(allUser);
        }
        
    }
}
