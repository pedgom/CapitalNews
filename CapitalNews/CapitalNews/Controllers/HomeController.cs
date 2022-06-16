using CapitalNews.Models;
using CapitalNews.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace CapitalNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Variável que identifica, dentro da base de dados a parte do utilizador.
        /// </summary>
       

        /// <summary>
        /// Variável que identifica a Base de dados do projeto
        /// </summary>
       

        // Construtor
        public HomeController(ILogger<HomeController> logger, CapitalDb context)
        {
           
            _logger = logger;
           
        }

        public IActionResult Index()
        {
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