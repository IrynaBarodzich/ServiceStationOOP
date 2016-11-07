using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ServiceStation.Models;

namespace ServiceStation.Data
{
    public class ServiceContext: DbContext
    {
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Orders> Orders { get; set; }

    }
}