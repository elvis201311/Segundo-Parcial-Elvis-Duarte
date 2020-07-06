using Microsoft.EntityFrameworkCore;
using Sundo_parcial_aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sundo_parcial_aplicada.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Proyecto> Jugadores { get; set; }
        public DbSet<Tareas> Partidas { get; set; }
        public object Proyecto { get; internal set; }

        //——————————————————————————————————————————————————————————————————————————————————————
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\TeacherControl.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 1, TipoTarea = "Analisis", Requerimiento = "Analizar la opción de clientes", Tiempo = 120 });
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 2, TipoTarea = "Diseño", Requerimiento = "Hacer un diseño excelente", Tiempo = 60 });
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 3, TipoTarea = "Programación", Requerimiento = "Programar todo el registro", Tiempo = 240 });
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 4, TipoTarea = "Prueba", Requerimiento = "Probar con mucho cuidado", Tiempo = 30 });
        }
    }
}