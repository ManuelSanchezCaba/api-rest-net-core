using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table("Role")]
    public class Role
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Usuario_Transaccion { get; set; }
        public Nullable<DateTime> Fecha_Transaccion { get; set; }
    }
}
