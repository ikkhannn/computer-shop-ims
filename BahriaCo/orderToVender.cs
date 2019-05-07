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
    public partial class orderToVender : Form
    {
        string Selected;

        EntityClass ec;
        ControlClass cc;
        DataTable dt;
        DatabaseHelper dbh;
        ComboBox com;

        public orderToVender()
        {
            InitializeComponent();

            ec = new EntityClass();
            cc = new ControlClass();
            dbh = new DatabaseHelper();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dealer d = new BahriaCo.Dealer();
            d.Show();
        }

        private void orderToVender_Load(object sender, EventArgs e)
        {
            cc.fillComboBox(comboBox2, "Vendor_Id", "Vendor");
            textBox3.Enabled = false;
            
            textBox3.Text = "Pending";
            //items in combobox
            string q = "select * from Products";
            dt = cc.getvalues(q);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Item.Items.Add(dt.Rows[i]["P_Name"]);
            }

            //auto id
            string query = "select isnull(max(cast(VOrder_Id as int)),0)+1 from OrderToVendor";

            dt = new DataTable();
            dt = cc.getvalues(query);
            textBox2.Text = dt.Rows[0][0].ToString();



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string v;
            v = comboBox2.SelectedItem.ToString();
            dt = new DataTable();
            string q = "select * from Vendor where Vendor_Id = '" + v + "'";




            dt = cc.getvalues(q);



            textBox1.Text = dt.Rows[0]["Vendor_Name"].ToString();
            textBox5.Text = dt.Rows[0]["Vendor_Phone"].ToString();
            textBox4.Text = dt.Rows[0]["Vendor_Address"].ToString();
          


            ec.Cus_Id = Convert.ToInt32(comboBox2.SelectedItem);

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                com = e.Control as ComboBox;
                if (com != null)
                {
                    // com.SelectedIndexChanged -= new EventHandler(com_SelectedIndexChanged);
                    com.SelectedIndexChanged += com_SelectedIndexChanged;


                }
            }
            catch (Exception)
            {


            }
        }






        private void com_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // metroGrid1.RowTemplate.Height = 50;
                // dataGridView1.Rows[i].Cells[4].Value = "Cal";
                //   i++;
                int index;
                Selected = (sender as ComboBox).SelectedItem.ToString();
                //  dt2 = new DataTable();




                //Selected = "mouse";
                string q = "select * from Products where P_Name = '" + Selected + "'";


                //  dt2=cc.getvalues(q);




                index = dataGridView1.CurrentCell.RowIndex;


                // MessageBox.Show(Convert.ToString(index));
                // e.Rows.Cells["Quantity"].Value = 1;
                string col = "P_Price";
                string rv = "";
                dbh.SelectSingleThings(q, col, ref rv);


                //   MessageBox.Show(rv);

                dataGridView1.Rows[index].Cells["Price"].Value = rv;



             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double totalamount = 0;


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                totalamount += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);

            }

            textBox7.Text = totalamount.ToString();
            ec.Vendor_Bal = Convert.ToDouble(textBox7.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ec.Vendor_Id = Convert.ToInt32(comboBox2.SelectedItem.ToString());
            string q = "Update Vendor set Vendor_Balance='" + ec.Vendor_Bal + "' where Vendor_Id='" + ec.Vendor_Id + "'";
            cc.insertDataWithoutImage(q);
            ec.VendorOrder_Date = dateTimePicker1.Value;
            ec.VendorOrder_Id = Convert.ToInt32(textBox2.Text);
            ec.VendorOrder_Status = textBox3.Text;
            int aa = 1;
            string q1 = "insert into OrderToVendor (VOrder_Date,VOrder_Status,Dealer_Id) values ('"+ec.VendorOrder_Date+ "','" + ec.VendorOrder_Status + "','" +aa+ "')";
            cc.insertDataWithoutImage(q1);


            int Count = dataGridView1.Rows.Count;
            int c = Count - 1;

            for (int i = 0; i < c; i++)
            {
                ec.VendorOrderLineItemMoney = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString());

                string productName = dataGridView1.Rows[i].Cells["Item"].Value.ToString();





                int qty = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());
                ec.VendorOrderLineItemSingleMoney = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value.ToString());
                int orderid = Convert.ToInt32(textBox2.Text);
                int dealerid = 1;
                

                //string q2 = "insert into VOrderLineItem(P_Name) values  ('" + productName + "','" + dealerid + "','" + productName + "')";
                string q2 =   "Insert into VOrderLineItem(P_Name,VOrderLine_Qnty,VOrderLine_TotalPrice,VOrderLine_Price,VendorOrder_Id,Dealer_Id) values  ('" + productName + "','" + qty + "' , '" + ec.VendorOrderLineItemMoney + "','" + ec.VendorOrderLineItemSingleMoney + "','" + orderid + "','" + dealerid + "')";
                cc.insertDataWithoutImage(q2);

                string updatequantity = "Update Products set P_Qnty+='" + qty + "' where P_Name='" + productName + "'";

                cc.insertDataWithoutImage(updatequantity);

            }

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[4].Index && e.RowIndex >= 0)
            {


                double amount;

                double a = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                double b = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());


                //  int b = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value.);
                amount = a * b;
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = amount;


                //   MessageBox.Show("Quantity Column");
            }
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[1].Value = 1;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
