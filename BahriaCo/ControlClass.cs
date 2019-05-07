using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace BahriaCo
{
    class ControlClass
    {
        DatabaseHelper dbh;
        EntityClass ec;
        DataTable dt;

        public ControlClass()
        {
            dbh = new DatabaseHelper();
            ec = new EntityClass();

            
        }
        public void InsertData()
        {
        }

        public bool insertDataWithoutImage(string q)
        {
            try
            {

                if (dbh.insertUpdateDelete(q))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");
            }
            return false;
        }
     public bool insertDataWithImage(EntityClass ec,string v,PictureBox p,string q)
        {
            try
            {
                if (dbh.insertDataWithImage(ec,v,p,q))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");

            }
            return false;
        }

        public void CustomerFillGridView(DataGridView dgv,string q)
        {
            byte[] img;
            dt = dbh.Search(q);
            int count = dt.Rows.Count;

            if (dt != null)
            {
                for (int i = 0; i < count; i++) 
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].Cells["cus_id"].Value = dt.Rows[i]["Customer_Id"].ToString();
                    dgv.Rows[i].Cells["cus_name"].Value = dt.Rows[i]["Customer_Name"].ToString();
                    dgv.Rows[i].Cells["cus_address"].Value = dt.Rows[i]["Customer_Address"].ToString();
                    dgv.Rows[i].Cells["cus_phone"].Value = dt.Rows[i]["Customer_Phone"].ToString();
                    string g= dt.Rows[i]["Customer_Photo"].ToString();
                    dgv.Rows[i].Cells["cus_balance"].Value = dt.Rows[i]["Customer_Balance"].ToString();
                    if (g != "")
                    {
                        img = (byte[])(dt.Rows[i]["Customer_Photo"]);
                        MemoryStream ms = new MemoryStream(img);
                        dgv.Rows[i].Cells["cus_photo"].Value = System.Drawing.Image.FromStream(ms);

                        if(dgv.Columns["cus_photo"] is DataGridViewImageColumn)
                        {
                            ((DataGridViewImageColumn)dgv.Columns["cus_photo"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        }
                        
                    }
                }
            }
        }
        public void PaymentOrderFillGridView(DataGridView dgv, string q)
        {
            byte[] img;
            dt = dbh.Search(q);
            int count = dt.Rows.Count;

            if (dt != null)
            {
                for (int i = 0; i < count; i++)
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].Cells["Order_Id"].Value = dt.Rows[i]["Order_Id"].ToString();
                    dgv.Rows[i].Cells["Order_Status"].Value = dt.Rows[i]["Order_Status"].ToString();
                    dgv.Rows[i].Cells["Order_Date"].Value = dt.Rows[i]["Order_Date"].ToString();
                    dgv.Rows[i].Cells["Customer_Id"].Value = dt.Rows[i]["Customer_Id"].ToString();
                    
                }
            }
        }
        public void VendorPaymentOrderFillGridView(DataGridView dgv, string q)
        {
            byte[] img;
            dt = dbh.Search(q);
            int count = dt.Rows.Count;

            if (dt != null)
            {
                for (int i = 0; i < count; i++)
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].Cells["VOrder_Id"].Value = dt.Rows[i]["VOrder_Id"].ToString();
                    dgv.Rows[i].Cells["VOrder_Status"].Value = dt.Rows[i]["VOrder_Status"].ToString();
                    dgv.Rows[i].Cells["VOrder_Date"].Value = dt.Rows[i]["VOrder_Date"].ToString();
                    dgv.Rows[i].Cells["Dealer_Id"].Value = dt.Rows[i]["Dealer_Id"].ToString();

                }
            }
        }
        public void RepairDetailFillGridView(DataGridView dgv, string q)
        {
            byte[] img;
            dt = dbh.Search(q);
            int count = dt.Rows.Count;

            if (dt != null)
            {
                for (int i = 0; i < count; i++)
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].Cells["Repair_Id"].Value = dt.Rows[i]["Repair_Id"].ToString();
                    dgv.Rows[i].Cells["Repair_Fault"].Value = dt.Rows[i]["Repair_Fault"].ToString();
                    
                    

                }
            }
        }
        public void OrderLineItemFillGridView(DataGridView dgv, string q)
        {
            byte[] img;
            dt = dbh.Search(q);
            int count = dt.Rows.Count;

            if (dt != null)
            {
                for (int i = 0; i < count; i++)
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].Cells["P_Name"].Value = dt.Rows[i]["P_Name"].ToString();
                    dgv.Rows[i].Cells["OrderLine_Qnty"].Value = dt.Rows[i]["OrderLine_Qnty"].ToString();
                    dgv.Rows[i].Cells["OrderLine_TotalPrice"].Value = dt.Rows[i]["OrderLine_TotalPrice"].ToString();
                    dgv.Rows[i].Cells["OrderLine_Price"].Value = dt.Rows[i]["OrderLine_Price"].ToString();
                    dgv.Rows[i].Cells["oid"].Value = dt.Rows[i]["Order_Id"].ToString();


                }
            }
        }
        public void VendorOrderLineItemFillGridView(DataGridView dgv, string q)
        {
            byte[] img;
            dt = dbh.Search(q);
            int count = dt.Rows.Count;

            if (dt != null)
            {
                for (int i = 0; i < count; i++)
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].Cells["P_Name"].Value = dt.Rows[i]["P_Name"].ToString();
                    dgv.Rows[i].Cells["OrderLine_Qnty"].Value = dt.Rows[i]["VOrderLine_Qnty"].ToString();
                    dgv.Rows[i].Cells["OrderLine_TotalPrice"].Value = dt.Rows[i]["VOrderLine_TotalPrice"].ToString();
                    dgv.Rows[i].Cells["OrderLine_Price"].Value = dt.Rows[i]["VOrderLine_Price"].ToString();
                    dgv.Rows[i].Cells["oid"].Value = dt.Rows[i]["VendorOrder_Id"].ToString();


                }
            }
        }

        public void RequestLineItemFillGridView(DataGridView dgv, string q)
        {
            byte[] img;
            dt = dbh.Search(q);
            int count = dt.Rows.Count;

            if (dt != null)
            {
                for (int i = 0; i < count; i++)
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].Cells["Customer_Id"].Value = dt.Rows[i]["Customer_Id"].ToString();
                    dgv.Rows[i].Cells["Repair_Price"].Value = dt.Rows[i]["Repair_Price"].ToString();
                    dgv.Rows[i].Cells["Repair_Description"].Value = dt.Rows[i]["RepairDetail_Description"].ToString();
                    dgv.Rows[i].Cells["Repair_Id"].Value = dt.Rows[i]["Repair_Id"].ToString();
                    


                }
            }
        }

        public void VendorFillGridView(DataGridView dgv, string q)
        {
            byte[] img;
            dt = dbh.Search(q);
            int count = dt.Rows.Count;

            if (dt != null)
            {
                for (int i = 0; i < count; i++)
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].Cells["Vendor_Id"].Value = dt.Rows[i]["Vendor_Id"].ToString();
                    dgv.Rows[i].Cells["Vendor_Name"].Value = dt.Rows[i]["Vendor_Name"].ToString();
                    dgv.Rows[i].Cells["Vendor_Address"].Value = dt.Rows[i]["Vendor_Address"].ToString();
                    dgv.Rows[i].Cells["Vendor_Phone"].Value = dt.Rows[i]["Vendor_Phone"].ToString();
                    string g = dt.Rows[i]["Vendor_Photo"].ToString();
                    dgv.Rows[i].Cells["Vendor_Balance"].Value = dt.Rows[i]["Vendor_Balance"].ToString();
                    if (g != "")
                    {
                        img = (byte[])(dt.Rows[i]["Vendor_Photo"]);
                        MemoryStream ms = new MemoryStream(img);
                        dgv.Rows[i].Cells["Vendor_Photo"].Value = System.Drawing.Image.FromStream(ms);

                        if (dgv.Columns["Vendor_Photo"] is DataGridViewImageColumn)
                        {
                            ((DataGridViewImageColumn)dgv.Columns["Vendor_Photo"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        }

                    }
                }
            }
        }
        public void ProductFillGridView(DataGridView dgv, string q)
        {
            byte[] img;
            dt = dbh.Search(q);
            int count = dt.Rows.Count;

            if (dt != null)
            {
                for (int i = 0; i < count; i++)
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].Cells["pname"].Value = dt.Rows[i]["P_Name"].ToString();
                    dgv.Rows[i].Cells["pquantity"].Value = dt.Rows[i]["P_Qnty"].ToString();
                    dgv.Rows[i].Cells["pprice"].Value = dt.Rows[i]["P_Price"].ToString();
                    dgv.Rows[i].Cells["pbrand"].Value = dt.Rows[i]["P_Brand"].ToString();
                    string g = dt.Rows[i]["P_Photo"].ToString();
                    
                    if (g != "")
                    {
                        img = (byte[])(dt.Rows[i]["P_Photo"]);
                        MemoryStream ms = new MemoryStream(img);
                        dgv.Rows[i].Cells["pphoto"].Value = System.Drawing.Image.FromStream(ms);

                        if (dgv.Columns["pphoto"] is DataGridViewImageColumn)
                        {
                            ((DataGridViewImageColumn)dgv.Columns["pphoto"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        }

                    }
                }
            }
        }


        public void fillComboBox(ComboBox cb,string v,string q)
        {
            string query = "select * from " + q + " ";
            dt = dbh.Search(query);
            if (dt != null)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    cb.Items.Add(dt.Rows[i][v].ToString());

                }
            }

        }
        public DataTable getvalues(string q)
        {
           
            dt = dbh.Search(q);
            if (dt != null)
            {
                return dt;
            }

            return null;
           

        }



    }


}
