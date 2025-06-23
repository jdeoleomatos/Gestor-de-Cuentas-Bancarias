
using System.Linq;
using Entidades;

namespace CapaDatos
{
    public class Datos
    {

        public BaseDatos _context;
        public Datos()
        {
            _context = new BaseDatos();
        }

        public bool Registro(Propietario modelo)
        {
            _context.usuarios.Add(modelo);
            return _context.SaveChanges() > 0;
        }

        public bool Login(string correo_electronico, string contrasena)
        {
            return _context.usuarios.Any(p => p.Correo_electronico == correo_electronico && p.Contrasena == contrasena);
        }

        public Propietario ObtenerPropietarioPorCorreo(string correo_electronico)
        {
            return _context.usuarios.FirstOrDefault(p => p.Correo_electronico == correo_electronico);
        }

        public bool ActualizarSaldo(string correo_electronico, decimal nuevoSaldo)
        {
            var propietarioExistente = _context.usuarios.SingleOrDefault(u => u.Correo_electronico == correo_electronico);
            if (propietarioExistente != null)
            {
                propietarioExistente.Saldo = nuevoSaldo;
                return _context.SaveChanges() > 0;
            }
            return false;
        }
        public void RetirarSaldoEnDB(decimal saldo, string correo)
        {
            var propietario = _context.usuarios.SingleOrDefault(p => p.Correo_electronico == correo);
            if (propietario != null)
            {
                if (propietario.Saldo >= saldo)
                {
                    propietario.Saldo -= saldo;
                    _context.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("Saldo insuficiente.");
                }
            }
            else
            {
                throw new KeyNotFoundException("Propietario no encontrado.");
            }
        }

      

       
    }
}