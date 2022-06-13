using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RaZorWebxxx.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaZorWebxxx.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductServices _prodductservice;

        public FirstController(ILogger<FirstController> logger ,ProductServices prodductservice )
        {
            _logger = logger;
            _prodductservice = prodductservice;
        }
        [TempData]
        public string Statusmessage { set; get; }
        [AcceptVerbs("POST","GET")]
        public IActionResult Viewproduct(int? id)
        {

            var product = _prodductservice.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                Statusmessage = "Sản Phẩm Bạn yêu cầu không có";


                return Redirect(Url.Action("Index", "Home"));
            }
            this.ViewData["product"] = product;
            ViewData["Title"] = product.Name;
            return View("Viewproduct2");


           
        }
    }
}
