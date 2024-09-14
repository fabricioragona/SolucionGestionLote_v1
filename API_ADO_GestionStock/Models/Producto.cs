using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace API_ADO_GestionStock.Models
{
    public class Producto
    {
        #region Atributo 

        string conectionString = @"Data Source=COR0566; Initial Catalog=GestionStock_v1; Integrated Security= True ";

        #endregion

        #region Propiedades 


        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public bool Habilitado { get; set; }
      

        public DateTime FechaCreacion { get; set; }
        #endregion


        #region Metodos

        public DataTable ListarTodos()
        {
            string sqlsentencia = "select * from Producto";

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
            string sqlsentencia = "select * from Producto where ID=" + ID;

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
            string sqlsentencia = "insert into Producto values ('" + Nombre + "','" + Codigo + "','" + Habilitado + "','" + FechaCreacion + "')";

            SqlConnection sqlCnn = new SqlConnection();
            sqlCnn.ConnectionString = conectionString;

            SqlCommand sqlCom = new SqlCommand(sqlsentencia, sqlCnn);


            sqlCnn.Open();

            sqlCom.ExecuteNonQuery();

            sqlCnn.Close();

        }


        public void Modificar()
        {
            string sqlsentencia = "update Producto set Nombre='" + Nombre + "', Codigo = '" + Codigo + "', Habilitado ='" + Habilitado + "', FechaCreacion ='" + FechaCreacion + "' where ID = " + ID;


            SqlConnection sqlCnn = new SqlConnection();
            sqlCnn.ConnectionString = conectionString;

            SqlCommand sqlCom = new SqlCommand(sqlsentencia, sqlCnn);


            sqlCnn.Open();

            sqlCom.ExecuteNonQuery();

            sqlCnn.Close();


        }



        public void Eliminar()
        {
            string sqlsentencia = "delete  from Producto where ID=" + ID;

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
