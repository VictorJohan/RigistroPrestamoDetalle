using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroPrestamoDetalle.Entidades
{
    public class MorasDetalle//ESTA CLASE NO DEBE SER INCLUIDA EN EL CONTEXTO
    {
        [Key]
        public int MoraId { get; set; }
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public double Valor { get; set; }

        //A DIFERENCIA DE LA CLASE Moras ESTA LLEVA DOS CONTRUCTORES
        //La tabla detalle lleva dos constructores
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
