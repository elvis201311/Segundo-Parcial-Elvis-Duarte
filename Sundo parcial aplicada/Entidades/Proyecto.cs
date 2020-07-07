using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sundo_parcial_aplicada.Entidades
{
    public class Proyecto
    {
        [Key]
        public int ProyectoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }

        [ForeignKey("ProyectoId")]
        public virtual List<ProyectoDetalle> Detalles { get; set; } = new List<ProyectoDetalle>();
    }
}