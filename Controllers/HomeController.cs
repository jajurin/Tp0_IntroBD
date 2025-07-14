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
    string Id = HttpContext.Session.GetString("IdIntegrante");
    if (string.IsNullOrEmpty(Id))
        return RedirectToAction("Login");

    int id = int.Parse(Id);

     Integrantes logueado = null;
     foreach (var integrante in bd.Integrantes())
   {
    if (integrante.IdIntegrantes == id)
    {
        logueado = integrante;
    }
   }

if (logueado == null)
    return RedirectToAction("Login");

List<Integrantes> equipo = new List<Integrantes>();
foreach (var integrante in bd.Integrantes())
{
    if (integrante.Equipo == logueado.Equipo)
    {
        equipo.Add(integrante);
    }
}


    return View((Logueado: logueado, Equipo: equipo));
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