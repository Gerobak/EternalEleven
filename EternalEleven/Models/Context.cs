using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EternalEleven.Models
{
    public class ActionDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}