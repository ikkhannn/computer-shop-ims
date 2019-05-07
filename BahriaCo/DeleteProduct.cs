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
    public partial class DeleteProduct : Form
    {

        EntityClass ec;
        ControlClass cc;
        DataTable dt1;
        public DeleteProduct()
        {
            InitializeComponent();

            ec = new EntityClass();
            cc = new ControlClass();

        }

        private void DeleteProduct_Load(object sender, EventArgs e)
        {
            cc.fillComboBox(comboBox1, "P_Id", "Products");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string v;
                v = comboBox1.SelectedItem.ToString();
                dt1 = new DataTable();
                string q = "DELETE FROM Vendor where P_Name='" + v + "'";

                cc.insertDataWithoutImage(q);
                MessageBox.Show("Item deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("The Item doesnt exist");

            }
        }
    }
}
