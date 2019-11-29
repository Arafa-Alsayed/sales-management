using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace products_management.dal
{
    class dataAccesslayer
    {
        SqlConnection sqlconnection;
        public dataAccesslayer()
            {       //use @ if use charcter / \  and server=. to run app on any computer and use it as server
                   //and we secuirity true if you dont computer password but you do password it is false andthen write username,,password
            sqlconnection = new SqlConnection(@"Data Source=.;Initial Catalog=product_db;Integrated Security=True");
            }

                //method to open connection
        public void open()
        {
            if (sqlconnection.State != ConnectionState.Open)
                sqlconnection.Open();
        }

                      //method to close connection
        public void close()
        {
            if (sqlconnection.State == ConnectionState.Open)
                sqlconnection.Close();
        }

                    //method to read data from database
        public DataTable select_data(string stored_procedure,SqlParameter[]param)
          {
             SqlCommand sqlcmd = new SqlCommand();
             sqlcmd.CommandType = CommandType.StoredProcedure;
             sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;
                           
           if (param!=null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
               
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

                 }
        //methode do insert ,delete,update in database
        public void excutecommand(string stored_procedure,SqlParameter[]param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;
            if(param!=null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();             //it run without return thing

        }




    }
}
