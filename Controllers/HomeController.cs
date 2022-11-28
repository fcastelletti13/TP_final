using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_final.Models;

namespace TP_final.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IWebHostEnvironment _environment;
    public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
    {
        _logger = logger;
        _environment = environment;
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
        ViewBag.ListaPosts =  BD.ListarPosts();
        return View();
    }
   [HttpPost]public IActionResult AgregarPost(Post post, IFormFile MyFile){
        post.Foto = MyFile.FileName;
        using (var stream = System.IO.File.Create(this._environment.WebRootPath + @"\img\usuarios\" + MyFile.FileName)) MyFile.CopyTo(stream);
        post.FechaCreacion = DateTime.Now;
        BD.AgregarPost(post);
        return RedirectToAction("Foro");
    }
    public IActionResult CerrarSesion()
    {
        usuarioActivo = usuarioSinSesion;
        return RedirectToAction("Index");
    }

    public Usuario DevolverUsuario(int id)
    {
        Usuario usuario = BD.ListarUnUsuario(id);
        return usuario;
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
    [HttpPost] public IActionResult ValidarRegistro(string nombre, string contrasena, string contrasena2, IFormFile MyFile)
    {
        if (contrasena != contrasena2) return RedirectToAction("IniciarSesion", new{mensaje = "Las contraseñas no coinciden!"});
        
        List<Usuario> ListaUsuarios = BD.ListarUsuarios();
        foreach (Usuario item in ListaUsuarios)
        {
            if (nombre == item.Nombre)
            {
                return RedirectToAction("IniciarSesion", new{mensaje = $"El nombre <b>{nombre}</b> ya está en uso!"});
            }
        }

        string wwwRootPath = this._environment.WebRootPath;
        using (var stream = System.IO.File.Create(wwwRootPath + @"\img\usuarios\" + MyFile.FileName)) MyFile.CopyTo(stream);

        Usuario usuario = new Usuario(-1, nombre, contrasena, MyFile.FileName);

        int id = BD.AgregarUsuario(usuario);
        usuarioActivo = BD.ListarUnUsuario(id);

        return RedirectToAction("Index");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
