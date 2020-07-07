using Sundo_parcial_aplicada.DAL;
using Sundo_parcial_aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sundo_parcial_aplicada.BLL
{
    public class TareasBLL
    {
        public static List<Tareas> GetList()
        {
            List<Tareas> tareas = new List<Tareas>();
            Contexto contexto = new Contexto();

            try
            {
                tareas = contexto.Tareas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return tareas;
        }
    }
}