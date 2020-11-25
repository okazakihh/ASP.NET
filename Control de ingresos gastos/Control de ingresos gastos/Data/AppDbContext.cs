using Control_de_ingresos_gastos.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Control_de_ingresos_gastos.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(): base("DefaultConnection")
        {

        }
        public DbSet<IngresoGastos> IngresosGastos { get; set; }
    }
}