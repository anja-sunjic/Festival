using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.ViewModels.Stage;
using FestivalWebApplication.ViewModels.Stage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Festival.Web.Controllers;

namespace FestivalWebApplication.Controllers
{
    [Authorize]
    public class StageController : BaseController
    {
        private readonly IStageRepository _repo;
        public StageController(IStageRepository repo)
        {
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
                return View("New");
            }
            Stage stage = new Stage();
            stage.Name = Model.Name;
            stage.Capacity = Model.Capacity;
            stage.SponsorID = Model.SponsorID;

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

            Model.SponsorId = (int)x.SponsorID;

            return View("Edit", Model);

        }
        public IActionResult Save(EditStageVM Model)
        {
            //finding stage in db
            Stage stage = _repo.GetByID(Model.Id);
            //changing data
            stage.Name = Model.Name;
            stage.Capacity = Model.Capacity;
            stage.SponsorID = Model.SponsorId;

            _repo.Save();

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
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
                SponsorName = _repo.GetSponsor(id).CompanyName
            };
            return View(model);
        }
    }
}
