using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FestivalWebApplication.ViewModels.Performance;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FestivalWebApplication.Controllers
{
    public class PerformanceController : Controller
    {
        private readonly FestivalContext _db;

        public PerformanceController(FestivalContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        public IActionResult List()
        {
            List<PerformanceListVM> Model = _db.Performance.Select(p =>
                 new PerformanceListVM
                 {
                     PerformanceID=p.ID,
                     Start = p.Start,
                     Performer=_db.Performer.Where(x=> x.ID==p.PerformerID).FirstOrDefault().Name,
                     Stage=_db.Stage.Where(x=> x.ID==p.StageID).FirstOrDefault().Name

                 }).ToList();
            return View("List", Model);
        }

        public IActionResult New()
        {
            NewPerformanceVM Model = new NewPerformanceVM();
            Model.Stages = _db.Stage.Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.ID.ToString()
            }).ToList();

            Model.Performers = _db.Performer.Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.ID.ToString()
            }).ToList();

            return View("New",Model);
        }
        public IActionResult SaveNew(NewPerformanceVM Model)
        {
            Performance performance = new Performance();
            performance.Start = Model.Start;
            performance.StageID = Model.StageID;
            performance.PerformerID = Model.PerformerID;

            _db.Performance.Add(performance);
            _db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}