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

    public partial class DeleteVendor : Form
    {
        EntityClass ec;
        ControlClass cc;
        DataTable dt1;
        public DeleteVendor()
        {
            InitializeComponent();

            ec = new EntityClass();
            cc = new ControlClass();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DeleteVendor_Load(object sender, EventArgs e)
        {
            cc.fillComboBox(comboBox1, "Vendor_Id", "Vendor");



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                string v;
                v = comboBox1.SelectedItem.ToString();
                dt1 = new DataTable();
                string q = "DELETE FROM Vendor where Vendor_Id='"+v+"'";

                cc.insertDataWithoutImage(q);
                MessageBox.Show("vendor deleted");
            }catch(Exception ex){
                MessageBox.Show("The vendor doesnt exist");

            }

        }
    }
}
