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
    public class ProductoController : ApiController
    {
        // GET: api/Producto
        public DataTable Get()
        {
            Producto oProducto = new Producto();
            return oProducto.ListarTodos();

        }

        // GET: api/Producto/5
        public Producto Get(int id)
        {
            Producto oProducto = new Producto();
            oProducto.ID = id;

            DataTable dt = oProducto.ListarPorId();

            oProducto.Nombre = dt.Rows[0][1].ToString();
            oProducto.Codigo = dt.Rows[0][2].ToString();
            oProducto.Habilitado = bool.Parse(dt.Rows[0][3].ToString());
            oProducto.FechaCreacion = DateTime.Parse(dt.Rows[0][4].ToString());
            

            return oProducto;
        }

        // POST: api/Producto
        public void Post([FromBody] Producto value)
        {
            Producto oProducto = new Producto();

            oProducto.Nombre = value.Nombre;
            oProducto.Codigo = value.Codigo;
            oProducto.Habilitado = value.Habilitado;
            oProducto.FechaCreacion = value.FechaCreacion;
            



            oProducto.Guardar();


        }

        // PUT: api/Producto/5
        public void Put(int id, [FromBody] Producto value)
        {
            Producto oProducto = new Producto();
            oProducto.ID = id;


            oProducto.Nombre = value.Nombre;
            oProducto.Codigo = value.Codigo;
            oProducto.Habilitado = value.Habilitado;
            oProducto.FechaCreacion = value.FechaCreacion;


            oProducto.Modificar();


        }

        // DELETE: api/Producto/5
        public void Delete(int id)
        {
            Producto oProducto = new Producto();
            oProducto.ID = id;

            oProducto.Eliminar();

        }
    }
}
