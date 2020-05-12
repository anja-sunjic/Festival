using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.Areas.Guest.ViewModels.Performer;
using Microsoft.AspNetCore.Mvc;

namespace Festival.Web.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class PerformerController : Controller
    {
        private readonly IPerformerRepository _repo;
        public PerformerController(IPerformerRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index(int id)
        {
            return RedirectToAction("Details", new { id });
        }
        public IActionResult Details(int id)
        {
            Performer p = _repo.GetByID(id);
            PerformerDetailsVM Model = new PerformerDetailsVM
            {
                Id = p.ID,
                Name = p.Name,
                Picture = p.Picture,
                PromoText = p.PromoText
            };

            return PartialView(Model);
        }
    }
}