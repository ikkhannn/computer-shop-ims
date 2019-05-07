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
    public partial class TypeOfOrder : Form
    {
        public TypeOfOrder()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            this.Hide();
            TakeOrder to = new TakeOrder();
            to.ShowDialog();
        }

        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            this.Hide();
            request r = new BahriaCo.request();
            r.ShowDialog();


        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dealer d = new BahriaCo.Dealer();
            d.Show();
        }
    }
}
