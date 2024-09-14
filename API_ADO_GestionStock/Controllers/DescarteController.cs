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
    public class DescarteController : ApiController
    {
        // GET: api/Descarte
        public DataTable Get()
        {
            Descarte oDescarte = new Descarte();
            return oDescarte.ListarTodos();

        }

        // GET: api/Descarte/5
        public Descarte Get(int id)
        {
            Descarte oDescarte = new Descarte();
            oDescarte.ID = id;

            DataTable dt = oDescarte.ListarPorId();

            oDescarte.Cantidad = int.Parse(dt.Rows[0][1].ToString());
            oDescarte.FechaCreacion = DateTime.Parse(dt.Rows[0][2].ToString());
            oDescarte.ID_Lote = int.Parse(dt.Rows[0][3].ToString());
            oDescarte.ID_Usuario = int.Parse(dt.Rows[0][4].ToString());

            return oDescarte;
        }

        // POST: api/Descarte
        public void Post([FromBody] Descarte value)
        {
            Descarte oDescarte = new Descarte();

            oDescarte.Cantidad =  value.Cantidad;
            oDescarte.FechaCreacion = value.FechaCreacion;
            oDescarte.ID_Lote = value.ID_Lote;
            oDescarte.ID_Usuario = value.ID_Usuario;

            oDescarte.Guardar();



        }

        // PUT: api/Descarte/5
        public void Put(int id, [FromBody] Descarte value)
        {
            Descarte oDescarte = new Descarte();
            oDescarte.ID = id;


            oDescarte.Cantidad = value.Cantidad;
            oDescarte.FechaCreacion = value.FechaCreacion;
            oDescarte.ID_Lote = value.ID_Lote;
            oDescarte.ID_Usuario = value.ID_Usuario;

            oDescarte.Modificar();


        }

        // DELETE: api/Descarte/5
        public void Delete(int id)
        {
            Descarte oDescarte = new Descarte();
            oDescarte.ID = id;

            oDescarte.Eliminar();

        }
    }
}
