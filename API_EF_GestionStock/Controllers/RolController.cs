using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_EF_GestionStock.Controllers
{
    public class RolController : ApiController
    {
        // GET: api/Rol
        public List<Rol> Get()
        {
            List<Rol> oRol = new List<Rol>();

            using (GestionStock_v1Entities db = new GestionStock_v1Entities())
            {
                oRol = db.Rol.ToList();
            }

            return oRol;
        }

        // GET: api/Rol/5
        public Rol Get(int id)
        {
            Rol oRol = new Rol();

            using (GestionStock_v1Entities db = new GestionStock_v1Entities())
            {
                oRol = db.Rol.Find(id);

            }

            return oRol;
        }

        // POST: api/Rol
        public void Post([FromBody] Rol value)
        {
         
            using (GestionStock_v1Entities db = new GestionStock_v1Entities())
            {
                db.Rol.Add(value);
                db.SaveChanges();

            }

        }

        // PUT: api/Rol/5
        public void Put(int id, [FromBody] Rol value)
        {
            using (GestionStock_v1Entities db = new GestionStock_v1Entities())
            {
                var oRol = db.Rol.Find(id);

                oRol.Nombre = value.Nombre;


                db.Entry(oRol).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

        }

        // DELETE: api/Rol/5
        public void Delete(int id)
        {
            using (GestionStock_v1Entities db = new GestionStock_v1Entities())
            {
                var oRol = db.Rol.Find(id);
                db.Rol.Remove(oRol);
                db.SaveChanges();

            }
        }
    }
}
