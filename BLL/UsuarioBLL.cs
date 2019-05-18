using Registro_Usuario.DAL;
using Registro_Usuario.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Usuario.BLL
{

    /// <summary>
    /// En esta clase se programan la logica de negocio
    /// </summary>
    public class UsuarioBLL
    {
        public static object Usuarios { get; private set; }

        public static bool Guardar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {     //Usuario es la variable deL Contexto
                if (contexto.Usuario.Add(usuarios) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose(); //cerrando conexion

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }
        // Usuarios es la clase HECHA EN identidad

        public static bool Modificar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {

                contexto.Entry(usuarios).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;

                }
                contexto.Dispose();


            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Usuarios usuarios = contexto.Usuario.Find(Id);
                contexto.Usuario.Remove(usuarios);
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        
       

        public static Usuarios Buscar(int Id)
        {
            Contexto contexto = new Contexto();
            Usuarios usuarios = new Usuarios();
            try
            {
                usuarios = contexto.Usuario.Find(Id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return usuarios;

        }

        public static List<Usuarios> Getlist(Expression<Func<Usuarios, bool>> expression)
        {
            List<Usuarios> Usuario = new List<Usuarios>();
            Contexto contexto = new Contexto();
            try
            {
                Usuarios = contexto.Usuario.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Usuario;
        }

    }
}
 