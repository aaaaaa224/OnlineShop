using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Models.DAO
{
   public class DataProvider
    {
       private const string chuoiketnoi = @"Data Source=DESKTOP-N95HQV0\MYSQL;Initial Catalog=Demo;Integrated Security=True";
       public SqlConnection con = new SqlConnection(chuoiketnoi);

        public int open()
        {
           
            try
            {
                con.Open();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (Exception)
            {
                return -1;

            }  
            return 1;
        }
    }
 
}
