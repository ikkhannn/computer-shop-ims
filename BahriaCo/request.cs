using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BahriaCo
{
    public partial class request : Form
    {

        public String imageloc = null;
        EntityClass ec;
        ControlClass cc;
        DataTable dt1;


        public request()
        {
            InitializeComponent();
            
        }

        private void request_Load(object sender, EventArgs e)
        {
            ec = new EntityClass();
            cc = new ControlClass();
            textBox3.Enabled = false;
            textBox3.Text = "Pending";
            cc.fillComboBox(comboBox2, "Customer_Id", "Customer");

            //auto id
            string query = "select isnull(max(cast(Repair_Id as int)),0)+1 from TakeRepair";

            dt1 = new DataTable();
            dt1 = cc.getvalues(query);
            textBox6.Text = dt1.Rows[0][0].ToString();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string v;
            v = comboBox2.SelectedItem.ToString();
            dt1 = new DataTable();
            string q = "select * from Customer where Customer_Id = '" + v + "'";




            dt1 = cc.getvalues(q);
            textBox1.Text = dt1.Rows[0]["Customer_Name"].ToString();
            textBox5.Text = dt1.Rows[0]["Customer_Phone"].ToString();
            textBox4.Text = dt1.Rows[0]["Customer_Address"].ToString();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ec.Cus_Id = Convert.ToInt32(comboBox2.SelectedItem.ToString());
            ec.Repair_date = dateTimePicker1.Value;
           
            ec.Repair_status = textBox3.Text;
            ec.Repair_Fault =textBox2.Text;
            
            string q1 = "insert into TakeRepair (Repair_Status,Repair_Date,Customer_Id,Repair_Fault) values ('" + ec.Repair_status + "','" + ec.Repair_date + "','" + ec.Cus_Id + "','"+ec.Repair_Fault+"')";
            bool t=cc.insertDataWithoutImage(q1);
            if (t)
            {
                MessageBox.Show("data entered successfully");
            }

           

           

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
