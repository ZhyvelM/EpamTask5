using AutoMapper;
using BL;
using BL.Elements;
using BL.Interfaces;
using EpamTask5.Models;
using EpamTask5.Util;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpamTask5.Controllers
{
    public class SaleController : Controller
    {
        private IMapper _mapper;
        private ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _mapper = new Mapper(WebMapperConfig.Configure());
            _saleService = saleService;
        }

        // GET: Sale
        public ActionResult Index(int? page)
        {
            ViewBag.CurrentPage = page ?? 1;
            return View();
        }

        [HttpPost]
        public ActionResult GetAll()
        {
            var sales = _mapper.Map<IEnumerable<SaleDTO>, IEnumerable<SaleViewModel>>(_saleService.GetAll());
            return PartialView(sales);
        }

        public ActionResult Sales(int? page)
        {
            try
            {
                var sales = _mapper.Map<IEnumerable<SaleDTO>, IEnumerable<SaleViewModel>>(_saleService.GetAll());
                ViewBag.CurrentPage = page;
                return PartialView("Sales", sales.ToPagedList(1, sales.Count() == 0 ? 1 : sales.Count()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sales(SaleFilter model)
        {
            try
            {
                if (ModelState.Values.Any(x=> x.Value.AttemptedValue != ""))
                {
                    var sales = _mapper.Map<IEnumerable<SaleDTO>, IEnumerable<SaleViewModel>>(_saleService.GetAll());
                    if (model.Date != null)
                    {
                        sales = sales.Where(x => (x.Date.Equals(model.Date)));
                    }
                    if (model.ClientName != null)
                    {
                        sales = sales.Where(x => x.ClientName.ToLower().Contains(model.ClientName.ToLower()));
                    }
                    if (model.Product != null)
                    {
                        sales = sales.Where(x => x.Product.ToLower().Contains(model.Product.ToLower()));
                    }
                    if (model.SaleManager != null)
                    {
                        sales = sales.Where(x => x.SaleManager.ToLower().Contains(model.SaleManager.ToLower()));
                    }
                    if (model.Price != 0)
                    {
                        sales = sales.Where(x => x.Price.Equals(model.Price));
                    }
                    return PartialView("Sales", sales.ToPagedList(1, sales.Count() == 0 ? 1 : sales.Count()));

                }
                
                return GetAll();
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        // GET: Sale/Details/5
        public ActionResult Details(int id)
        {
            return View(_mapper.Map<SaleDTO, SaleViewModel>(_saleService.FindById(id)));
        }

        // GET: Sale/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create(int? page)
        {
            var model = new CreateSaleViewModel();
            ViewBag.CurrentPage = page;
            return View(model);
        }

        // POST: Sale/Create
        [HttpPost]
        public ActionResult Create(CreateSaleViewModel model, int? page)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                _saleService.AddSale(_mapper.Map<CreateSaleViewModel, SaleDTO>(model));

                return RedirectToAction("Index", new { page = page });
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Sale/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id, int? page)
        {
            ViewBag.CurrentPage = page;
            return View(_mapper.Map<SaleDTO, SaleViewModel>(_saleService.FindById(id)));
        }

        // POST: Sale/Edit/5
        [HttpPost]
        public ActionResult Edit(SaleViewModel model, int? page)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _saleService.Update(_mapper.Map<SaleViewModel, SaleDTO>(model));
                    return RedirectToAction("Index", new { page = page });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sale/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id, int? page)
        {
            ViewBag.CurrentPage = page;
            return View(_mapper.Map<SaleDTO, SaleViewModel>(_saleService.FindById(id)));
        }

        // POST: Sale/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection, int? page)
        {
            try
            {
                _saleService.Delete(id);
                return RedirectToAction("Index", new { page = page });
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _saleService != null)
            {
                _saleService.Dispose();
                _saleService = null;
            }
            base.Dispose(disposing);
        }
    }
}
