using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.Areas.Admin.ViewModels.PurchaseVoucher;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PurchaseVoucherController : Controller
    {
        private readonly IPurchaseVoucherRepository _repo;

        public PurchaseVoucherController(IPurchaseVoucherRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            List<PurchaseVoucherListVM> model = _repo.GetAll().Select(x => new PurchaseVoucherListVM
            {
                ID = x.ID,
                VoucherCode = x.VoucherCode,
                ExpirationDate = x.ExpirationDate,
                Discount = x.Discount,
                NumberOfRedeemedVouchers = x.NumberOfRedeemedVouchers
            }).ToList();

            return View(model);
        }

        public IActionResult New()
        {
            var model = new NewPurchaseVoucherVM();
            return View(model);
        }

        public IActionResult SaveNew(NewPurchaseVoucherVM model)
        {
            var purchaseVoucher = new PurchaseVoucher()
            {
                VoucherCode = model.VoucherCode,
                ExpirationDate = model.ExpirationDate,
                Discount = model.Discount
            };

            _repo.Add(purchaseVoucher);
            return RedirectToAction("List");
        }
    }
}
