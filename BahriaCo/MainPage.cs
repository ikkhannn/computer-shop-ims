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
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            this.Hide();
            Dealer d = new BahriaCo.Dealer();
            d.ShowDialog();

        }

        

        private void tileItem2_ItemClick_1(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            this.Hide();
            orderDetail o = new orderDetail();
            o.ShowDialog();

        }

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            this.Hide();
            requestDetail r = new requestDetail();
            r.ShowDialog();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }
    }
}
