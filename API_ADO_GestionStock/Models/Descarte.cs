using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace API_ADO_GestionStock.Models
{
    public class Descarte
    {
        #region Atributo 

        string conectionString = @"Data Source=COR0566; Initial Catalog=GestionStock_v1; Integrated Security= True ";

        #endregion

        #region Propiedades 


        public int ID { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int ID_Lote { get; set; }
        public int ID_Usuario { get; set; }
        #endregion


        #region Metodos

        public DataTable ListarTodos()
        {
            string sqlsentencia = "select * from Descarte";

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
            string sqlsentencia = "select * from Descarte where ID=" + ID;

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
            string sqlsentencia = "insert into Descarte values(" + Cantidad + ",'" + FechaCreacion + "'," + ID_Lote + "," + ID_Usuario + ")";

            SqlConnection sqlCnn = new SqlConnection();
            sqlCnn.ConnectionString = conectionString;

            SqlCommand sqlCom = new SqlCommand(sqlsentencia, sqlCnn);


            sqlCnn.Open();

            sqlCom.ExecuteNonQuery();

            sqlCnn.Close();

        }


        public void Modificar()
        {
            string sqlsentencia = "update Descarte set Cantidad=" + Cantidad + ", FechaCreacion = '" + FechaCreacion + "', ID_Lote =" + ID_Lote + ", ID_Usuario=" + ID_Usuario + "where ID=" + ID;

            SqlConnection sqlCnn = new SqlConnection();
            sqlCnn.ConnectionString = conectionString;

            SqlCommand sqlCom = new SqlCommand(sqlsentencia, sqlCnn);


            sqlCnn.Open();

            sqlCom.ExecuteNonQuery();

            sqlCnn.Close();


        }

        public void Eliminar()
        {
            string sqlsentencia = "delete  from Descarte where ID=" + ID;

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
