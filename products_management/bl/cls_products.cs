using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace products_management.bl
{
    class cls_products
    {
        public DataTable get_all_category()
        {
            dal.dataAccesslayer op = new products_management.dal.dataAccesslayer();
            DataTable dt = new DataTable();
            dt = op.select_data("sp_get_all_category", null);
            op.close();
            return dt;
            

        }
        public void add_product(int id_cat,string id_product ,string labelpd, int qtstock,string  price, byte[] image_product)
        {
            dal.dataAccesslayer op1 = new dal.dataAccesslayer();
            op1.open();
            SqlParameter[] param = new SqlParameter[6];
           

            param[0] = new SqlParameter("@id_product", SqlDbType.VarChar, 20);
            param[0].Value = id_product;


            param[1] = new SqlParameter("@label_product", SqlDbType.NVarChar, 50);
            param[1].Value = labelpd;


            param[2] = new SqlParameter("@qte_in_stock", SqlDbType.Int);
            param[2].Value = qtstock;


            param[3] = new SqlParameter("@price", SqlDbType.VarChar, 30);
            param[3].Value = price;


            param[4] = new SqlParameter("@image", SqlDbType.Image);
            param[4].Value = image_product;

            param[5] = new SqlParameter("@id_cat", SqlDbType.Int);
            param[5].Value = id_cat;

            op1.excutecommand("sp_addproduct", param);
            op1.close();
            

        }
        public DataTable distinctid(string id)
        {
            dal.dataAccesslayer opp2 = new dal.dataAccesslayer();
            opp2.open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
             param[0] = new SqlParameter("@id",SqlDbType.VarChar,20);
            param[0].Value = id;
            dt = opp2.select_data("sp_distinct_id", param);
            opp2.close();
                return dt;

        }
        // methode bring all data for datagridview
        public DataTable get_all_products()
        {
            dal.dataAccesslayer op = new products_management.dal.dataAccesslayer();
            DataTable dt = new DataTable();
            dt = op.select_data("sp_get_all_products", null);
            op.close();
            return dt;
        }

        public DataTable alldata_searching(string textsearch)
        {
            dal.dataAccesslayer op = new products_management.dal.dataAccesslayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            param[0].Value = textsearch;
            

            dt = op.select_data("sp_alldata_searching", param);
            op.close();
            return dt;
        }


        public void delete_data(string id)
        {
            dal.dataAccesslayer dal = new products_management.dal.dataAccesslayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            param[0].Value = id;

            dal.excutecommand("sp_delete_data", param);
            dal.close();

        }

        //methode bring product image for viewing
        public DataTable getimage(string id)
        {
            dal.dataAccesslayer dal = new products_management.dal.dataAccesslayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            param[0].Value = id;
            DataTable dt = new DataTable();
            dt = dal.select_data("sp_getimage_product", param);
            return dt;
        }

        //do methode update table product
        
        /// </summary>
        /// <param name="id_product"></param>
        /// <param name="label_product"></param>
        /// <param name="qte_instock"></param>
        /// <param name="price"></param>
        /// <param name="image"></param>
        /// <param name="id_cat"></param>
        public void update_products(string id_product,string label_product,int qte_instock,string price,byte[]image,int id_cat )
        {
            dal.dataAccesslayer dal = new products_management.dal.dataAccesslayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@id_product", SqlDbType.NVarChar, 20);
            param[0].Value = id_product;

            param[1] = new SqlParameter("@label_product", SqlDbType.NVarChar, 50);
            param[1].Value = label_product;

            param[2] = new SqlParameter("@qte_in_stock", SqlDbType.Int);
            param[2].Value = qte_instock;

            param[3] = new SqlParameter("@price", SqlDbType.NVarChar);
            param[3].Value = price;

            param[4] = new SqlParameter("@image", SqlDbType.Image);
            param[4].Value = image;

            param[5] = new SqlParameter("@id_cat", SqlDbType.Int);
            param[5].Value = id_cat;

            dal.excutecommand("sp_updateprocduct", param);
            dal.close();

        }



    }
}
