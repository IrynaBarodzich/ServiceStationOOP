using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStation.Data;
using ServiceStation.Models;
using System.Data;
using ServiceStation.Repositories;
using AutoMapper;
using ServiceStation.ViewModels;

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
            var model = Mapper.Map<Orders, OrdersViewModel>(_unitOfWork.RepositoryFor<Orders, int>().Get(id));
            return View(model);
        }


        public ViewResult Create(int id)
        {
            TempData["id"] = id;
            return View();
        }



        public ActionResult Delete(int id)
        {
            var model = Mapper.Map<Orders, OrdersViewModel>(_unitOfWork.RepositoryFor<Orders, int>().Get(id));
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(OrdersViewModel model)
        {
            var order = _unitOfWork.RepositoryFor<Orders, int>().Get(model.OrdersID);
            Mapper.Map(model, order);
            if (TryUpdateModel(order))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        _unitOfWork.RepositoryFor<Orders, int>().Update(order);
                        _unitOfWork.Commit();
                        return RedirectToAction("Details/" + model.CarsID, "Cars");
                    }
                }
                catch (DataException)
                {
                    throw;
                }
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult Create(OrdersViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var order = Mapper.Map<OrdersViewModel, Orders>(model);

                    _unitOfWork.RepositoryFor<Orders, int>().Create(order);
                    _unitOfWork.Commit();
                    return RedirectToAction("Details/" + order.CarsID, "Cars");
                }
            }
            catch (DataException)
            {
                throw;
            }
            return View();
        }



        [HttpPost]
        public ActionResult Delete(OrdersViewModel model)
          {
              var order = Mapper.Map<OrdersViewModel, Orders>(model); 
            //var order = _unitOfWork.RepositoryFor<Orders, int>().Get(model.OrdersID);
              Mapper.Map(model, order);
                try
                {
                    if (ModelState.IsValid)
                    {
                        _unitOfWork.RepositoryFor<Orders, int>().Delete(order.OrdersID);
                        _unitOfWork.Commit();
                    }
                }
                catch (DataException)
                {
                    throw;
                }
            return RedirectToAction("Details/" + 1, "Cars");
        }



        /*      protected override void Dispose(bool disposing)
              {
                  unitOfWork.Dispose();
                  base.Dispose(disposing);
              }

      */




    }
}
