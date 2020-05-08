using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.Areas.Guest.ViewModels.Performance;
using Microsoft.AspNetCore.Mvc;

namespace Festival.Web.Areas.Guest.Controllers
{
    [Area("Guest")]
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
            List<GroupedPerformanceListVM> Model = new List<GroupedPerformanceListVM>();
            var query = _repo.GetAll().GroupBy(x => x.Start.Date).OrderBy(x => x.Key);
            foreach (IGrouping<DateTime, Performance> group in query)
            {
                Model.Add(new GroupedPerformanceListVM
                {
                    Key = group.Key.ToString("dd/MM"),
                    Performances = group.Where(g => g.Start.Date == group.Key).OrderBy(m => m.Start).Select(p => new PerformanceListVM
                    {
                        PerformanceID = p.ID,
                        Date = p.Start.ToString("dd/MM"),
                        StartTime = p.Start.ToString("hh:mm tt"),
                        Performer = p.Performer.Name,
                        Stage = p.Stage.Name,
                        Image = p.Performer.Picture
                    }).ToList()
                });
            }


            return View(Model);
        }
    }
}