using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.Helper;
using Festival.Web.ViewModels.Stage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FestivalWebApplication.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class StageController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IStageRepository _repo;
        public StageController(IWebHostEnvironment environment, IStageRepository repo)
        {
            _hostingEnvironment = environment;
            _repo = repo;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            //fetching all stages
            List<StagesListVM> Model = _repo.GetAll().Select(s => new StagesListVM
            {
                StageID = s.ID,
                Name = s.Name,
                Capacity = s.Capacity,
                Sponsor = s.Sponsor.CompanyName
            }).ToList();

            //ordered list
            int broj = 0;
            foreach (StagesListVM x in Model)
            {
                x.Number = ++broj;
            }
            return View(Model);
        }
        public IActionResult New()
        {
            NewStageVM Model = new NewStageVM();
            //populating sponsors list
            Model.Sponsors = _repo.GetAllSponsors().Select(s => new SelectListItem
            {
                Text = s.CompanyName,
                Value = s.ID.ToString(),
            }).ToList();

            return View(Model);
        }

        public IActionResult SaveNew(NewStageVM Model)
        {
            if (!ModelState.IsValid)
            {
                Model.Sponsors = _repo.GetAllSponsors().Select(s => new SelectListItem
                {
                    Text = s.CompanyName,
                    Value = s.ID.ToString(),
                }).ToList();
                return View("New", Model);
            }
            string uniqueFileName = Image.Upload(Model.Image, _hostingEnvironment, "stages");
            Stage stage = new Stage();
            stage.Name = Model.Name;
            stage.Capacity = Model.Capacity;
            stage.SponsorID = Model.SponsorID;
            stage.Image = uniqueFileName;

            _repo.Add(stage);

            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            //fetching stage object
            Stage x = _repo.GetByID(id);

            //assigning data from x to Model
            EditStageVM Model = new EditStageVM();
            Model.Id = x.ID;
            Model.Name = x.Name;
            Model.Capacity = x.Capacity;

            Model.Sponsors = _repo.GetAllSponsors().Select(s => new SelectListItem
            {
                Text = s.CompanyName,
                Value = s.ID.ToString(),
            }).ToList();

            Model.SponsorID = (int)x.SponsorID;

            return View("Edit", Model);

        }
        public IActionResult Save(EditStageVM Model)
        {
            if (!ModelState.IsValid)
            {
                Model.Sponsors = _repo.GetAllSponsors().Select(s => new SelectListItem
                {
                    Text = s.CompanyName,
                    Value = s.ID.ToString(),
                }).ToList();
                return View("Edit", Model);
            }
            //finding stage in db
            Stage stage = _repo.GetByID(Model.Id);
            //changing data
            stage.Name = Model.Name;
            stage.Capacity = Model.Capacity;
            stage.SponsorID = Model.SponsorID;
            if (Model.Image != null)
            {
                string uniqueFileName = Image.Upload(Model.Image, _hostingEnvironment, "stages");
                stage.Image = uniqueFileName;
            }
            _repo.Save();

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var stage = _repo.GetByID(id);
            Image.Delete(_hostingEnvironment, "stages", stage.Image);
            _repo.Delete(id);
            return RedirectToAction("List");
        }

        public IActionResult Detail(int id)
        {
            Stage x = _repo.GetByID(id);
            DetailStageVM model = new DetailStageVM
            {
                Id = x.ID,
                Name = x.Name,
                Capacity = x.Capacity,
                SponsorName = _repo.GetSponsor(id).CompanyName,
                Image = x.Image

            };
            return View(model);
        }
    }
}
