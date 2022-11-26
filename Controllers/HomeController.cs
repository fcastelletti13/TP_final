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
    private static Usuario usuarioSinSesion = new Usuario(-1, String.Empty, String.Empty, "no_profile_picture.png");
    private static Usuario usuarioActivo = usuarioSinSesion;
    public IActionResult Index()
    {
        ViewBag.Usuario = usuarioActivo;
        ViewBag.Goleadores = BD.ListarGoleadores();
        ViewBag.Asistidores = BD.ListarAsistidores();
        return View();
    }
    public IActionResult IniciarSesion(string mensaje = "")
    {
        ViewBag.Usuario = usuarioActivo;
        ViewBag.mensaje = mensaje;
        return View();
    }
    public IActionResult Partidos()
    {
        ViewBag.Usuario = usuarioActivo;
        ViewBag.ListarPartidos = BD.ListarPartidos();
        return View();
    }
    public IActionResult Tablas()
    {
        ViewBag.Usuario = usuarioActivo;
        ViewBag.Goleadores = BD.ListarGoleadores();
        ViewBag.ListaEquipos = BD.ListarEquipos();
        return View();
    }
    public IActionResult Foro()
    {
        ViewBag.Usuario = usuarioActivo;
        return View();
    }

    [HttpPost] public IActionResult ValidarInicio(string nombre, string contrasena)
    {
        List<Usuario> ListaUsuarios = BD.ListarUsuarios();
        foreach (Usuario item in ListaUsuarios)
        {
            if (nombre == item.Nombre && contrasena == item.Contraseña)
            {
                usuarioActivo = item;
                return RedirectToAction("Index");
            }
        }
        return RedirectToAction("IniciarSesion", new{mensaje = "Usuario o contraseña incorrecta"});
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
