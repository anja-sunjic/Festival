using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Festival.Data.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Festival.Web.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class AccommodationsController : Controller
    {
        private readonly IAccommodationRepository _repo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AccommodationsController(IAccommodationRepository repo, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}