using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using API_ADO_GestionStock.Models;

namespace API_ADO_GestionStock.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        public DataTable Get()
        {
            Usuario oUsuario = new Usuario();
            return oUsuario.ListarTodos();

        }

        // GET: api/Usuario/5
        public Usuario Get(int id)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.ID = id;

            DataTable dt = oUsuario.ListarPorId();

            oUsuario.NombreUsuario = dt.Rows[0][1].ToString();
            oUsuario.Nombre = dt.Rows[0][2].ToString();
            oUsuario.Apellido = dt.Rows[0][3].ToString();
            oUsuario.Email = dt.Rows[0][4].ToString();
            oUsuario.Contrasena = dt.Rows[0][5].ToString();
            oUsuario.FechaCreacion = DateTime.Parse(dt.Rows[0][6].ToString());
            oUsuario.ID_Rol= int.Parse(dt.Rows[0][7].ToString());

            return oUsuario;
        }

        // POST: api/Usuario
        public void Post([FromBody] Usuario value)
        {
            Usuario oUsuario = new Usuario();

            oUsuario.NombreUsuario = value.NombreUsuario;
            oUsuario.Nombre = value.Nombre;
            oUsuario.Apellido = value.Apellido;
            oUsuario.Email = value.Email;
            oUsuario.Contrasena = value.Contrasena;
            oUsuario.FechaCreacion = value.FechaCreacion;
            oUsuario.ID_Rol = value.ID_Rol;



            oUsuario.Guardar();


        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody] Usuario value)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.ID = id;


            oUsuario.NombreUsuario = value.NombreUsuario;
            oUsuario.Nombre = value.Nombre;
            oUsuario.Apellido = value.Apellido;
            oUsuario.Email = value.Email;
            oUsuario.Contrasena = value.Contrasena;
            oUsuario.FechaCreacion = value.FechaCreacion;
            oUsuario.ID_Rol = value.ID_Rol;

            oUsuario.Modificar();


        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.ID = id;

            oUsuario.Eliminar();

        }
    }
}
