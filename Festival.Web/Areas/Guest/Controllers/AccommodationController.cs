using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Festival.Data.Repositories;
using Festival.Web.Areas.Guest.ViewModels.Accommodation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Festival.Web.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class AccommodationController : Controller
    {
        private readonly IAccommodationRepository _repo;

        public AccommodationController(IAccommodationRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            List<AccommodationListVM> Model = _repo.GetAll().Select(a => new AccommodationListVM
            {
                ID = a.ID,
                Address = a.Address,
                Description = a.Description,
                Distance = a.Distance,
                Name = a.Name,
                PhoneNumber = a.PhoneNumber,
                Picture = a.Picture
            }).ToList();

            return View(Model);
        }
    }
}