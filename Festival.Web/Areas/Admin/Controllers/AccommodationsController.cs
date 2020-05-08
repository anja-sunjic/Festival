using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.Helper;
using Festival.Web.ViewModels.Accommodation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Web.Controllers
{
    [Authorize]
    [Area("Admin")]
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

        public IActionResult List()
        {


            List<AccommodationListVM> model = _repo.GetAll().Select(acc => new AccommodationListVM
            {
                ID = acc.ID,
                Description = acc.Description ?? "No Description",
                Distance = acc.Distance,
                Name = acc.Name,
                PhoneNumber = acc.PhoneNumber,
                Address = acc.Address
            }).ToList();

            return View("List", model);

        }

        public IActionResult New()
        {
            NewAccommodationVM model = new NewAccommodationVM();
            return View(model);
        }

        public IActionResult Detail(int ID)
        {
            Accommodation accomodation = _repo.GetByID(ID);
            var model = new DetailAccommodationVM()
            {
                ID = accomodation.ID,
                Name = accomodation.Name,
                PhoneNumber = accomodation.PhoneNumber,
                Distance = accomodation.Distance,
                Description = accomodation.Description,
                Address = accomodation.Address,
                Picture = accomodation.Picture
            };
            return View(model);
        }

        public IActionResult Delete(int ID)
        {
            var acc = _repo.GetByID(ID);
            Image.Delete(_webHostEnvironment, "accommodations", acc.Picture);
            _repo.Delete(ID);
            return Redirect("/Accommodations/List");
        }

        public IActionResult Edit(int Id)
        {
            Accommodation accommodation = _repo.GetByID(Id);
            EditAccommodationVM model = new EditAccommodationVM
            {
                ID = Id,
                Name = accommodation.Name,
                PhoneNumber = accommodation.PhoneNumber,
                Distance = accommodation.Distance,
                Description = accommodation.Description,
                Address = accommodation.Address
            };
            return View("Edit", model);
        }


        public IActionResult SaveNew(NewAccommodationVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("New");
            }

            string uniqueFileName = Image.Upload(model.ProfileImage, _webHostEnvironment, "accommodations");

            Accommodation accommodation = new Accommodation()
            {
                Name = model.Name,
                Distance = model.Distance,
                PhoneNumber = model.PhoneNumber,
                Description = model.Description,
                Address = model.Address,
                Picture = uniqueFileName
            };

            _repo.Add(accommodation);
            return RedirectToAction("List");
        }


        public IActionResult Save(EditAccommodationVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }
            Accommodation acc = _repo.GetByID(model.ID);
            acc.Name = model.Name;
            acc.Description = model.Description;
            acc.Distance = model.Distance;
            acc.PhoneNumber = model.PhoneNumber;
            acc.Address = model.Address;
            if (model.ProfileImage != null)
            {
                string uniqueFileName = Image.Upload(model.ProfileImage, _webHostEnvironment, "accommodations");
                acc.Picture = uniqueFileName;
            }
            _repo.Save();
            return RedirectToAction("List");
        }
    }
}
