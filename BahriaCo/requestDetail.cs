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
    public partial class requestDetail : Form
    {

        ControlClass cc;
        DatabaseHelper dbh;
        EntityClass ec;
        DataTable dt;
        public requestDetail()
        {
            InitializeComponent();

            cc = new ControlClass();
            dbh = new DatabaseHelper();
            ec = new EntityClass();
        }

        private void requestDetail_Load(object sender, EventArgs e)
        {
            cc.fillComboBox(comboBox1, "Customer_Id", "Customer");
            //auto id

         
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainPage mp = new BahriaCo.MainPage();
            mp.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            
            ec.Cus_Id = Convert.ToInt32(comboBox1.SelectedItem.ToString());
            dataGridView1.Rows.Clear();
            string q2 = "select * from TakeRepair where Customer_Id='" + ec.Cus_Id + "'";
            cc.RepairDetailFillGridView(dataGridView1, q2);
            dt = new DataTable();   
            dt = cc.getvalues(q2);
           textBox6.Text=dt.Rows[0][0].ToString();


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int Count = dataGridView1.Rows.Count;
            int c = Count - 1;

            for (int i = 0; i < c; i++)
            {
                ec.Repair_Price = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString());
                ec.Repair_Description = dataGridView1.Rows[i].Cells[2].Value.ToString();
                ec.Repair_id = Convert.ToInt32(textBox6.Text);

                
                string q2 = "insert into RepairDetail (Customer_Id,RepairDetail_Description,Repair_Id,Repair_Price) values  ('" +ec.Cus_Id + "','" + ec.Repair_Description+ "' , '" + ec.Repair_id+ "','" + ec.Repair_Price+"')";
                cc.insertDataWithoutImage(q2);

            }
            double totalamount = 0;


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                totalamount += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);

            }

            ec.Repair_TotalPrice = totalamount;
            
            this.Hide();
            requestPayment obj = new requestPayment();
            obj.ShowDialog();

        }
    }
}
