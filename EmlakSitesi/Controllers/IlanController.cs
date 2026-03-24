using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmlakSitesi.Data;
using EmlakSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmlakSitesi.Controllers
{
    public class IlanController : Controller
    {
        private readonly ILogger<IlanController> _logger;
        private readonly AppDbContext _ilan;
        public IlanController(ILogger<IlanController> logger,AppDbContext ilan)
        {
            _logger = logger;
            _ilan = ilan;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Ilan ilan,IFormFile Foto)
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}