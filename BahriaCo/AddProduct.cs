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


using System.IO;


namespace BahriaCo
{
    public partial class AddProduct : Form
    {
        public String imageloc = null;
        EntityClass ec1;
        ControlClass cc1;
        DataTable dt1;

        public AddProduct()
        {
            InitializeComponent();
            ec1 = new EntityClass();
            cc1 = new ControlClass();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0 || textBox4.TextLength == 0)
            {

                MessageBox.Show("One or more data fields are empty");
            }
            else
            {
                ec1.Product_Name = textBox2.Text;
                ec1.Product_Qty = Convert.ToInt32(textBox3.Text);
                ec1.Product_Price = Convert.ToDouble(textBox4.Text);
                ec1.Product_Brand = textBox1.Text;


                if (imageloc == null)


                {


                    string q1 = "insert into Products (P_Name,P_Qnty,P_Price,P_Brand) values ('" + ec1.Product_Name + "','" + ec1.Product_Qty + "','" + ec1.Product_Price + "','" + ec1.Product_Brand + "')";
                    if (cc1.insertDataWithoutImage(q1))
                    {
                        MessageBox.Show("Product entered Successfully");

                    }
                    else
                    {
                        MessageBox.Show("Product registeration failed");
                    }

                }
                else
                {
                    string q2 = "insert into Products (P_Name,P_Qnty,P_Price,P_Brand,P_Photo) values ('" + ec1.Product_Name + "','" + ec1.Product_Qty + "','" + ec1.Product_Price + "','" + ec1.Product_Brand + "',@img)";

                    //string q2 = "insert into Customer (Customer_Id,Customer_Name,Customer_Address,Customer_Phone,Customer_Balance,Customer_Photo) values ('" + ec.Cus_Id + "','" + ec.Cus_Name + "','" + ec.Cus_Address + "','" + ec.Cus_Phone + "','" + ec.Cus_Bal + "',@img)";
                    if (cc1.insertDataWithImage(ec1, imageloc, pictureBox1, q2))
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image files | *.jpg; *.jpeg; *.png; *.gif; *.icon";
            DialogResult dr = openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            imageloc = openFileDialog1.FileName.ToString();


        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string q = "select * from Products";
            cc1.ProductFillGridView(dataGridView1, q);
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            //auto id
            string query = "select isnull(max(cast(P_Id as int)),0)+1 from Products";

            dt1= new DataTable();
            dt1 = cc1.getvalues(query);
            textBox5.Text = dt1.Rows[0][0].ToString();

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dealer d = new BahriaCo.Dealer();
            d.Show();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteProduct dp = new DeleteProduct();
            dp.ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
