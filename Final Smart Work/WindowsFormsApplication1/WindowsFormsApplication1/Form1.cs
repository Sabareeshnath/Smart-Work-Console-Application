using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=SABZZ\SQLEXPRESS;Initial Catalog=SmartWork;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr,dr2;
        
         
        
            
        public Form1()
        {
            
            cmd.Connection = cn;
            cm.Connection = cn;
            InitializeComponent();
            loadElectrician();
            loadPlumbers();
             Electrician.Update();
            Plumbers.Update();


            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
            cm.Connection = cn;

            
            loadElectrician();
            loadPlumbers();

            Electrician.Update();
            Plumbers.Update();
        
            cname.Text = " ";
            cnum.Text = " ";
            caddr.Text = " ";
            creport.Text = " ";
            crooted.Text = " ";
            Electrician.Text = " ";
            Plumbers.Text = " ";

        }

             

        private void button1_Click_1(object sender, EventArgs e)
        {


            string customer;
            string customerID= String.Empty;
            int num;
            char[] b=new char[0];
            cn.Open();
            cm.CommandText= "SELECT COUNT(cust_id) FROM customerdetails";
            Int32 count = (Int32)cm.ExecuteScalar();
           
            cn.Close();
            

           cn.Open();
            cmd.CommandText = " select max(cust_id) from customerdetails";
            dr=cmd.ExecuteReader();
        if (count==0)
            {

                customerID = "A100";

               
            }
            else
            {
                while (dr.Read())
                {
                    customerID = dr[0].ToString().Trim();
                                      
                }
                string s = customerID.Substring(0, 1);
                string n = customerID.Substring(1, 3);
                num = int.Parse(n);

                if (num == 999)
                {
                    b = s.ToCharArray();
                    ++b[0];
                     customer = new string(b);
                     num = 100;
                     customerID = String.Concat(customer, num);
                     
                }
                else
                {                    
                    ++num;
                    customer = s;
                    customerID = String.Concat(customer, num);
                   
                }
             
           }
            dr.Close();
            cn.Close();

            id.Text = customerID;
                       
       if (cname.Text != " " && cnum.Text != " " && caddr.Text != " " && creport.Text != " " && crooted.Text != " ")
            {


                cn.Open();

                cmd.CommandText = "insert into customerdetails (cust_id,names,number,caddr,report,rooted) values ('"+id.Text.TrimStart()+"','"+cname.Text.TrimStart()+"','"+cnum.Text.TrimStart()+"','"+caddr.Text.TrimStart()+"','"+creport.Text.TrimStart()+"','"+crooted.Text.TrimStart()+"')";
                
                cmd.ExecuteNonQuery();

                cmd.Clone();



                MessageBox.Show("Saved Successfully !! ");
                cn.Close();
                cname.Text = " ";
                cnum.Text = " ";
                caddr.Text = " ";
                creport.Text = " ";
                crooted.Text = " ";
                id.Text = " ";
                

            }

            else
            {
                MessageBox.Show("Invalid Input !! ");
            }

        }



        private void loadElectrician()
        {
            this.Refresh();
            Electrician.Items.Clear();
            cn.Open();
            this.Refresh();
            cmd.CommandText = "select * from  electricans";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Electrician.Items.Add(dr[0].ToString());
                    Electrician.Items.Add(dr[1].ToString());
                    Electrician.Items.Add(dr[2].ToString());
                    Electrician.Items.Add('\n');

                }
            }
            cn.Close();

        }
        private void loadPlumbers()
        {
            
            Plumbers.Items.Clear();
            cn.Open();
            this.Refresh();
            cmd.CommandText = "select * from  plumbers";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Plumbers.Items.Add(dr[0].ToString());
                    Plumbers.Items.Add(dr[1].ToString());
                    Plumbers.Items.Add(dr[2].ToString());
                    Plumbers.Items.Add('\n');
                    

                }
            }
            dr.Close();
            cn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cname.Text != " " || id.Text !=" ")
            {
                id.ReadOnly=true;
                cn.Open();
                cmd.CommandText = " update customerdetails set names='"+cname.Text.TrimStart()+"',number='"+cnum.Text.TrimStart()+"',caddr='"+caddr.Text.TrimStart()+"',report='"+ creport.Text.TrimStart()+"',rooted='"+crooted.Text.TrimStart()+"' where names='"+cname.Text.TrimStart()+"'";
 
                cmd.ExecuteNonQuery();
                cmd.Clone();

                cn.Close();
                MessageBox.Show("Customer Detail Update");
                cname.Text = " ";
                cnum.Text = " ";
                caddr.Text = " ";
                creport.Text = " ";
                crooted.Text = " ";
                id.Text = " ";
            }
        }

        private void search_Click_1(object sender, EventArgs e)
        {
            if (cname.Text != " " || id.Text != " ")
            {

                cn.Open();
                cmd.CommandText = "select * from  customerdetails where names='"+cname.Text.Trim()+"' or cust_id='"+id.Text.Trim()+"'";
                dr = cmd.ExecuteReader();
                

                if (dr.HasRows)
                {
                    cname.Text = " ";
                    cnum.Text = " ";
                    caddr.Text = " ";
                    creport.Text = " ";
                    crooted.Text = " ";
                    id.Text = " ";
                    while (dr.Read())
                    {
                        id.Text = dr[0].ToString().Trim();
                        cname.Text = dr[1].ToString().Trim();
                        cnum.Text = dr[2].ToString().Trim();
                        caddr.Text = dr[3].ToString().Trim();
                        creport.Text = dr[4].ToString().Trim();
                        crooted.Text = dr[5].ToString().Trim();


                    }
                }

                else
                {
                    MessageBox.Show("Customer Not Found");
                    cname.Text = " ";
                    cnum.Text = " ";
                    caddr.Text = " ";
                    creport.Text = " ";
                    crooted.Text = " ";
                    id.Text = " ";
                }
                dr.Close();
                cn.Close();
            }
      
            }

        private void display_Click(object sender, EventArgs e)
        {
            cname.Text = " ";
            cnum.Text = " ";
            caddr.Text = " ";
            creport.Text = " ";
            crooted.Text = " ";
            id.Text = " ";
            Customer_Details cd = new Customer_Details();
            cd.ShowDialog();
        }



        private void worksearch_Click(object sender, EventArgs e)
        {
            Plumbers.Items.Clear();
            Electrician.Items.Clear();
            cn.Open();

            if (place.Text.TrimStart() != " ")
            {

              cmd.CommandText = "select * from  plumbers where paddr='"+place.Text.TrimStart()+"'";
              cmd.ExecuteNonQuery();
              dr = cmd.ExecuteReader();
                
   
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Plumbers.Items.Add(dr[0].ToString());
                    Plumbers.Items.Add(dr[1].ToString());
                    Plumbers.Items.Add(dr[2].ToString());
                    Plumbers.Items.Add('\n');

                }
            }
            dr.Close();
         
         
                cm.CommandText = "select * from electricans where eaddr='"+place.Text.TrimStart()+"'";
                cm.ExecuteNonQuery();
                dr2 = cm.ExecuteReader(); 

            if (dr2.HasRows)
            {
                while (dr2.Read())
                {
                    Electrician.Items.Add(dr2[0].ToString());
                    Electrician.Items.Add(dr2[1].ToString());
                    Electrician.Items.Add(dr2[2].ToString());
                    Electrician.Items.Add('\n');
                }
            }

       
            dr2.Close();
          

                
            }

            cn.Close();



        }

        private void modify_Click(object sender, EventArgs e)
        {
            Form3 cd = new Form3();
            cd.ShowDialog();
        
        }


          
        



    
}

            
}




        

      
 
       

        

        
    




       
