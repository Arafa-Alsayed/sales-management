using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace products_management.bl
{
   public class cls_customers
    {
       //methode to add new data to table in database
        public void addcustomer(int id_customer,string firstname,string lastname,string phone,string email,byte[]image,string checkimg)
        {
            dal.dataAccesslayer dall = new dal.dataAccesslayer();
            dall.open();
            SqlParameter[] parms = new SqlParameter[7];
            parms[0] = new SqlParameter("@id_customer", SqlDbType.Int);
            parms[0].Value = id_customer;

            parms[1]=new SqlParameter("@first_name",SqlDbType.NVarChar,30);
            parms[1].Value=firstname;

            parms[2]=new SqlParameter("@last_name",SqlDbType.NVarChar,30);
            parms[2].Value=lastname;

            parms[3] = new SqlParameter("@phone", SqlDbType.NVarChar,11);
            parms[3].Value=phone;


            parms[4] = new SqlParameter("@email", SqlDbType.NVarChar, 30);
            parms[4].Value=email;


            parms[5] = new SqlParameter("@image", SqlDbType.Image);
            parms[5].Value=image;

            parms[6]=new SqlParameter("@checkimg",SqlDbType.NVarChar,30);
            parms[6].Value = checkimg;
            
            dall.excutecommand("sp_addcustomer", parms);
            dall.close();

        }
       //to check that id isnot dublicat
       public DataTable checkrows(int id)
        {
      
            dal.dataAccesslayer co = new dal.dataAccesslayer();
            co.open();
            SqlParameter[] param =new SqlParameter[1];
           param[0]=new SqlParameter("@idcustomer", SqlDbType.Int);
            param[0].Value = id;
            co.close();
         return co.select_data("sp_getcustomer", param);
          
         
        }
       //to get all data customer
       public DataTable allcustomer()
       {
           dal.dataAccesslayer dal = new dal.dataAccesslayer();
           DataTable dt = new DataTable();
           dt = dal.select_data("sp_getallcustomer", null);
           dal.close();
           return dt;

       }
       public void del_customer(int id)
       {
           dal.dataAccesslayer Al = new dal.dataAccesslayer();
           Al.open();
           SqlParameter[] parm =new SqlParameter[1];
           parm[0]=new SqlParameter("@idcustomer",SqlDbType.Int);
           parm[0].Value=id;
           Al.excutecommand("sp_deletecustomer", parm);
           Al.close();
       }

       public void update_customer(int idcust,string fname,string lname,string phone,string email,byte[]img,string checkimg)
       {
           dal.dataAccesslayer Al = new dal.dataAccesslayer();
           Al.open();
           SqlParameter[] param = new SqlParameter[7];
           param[0] = new SqlParameter("@id_customer", SqlDbType.Int);
           param[0].Value = idcust;

           param[1] = new SqlParameter("@first_name ", SqlDbType.NVarChar,30);
           param[1].Value = fname;

            param[2] = new SqlParameter("@last_name ", SqlDbType.NVarChar,30);
           param[2].Value = lname;

            param[3] = new SqlParameter("@telephone ", SqlDbType.NVarChar,11);
           param[3].Value = phone;

            param[4] = new SqlParameter("@email ", SqlDbType.NVarChar,30);
           param[4].Value = email;

            param[5] = new SqlParameter("@image", SqlDbType.Image);
           param[5].Value = img;

           param[6] = new SqlParameter("@checkimg", SqlDbType.NVarChar,30);
           param[6].Value = checkimg;


           Al.excutecommand("sp_updatcustomer", param);
           Al.close();
           

       }
       public DataTable serchcustomer(string search)
       {
           dal.dataAccesslayer AL = new dal.dataAccesslayer();
           DataTable dt = new DataTable();
           AL.open();
           SqlParameter[] parm = new SqlParameter[1];
           parm[0] = new SqlParameter("@search", SqlDbType.NVarChar, 50);
           parm[0].Value = search;
         dt= AL.select_data("sp_searchcustomer", parm);
         AL.close();
         return dt;
       

       }

   







    }
}
