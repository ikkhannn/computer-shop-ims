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
    public partial class paymentCustomer : Form
    {

        EntityClass ec;
        ControlClass cc;
        DataTable dt1;


        public paymentCustomer()
        {
            InitializeComponent();
            ec = new EntityClass();
            cc = new ControlClass();

        }
        
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void paymentCustomer_Load(object sender, EventArgs e)
        {
            cc.fillComboBox(comboBox1, "Customer_Id", "Customer");
            textBox7.Enabled = false;
            //auto id
            string query = "select isnull(max(cast(OrderPayment_Id as int)),0)+1 from OrderPayment";

            dt1 = new DataTable();
            dt1 = cc.getvalues(query);
            textBox6.Text = dt1.Rows[0][0].ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string v;
            v = comboBox1.SelectedItem.ToString();
            dt1 = new DataTable();
            string q = "select * from Customer where Customer_Id = '" + v + "'";




            dt1 = cc.getvalues(q);

            string w = dt1.Rows[0]["Customer_Id"].ToString();

            string q1 = "select * from Customer where Customer_Id= '" + w + "'";

            dt1 = cc.getvalues(q1);
            
            textBox1.Text = dt1.Rows[0]["Customer_Name"].ToString();
            textBox5.Text = dt1.Rows[0]["Customer_Phone"].ToString();
            textBox4.Text = dt1.Rows[0]["Customer_Address"].ToString();
            textBox2.Text = dt1.Rows[0]["Customer_Balance"].ToString();


            ec.Cus_Id = Convert.ToInt32(comboBox1.SelectedItem);


           

            dataGridView1.Rows.Clear();
            string q2 = "select * from TakeOrder where Customer_Id='"+ec.Cus_Id+"'";
            cc.PaymentOrderFillGridView(dataGridView1, q2);
            


            
            string q3 = "select * from OrderLineItem where Customer_Id='"+ec.Cus_Id+"'";
            cc.OrderLineItemFillGridView(dataGridView2, q3);


            double totalamount = 0;


            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {

                totalamount += Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);

            }

            textBox2.Text = totalamount.ToString();
            ec.Cus_Bal = Convert.ToDouble(textBox2.Text);


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Double a=Convert.ToDouble(textBox2.Text);
            Double b = Convert.ToDouble(textBox3.Text);
            Double c = a - b;
            textBox8.Text = Convert.ToString(c);
            ec.Cus_Bal = c;
            string q = "Update Customer set Customer_Balance='" + ec.Cus_Bal + "' where Customer_Id='" + ec.Cus_Id + "'";
            cc.insertDataWithoutImage(q);
            ec.Order_status="Fulfilled";
            string q1 = "Update TakeOrder set Order_Status='"+ec.Order_status+"' where Customer_Id='"+ec.Cus_Id+"'";
            cc.insertDataWithoutImage(q1);

            ec.OrderPayment_Balance = c;
            
            ec.OrderPayment_Date = dateTimePicker1.Value;
            ec.OrderPayment_Recieved= Convert.ToDouble(textBox3.Text);
            if (c==0) {
                ec.OrderPayment_Status = "Fulfilled";
            }else
            {
                ec.OrderPayment_Status = "Pending";
            }
                string q2 = "insert into OrderPayment (OrderPayment_Date,OrderPayment_Bal,OrderPayment_Recieved,OrderPayment_Status,Customer_Id) values ('"+ec.OrderPayment_Date+"','"+ec.OrderPayment_Balance+"','"+ec.OrderPayment_Recieved+"','"+ec.OrderPayment_Status+"','"+ec.Cus_Id+"')";
            bool t=cc.insertDataWithoutImage(q2);

            if (t)
            {
                MessageBox.Show("payment done");
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dealer d = new BahriaCo.Dealer();
            d.Show();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
