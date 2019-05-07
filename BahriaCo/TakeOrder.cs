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
    public partial class TakeOrder : Form
    {
        int i = 1;
        string Selected;
        ControlClass cc;
        DatabaseHelper dbh;
        ComboBox com;
        EntityClass ec;
        DataTable dt1;
        DataTable dt2;
        DataTable dt3;
        DataTable dt6;

        public TakeOrder()
        {
            InitializeComponent();
            cc = new ControlClass();
            dbh = new DatabaseHelper();
            ec = new EntityClass();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows[0].Cells[4].Value = "Cal";
            comboBox1.SelectedIndex = 0;
            cc.fillComboBox(comboBox2,"Customer_Id","Customer");

            //auto id
            string query = "select isnull(max(cast(Order_Id as int)),0)+1 from TakeOrder";

            dt1 = new DataTable();
            dt1 = cc.getvalues(query);
            textBox2.Text = dt1.Rows[0][0].ToString();

            //items in combobox
            string q = "select * from Products";
            dt6 = cc.getvalues(q);
            for (int i = 0; i < dt6.Rows.Count; i++)
            {
                Item.Items.Add(dt6.Rows[i]["P_Name"]);
            }



        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridView1.Columns[1].Index && e.RowIndex >=0)
            {
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = 121;
                MessageBox.Show("Quantity Column");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string v;
            v = comboBox2.SelectedItem.ToString();
            dt1 = new DataTable();
            string q="select * from Customer where Customer_Id = '"+v+"'";




            dt1 = cc.getvalues(q);
            textBox1.Text = dt1.Rows[0]["Customer_Name"].ToString();
            textBox5.Text = dt1.Rows[0]["Customer_Phone"].ToString();
            textBox4.Text = dt1.Rows[0]["Customer_Address"].ToString();
            


        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                com = e.Control as ComboBox;
                if(com != null)
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
                string q="select * from Products where P_Name = '"+ Selected +"'";

                
              //  dt2=cc.getvalues(q);
               



               index = dataGridView1.CurrentCell.RowIndex;


                // MessageBox.Show(Convert.ToString(index));
                // e.Rows.Cells["Quantity"].Value = 1;
                string col = "P_Price";
                string  rv = "";
                dbh.SelectSingleThings(q,col, ref rv);


             //   MessageBox.Show(rv);

                dataGridView1.Rows[index].Cells["Price"].Value = rv;
                
                

                /*
               `
                
                string pprice = "";

                string q = "Select * from Product where ProductName = '" + selected + "'";
                string IE = "ProductImage";

                cc.SelectSingleImageGrid(pimage, q, IE);
                cc.SelectSingleImage(pictureBox1, q, IE);
                dbh.SelectSingleThings(q, "ProductPrice", ref pprice);




                metroGrid1.Rows[index].Cells["price"].Value = pprice;
                metroGrid1.Rows[index].Cells["pimage"].Value = pictureBox1.Image;



                price1 = Convert.ToDouble(metroGrid1.Rows[index].Cells["price"].Value.ToString());

                */

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
           // MessageBox.Show(e.RowIndex.ToString());
        }

        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double totalamount=0;
            
          
            for(int i = 0;i< dataGridView1.Rows.Count; i++)
            {
                
               totalamount += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);

            }

            textBox7.Text = totalamount.ToString();
            ec.Cus_Bal = Convert.ToDouble(textBox7.Text);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           ec.Cus_Id=Convert.ToInt32(comboBox2.SelectedItem.ToString());
            string q="Update Customer set Customer_Balance='"+ec.Cus_Bal+"' where Customer_Id='"+ec.Cus_Id+"'";
            cc.insertDataWithoutImage(q);
            ec.Order_date = dateTimePicker1.Value;
            ec.Order_id = Convert.ToInt32(textBox2.Text.ToString());
            ec.Order_status = comboBox1.SelectedItem.ToString();

            string q1 = "insert into TakeOrder (Order_Status,Customer_Id,Order_Date) values ('" + ec.Order_status + "','" + ec.Cus_Id + "','"+ec.Order_date+"')";
            cc.insertDataWithoutImage(q1);


            int Count = dataGridView1.Rows.Count;
            int c = Count - 1;

            for (int i = 0; i < c; i++)
            {
                ec.OrderLineItemMoney = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString());
                
                string productName = dataGridView1.Rows[i].Cells["Item"].Value.ToString();
                

              


                int qty = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());
                ec.OrderLineItemSingleMoney = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value.ToString());
                int orderid = Convert.ToInt32(textBox2.Text);

                string q2 = "Insert into OrderLineItem (P_Name,OrderLine_Qnty,OrderLine_TotalPrice,OrderLine_Price,Order_Id,Customer_Id) values  ('" + productName + "','" + qty + "' , '" + ec.OrderLineItemMoney + "','" + ec.OrderLineItemSingleMoney+ "','" + orderid+ "','" + ec.Cus_Id + "')";
                
                cc.insertDataWithoutImage(q2);

                string updatequantity = "Update Products set P_Qnty-='"+qty+"'where P_Name='"+productName+"'";

               bool a= cc.insertDataWithoutImage(updatequantity);

                if (a)
                {
                    MessageBox.Show("successfull");
                }

            }


            }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            
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

        private void dataGridView1_DefaultValuesNeeded_1(object sender, DataGridViewRowEventArgs e)
        {

            e.Row.Cells[1].Value = 1;

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dealer d = new BahriaCo.Dealer();
            d.Show();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
