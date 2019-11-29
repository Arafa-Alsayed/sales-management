using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace products_management.bl
{
    class cls_login
    {
        public DataTable login(string id, string password)
        {
            dal.dataAccesslayer dal = new products_management.dal.dataAccesslayer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            param[0].Value = id;
            param[1] = new SqlParameter("@pass_word", SqlDbType.NVarChar, 50);
            param[1].Value = password;

            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select_data("sp_login", param);
            dal.close();
            return dt;
           
        }
     
        public void add_users(string id,string password,string usertype,string fullname)
        {
            dal.dataAccesslayer dal = new products_management.dal.dataAccesslayer();
            SqlParameter[] param = new SqlParameter[4];
            dal.open();
            param[0]=new SqlParameter("@id",SqlDbType.NVarChar,50);
            param[0].Value=id;

            param[1]=new SqlParameter("@pass_word",SqlDbType.NVarChar,50);
            param[1].Value=password;

            param[2]=new SqlParameter("@user_type",SqlDbType.NVarChar,50);
            param[2].Value=usertype;

            param[3]=new SqlParameter("@salesname",SqlDbType.NVarChar,50);
            param[3].Value=fullname;
            dal.excutecommand("sp_addusers",param);
            dal.close();

        }
        public DataTable serchusers(string search)
        {
            dal.dataAccesslayer AL = new dal.dataAccesslayer();
            DataTable dt = new DataTable();
            AL.open();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@varsearch", SqlDbType.NVarChar, 50);
            parm[0].Value = search;
            dt = AL.select_data("sp_getallusers", parm);
            AL.close();
            return dt;


        }
        public void edit_users(string id, string password, string usertype, string fullname)
        {
            dal.dataAccesslayer dal = new products_management.dal.dataAccesslayer();
            SqlParameter[] param = new SqlParameter[4];
            dal.open();
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@pass_word", SqlDbType.NVarChar, 50);
            param[1].Value = password;

            param[2] = new SqlParameter("@user_type", SqlDbType.NVarChar, 50);
            param[2].Value = usertype;

            param[3] = new SqlParameter("@salesname", SqlDbType.NVarChar, 50);
            param[3].Value = fullname;
            dal.excutecommand("sp_editusers", param);
            dal.close();

        }
        public void delete_users(string id)
        {
            dal.dataAccesslayer dal = new products_management.dal.dataAccesslayer();
            SqlParameter[] param = new SqlParameter[1];
            dal.open();
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            param[0].Value = id;
            dal.excutecommand("sp_deleteusers", param);
            dal.close();

        }

    }
}
