using Festival.Data.Models;
using Festival.Data.Repositories;
using FestivalWebApplication.ViewModels.Accommodation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FestivalWebApplication.Controllers
{
    [Authorize]
    public class AccommodationsController : Controller
    {
        private readonly IAccommodationRepository _repo;

        public AccommodationsController(IAccommodationRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            List<AccommodationListVM> model = _repo.GetAll().Select(acc => new AccommodationListVM
            {
                ID = acc.ID,
                Description = acc.Description,
                Distance = acc.Distance,
                Name = acc.Name,
                PhoneNumber = acc.PhoneNumber
            }).ToList();
            return View("List", model);

        }

        public IActionResult New()
        {
            NewAccommodationVM Model = new NewAccommodationVM();
            return View(Model);
        }

        public IActionResult Detail(int ID)
        {
            Accommodation accomodation = _repo.GetByID(ID);
            DetailAccommodationVM Model = new DetailAccommodationVM()
            {
                ID = accomodation.ID,
                Name = accomodation.Name,
                PhoneNumber = accomodation.PhoneNumber,
                Distance = accomodation.Distance,
                Description = accomodation.Description
            };
            return View(Model);
        }

        public IActionResult Delete(int ID)
        {
            _repo.Delete(ID);
            return Redirect("/Accommodations/List");
        }

        public IActionResult Edit(int Id)
        {
            Accommodation accommodation = _repo.GetByID(Id);
            EditAccommodationVM Model = new EditAccommodationVM
            {
                ID = Id,
                Name = accommodation.Name,
                PhoneNumber = accommodation.PhoneNumber,
                Distance = accommodation.Distance,
                Description = accommodation.Description
            };
            return View("Edit", Model);
        }


        public IActionResult SaveNew(NewAccommodationVM Model)
        {
            Accommodation accommodation = new Accommodation()
            {
                Name = Model.Name,
                Distance = Model.Distance,
                PhoneNumber = Model.PhoneNumber,
                Description = Model.Description
            };

            _repo.Add(accommodation);
            return RedirectToAction("List");
        }


        public IActionResult Save(EditAccommodationVM Model)
        {
            Accommodation acc = _repo.GetByID(Model.ID);
            acc.Name = Model.Name;
            acc.Description = Model.Description;
            acc.Distance = Model.Distance;
            acc.PhoneNumber = Model.PhoneNumber;
            _repo.Save();
            return RedirectToAction("List");
        }
    }
}
