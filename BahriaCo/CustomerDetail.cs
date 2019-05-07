using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using System.Data.SqlClient;


namespace BahriaCo
{
    public partial class CustomerDetail : Form
    {
        public String imageloc = null;
        EntityClass ec;
        ControlClass cc;
        DataTable dt1;
        DatabaseHelper dbh;

        public CustomerDetail()
        {
            InitializeComponent();
            ec = new EntityClass();
            cc = new ControlClass();
            dbh = new DatabaseHelper();
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void CustomerDetail_Load(object sender, EventArgs e)
        {
            string query = "select isnull(max(cast(Customer_Id as int)),0)+1 from Customer";

            dt1 = new DataTable();
            dt1 = cc.getvalues(query);
            textBox1.Text = dt1.Rows[0][0].ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image files | *.jpg; *.jpeg; *.png; *.gif; *.icon";
            DialogResult dr = openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            imageloc = openFileDialog1.FileName.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            ec.Cus_Id = Convert.ToInt32(textBox1.Text);
            ec.Cus_Name = textBox2.Text;
            ec.Cus_Phone = textBox5.Text;
            ec.Cus_Address = textBox4.Text;
            
            ec.Cus_Time = dateTimePicker1.Value.Date;
            if (imageloc == null)
            {
                string q1 = "insert into Customer (Customer_Name,Customer_Address,Customer_Phone) values ('" + ec.Cus_Name + "','" + ec.Cus_Address + "','" + ec.Cus_Phone + "')";
                if (cc.insertDataWithoutImage(q1))
                {
                    MessageBox.Show("Customer Registered Successfully");

                }
                else
                {
                    MessageBox.Show("Customer registeration failed");
                }

            }
            else
            {
                string q2 = "insert into Customer (Customer_Name,Customer_Address,Customer_Phone,Customer_Photo) values ('" + ec.Cus_Name + "','" + ec.Cus_Address + "','" + ec.Cus_Phone + "',@img)";
                if (cc.insertDataWithImage(ec, imageloc, pictureBox1, q2))
                {
                    MessageBox.Show("Data Saved with image");
                }
                else
                {
                    MessageBox.Show("Data saving failed");
                }
                imageloc = null;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string q = "select * from Customer";
            cc.CustomerFillGridView(dataGridView1,q);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dealer d = new BahriaCo.Dealer();
            d.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
               
               
         /*   SqlDataAdapter sda = new SqlDataAdapter("Select isnull(max(cast(Customer_id as int)),0)+1 from Customer", dbh.conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            textBox1.Text = dt.Rows[0][0].ToString();
            */
        }
    }
}