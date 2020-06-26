using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroPrestamoDetalle.BLL;
using RegistroPrestamoDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPrestamoDetalle.BLL.Tests
{
    [TestClass()]
    public class MorasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Moras Mora = new Moras();
            Mora.MoraId = 1;
            Mora.Fecha = DateTime.Now;
            Mora.Total = 1234;

            var detalle = new MorasDetalle(1, 2, 3, 4);

            Mora.MorasDetalle.Add(detalle);

            Assert.IsTrue(MorasBLL.Guardar(Mora));
        }

        [TestMethod()]
        public void ExisteTest()
        {
            Assert.IsTrue(MorasBLL.Existe(1));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Moras encontrado = MorasBLL.Buscar(1);

            Assert.IsTrue(encontrado != null);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.IsTrue(MorasBLL.Eliminar(1));
        }
    }
}