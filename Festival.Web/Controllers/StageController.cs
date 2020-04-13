using Festival.Data.Models;
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
        private readonly FestivalContext _db;
        public StageController(FestivalContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            //fetching all stages
            List<StagesListVM> Model = _db.Stage.Select(s => new StagesListVM
            {
                StageID = s.ID,
                Name = s.Name,
                Capacity = s.Capacity,
                Sponsor = _db.Sponsor.Where(x => x.ID == s.ID).FirstOrDefault().CompanyName
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
            Model.Sponsors = _db.Sponsor.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.CompanyName
            }).ToList();

            return View(Model);
        }

        public IActionResult SaveNew(NewStageVM Model)
        {
            Stage stage = new Stage();
            stage.Name = Model.Name;
            stage.Capacity = Model.Capacity;
            stage.SponsorID = Model.SponsorID;

            _db.Stage.Add(stage);
            _db.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            //fetching stage object
            Stage x = _db.Stage.Find(id);

            //assigning data from x to Model
            EditStageVM Model = new EditStageVM();
            Model.Id = x.ID;
            Model.Name = x.Name;
            Model.Capacity = x.Capacity;

            Model.Sponsors = _db.Sponsor.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.CompanyName
            }).ToList();

            Model.SponsorId = (int)x.SponsorID;

            return View("Edit", Model);

        }
        public IActionResult Save(EditStageVM Model)
        {
            //finding stage in db
            Stage stage = _db.Stage.Find(Model.Id);
            //changing data
            stage.Name = Model.Name;
            stage.Capacity = Model.Capacity;
            stage.SponsorID = Model.SponsorId;

            _db.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            Stage stage = _db.Stage.Find(id);
            _db.Stage.Remove(stage);
            _db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
