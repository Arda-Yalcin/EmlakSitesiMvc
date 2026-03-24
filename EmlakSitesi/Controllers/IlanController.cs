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
            if (ModelState.IsValid)
            {
                if(Foto != null)
                {
                    var uzanti=Path.GetExtension(Foto.FileName);
                    var yeniAd=Guid.NewGuid+uzanti;
                    var yol=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images",yeniAd);
                    if (Foto.ContentType == "image/png" || Foto.ContentType == "image/jpg" || Foto.ContentType == "image/jpeg")
                    {
                        using(var stream=new FileStream(yol, FileMode.Create))
                        {
                            try
                            {
                                Foto.CopyTo(stream);
                                ilan.Foto=yeniAd;
                                _ilan.Ilanlar.Add(ilan);
                                _ilan.SaveChanges();
                                return RedirectToAction("Index","Ilan");
                            }
                            catch(System.Exception)
                            {
                                throw;
                            }
                        }
                    }else ViewBag.Error="Hatalı Dosya Formatı";
                }else ViewBag.Error="Önce Foto Yükle";
            }
            return View(ilan);
            
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}