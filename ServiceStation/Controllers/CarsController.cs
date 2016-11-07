using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStation.Data;
using ServiceStation.Models;
using System.Data.Entity;
using System.Data;
using ServiceStation.Repositories;

namespace ServiceStation.Controllers
{
    public class CarsController : Controller
    {

        ServiceContext db = new ServiceContext();

        IUnitOfWork _unitOfWork;

        Repository<Cars, int> _repo;

      /*  public CarsController()
        {

        }
        */
         public CarsController(IUnitOfWork unitOfWork,Repository<Cars,int> repo)
          {
         //     _unitOfWork = unitOfWork;
        //      _repo = repo;
              _unitOfWork = new UnitOfWork(db);
              _repo = new Repository<Cars, int>(db);
          }
         


        public ViewResult Details(int id)
        {
            Cars car = _repo.Get(id);
            return View(car);
        }


        public ActionResult Edit(int id)
        {
            Cars car = _repo.Get(id);
            return View(car);
        }


        public ViewResult Create(int id)
        {
            //     Session["id"] = id;
            TempData["id"] = id;
            return View();
        }


        public ActionResult Delete(int id)
        {
            return View(_repo.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Cars car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.Update(car);
                    _unitOfWork.Commit();
                    return RedirectToAction("Details/" + car.ClientsID, "Clients");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException) 
                throw;
            }
            return View(car);
        }


        [HttpPost]
        public ActionResult Create(Cars car)
        {
            //   car.ClientsID = (int)Session["id"];
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.Create(car);
                    _unitOfWork.Commit();
                    return RedirectToAction("Details/" + car.ClientsID, "Clients");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(car);
        }



        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var car = _repo.Get(id);
            try
            {
                _repo.Delete(id);
                _unitOfWork.Commit();
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");

            }
            return RedirectToAction("Details/" + car.ClientsID, "Clients");
        }




    }
}
