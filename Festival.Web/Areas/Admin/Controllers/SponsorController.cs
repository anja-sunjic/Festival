using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.Helper;
using Festival.Web.ViewModels.Sponsor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FestivalWebApplication.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class SponsorController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly ISponzorRepository _repo;

        public SponsorController(IWebHostEnvironment environment, ISponzorRepository repo)
        {
            hostingEnvironment = environment;
            _repo = repo;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        public IActionResult List()
        {

            List<SponsorsListVM> Model = _repo.GetAll().Select(s => new SponsorsListVM
            {
                SponsorID = s.ID,
                CompanyName = s.CompanyName,
                ContactPersonName = s.ContactPersonName,
                Number = s.PhoneNumber,
                Address = s.Address
            }).ToList();
            return View(Model);

        }
        public IActionResult New()
        {
            NewSponsorVM Model = new NewSponsorVM();
            return View(Model);
        }
        public IActionResult SaveNew(NewSponsorVM Model)
        {
            if (!ModelState.IsValid)
            {
                return View("New");
            }

            string uniqueFileName = Image.Upload(Model.Image, hostingEnvironment, "sponsors");

            Sponsor sponsor = new Sponsor()
            {
                CompanyName = Model.CompanyName,
                Address = Model.Address,
                PhoneNumber = Model.PhoneNumber,
                ContactPersonName = Model.ContactPersonName,
                Image = uniqueFileName
            };

            _repo.Add(sponsor);
            return RedirectToAction("List");
        }
        public IActionResult Edit(int id)
        {
            Sponsor sponsor = _repo.GetByID(id);
            EditSponsorVM model = new EditSponsorVM
            {
                Id = sponsor.ID,
                CompanyName = sponsor.CompanyName,
                Address = sponsor.Address,
                ContactPersonName = sponsor.ContactPersonName,
                PhoneNumber = sponsor.PhoneNumber
            };
            return View("Edit", model);
        }

        public IActionResult Save(EditSponsorVM Model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", Model);
            }
            Sponsor sponsor = _repo.GetByID(Model.Id);
            sponsor.CompanyName = Model.CompanyName;
            sponsor.Address = Model.Address;
            sponsor.PhoneNumber = Model.PhoneNumber;
            sponsor.ContactPersonName = Model.ContactPersonName;
            if (Model.Image != null)
            {
                string uniqueFileName = Image.Upload(Model.Image, hostingEnvironment, "sponsors");
                sponsor.Image = uniqueFileName;
            }
            _repo.Save();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var sponsor = _repo.GetByID(id);
            Image.Delete(hostingEnvironment, "sponsors", sponsor.Image);
            _repo.Delete(id);
            return RedirectToAction("List");
        }

        public IActionResult Detail(int id)
        {
            Sponsor sponsor = _repo.GetByID(id);
            DetailSponsorVM model = new DetailSponsorVM()
            {
                Id = sponsor.ID,
                CompanyName = sponsor.CompanyName,
                Address = sponsor.Address,
                ContactPersonName = sponsor.ContactPersonName,
                PhoneNumber = sponsor.PhoneNumber,
                Image = sponsor.Image
            };
            return View("Detail", model);
        }
    }
}
