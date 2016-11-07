using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStation.Data;
using ServiceStation.Models;
using System.Data;
using ServiceStation.Repositories;

namespace ServiceStation.Controllers
{
    public class OrdersController : Controller
    {


        IUnitOfWork _unitOfWork;

        Repository<Orders, int> _repo;

        ServiceContext db = new ServiceContext();

     /*   public OrdersController()
        {

        }*/



           public OrdersController(IUnitOfWork unitOfWork,Repository<Orders,int> repo)
           {
               _unitOfWork = new UnitOfWork(db);
               _repo = new Repository<Orders, int>(db);
           }



        public ViewResult Edit(int id)
        {
            Orders order = _repo.Get(id);
            return View(order);
        }


        public ViewResult Create(int id)
        {
            TempData["id"] = id;
            return View();
        }



        public ActionResult Delete(int id, bool? saveChangesError)
        {

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes.";
            }
            return View(_repo.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Orders order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.Update(order);
                    _unitOfWork.Commit();
                    return RedirectToAction("Details/" + order.CarsID, "Cars");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException) 
                throw;
            }
            return View(order);
        }


        [HttpPost]
        public ActionResult Create(Orders order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.Create(order);
                    _unitOfWork.Commit();
                    return RedirectToAction("Details/" + order.CarsID, "Cars");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(order);
        }



        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders order = _repo.Get(id);
            try
            {
                _repo.Delete(id);
                _unitOfWork.Commit();
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException) 
                return RedirectToAction("Delete",
                    new System.Web.Routing.RouteValueDictionary {  
                { "id", id },  
                { "saveChangesError", true } });
            }
            return RedirectToAction("Details/" + order.CarsID, "Cars");
        }

        /*      protected override void Dispose(bool disposing)
              {
                  unitOfWork.Dispose();
                  base.Dispose(disposing);
              }

      */




    }
}
