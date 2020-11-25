using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using control_de_gastos.Models;

namespace control_de_gastos.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext() : base("DefaultConnection")
        {

        }
        public DbSet<IngresoGastosJF> IngresoGastos { get; set; }
    }
} 