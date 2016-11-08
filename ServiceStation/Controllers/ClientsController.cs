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


    //    IRepository<Clients, int> _repo;


       public ClientsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
      //      _repo = repo;
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
    Mapper.Map<IEnumerable<Clients>, List<ClientsViewModel>>(_unitOfWork.RepositoryFor<Clients,int>().GetList()
    .Where(c => c.FirstName == firstName)
    .Where(c => c.LastName == lastName));
            return View(clients);
        }



        public ViewResult Details(int id)
        {
            var model = Mapper.Map<Clients, ClientsViewModel>(_unitOfWork.RepositoryFor<Clients, int>().Get(id));
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

          //  Clients client = _repo.Get(id);
            var model = Mapper.Map<Clients, ClientsViewModel>(_unitOfWork.RepositoryFor<Clients, int>().Get(id));
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
            var client = _unitOfWork.RepositoryFor<Clients, int>().Get(model.ClientsID);
            Mapper.Map(model, client);
            if (TryUpdateModel(client))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                      /*  int newId = model.ClientsID;
                        IEnumerable<Cars> cars = _unitOfWork.RepositoryFor<Cars, int>().GetList().Where(c => c.ClientsID == newId);
                        foreach (var car in cars)
                        {
                            db.Entry(car).State = EntityState.Modified;
                        }*/

                        _unitOfWork.RepositoryFor<Clients, int>().Update(client);

                        _unitOfWork.Commit();
                        return RedirectToAction("Details/" + model.ClientsID);
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
        public ActionResult Create(ClientsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                   var client = Mapper.Map<ClientsViewModel, Clients>(model);

                   _unitOfWork.RepositoryFor<Clients, int>().Create(client);
                    _unitOfWork.Commit();
                    return RedirectToAction("Details/" + client.ClientsID, "Clients");
                }
            }
            catch (DataException)
            {
                throw;
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
