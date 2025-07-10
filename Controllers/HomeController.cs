using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TP0_INTROBD;
using System.Collections.Generic;

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
            List<Integrantes> integrantes = bd.Integrantes();
            Integrantes usuario = null;

            foreach (Integrantes i in integrantes)
            {
                if (i.Email == email && i.Password == password)
                {
                    usuario = i;
                }
            }

            if (usuario != null)
            {
                HttpContext.Session.SetString("IdIntegrante", usuario.IdIntegrantes.ToString());
                return RedirectToAction("Perfil");
            }

            
            ViewBag.Error = "Email o contraseña incorrectos.";
            return View();
        }

        public IActionResult Perfil()
        {
    
            string Texto = HttpContext.Session.GetString("IdIntegrante");

            if (string.IsNullOrEmpty(Texto))
            {
                return RedirectToAction("Login");
            }

            
            int id = int.Parse(Texto);

            List<Integrantes> integrantes = bd.Integrantes();
            Integrantes logueado = null;

            foreach (Integrantes i in integrantes)
            {
                if (i.IdIntegrantes == id)
                {
                    logueado = i;
                    
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
        [HttpGet]
public IActionResult Registro()
{
    return View();
}

[HttpPost]
public IActionResult Registro(string nombre, string email, string password, string domicilio, string fechaNacimiento, string genero)
{
    if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
    {
        ViewBag.Error = "Nombre, email y contraseña son obligatorios.";
        return View();
    }

    
    DateTime fechaNac;
    if (!DateTime.TryParse(fechaNacimiento, out fechaNac))
    {
        fechaNac = DateTime.MinValue; // o date default
            }

    Integrantes nuevo = new Integrantes
    {
        Nombre = nombre,
        Email = email,
        Password = password,
        Domicilio = domicilio,
        FechaNacimiento = fechaNac,
        Genero = genero
    };

    bd.AgregarIntegrante(nuevo);

    return RedirectToAction("Login");
}
    }

}