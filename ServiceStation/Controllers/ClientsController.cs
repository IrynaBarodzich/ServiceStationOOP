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



namespace ServiceStation.Controllers
{
    public class ClientsController : Controller
    {



       /*      public ClientsController()
             {

             }*/

        ServiceContext db = new ServiceContext();

        IUnitOfWork _unitOfWork;

        IRepository<Clients, int> _repo;


       public ClientsController(UnitOfWork unitOfWork, IRepository<Clients, int> repo)
        {
    //        _unitOfWork = unitOfWork;
    //        _repo = repo;
            _unitOfWork = new UnitOfWork(db);
            _repo = new Repository<Clients, int>(db);
        }




        //      private ServiceContext db = new ServiceContext();

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult List(string firstName, string lastName)
        {


            var clients = _repo.GetList()
                 .Where(c => c.FirstName == firstName)
                 .Where(c => c.LastName == lastName);
            return View(clients.ToList());
        }



        public ViewResult Details(int id)
        {
            return View(_repo.Get(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            Clients client = _repo.Get(id);
            TempData["firstName"] = client.FirstName;
            TempData["lastName"] = client.LastName;
            return View(client);
        }

        public ViewResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Edit(Clients client)

        {
            try
            {
                if (ModelState.IsValid)
                {
                        _repo.Update(client);
                         _unitOfWork.Commit();
                         return RedirectToAction("Details/" + client.ClientsID);
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException) 
                throw;
            }      
            return View(client);
        }

     

        [HttpPost]
        public ActionResult Create(Clients client)
        {
            try
            {
                if (ModelState.IsValid)
                {
            //        Mapper.Initialize(cfg => cfg.CreateMap<Clients, CreateClient>());
                    // сопоставление
            //        var clients =
             //           Mapper.Map<IEnumerable<Clients>, List<CreateClient>>(_repo.GetList());
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
            return View(client);
        }

        /*    protected override void Dispose(bool disposing)
            {
                _unitOfWork.Dispose();
                base.Dispose(disposing);
            }*/








    }
}
