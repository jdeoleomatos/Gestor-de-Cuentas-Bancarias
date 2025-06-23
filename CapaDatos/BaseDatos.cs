using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace CapaDatos
{
    public class BaseDatos : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer("server= JOB; initial catalog = Poo1; integrated security = true; TrustServerCertificate= true;");
        }

           public DbSet<Propietario> usuarios { get; set; }



        
    }
}
