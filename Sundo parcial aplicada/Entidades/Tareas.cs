using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sundo_parcial_aplicada.Entidades
{
  public class Tareas
   
    {
        [Key]
        public int TareaId { get; set; }
        public string TipoTarea { get; set; }
        public string Requerimiento { get; set; }
        public double Tiempo { get; set; }
    }
}