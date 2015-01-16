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
using System.Data.SqlTypes;
namespace WindowsFormsApplication1
{
    public partial class Employee_Details : Form
    {

        public Employee_Details()
        {
            InitializeComponent();
        
        }

        private void displelect_Click(object sender, EventArgs e)
        {
            electricians obj = new electricians();
            obj.ShowDialog();
        }

        private void dispplum_Click(object sender, EventArgs e)
        {
            Plumbers obj = new Plumbers();
            obj.ShowDialog();
        }

      
       
    }
}
