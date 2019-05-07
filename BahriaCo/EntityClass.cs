using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BahriaCo
{


    class EntityClass
    {
        //customer entities
        public int Cus_Id { get; set; }
        public string Cus_Name { get; set; }
        public string Cus_Phone { get; set; }
        public string Cus_Address { get; set; }
        public byte[] Cus_Photo { get; set; }

        public DateTime Cus_Time { get; set; }

        public double Cus_Bal { get; set; }


        


        public int Order_id { get; set; }
        public string Order_status { get; set; }

        public DateTime Order_date { get; set; }
        public int Repair_id { get; set; }
        public string Repair_status { get; set; }

        public DateTime Repair_date { get; set; }

        public string Repair_Fault { get; set; }
        public string Repair_Description { get; set; }
        public double Repair_Price { get; set; }
        public double Repair_TotalPrice { get; set; }

        public DateTime RepairPayment_Date { get; set; }
        public double RepairPayment_Balance { get; set; }
        public double RepairPayment_Recieved { get; set; }
        

        public int VendorOrder_Id { set; get; }
        public DateTime VendorOrder_Date { get; set; }
        public string VendorOrder_Status { get; set; }


      public string VOrderPayment_Status { get; set; }
       public double VOrderPayment_Balance { get; set; }
       public double VOrderPayment_Paid { get; set; }
       public DateTime VOrderPayment_Date { get; set; }


        public string RepairPayment_Status { get; set; }
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Product_Qty { get; set; }
        public double Product_Price { get; set; }
        public string Product_Brand { get; set; }

        public DateTime OrderPayment_Date { get; set; }
        public double OrderPayment_Balance { get; set; }
        public double OrderPayment_Recieved { get; set; }
        public string OrderPayment_Status { get; set; }
       


        public byte[] Product_Photo { get; set; }

        public int Vendor_Id { get; set; }
        public string Vendor_Name { get; set; }
        public string Vendor_Phone { get; set; }
        public string Vendor_Address { get; set; }
        public byte[] Vendor_Photo { get; set; }

       

        public double Vendor_Bal { get; set; }





        public double OrderLineItemMoney { get; set; }
        public double OrderLineItemSingleMoney { get; set; }
        public double VendorOrderLineItemMoney { get; set; }
        public double VendorOrderLineItemSingleMoney { get; set; }



        
    }
}
