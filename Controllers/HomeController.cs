using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_final.Models;

namespace TP_final.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(Usuario usuario = null)
    {
        if (usuario == null)
        {
            usuario = new Usuario();
            usuario.Foto = "no_profile_picture.png";
        }
        ViewBag.Usuario = usuario;
        ViewBag.Goleadores = BD.ListarGoleadores();
        ViewBag.Asistidores = BD.ListarAsistidores();
        return View();
    }


    [HttpPost] public IActionResult ValidarInicio(string nombre, string contrasena)
    {
        List<Usuario> ListaUsuarios = BD.ListarUsuarios();
        foreach (Usuario item in ListaUsuarios)
        {
            if (nombre == item.Nombre && contrasena == item.Contraseña)
            {
                return RedirectToAction("Index", new{usuario = item});
            }
        }
        return RedirectToAction("IniciarSesion", new{mensaje = "Usuario o contraseña incorrecta"});
    }
    public IActionResult IniciarSesion(string mensaje = "")
    {
        
        ViewBag.mensaje = mensaje;
        return View();
    }
    public IActionResult Primera()
    {
        return View();
    }
    public IActionResult Partidos()
    {
        ViewBag.ListarPartidos = BD.ListarPartidos();
        return View();
    }
    public IActionResult Tablas()
    {
        ViewBag.Goleadores = BD.ListarGoleadores();
        ViewBag.ListaEquipos = BD.ListarEquipos();
        return View();
    }
    public IActionResult Foro()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
