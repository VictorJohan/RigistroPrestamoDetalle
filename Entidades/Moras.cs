using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistroPrestamoDetalle.Entidades
{
    public class Moras
    {
        [Key]
        public int MoraId { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }

        //aqui se le esta pasando una llave foranea a la clase MorasDetalle(Tabla)
        //es la Primary Key de esta misma clase(Tabla)
        [ForeignKey("MoraId")]
        public virtual List<MorasDetalle> MorasDetalles { get; set; }

        public Moras()//en este constructor se deben inicializar las propiedades creadas en esta clase
        {
            MoraId = 0;
            Fecha = DateTime.Now;
            Total = 0;
            MorasDetalles = new List<MorasDetalle>();
        }
        
    }
}
