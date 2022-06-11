using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapitalNews.Data;
using CapitalNews.Models;

namespace CapitalNews.Controllers
{
    public class SobreNosController : Controller
    {
        private readonly CapitalDb _context;

        public SobreNosController(CapitalDb context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
