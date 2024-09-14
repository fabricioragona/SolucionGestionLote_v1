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
    public class LoteController : ApiController
    {
        // GET: api/Lote
        public DataTable Get()
        {
            Lote oLote = new Lote();
            return oLote.ListarTodos();

        }

        // GET: api/Lote/5
        public Lote Get(int id)
        {
            Lote oLote = new Lote();
            oLote.ID = id;

            DataTable dt = oLote.ListarPorId();

            oLote.Nombre = dt.Rows[0][1].ToString();
            oLote.CantidadInicial = int.Parse(dt.Rows[0][2].ToString()); 
            oLote.CantidadActual = int.Parse(dt.Rows[0][3].ToString()); 
            oLote.FechaCreacion = DateTime.Parse(dt.Rows[0][4].ToString());
            oLote.ID_Producto = int.Parse(dt.Rows[0][5].ToString());
            oLote.ID_Usuario = int.Parse(dt.Rows[0][6].ToString());

            return oLote;
        }

        // POST: api/Lote
        public void Post([FromBody] Lote value)
        {
            Lote oLote = new Lote();

            oLote.Nombre = value.Nombre;
            oLote.CantidadInicial = value.CantidadInicial;
            oLote.CantidadActual = value.CantidadActual;
            oLote.FechaCreacion = value.FechaCreacion;
            oLote.ID_Producto = value.ID_Producto;
            oLote.ID_Usuario = value.ID_Usuario;


            oLote.Guardar();


        }

        // PUT: api/Lote/5
        public void Put(int id, [FromBody] Lote value)
        {
            Lote oLote = new Lote();
            oLote.ID = id;


            oLote.Nombre = value.Nombre;
            oLote.CantidadInicial = value.CantidadInicial;
            oLote.CantidadActual = value.CantidadActual;
            oLote.FechaCreacion = value.FechaCreacion;
            oLote.ID_Producto = value.ID_Producto;
            oLote.ID_Usuario = value.ID_Usuario;


            oLote.Modificar();


        }

        // DELETE: api/Lote/5
        public void Delete(int id)
        {
            Lote oLote = new Lote();
            oLote.ID = id;

            oLote.Eliminar();

        }
    }
}
