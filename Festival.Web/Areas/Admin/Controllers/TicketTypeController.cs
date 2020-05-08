using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.ViewModels.TicketType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FestivalWebApplication.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class TicketTypeController : Controller
    {
        private readonly ITicketTypeRepository _repo;

        public TicketTypeController(ITicketTypeRepository repo)
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

        public IActionResult List()
        {
            List<TicketTypeListVM> Model = _repo.GetAll().Select(p => new TicketTypeListVM
            {
                Id = p.ID,
                Name = p.Name,
                Price = p.Price,
                TicketsBought = _repo.GetNumberOfTicketsBought(p.ID),
                Description = p.Description
            }).ToList();

            return View(Model);
        }

        public IActionResult New()
        {
            NewTicketTypeVM Model = new NewTicketTypeVM();

            return View(Model);
        }

        public IActionResult SaveNew(NewTicketTypeVM Model)
        {
            if (!ModelState.IsValid)
            {
                return View("New");
            }
            TicketType ticketType = new TicketType()
            {
                Name = Model.Name,
                Price = Model.Price,
                Description = Model.Description,
                Tier = Model.Tier
            };
            _repo.Add(ticketType);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int Id)
        {
            _repo.Delete(Id);
            return RedirectToAction("List");
        }
        public IActionResult Edit(int Id)
        {
            TicketType tt = _repo.GetByID(Id);
            var model = new EditTicketTypeVM
            {
                Id = tt.ID,
                Name = tt.Name,
                Price = tt.Price,
                Description = tt.Description,
                Tier = tt.Tier
            };

            return View(model);
        }

        public IActionResult Save(EditTicketTypeVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }
            var tt = _repo.GetByID(model.Id);
            tt.Name = model.Name;
            tt.Price = model.Price;
            tt.Description = model.Description;
            tt.Tier = model.Tier;
            _repo.Save();
            return RedirectToAction("List");
        }

        public IActionResult Detail(int Id)
        {
            TicketType tt = _repo.GetByID(Id);
            var model = new DetailTicketTypeVM
            {
                Id = tt.ID,
                Name = tt.Name,
                Description = tt.Description,
                Price = tt.Price,
                TicketsSold = _repo.GetNumberOfTicketsBought(tt.ID)
            };
            return View(model);
        }
    }

}
