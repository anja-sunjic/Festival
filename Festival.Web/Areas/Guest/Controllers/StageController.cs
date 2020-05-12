using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.Areas.Guest.ViewModels.Stage;
using Microsoft.AspNetCore.Mvc;

namespace Festival.Web.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class StageController : Controller
    {
        private readonly IStageRepository _repo;
        public StageController(IStageRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index(int id)
        {
            return RedirectToAction("Details", new { id });
        }
        public IActionResult Details(int id)
        {
            Stage s = _repo.GetByID(id);
            StageDetailsVM Model = new StageDetailsVM
            {
                ID = s.ID,
                Capacity = s.Capacity,
                Name = s.Name,
                SponsorName = s.Sponsor.CompanyName,
                SponsorImage = s.Sponsor.Image,
                Image = s.Image
            };

            return PartialView(Model);
        }
    }
}