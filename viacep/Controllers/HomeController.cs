using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using viacep.Models;
using viacep.Viacep;

namespace viacep.Controllers
{
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

        [HttpPost]
        public IActionResult Index(string cep)
        {
            var Buscacep = new ViaCep().BuscarPorCep(cep);

            ViewData["CepViewModel"] = "Cep: " + Buscacep.Cep;
            ViewData["CepViewModel"] += ", Endereço: " + Buscacep.Logradouro;
            ViewData["CepViewModel"] += ", Bairro: " + Buscacep.Bairro;
            ViewData["CepViewModel"] += ", Cidade: " + Buscacep.Cidade;
            ViewData["CepViewModel"] += ", UF: " + Buscacep.Uf;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
