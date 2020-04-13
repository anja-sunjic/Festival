using Festival.Data.Models;
using Festival.Data.Repositories;
using FestivalWebApplication.ViewModels.ShopItem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FestivalWebApplication.Controllers
{
    [Authorize]
    public class ShopItemController : Controller
    {
        private readonly FestivalContext _context;
        private readonly IShopItemRepository _repo;

        public ShopItemController(FestivalContext context, IShopItemRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            List<ShopItemListVM> model = _repo.GetAll().Select(p =>
                 new ShopItemListVM
                 {
                     ID = p.ID,
                     Name = p.Name,
                     Price = p.Price,
                     Quantity = p.Quantity,
                     Description = p.Description
                 }).ToList();
            return View("List", model);
        }

        public IActionResult New()
        {
            NewShopItemVM Model = new NewShopItemVM();
            return View(Model);
        }

        public IActionResult Delete(int ID)
        {
            _repo.Delete(ID);
            return Redirect("/ShopItem/List");
        }

        public IActionResult Detail(int ID)
        {
            ShopItem item = _repo.GetByID(ID);
            DetailShopItemVM model = new DetailShopItemVM()
            {
                ID = item.ID,
                Name = item.Name,
                Quantity = item.Quantity,
                Price = item.Price,
                Description = item.Description,

            };
            return View(model);
        }

        public IActionResult Edit(int ID)
        {
            ShopItem shopItem = _repo.GetByID(ID);
            EditShopItemVM Model = new EditShopItemVM
            {
                ID = ID,
                Name = shopItem.Name,
                Price = shopItem.Price,
                Quantity = shopItem.Quantity,
                Description = shopItem.Description
            };
            return View("Edit", Model);
        }

        [HttpPost]
        public IActionResult SaveNew(NewShopItemVM model)
        {
            ShopItem shopItem = new ShopItem()
            {
                Name = model.Name,
                Price = model.Price,
                Quantity = model.Quantity,
                Description = model.Description
            };

            _repo.Add(shopItem);

            return RedirectToAction("List");
        }

        public IActionResult Save(EditShopItemVM model)
        {
            ShopItem shopItem = _repo.GetByID(model.ID);
            shopItem.Name = model.Name;
            shopItem.Description = model.Description;
            shopItem.Price = model.Price;
            shopItem.Quantity = model.Quantity;
            _repo.Save();
            return RedirectToAction("List");
        }

    }
}
