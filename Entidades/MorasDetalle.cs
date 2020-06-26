using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroPrestamoDetalle.Entidades
{
    public class MorasDetalle//ESTA CLASE NO DEBE SER INCLUIDA EN EL CONTEXTO
    {
        [Key]
        public int Id { get; set; }
        public int MoraId { get; set; }
        public int PrestamoId { get; set; }
        public double Valor { get; set; }

        public MorasDetalle(int id, int moraId, int prestamoId, double valor)
        {
            Id = id;
            MoraId = moraId;
            PrestamoId = prestamoId;
            Valor = valor;
        }
    }
}
