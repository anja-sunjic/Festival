using Festival.Data.Models;
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

        public ShopItemController(FestivalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            List<ShopItemListVM> p = _context.ShopItem.Select(p =>
                 new ShopItemListVM
                 {
                     ID = p.ID,
                     Name = p.Name,
                     Price = p.Price,
                     Quantity = p.Quantity,
                     Description = p.Description
                 }).ToList();
            return View("List", p);
        }

        public IActionResult New()
        {
            NewShopItemVM Model = new NewShopItemVM();
            return View(Model);
        }

        public IActionResult Delete(int ID)
        {
            ShopItem shopItem = _context.ShopItem.Find(ID);
            _context.Remove(shopItem);
            _context.SaveChanges();
            return Redirect("List");
        }

        public IActionResult Edit(int ID)
        {
            ShopItem shopItem = _context.ShopItem.Find(ID);
            EditShopItemVM Model = new EditShopItemVM
            {
                Name = shopItem.Name,
                Price = shopItem.Price,
                Quantity = shopItem.Quantity,
                Description = shopItem.Description
            };
            return View("Edit", Model);
        }

        [HttpPost]
        public IActionResult SaveNew(NewShopItemVM Model)
        {
            ShopItem shopItem = new ShopItem()
            {
                Name = Model.Name,
                Price = Model.Price,
                Quantity = Model.Quantity,
                Description = Model.Description
            };

            _context.ShopItem.Add(shopItem);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Save(EditShopItemVM Model)
        {
            ShopItem shopItem = _context.ShopItem.Find(Model.ID);
            shopItem.Name = Model.Name;
            shopItem.Description = Model.Description;
            shopItem.Price = Model.Price;
            shopItem.Quantity = Model.Quantity;
            _context.SaveChanges();
            return RedirectToAction("List");
        }

    }
}
