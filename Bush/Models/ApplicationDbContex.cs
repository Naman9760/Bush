using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bush.Models
{
    public class ApplicationDbContex : DbContext
    {
        public ApplicationDbContex() : base("Data Source=EYTECLAP5\\MSSQLSERVER2019;" +
            "Initial Catalog=Emp;Integrated Security=True;Pooling=False") { }
        public DbSet<Empolyee> empolyees { get; set; }
       
    }
}