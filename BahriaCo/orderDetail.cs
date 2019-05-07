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
    public partial class orderDetail : Form
    {
        public orderDetail()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage mp = new MainPage();
            mp.ShowDialog();

        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MainPage mp = new BahriaCo.MainPage();
            mp.ShowDialog();
        }

        private void simpleButton2_Click_2(object sender, EventArgs e)
        {
            this.Hide();

            MainPage mp = new BahriaCo.MainPage();
            mp.ShowDialog();
        } 
    }
}
