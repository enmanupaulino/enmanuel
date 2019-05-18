using Registro_Usuario.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Usuario.DAL
{
    public class Contexto : DbContext
    {
        internal IEnumerable<Usuarios> usuarios;

        public DbSet<Usuarios> Usuario { get; set; }

        public Contexto() : base("ConStr")
        { }
    
    
    }
}
