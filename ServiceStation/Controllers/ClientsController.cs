using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStation.Data;
using ServiceStation.Models;
using System.Data;
using System.Data.Entity;
using AutoMapper;
using ServiceStation.Repositories;
using ServiceStation.ViewModels;



namespace ServiceStation.Controllers
{
    public class ClientsController : Controller
    {



       /*      public ClientsController()
             {

             }*/

  //      ServiceContext db = new ServiceContext();

        IUnitOfWork _unitOfWork;

        IRepository<Clients, int> _repo;


       public ClientsController(UnitOfWork unitOfWork, IRepository<Clients, int> repo)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
    //        _unitOfWork = new UnitOfWork(db);
    //        _repo = new Repository<Clients, int>(db);
        }




        //      private ServiceContext db = new ServiceContext();

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult List(string firstName, string lastName)
        {


   /*         var clients = _repo.GetList()
                 .Where(c => c.FirstName == firstName)
                 .Where(c => c.LastName == lastName);*/
            var clients =
    Mapper.Map<IEnumerable<Clients>, List<ClientsViewModel>>(_repo.GetList()
    .Where(c => c.FirstName == firstName)
    .Where(c => c.LastName == lastName));
            return View(clients);
        }



        public ViewResult Details(int id)
        {
            var model = Mapper.Map<Clients, ClientsViewModel>(_repo.Get(id));
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

          //  Clients client = _repo.Get(id);
            var model = Mapper.Map<Clients, ClientsViewModel>(_repo.Get(id));
            TempData["firstName"] = model.FirstName;
            TempData["lastName"] = model.LastName;
            return View(model);
        }

        public ViewResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Edit(ClientsViewModel model)

        {
            try
            {
                if (ModelState.IsValid)
                {
                   var client = _repo.Get(model.ClientsID);
                   Mapper.Map(model, client);

                    _repo.Update(client);
                    _unitOfWork.Commit();
                    return RedirectToAction("Details/" + model.ClientsID);
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException) 
                //  ModelState.AddModelError("", "Unable to save changes.");
                //  return RedirectToAction("Details/" + client.ClientsID);
            }
            return View(model);
        }

     

        [HttpPost]
        public ActionResult Create(ClientsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                   var client = Mapper.Map<ClientsViewModel, Clients>(model);

                    _repo.Create(client);
                    _unitOfWork.Commit();
                    return RedirectToAction("Details/" + client.ClientsID, "Clients");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException) 
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View();
        }

        /*    protected override void Dispose(bool disposing)
            {
                _unitOfWork.Dispose();
                base.Dispose(disposing);
            }*/








    }
}
