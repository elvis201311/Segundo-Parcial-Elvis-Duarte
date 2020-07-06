using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sundo_parcial_aplicada.Entidades
{
    public class Entidades
    {
        [Key]
        public int Proyectoid { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }
    }
}
