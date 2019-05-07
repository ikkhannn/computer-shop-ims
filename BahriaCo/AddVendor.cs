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
    public partial class AddVendor : Form
    {

        public String imageloc = null;
        EntityClass ec;
        ControlClass cc;
        DataTable dt;
        public AddVendor()
        {
            InitializeComponent();
            ec = new EntityClass();
            cc = new ControlClass();
        }

        private void AddVendor_Load(object sender, EventArgs e)
        {
            string query = "select isnull(max(cast(Customer_Id as int)),0)+1 from Customer";

            dt = new DataTable();
            dt = cc.getvalues(query);
            textBox1.Text = dt.Rows[0][0].ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image files | *.jpg; *.jpeg; *.png; *.gif; *.icon";
            DialogResult dr = openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            imageloc = openFileDialog1.FileName.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength == 0 || textBox5.TextLength == 0 || textBox4.TextLength == 0) {MessageBox.Show("one or more data fields are empty"); }
            else
            {

                ec.Vendor_Id = Convert.ToInt32(textBox1.Text);
                ec.Vendor_Name = textBox2.Text;
                ec.Vendor_Phone = textBox5.Text;
                ec.Vendor_Address = textBox4.Text;

                if (imageloc == null)
                {
                    string q1 = "insert into Vendor (Vendor_Name,Vendor_Address,Vendor_Phone) values ('" + ec.Vendor_Name + "','" + ec.Vendor_Address + "','" + ec.Vendor_Phone + "')";
                    if (cc.insertDataWithoutImage(q1))
                    {
                        MessageBox.Show("Vendor Registered Successfully");

                    }
                    else
                    {
                        MessageBox.Show("Vendor registeration failed");
                    }

                }
                else
                {
                    string q2 = "insert into Vendor (Vendor_Name,Vendor_Address,Vendor_Phone,Vendor_Photo) values ('" + ec.Vendor_Name + "','" + ec.Vendor_Address + "','" + ec.Vendor_Phone + "',@img)";
                    // string q2 = "insert into Customer (Customer_Id,Customer_Name,Customer_Address,Customer_Phone,Customer_Balance,Customer_Photo) values ('" + ec.Cus_Id + "','" + ec.Cus_Name + "','" + ec.Cus_Address + "','" + ec.Cus_Phone + "','" + ec.Cus_Bal + "',@img)";
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
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string q = "select * from Vendor";
            cc.VendorFillGridView(dataGridView1, q);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dealer mp = new BahriaCo.Dealer();
            mp.ShowDialog();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteVendor dv = new DeleteVendor();
            dv.ShowDialog();
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }
    }
}
