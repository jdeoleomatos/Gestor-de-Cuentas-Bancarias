using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Propietario
    {

        [Key] public int id { get; set; }
        public string Nombre_completo { get; set; }
        public string Carrera { get; set; }
        public string Correo_electronico { get; set; }
        public string Contrasena { get; set; }
        public decimal Saldo { get; set; } = 0;
    }
}
