using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;


namespace BahriaCo
{
    class DatabaseHelper
    {
      public SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        EntityClass ec;

        public DatabaseHelper()
        {
            string connectionString = "insert connection string here";
            conn = new SqlConnection(connectionString);
            ec = new EntityClass();
            
        }
        public bool insertUpdateDelete(string query)
        {
            try
            {
                cmd = new SqlCommand(query, conn);
                conn.Open();
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    conn.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            conn.Close();
            return false;

        }


        public void SelectSingleThings(string q, string columnname, ref string returnvalue)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(q, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    returnvalue = dr[columnname].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
                conn.Close();
            }

        }


        public bool insertDataWithImage(EntityClass ec,string v,PictureBox p,string q)
        {
            try
            {
                conn.Open();
                if (v == null)
                {
                    cmd = new SqlCommand(q,conn);
                }
                else
                {
                    byte[] img = null;
                    FileStream fs = new FileStream(v, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);

                    cmd = new SqlCommand(q,conn);
                    cmd.Parameters.Add("@img", img);


                }

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    conn.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");
            }
            conn.Close();
            return false;
        }
        


        public DataTable Search(string q)
        {
            try
            {
                cmd = new SqlCommand(q, conn);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error searching");
               
            }
            return null;
        }

    }
}
