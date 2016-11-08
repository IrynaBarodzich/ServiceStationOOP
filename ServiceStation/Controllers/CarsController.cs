using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStation.Data;
using ServiceStation.Models;
using System.Data.Entity;
using System.Data;
using ServiceStation.Repositories;
using AutoMapper;
using ServiceStation.ViewModels;

namespace ServiceStation.Controllers
{
    public class CarsController : Controller
    {

 //       ServiceContext db = new ServiceContext();

        IUnitOfWork _unitOfWork;

    //    IRepository<Cars, int> _repo;

      /*  public CarsController()
        {

        }
        */
         public CarsController(IUnitOfWork unitOfWork)
          {
              _unitOfWork = unitOfWork;
          //    _unitOfWork = new UnitOfWork(db);
         //     _repo = new Repository<Cars, int>(db);
          }
         


        public ViewResult Details(int id)
        {
            var model = Mapper.Map<Cars, CarsViewModel>(_unitOfWork.RepositoryFor<Cars, int>().Get(id));
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var model = Mapper.Map<Cars, CarsViewModel>(_unitOfWork.RepositoryFor<Cars, int>().Get(id));
            return View(model);
        }


        public ViewResult Create(int id)
        {
            //     Session["id"] = id;
            TempData["id"] = id;
            return View();
        }


        public ActionResult Delete(int id)
        {
            var model = Mapper.Map<Cars, CarsViewModel>(_unitOfWork.RepositoryFor<Cars, int>().Get(id));
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CarsViewModel model)
        {
            var car = _unitOfWork.RepositoryFor<Cars, int>().Get(model.CarsID);
            Mapper.Map(model, car);
            if (TryUpdateModel(car))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        _unitOfWork.RepositoryFor<Cars, int>().Update(car);
                        _unitOfWork.Commit();
                        return RedirectToAction("Details/" + car.ClientsID, "Clients");
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
        public ActionResult Create(CarsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var car = Mapper.Map<CarsViewModel, Cars>(model);

                    _unitOfWork.RepositoryFor<Cars, int>().Create(car);
                    _unitOfWork.Commit();
                    return RedirectToAction("Details/" + car.ClientsID, "Clients");
                }
            }
            catch (DataException)
            {
                throw;
            }
            return View();
        }



        [HttpPost]
        public ActionResult Delete(CarsViewModel model)
        {
            int id = model.CarsID;
            var car = _unitOfWork.RepositoryFor<Cars, int>().Get(model.CarsID);
            Mapper.Map(model, car);
                try
                {
                    if (ModelState.IsValid)
                    {
                        _unitOfWork.RepositoryFor<Orders, int>().Delete(car.CarsID);
                        _unitOfWork.Commit();
                    }
                }
                catch (DataException)
                {
                    throw;
                }          
            return RedirectToAction("Details/" + id, "Clients");
        }




    }
}
