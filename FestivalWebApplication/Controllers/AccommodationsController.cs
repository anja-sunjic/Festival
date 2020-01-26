using ClassLibrary.Models;
using FestivalWebApplication.ViewModels.Accommodation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FestivalWebApplication.Controllers
{
    public class AccommodationsController : Controller
    {
        private readonly FestivalContext _context;

        public AccommodationsController(FestivalContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            List<AccommodationListVM> Model = _context.Accommodation.Select(p =>
                 new AccommodationListVM
                 {
                     ID = p.ID,
                     Name = p.Name,
                     PhoneNumber = p.PhoneNumber,
                     Distance = p.Distance,
                     Description = p.Description
                 }).ToList();
            return View("List", Model);
        }

        public IActionResult New()
        {
            NewAccommodationVM Model = new NewAccommodationVM();
            return View(Model);
        }

        public IActionResult Delete(int ID)
        {
            Accommodation accommodation = _context.Accommodation.Find(ID);
            _context.Remove(accommodation);
            _context.SaveChanges();
            return Redirect("List");
        }

        public IActionResult Edit(int Id)
        {
            Accommodation accommodation = _context.Accommodation.Find(Id);
            EditAccommodationVM Model = new EditAccommodationVM
            {
                Name = accommodation.Name,
                PhoneNumber = accommodation.PhoneNumber,
                Distance = accommodation.Distance,
                Description = accommodation.Description
            };
            return View("Edit", Model);
        }

        [HttpPost]
        public IActionResult SaveNew(NewAccommodationVM Model)
        {
            Accommodation accommodation = new Accommodation()
            {
                Name = Model.Name,
                Distance = Model.Distance,
                PhoneNumber = Model.PhoneNumber,
                Description = Model.Description
            };

            _context.Accommodation.Add(accommodation);
            _context.SaveChanges();

            return RedirectToAction("List");
        }


        public IActionResult Save(EditAccommodationVM Model)
        {
            Accommodation acc = _context.Accommodation.Find(Model.ID);
            acc.Name = Model.Name;
            acc.Description = Model.Description;
            acc.Distance = Model.Distance;
            acc.PhoneNumber = Model.PhoneNumber;
            _context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
