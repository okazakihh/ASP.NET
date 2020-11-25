using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Control_de_ingresos_gastos.Models
{
    public class IngresoGastos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Descripcion { get; set; }

        [Required]
        public bool EsIngreso { get; set; }

        [Required]
        public double Valor { get; set; }

     
    }
}