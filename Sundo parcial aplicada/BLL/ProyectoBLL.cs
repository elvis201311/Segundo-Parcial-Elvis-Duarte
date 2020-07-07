using Microsoft.EntityFrameworkCore;
using Sundo_parcial_aplicada.DAL;
using Sundo_parcial_aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sundo_parcial_aplicada.BLL
{

       public class ProyectosBLL
    {
        
        public static bool Guardar(Proyecto proyectos)
        {
            bool paso;

            if (!Existe(proyectos.ProyectoId))
                paso = Insertar(proyectos);
            else
                paso = Modificar(proyectos);

            return paso;
        }
       
        public static bool Insertar(Proyecto proyectos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Proyecto.Add(proyectos);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
       
        public static bool Modificar(Proyecto proyectos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                //Borrar el detalle anterior.
                contexto.Database.ExecuteSqlRaw($"Delete From ProyectosDetalle Where ProyectosId={proyectos.ProyectoId}");

                foreach (var item in proyectos.Detalles)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(proyectos).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
       
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var proyectos = contexto.Proyecto.Find(id);
                if (proyectos != null)
                {
                    contexto.Proyecto.Remove(proyectos);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        
        public static List<Proyecto> GetList(Expression<Func<Proyecto, bool>> criterio)
        {
            List<Proyecto> lista = new List<Proyecto>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Proyecto.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
       
        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Proyecto.Any(p => p.ProyectoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
       
        public static Proyecto Buscar(int id)
        {
            Proyecto proyectos = new Proyecto();
            Contexto contexto = new Contexto();

            try
            {
                proyectos = contexto.Proyecto
                    .Where(p => p.ProyectoId == id)
                    .Include(p => p.Detalle).ThenInclude(t => t.tipo)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return proyectos;
        }
    }
}
