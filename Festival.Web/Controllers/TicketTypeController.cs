using Festival.Data.Models;
using FestivalWebApplication.ViewModels.TicketType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FestivalWebApplication.Controllers
{
    [Authorize]
    public class TicketTypeController : Controller
    {
        private readonly FestivalContext _db;

        public TicketTypeController(FestivalContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<TicketTypeVM> Model = _db.TicketType.Select(p => new TicketTypeVM
            {
                Id = p.ID,
                Name = p.Name,
                Price = p.Price
            }).ToList();
            return View(Model);
        }
        public IActionResult New()
        {
            TicketTypeVM Model = new TicketTypeVM();

            return View(Model);
        }
        public IActionResult Delete(int Id)
        {

            TicketType ticketType = _db.TicketType.Find(Id);

            _db.Remove(ticketType);
            _db.SaveChanges();
            return Redirect("/TicketType/Index");
        }
        public IActionResult Update(int Id)
        {
            TicketType ticketType = _db.TicketType.Find(Id);
            TicketTypeVM Model = new TicketTypeVM
            {
                Id = ticketType.ID,
                Name = ticketType.Name,
                Price = ticketType.Price
            };

            return View("New", Model);
        }


        [HttpPost]
        public IActionResult SaveNew(TicketTypeVM Model)
        {

            TicketType ticketType;

            if (Model.Id == 0)
            {
                ticketType = new TicketType();
                _db.TicketType.Add(ticketType);

            }
            else
            {
                ticketType = _db.TicketType.Find(Model.Id);
            }

            ticketType.Name = Model.Name;
            ticketType.Price = Model.Price;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}
