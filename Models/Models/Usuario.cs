using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal Cedula { get; set; }
        public string Usuario_Nombre { get; set; }
        public string Contrasena { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Usuario_Transaccion { get; set; }
        public Nullable<DateTime> Fecha_Transaccion { get; set; }
    }
}
