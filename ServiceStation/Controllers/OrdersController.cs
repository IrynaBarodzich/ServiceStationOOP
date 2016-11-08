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

     //   Repository<Orders, int> _repo;

     //   ServiceContext db = new ServiceContext();

     /*   public OrdersController()
        {

        }*/



           public OrdersController(IUnitOfWork unitOfWork)
           {
               _unitOfWork = unitOfWork;
        //       _repo = repo;
           }



        public ViewResult Edit(int id)
        {
            Orders order = _unitOfWork.RepositoryFor<Orders, int>().Get(id);
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
            return View(_unitOfWork.RepositoryFor<Orders, int>().Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Orders order)
        {
            var _order = _unitOfWork.RepositoryFor<Orders, int>().Get(order.OrdersID);
            if (TryUpdateModel(_order))
            {

                try
                {
                    if (ModelState.IsValid)
                    {
                        _unitOfWork.RepositoryFor<Orders, int>().Update(_order);
                        _unitOfWork.Commit();
                        return RedirectToAction("Details/" + _order.CarsID, "Cars");
                    }
                }
                catch (DataException)
                {
                    //Log the error (add a variable name after DataException) 
                    throw;
                }
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
                    _unitOfWork.RepositoryFor<Orders, int>().Create(order);
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
            Orders order = _unitOfWork.RepositoryFor<Orders, int>().Get(id);
            try
            {
                _unitOfWork.RepositoryFor<Orders, int>().Delete(id);
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
