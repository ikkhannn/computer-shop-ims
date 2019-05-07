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
    public partial class requestPayment : Form
    {

        ControlClass cc;
        DatabaseHelper dbh;
        EntityClass ec;
        DataTable dt;
        public static double totalamount;
        public requestPayment()
        {
            InitializeComponent();
            cc = new ControlClass();
            dbh = new DatabaseHelper();
            ec = new EntityClass();

        }
        

        private void requestPayment_Load(object sender, EventArgs e)
        {
            cc.fillComboBox(comboBox2, "Customer_Id", "Customer");
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage mp =new MainPage();
            mp.Show();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string v;
            v = comboBox2.SelectedItem.ToString();
            dt = new DataTable();
            string q = "select * from Customer where Customer_Id = '" + v + "'";




            dt = cc.getvalues(q);
            textBox1.Text = dt.Rows[0]["Customer_Name"].ToString();
            textBox5.Text = dt.Rows[0]["Customer_Phone"].ToString();
            textBox4.Text = dt.Rows[0]["Customer_Address"].ToString();





 
            ec.Cus_Id = Convert.ToInt32(comboBox2.SelectedItem);
            string q3 = "select * from RepairDetail where Customer_Id='" + ec.Cus_Id + "'";
            cc.RequestLineItemFillGridView(dataGridView1, q3);





            double totalamount = 0;


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                totalamount += Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);

            }

            textBox9.Text = totalamount.ToString();
            ec.Cus_Bal = Convert.ToDouble(textBox9.Text);



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox9.Text);
            double b = Convert.ToDouble(textBox2.Text);
            double c = a - b;
            textBox6.Text = Convert.ToString(c);
            ec.RepairPayment_Balance = c;
            ec.Cus_Id = Convert.ToInt32(comboBox2.SelectedItem);

            

            ec.RepairPayment_Date = dateTimePicker1.Value;
            ec.RepairPayment_Recieved = Convert.ToDouble(textBox2.Text);
            if (c == 0)
            {
                ec.RepairPayment_Status = "Fulfilled";
            }
            else
            {
                ec.RepairPayment_Status = "Pending";
            }
            string q2 = "insert into RepairPayment(RepairPayment_Date,RepairPayment_Bal,RepairPayment_Status,Customer_Id,RepairPayment_Recieved) values ('"+ec.RepairPayment_Date+"','"+ec.RepairPayment_Balance+"','"+ec.RepairPayment_Status+"','"+ec.Cus_Id+"','"+ec.RepairPayment_Recieved+"')";
            bool t=cc.insertDataWithoutImage(q2);

            if (t)
            {
                MessageBox.Show("Payment done");
            }

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
