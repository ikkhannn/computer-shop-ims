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
    public partial class paymentVender : Form
    {

        EntityClass ec;
        ControlClass cc;
        DataTable dt1;
        public paymentVender()
        {
            InitializeComponent();
            ec = new EntityClass();
            cc = new ControlClass();




        }

        private void paymentVender_Load(object sender, EventArgs e)
        {
            cc.fillComboBox(comboBox1, "Vendor_Id", "Vendor");
            textBox7.Enabled = false;
            //auto id
            string query = "select isnull(max(cast(VOrderPayment_Id as int)),0)+1 from VOrderPayment";

            dt1 = new DataTable();
            dt1 = cc.getvalues(query);
            textBox6.Text = dt1.Rows[0][0].ToString();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dealer d = new BahriaCo.Dealer();
            d.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string v;
            v = comboBox1.SelectedItem.ToString();
            dt1 = new DataTable();
            string q = "select * from Vendor where Vendor_Id = '" + v + "'";




            dt1 = cc.getvalues(q);

            string w = dt1.Rows[0]["Vendor_Id"].ToString();

            string q1 = "select * from Vendor where Vendor_Id= '" + w + "'";

            dt1 = cc.getvalues(q1);

            textBox9.Text = dt1.Rows[0]["Vendor_Name"].ToString();
            textBox5.Text = dt1.Rows[0]["Vendor_Phone"].ToString();
            textBox4.Text = dt1.Rows[0]["Vendor_Address"].ToString();
            textBox2.Text = dt1.Rows[0]["Vendor_Balance"].ToString();


            ec.Vendor_Id = Convert.ToInt32(comboBox1.SelectedItem);


            int dealerid = 1;

            dataGridView1.Rows.Clear();
            string q2 = "select * from OrderToVendor where Dealer_Id='" + dealerid + "'";
            cc.VendorPaymentOrderFillGridView(dataGridView1, q2);




            string q3 = "select * from VOrderLineItem where Dealer_Id='" + dealerid + "'";
            cc.VendorOrderLineItemFillGridView(dataGridView2, q3);


            double totalamount = 0;


            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {

                totalamount += Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);

            }

            textBox2.Text = totalamount.ToString();
            ec.Vendor_Bal = Convert.ToDouble(textBox2.Text);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Double a = Convert.ToDouble(textBox2.Text);
            Double b = Convert.ToDouble(textBox3.Text);
            Double c = a - b;
            textBox1.Text = Convert.ToString(c);
            ec.Vendor_Bal = c;
            string q = "Update Vendor set Vendor_Balance='" + ec.Vendor_Bal + "' where Vendor_Id='" + ec.Vendor_Id + "'";
            cc.insertDataWithoutImage(q);
            ec.VendorOrder_Status = "Fulfilled";
            int dealerid = 1;
            string q1 = "Update OrderToVendor set VOrder_Status='" + ec.VendorOrder_Status + "' where Dealer_Id='" + dealerid + "'";
            cc.insertDataWithoutImage(q1);

            ec.VOrderPayment_Balance = c;

            ec.VOrderPayment_Date = dateTimePicker1.Value;
            ec.VOrderPayment_Paid = Convert.ToDouble(textBox3.Text);
            if (c == 0)
            {
                ec.VOrderPayment_Status = "Fulfilled";
            }
            else
            {
                ec.VOrderPayment_Status = "Pending";
            }
            string q2 = "insert into VOrderPayment (VOrderPayment_Date,VOrderPayment_Bal,VOrderPayment_Paid,VOrderPayment_Status,Vendor_Id) values ('" + ec.VOrderPayment_Date + "','" + ec.VOrderPayment_Balance + "','" + ec.VOrderPayment_Paid + "','" + ec.VOrderPayment_Status + "','" + ec.Vendor_Id + "')";
            cc.insertDataWithoutImage(q2);
            
            string q3 = "update Vendor set Vendor_Balance+='"+c+"' where Vendor_Id='"+ec.Vendor_Id+"'";
        }

        private void labelControl12_Click(object sender, EventArgs e)
        {

        }
    }
}
