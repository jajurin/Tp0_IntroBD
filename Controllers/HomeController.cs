using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TP0_INTROBD;

namespace TP0_INTROBD.Controllers
{
    public class HomeController : Controller
    {
        private BD bd = new BD();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            List<Integrantes> todos = bd.Integrantes();
            Integrantes usuario = null;

            foreach (Integrantes i in todos)
            {
                if (i.Email == email && i.Password == password)
                {
                    usuario = i;
                    
                }
            }

            if (usuario != null)
            {
                HttpContext.Session.SetInt32("IdIntegrante", usuario.IdIntegrantes);
                return RedirectToAction("Perfil");
            }

            ViewBag.Error = "Email o contraseña incorrectos.";
            return View();
        }

        public IActionResult Perfil()
        {
            int? id = HttpContext.Session.GetInt32("IdIntegrante");
            if (id == null)
            {
                return RedirectToAction("Login");
            }

            List<Integrantes> todos = bd.Integrantes();
            Integrantes logueado = null;

            foreach (Integrantes i in todos)
            {
                if (i.IdIntegrantes == id)
                {
                    logueado = i;
                    break;
                }
            }

            return View(logueado);
        }
        public IActionResult Index()
{
    return RedirectToAction("Login");
}

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}