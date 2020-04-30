using Festival.Data.Models;
using Festival.Data.Repositories;
using FestivalWebApplication.ViewModels.Stage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FestivalWebApplication.Controllers
{
    [Authorize]
    public class StageController : Controller
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

        //public IActionResult Edit(int id)
        //{
        //    //fetching stage object
        //    Stage x = _db.Stage.Find(id);

        //    //assigning data from x to Model
        //    EditStageVM Model = new EditStageVM();
        //    Model.Id = x.ID;
        //    Model.Name = x.Name;
        //    Model.Capacity = x.Capacity;

        //    Model.Sponsors = _db.Sponsor.Select(s => new SelectListItem
        //    {
        //        Value = s.ID.ToString(),
        //        Text = s.CompanyName
        //    }).ToList();

        //    Model.SponsorId = (int)x.SponsorID;

        //    return View("Edit", Model);

        //}
        //public IActionResult Save(EditStageVM Model)
        //{
        //    //finding stage in db
        //    Stage stage = _db.Stage.Find(Model.Id);
        //    //changing data
        //    stage.Name = Model.Name;
        //    stage.Capacity = Model.Capacity;
        //    stage.SponsorID = Model.SponsorId;

        //    _db.SaveChanges();

        //    return RedirectToAction("List");
        //}

        //public IActionResult Delete(int id)
        //{
        //    Stage stage = _db.Stage.Find(id);
        //    _db.Stage.Remove(stage);
        //    _db.SaveChanges();

        //    return RedirectToAction("List");
        //}
    }
}
