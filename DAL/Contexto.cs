using Microsoft.EntityFrameworkCore;
using RegistroPrestamoDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPrestamoDetalle.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Moras> Moras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\Prestamo.db");
        }
    }
}
