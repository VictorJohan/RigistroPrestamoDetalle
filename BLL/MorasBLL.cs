using Microsoft.EntityFrameworkCore;
using RegistroPrestamoDetalle.DAL;
using RegistroPrestamoDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace RegistroPrestamoDetalle.BLL
{
    public class MorasBLL
    {
        public static bool Guardar(Moras moras)
        {
            if (!Existe(moras.MoraId))
            {
                return Insertar(moras);
            }
            else
            {
                return Modificar(moras);
            }
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Moras.Any(e => e.MoraId == id);
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

        private static bool Insertar(Moras moras)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                if(contexto.Moras.Add(moras) != null)
                {
                    ok = contexto.SaveChanges() > 0;
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

            return ok;
        }

        private static bool Modificar(Moras moras)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM MorasDetalle Where MoraId={moras.MoraId}");
                foreach(var anterior in moras.MorasDetalles)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }
                contexto.Entry(moras).State = EntityState.Modified;
                ok = (contexto.SaveChanges() > 0);
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

        public static Moras Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Moras moras = new Moras();

            try
            {
                moras = contexto.Moras.Include(x => x.MorasDetalles).Where(p => p.MoraId == id).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return moras;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var eliminar = contexto.Moras.Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;
               ok = (contexto.SaveChanges() > 0);
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
    }
}
