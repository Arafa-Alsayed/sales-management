using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace products_management.bl
{
    class cls_orders
    {

        public DataTable getlast_orderid()
        {
            dal.dataAccesslayer dal = new dal.dataAccesslayer();
            DataTable dt = new DataTable();
            dt = dal.select_data("sp_ident_orderid", null);
            dal.close();
            return dt;

        }
        public void add_order(int id_order, string description_order, DateTime date_sell, string salesname, int customer_id)
        {
            dal.dataAccesslayer op1 = new dal.dataAccesslayer();
            op1.open();
            SqlParameter[] param = new SqlParameter[5];
           

            param[0] = new SqlParameter("@id_order", SqlDbType.Int);
            param[0].Value = id_order;


            param[1] = new SqlParameter("@description_order", SqlDbType.NVarChar, 50);
            param[1].Value = description_order;


            param[2] = new SqlParameter("@date_order", SqlDbType.DateTime);
            param[2].Value = date_sell;


            param[3] = new SqlParameter("@salesman", SqlDbType.VarChar, 50);
            param[3].Value = salesname;


            param[4] = new SqlParameter("@customer_id", SqlDbType.Int);
            param[4].Value = customer_id;



            op1.excutecommand("sp_addorder", param);
            op1.close();
            
        }
        public void add_detailsorder(string id_product, int order_id, int qte, string price, float discount, string price_total, string priceafter_discount)
        {
            dal.dataAccesslayer op1 = new dal.dataAccesslayer();
            op1.open();
            SqlParameter[] param = new SqlParameter[7];


            param[0] = new SqlParameter("@id_product", SqlDbType.VarChar, 20);
            param[0].Value = id_product;



            param[1] = new SqlParameter("@order_id", SqlDbType.Int);
            param[1].Value = order_id;


            param[2] = new SqlParameter("@qte", SqlDbType.Int);
            param[2].Value = qte;


            param[3] = new SqlParameter("@price", SqlDbType.NVarChar, 50);
            param[3].Value = price;


            param[4] = new SqlParameter("@discount", SqlDbType.Float);
            param[4].Value = discount;


            param[5] = new SqlParameter("@pricetotal", SqlDbType.NVarChar,50);
            param[5].Value = price_total;


            param[6] = new SqlParameter("@pric_afterdiscount", SqlDbType.NVarChar, 50);
            param[6].Value = priceafter_discount;


            op1.excutecommand("sp_adddetails_order", param);
            op1.close();


        }

        public DataTable checkquantity(string productid,int qte)
        {
            dal.dataAccesslayer acess = new dal.dataAccesslayer();
            DataTable dt = new DataTable();
            acess.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@idproduct", SqlDbType.VarChar, 20);
            param[0].Value = productid;

            param[1] = new SqlParameter("@quantity", SqlDbType.Int);
            param[1].Value = qte;
            dt=acess.select_data("sp_checkamount", param);
            acess.close();
            return dt;

        }











      
    }
}
