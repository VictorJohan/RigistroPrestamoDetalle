using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroPrestamoDetalle.Entidades
{
    public class MorasDetalle
    {
        [Key]
        public int MoraId { get; set; }
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public double Valor { get; set; }

        public MorasDetalle()
        {
            MoraId = 0;
            Id = 0;
            PrestamoId = 0;
            Valor = 0;
        }

        public MorasDetalle(int id, int prestamoId, double valor)
        {
            MoraId = 0;
            Id = id;
            PrestamoId = prestamoId;
            Valor = valor;
        }
    }
}
