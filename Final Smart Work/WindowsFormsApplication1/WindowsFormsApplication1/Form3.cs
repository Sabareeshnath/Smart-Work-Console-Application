using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=SABZZ\SQLEXPRESS;Initial Catalog=SmartWork;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public Form3()
        {
            InitializeComponent();
            cmd.Connection = cn;
            this.Refresh();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
            this.Refresh();
            wname.Text = " ";
            wmobile.Text = " ";
            wplace.Text = " ";
        }

        private void wsave_Click(object sender, EventArgs e)
        {
          


            if (comboBox1.Text == " ")
            {
                MessageBox.Show("Invalid Input !!");

            }
            else if (comboBox1.Text == "Electrician" && wname.Text != " " && wmobile.Text != " " && wplace.Text != " ")
            {
                

                    cn.Open();

                    cmd.CommandText = "insert into electricans (ename,eaddr,enumber) values ('"+wname.Text.TrimStart()+"','"+wplace.Text.TrimStart()+"','"+wmobile.Text.TrimStart()+"')";

                    cmd.ExecuteNonQuery();

                    cmd.Clone();

                

                    MessageBox.Show("Saved Successfully !! ");
                    cn.Close();

                    wname.Text = " ";
                    wmobile.Text = " ";
                    wplace.Text = " ";
                    comboBox1.Text = " ";

                }

                        

            else if (comboBox1.Text == "Plumber" && wname.Text != " " && wmobile.Text != " " && wplace.Text != " ")
            {
               
                    cn.Open();

                    cmd.CommandText = "insert into plumbers (pname,paddr,pnumber) values ('"+wname.Text.TrimStart()+"','"+wplace.Text.TrimStart()+"','"+wmobile.Text.TrimStart()+"')";

                    cmd.ExecuteNonQuery();

                    cmd.Clone();



                    MessageBox.Show("Saved Successfully !! ");
                    cn.Close();

                    wname.Text = " ";
                    wmobile.Text = " ";
                    wplace.Text = " ";
                    comboBox1.Text = " ";

                }

                else
                {
                    MessageBox.Show("Invalid Input Or Position Not Selected!! ");
                }
            }

        private void wsearch_Click(object sender, EventArgs e)
        {


            if (wname.Text != " " && comboBox1.Text == "Electrician")
            {

                cn.Open();
                cmd.CommandText = "select * from  electricans where ename='"+wname.Text.TrimStart()+"'";
                dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    wname.Text = " ";
                    wmobile.Text = " ";
                    wplace.Text = " ";
                    
                    while (dr.Read())
                    {

                        wname.Text = dr[0].ToString().TrimStart();
                        wplace.Text = dr[1].ToString().TrimStart();
                        wmobile.Text = dr[2].ToString().TrimStart();
                       

                    }
                }

                else
                {
                    MessageBox.Show("Employee Not Found");
                    wname.Text = " ";
                    wmobile.Text = " ";
                    wplace.Text = " ";
                    comboBox1.Text = " ";
                }
                dr.Close();
                cn.Close();
            }

            else if (wname.Text != " " && comboBox1.Text == "Plumber")
            {

                cn.Open();
                cmd.CommandText = "select * from  plumbers where pname='"+wname.Text.Trim()+"'";
                dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    wname.Text = " ";
                    wmobile.Text = " ";
                    wplace.Text = " ";

                    while (dr.Read())
                    {

                        wname.Text = dr[0].ToString().TrimStart();
                        wplace.Text = dr[1].ToString().TrimStart();
                        wmobile.Text = dr[2].ToString().TrimStart();


                    }
                }

                else
                {
                    MessageBox.Show("Employee Not Found");
                    wname.Text = " ";
                    wmobile.Text = " ";
                    wplace.Text = " ";
                    comboBox1.Text = " ";
                }
                dr.Close();
                cn.Close();
            }

            else
            {
                MessageBox.Show("Invalid Details Or Position Not Selected !! ");
            }
      
         }

        private void wupdate_Click(object sender, EventArgs e)
        {
            
            if (wname.Text != " " && comboBox1.Text=="Electrician")
            {
                cn.Open();
                cmd.CommandText = " update electricans set ename='"+ wname.Text.TrimStart()+"',eaddr='"+ wplace.Text.TrimStart()+"',enumber='"+ wmobile.Text.TrimStart()+"'";

                cmd.ExecuteNonQuery();
                cmd.Clone();

                cn.Close();
                MessageBox.Show("Employee Detail Update");
                wname.Text = " ";
                wmobile.Text = " ";
                wplace.Text = " ";
                comboBox1.Text = " ";
                

            }


            if (wname.Text != " " && comboBox1.Text == "Plumber")
            {
                cn.Open();
                cmd.CommandText = " update plumbers set pname='"+ wname.Text.TrimStart()+"',paddr='"+wplace.Text.TrimStart()+"',pnumber='"+wmobile.Text.TrimStart()+"'";

                cmd.ExecuteNonQuery();
                cmd.Clone();

                cn.Close();
                MessageBox.Show("Employee Detail Update");
                wname.Text = " ";
                wmobile.Text = " ";
                wplace.Text = " ";
                comboBox1.Text = " ";


            }
        }

        private void wdelete_Click(object sender, EventArgs e)
        {
            if (wname.Text != " " && comboBox1.Text == "Plumber")
            {
                cn.Open();
                cmd.CommandText = " delete from plumbers where pname='"+ wname.Text.TrimStart()+"'";

                cmd.ExecuteNonQuery();
                cmd.Clone();
                MessageBox.Show("Employee Details Deteled ");
                wname.Text = " ";
                wmobile.Text = " ";
                wplace.Text = " ";
                comboBox1.Text = " ";
                cn.Close();
            }

            else if (wname.Text != " " && comboBox1.Text == "Electrician")
            {
                cn.Open();
                cmd.CommandText = " delete from electricans where ename='"+wname.Text.TrimStart()+"'";

                cmd.ExecuteNonQuery();
                cmd.Clone();
                MessageBox.Show("Employee Details Deteled ");
                wname.Text = " ";
                wmobile.Text = " ";
                wplace.Text = " ";
                comboBox1.Text = " ";
                
                cn.Close();
            }

            else
            {
                wname.Text = " ";
                wmobile.Text = " ";
                wplace.Text = " ";
                comboBox1.Text = " ";
                MessageBox.Show("Record Not Found Or Position Not Selected");
            }
        }

        private void display_Click(object sender, EventArgs e)
        {
            
            Employee_Details obj = new Employee_Details();
            obj.ShowDialog();
        }

       
    
       
      
      
}    
    
       
}

