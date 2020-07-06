using Microsoft.EntityFrameworkCore;
using Sundo_parcial_aplicada.DAL;
using Sundo_parcial_aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sundo_parcial_aplicada.BLL
{
   public class ProyectoBLL
    { 

        public static bool Guardar(Proyecto proyecto)
    {
        if (!Existe(proyecto.ProyectoId))
            return Insertar(proyecto);
        else
            return Modificar(proyecto);
    }

    public static bool Existe(int id)
    {
        Contexto contexto = new Contexto();
        bool ok = false;

        try
        {
            ok = contexto.Proyecto.Any(p => p.ProyectoId == id);
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            contexto.Dispose();
        }

        return ok;
    }

    private static bool Insertar(Proyecto proyecto)
    {
        Contexto contexto = new Contexto();
        bool ok = false;

        try
        {
            contexto.Proyecto.Add(proyecto);
            ok = contexto.SaveChanges() > 0;
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            contexto.Dispose();
        }
        return ok;
    }

    private static bool Modificar(Proyecto proyecto)
    {
        Contexto contexto = new Contexto();
        bool ok = false;

        try
        {
            contexto.Database.ExecuteSqlRaw($"Delete FROM OrdenesDetalle Where ProyectoId={proyecto.ProyectoId}");
            foreach (var anterior in proyecto.ProyectoDetalles)
            {
                contexto.Entry(anterior).State = EntityState.Added;
            }
            contexto.Entry(proyecto).State = EntityState.Modified;
            ok = contexto.SaveChanges() > 0;
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            contexto.Dispose();
        }

        return ok;
    }

    public static Proyecto Buscar(int id)
    {
        Contexto contexto = new Contexto();
        Proyecto proyectos;

        try
        {
            proyectos = contexto.Proyecto.Find(id);
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

    public static bool Eliminar(int id)
    {
        Contexto contexto = new Contexto();
        bool ok = false;

        try
        {
            var proyecto = contexto.Proyectos.Find(id);
            contexto.Entry(proyecto).State = EntityState.Deleted;
            ok = contexto.SaveChanges() > 0;
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            contexto.Dispose();
        }

        return ok;
    }

    public static List<Proyectos> GetProyectos(Expression<Func<Proyectos, bool>> criterio)
    {
        List<Proyectos> lista = new List<Proyectos>();
        Contexto contexto = new Contexto();

        try
        {
            lista = contexto.Proyectos.Where(criterio).ToList();
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

}
}
