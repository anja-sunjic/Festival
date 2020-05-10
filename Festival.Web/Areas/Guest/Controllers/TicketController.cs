using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Festival.Data.Repositories;
using Festival.Web.Areas.Guest.ViewModels.Ticket;
using Microsoft.AspNetCore.Mvc;

namespace Festival.Web.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class TicketController : Controller
    {
        private readonly ITicketTypeRepository _repo;

        public TicketController(ITicketTypeRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            List<TicketsVM> model = _repo.GetAll().OrderByDescending(p => p.Tier).Select(p => new TicketsVM
            {
                Id = p.ID,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Tier = p.Tier
            }).ToList();

            return View(model);
        }
    }
}