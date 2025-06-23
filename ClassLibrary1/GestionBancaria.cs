using System;
using System.Transactions;
using CapaDatos;
using Entidades;
using System.Linq;

namespace CapaNegocios
{
    public class GestionBancaria
    {
        Datos servicio;
        public GestionBancaria()
        {
            servicio = new Datos();
        }

        public string RegistrarPersona(string nombre_completo, string correo_electronico, string carrera, string contrasena, decimal saldo)
        {
            var modelo = new Propietario
            {
                Nombre_completo = nombre_completo,
                Correo_electronico = correo_electronico,
                Carrera = carrera,
                Contrasena = contrasena,
                Saldo = saldo
            };
            if (servicio.Registro(modelo))
                return "Propietario creado correctamente";
            else
                return "No se pudo crear correctamente";
        }

        public string IniciarSesion(string Correo_electronico, string Contrasena)
        {
            if (servicio.Login(Correo_electronico, Contrasena))
            {
                return "Inicio de sesion exitoso";
            }
            else
            {
                return "Error al iniciar sesion. Intentelo nuevamente";
            }
        }

        public float Saldo { get; set; } = 0;

        // Función para retirar saldo
        public string RetirarSaldoEnDB(decimal saldo, string correo)
        {
            using (var context = new BaseDatos())
            {
                var propietario = context.usuarios.SingleOrDefault(p => p.Correo_electronico == correo);
                if (propietario != null)
                {
                    if (propietario.Saldo >= saldo)
                    {
                        propietario.Saldo -= saldo;
                        context.SaveChanges();
                        return "Saldo retirado correctamente.";
                    }
                    else
                    {
                        return "Saldo insuficiente.";
                    }
                }
                else
                {
                    return "Propietario no encontrado.";
                }
            }
        }

        // Función para depositar saldo
        public string DepositarSaldoEnDB(decimal saldo, string correo)
        {
            using (var context = new BaseDatos())
            {
                var propietario = context.usuarios.SingleOrDefault(p => p.Correo_electronico == correo);
                if (propietario != null)
                {
                    propietario.Saldo += saldo;
                    context.SaveChanges();
                    return "Saldo depositado correctamente.";
                }
                else
                {
                    return "Propietario no encontrado.";
                }
            }
        }

        // Función para obtener saldo
        public decimal ObtenerSaldoDesdeDB(string correo)
        {
            using (var context = new BaseDatos())
            {
                var propietario = context.usuarios.SingleOrDefault(p => p.Correo_electronico == correo);
                if (propietario != null)
                {
                    return propietario.Saldo;
                }
                else
                {
                    throw new KeyNotFoundException("Propietario no encontrado.");
                }
            }
        }
    }
}

