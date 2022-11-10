﻿using System.Diagnostics;
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

    public IActionResult Index()
    {
        return View();
    }
     public IActionResult IniciarSesion()
    {
        return View();
    }
    public IActionResult Primera()
    {
        return View();
    }
    public IActionResult Partidos()
    {
        return View();
    }
public IActionResult Tablas()
    {
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
