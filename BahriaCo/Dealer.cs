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
    public partial class Dealer : Form
    {
        public Dealer()
        {
            InitializeComponent();
        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            this.Hide();
            CustomerDetail c = new CustomerDetail();
            c.ShowDialog();
        }

        private void tileItem4_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            this.Hide();
            TypeOfOrder too = new TypeOfOrder();
            too.ShowDialog();
        }

        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            this.Hide();
            paymentCustomer pc = new paymentCustomer();
            pc.ShowDialog(); 
        }

        private void tileItem5_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            this.Hide();
            orderToVender oTV = new orderToVender();
            oTV.ShowDialog();
        }

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            this.Hide();
            paymentVender pV = new paymentVender();
            pV.ShowDialog();
        }

        private void tileItem6_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            this.Hide();
            AddProduct ap = new AddProduct();
            ap.ShowDialog();
        }

        private void tileItem7_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            this.Hide();
            AddVendor av = new AddVendor();
            av.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage mp = new BahriaCo.MainPage();
            mp.ShowDialog();
        }
    }
}
