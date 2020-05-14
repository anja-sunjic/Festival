using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.Areas.Admin.ViewModels.TicketVoucher;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TicketVoucherController : Controller
    {
        private readonly ITicketVoucherRepository _repo;

        public TicketVoucherController(ITicketVoucherRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            List<TicketVoucherListVM> model = _repo.GetAll().Select(x => new TicketVoucherListVM
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
            var model = new NewTicketVoucherVM();
            return View(model);
        }

        public IActionResult SaveNew(NewTicketVoucherVM model)
        {
            var ticketVoucher = new TicketVoucher()
            {
                VoucherCode = model.VoucherCode,
                ExpirationDate = model.ExpirationDate,
                Discount = model.Discount
            };

            _repo.Add(ticketVoucher);
            return View("List");
        }

        public IActionResult Detail(int ID)
        {
            TicketVoucher voucher = _repo.GetByID(ID);
            var model = new DetailTicketVoucherVM()
            {
                ID = voucher.ID,
                VoucherCode = voucher.VoucherCode,
                Discount = voucher.Discount,
                ExpirationDate = voucher.ExpirationDate,
                NumberOfRedeemedVouchers = voucher.NumberOfRedeemedVouchers
            };
            return View(model);
        }
    }
}
