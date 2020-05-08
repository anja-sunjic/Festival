using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.Helper;
using Festival.Web.ViewModels.Performance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FestivalWebApplication.Controllers
{

    [Area("Admin")]
    public class PerformanceController : Controller
    {
        private readonly FestivalContext _db;
        private readonly IPerformanceRepository _repo;

        public PerformanceController(FestivalContext db, IPerformanceRepository repo)
        {
            _db = db;
            _repo = repo;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        public IActionResult List(int? pageNumber)
        {
            int pageSize = 4;

            var model = _repo.GetAll().OrderBy(m => m.Start).ToList().Select(p =>
                 new PerformanceListVM
                 {
                     PerformanceID = p.ID,
                     Date = p.Start.ToString("dd/MM"),
                     StartTime = p.Start.ToString("hh:mm tt"),
                     Performer = p.Performer.Name,
                     Stage = p.Stage.Name

                 }).AsQueryable();


            var newModel = PaginatedList<PerformanceListVM>.CreateAsync(model, pageNumber ?? 1, pageSize);

            return View("List", newModel);
        }

        public IActionResult New()
        {
            var model = new NewPerformanceVM
            {
                Stages =
                    _repo.GetAllStages().Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.ID.ToString()
                    }).ToList(),
                Performers =
                    _repo.GetAllPerformers().Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.ID.ToString()
                    }).ToList(),
                Start = DateTime.Today
            };

            return View("New", model);
        }

        public IActionResult Edit(int id)
        {
            var performance = _repo.GetById(id);

            var model = new EditPerformanceVM
            {
                ID = id,
                Start = performance.Start,
                Stages =
                    _repo.GetAllStages().Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.ID.ToString()
                    }).ToList(),
                Performers =
                    _repo.GetAllPerformers().Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.ID.ToString()
                    }).ToList(),
                PerformerID = performance.PerformerID,
                StageID = performance.StageID
            };

            return View("Edit", model);
        }

        public IActionResult SaveNew(NewPerformanceVM model)
        {
            if (!ModelState.IsValid)
            {
                model = new NewPerformanceVM
                {
                    Stages =
                        _repo.GetAllStages().Select(s => new SelectListItem
                        {
                            Text = s.Name,
                            Value = s.ID.ToString()
                        }).ToList(),
                    Performers =
                        _repo.GetAllPerformers().Select(s => new SelectListItem
                        {
                            Text = s.Name,
                            Value = s.ID.ToString()
                        }).ToList(),
                    Start = DateTime.Today
                };

                return View("New", model);
            }

            var performance = new Performance
            {
                Start = model.Start,
                StageID = model.StageID,
                PerformerID = model.PerformerID
            };

            _repo.Add(performance);

            return RedirectToAction("List");
        }

        public IActionResult Save(EditPerformanceVM model)
        {
            var performance = _repo.GetById(model.ID);

            if (!ModelState.IsValid)
            {
                model = new EditPerformanceVM
                {
                    Stages =
                        _repo.GetAllStages().Select(s => new SelectListItem { Text = s.Name, Value = s.ID.ToString() })
                            .ToList(),
                    Performers =
                        _repo.GetAllPerformers()
                            .Select(s => new SelectListItem { Text = s.Name, Value = s.ID.ToString() }).ToList(),
                    Start = DateTime.Today,
                    PerformerID = performance.PerformerID,
                    StageID = performance.StageID
                };


                return View("Edit", model);
            }

            performance.Start = model.Start;
            performance.StageID = model.StageID;
            performance.PerformerID = model.PerformerID;

            _repo.Save();

            return RedirectToAction("List");
        }

        public IActionResult Detail(int id)
        {
            var performance = _repo.GetById(id);
            var model = new DetailPerformanceVM
            {
                ID = performance.ID,
                Start = performance.Start.ToString("dd/MM/yyyy hh:mm tt"),
                PerformerName = performance.Performer.Name,
                StageName = performance.Stage.Name,
                PerformerPicture = performance.Performer.Picture
            };
            return View("Detail", model);
        }

        public IActionResult Delete(int id)
        {
            _repo.Delete(id);

            return RedirectToAction("List");
        }
    }
}
