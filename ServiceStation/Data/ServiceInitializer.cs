using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ServiceStation.Models;

namespace ServiceStation.Data
{
    public class ServiceInitializer : DropCreateDatabaseIfModelChanges<ServiceContext>
    {
        protected override void Seed(ServiceContext context)
        {
            var clients = new List<Clients> 
            { 
                new Clients { FirstName = "Anton", LastName = "Romov", BirthDate = DateTime.Parse("2005-09-01"), Address = "Minsk", Phone="+375293452365", Email="romov@mail.ru" }, 
                new Clients { FirstName = "Ivan", LastName = "Orlov",   BirthDate = DateTime.Parse("2002-09-01"), Address = "Pinsk", Phone="+375294562365", Email="orlov@mail.ru"  }, 
                new Clients { FirstName = "Pavel", LastName = "Timov",   BirthDate = DateTime.Parse("2003-09-01"), Address = "Grodno", Phone="+375297317665", Email="timov@mail.ru"}, 
                new Clients { FirstName = "Alex", LastName = "Popov", BirthDate = DateTime.Parse("2002-09-01"), Address = "Minsk", Phone="+375293452365", Email="popov@mail.ru" }, 
                new Clients { FirstName = "Alina", LastName = "Gromova",  BirthDate = DateTime.Parse("2002-09-01"), Address = "Vitebsk", Phone="+375293756532", Email="gromova@mail.ru" }, 
                new Clients { FirstName = "Vadim", LastName = "Ostrov",  BirthDate = DateTime.Parse("2001-09-01"), Address = "Minsk", Phone="+375293456365", Email="ostrov@mail.ru" }, 
                new Clients { FirstName = "Maxim",  LastName = "Homin",       BirthDate = DateTime.Parse("2003-09-01"), Address = "Brest", Phone="+375298652365", Email="homin@mail.ru" }, 
                new Clients { FirstName = "Petr", LastName = "Krasko",       BirthDate = DateTime.Parse("2005-09-01"), Address = "Minsk", Phone="+375297892365", Email="krasko@mail.ru" } 
            };
            clients.ForEach(s => context.Clients.Add(s));
            context.SaveChanges();



            var cars = new List<Cars> 
            { 
                new Cars {Make = "Toyota", Model="Corolla", Year=2005, VIN="43SDFDGFG3535354D", ClientsID = 1 }, 
                new Cars {Make = "Toyota", Model="Yaris", Year=2008, VIN="FG6YH7UJGFDRT4W3D", ClientsID = 1}, 
                new Cars {Make = "Mazda", Model="3", Year=2005, VIN="DF5R3GDRT67YUJHFT", ClientsID = 1}, 
                new Cars {Make = "Toyota", Model="Corolla", Year=2005, VIN="76YHU890KHYIJGFTH", ClientsID = 2}, 
                new Cars {Make = "BMW", Model="X3", Year=2005, VIN="456GFT7YHU94RFDRT", ClientsID = 2}, 
                new Cars {Make = "Toyota", Model="Corolla", Year=2005, VIN="SRTGUI8OJNBDT6YU9", ClientsID = 2}, 
                new Cars {Make = "Mazda", Model="6", Year=2005, VIN="SERFT65GHYU890KJD", ClientsID = 3}, 
                new Cars {Make = "Toyota", Model="RAV4", Year=2005, VIN="SDRFTGYHUI945FGNY", ClientsID = 4}, 
                new Cars {Make = "Toyota", Model="Corolla", Year=2005, VIN="DER54FGT67YHUJ8IK", ClientsID = 4},
                new Cars {Make = "RENAULT", Model="Sandero", Year=2005, VIN="234ERFGHNJKLORTGH", ClientsID = 5}, 
                new Cars {Make = "BMW", Model="X6", Year=2005, VIN="SERTH7U89IJKOLSDR", ClientsID = 6}, 
                new Cars {Make = "RENAULT", Model="Clio", Year=2005, VIN="ASEFRT6YHU8JIKLO9", ClientsID = 7}, 
            };
            cars.ForEach(s => context.Cars.Add(s));
            context.SaveChanges();


            var courses = new List<Orders> 
            { 
                new Orders { Date = DateTime.Parse("12.03.2015"),  Amount = 99, Status="Completed", CarsID = 1}, 
                new Orders { Date = DateTime.Parse("16.07.2015"),  Amount = 100, Status="Completed", CarsID = 2}, 
                new Orders { Date = DateTime.Parse("22.04.2015"),  Amount = 88, Status="Completed", CarsID = 4}, 
                new Orders { Date = DateTime.Parse("12.03.2015"),  Amount = 13, Status="In Progress", CarsID = 3}, 
                new Orders { Date = DateTime.Parse("05.05.2015"),  Amount = 20, Status="Cancelled", CarsID = 1}, 
                new Orders { Date = DateTime.Parse("09.11.2015"),  Amount = 67, Status="In Progress", CarsID = 1}, 
                new Orders { Date = DateTime.Parse("12.12.2015"),  Amount = 34, Status="In Progress", CarsID = 2} 
            };
            courses.ForEach(s => context.Orders.Add(s));
            context.SaveChanges();
        } 
    }
}