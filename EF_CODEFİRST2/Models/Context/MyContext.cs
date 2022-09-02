using EF_CODEFİRST2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CODEFİRST2.Models.Context
{
    class MyContext : DbContext
    {
        public MyContext():base("MyConnection")
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
