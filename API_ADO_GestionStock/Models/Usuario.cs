using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace API_ADO_GestionStock.Models
{
    public class Usuario
    {
        #region Atributo 

        string conectionString = @"Data Source=COR0566; Initial Catalog=GestionStock_v1; Integrated Security= True ";

        #endregion

        #region Propiedades 


        public int ID { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int ID_Rol { get; set; }

        #endregion


        #region Metodos

        public DataTable ListarTodos()
        {
            string sqlsentencia = "select * from Usuario";

            SqlConnection sqlCnn = new SqlConnection();
            sqlCnn.ConnectionString = conectionString;


            SqlCommand sqlCom = new SqlCommand(sqlsentencia, sqlCnn);

            sqlCnn.Open();


            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCom;
            da.Fill(ds);


            sqlCnn.Close();



            return ds.Tables[0];

        }


        public DataTable ListarPorId()
        {
            string sqlsentencia = "select * from Usuario where ID=" + ID;

            SqlConnection sqlCnn = new SqlConnection();
            sqlCnn.ConnectionString = conectionString;

            SqlCommand sqlCom = new SqlCommand(sqlsentencia, sqlCnn);


            sqlCnn.Open();


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCom;

            DataSet ds = new DataSet();

            da.Fill(ds);


            sqlCnn.Close();

            return ds.Tables[0];
        }

        public void Guardar()
        {
            string sqlsentencia = "insert into Usuario values('" + NombreUsuario + "','" + Nombre + "','" + Apellido + "','" + Email + "','" + Contrasena + "','" + FechaCreacion + "'," + ID_Rol + ")";

            SqlConnection sqlCnn = new SqlConnection();
            sqlCnn.ConnectionString = conectionString;


            SqlCommand sqlCom = new SqlCommand(sqlsentencia, sqlCnn);


            sqlCnn.Open();

            sqlCom.ExecuteNonQuery();

            sqlCnn.Close();

        }


        public void Modificar()
        {
            string sqlsentencia = "update Usuario set NombreUsuario='" + NombreUsuario + "', Nombre = '" + Nombre  +"', Apellido = '" + Apellido + "', Email = '" + Email + "', Contrasena = '" + Contrasena + "', FechaCreacion = '" + FechaCreacion + "', ID_Rol =" + ID_Rol + " where ID =  " + ID;

            SqlConnection sqlCnn = new SqlConnection();
            sqlCnn.ConnectionString = conectionString;
        

            SqlCommand sqlCom = new SqlCommand(sqlsentencia, sqlCnn);


            sqlCnn.Open();

            sqlCom.ExecuteNonQuery();

            sqlCnn.Close();


        }

        public void Eliminar()
        {
            string sqlsentencia = "delete  from Usuario where ID=" + ID;

            SqlConnection sqlCnn = new SqlConnection();
            sqlCnn.ConnectionString = conectionString;

            SqlCommand sqlCom = new SqlCommand(sqlsentencia, sqlCnn);


            sqlCnn.Open();

            sqlCom.ExecuteNonQuery();

            sqlCnn.Close();


        }

        #endregion


    }
}