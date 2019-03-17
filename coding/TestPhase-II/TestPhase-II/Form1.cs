using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace TestPhase_II
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
                    private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Searchbutton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = RANA-MATEEN\SQLEXPRESS; Initial Catalog = CRUD_DB; Integrated Security = True");
            SqlDataAdapter sqd = new SqlDataAdapter("SELECT * FROM Employee where Emp_Id ='" + Searchbar.Text + "' ", con);
            DataTable dt = new DataTable();
            sqd.Fill(dt);
            if (dt.Rows.Count>0)
            {
                Statusbar.Text = "Record Found";
                Statusbar.ForeColor = Color.Green;
                Statusbar.Font = new Font(Statusbar.Font, FontStyle.Bold);

                

                Empid.Text = dt.Rows[0][0].ToString();
                Empname.Text = dt.Rows[0][1].ToString();
                Address.Text = dt.Rows[0][2].ToString();
                DOB.Text = dt.Rows[0][3].ToString();
                Salary.Text = dt.Rows[0][4].ToString();
                Timein.Text = dt.Rows[0][5].ToString();
            }
            else
            {
                Statusbar.Text = "Record NOT Found";
                Statusbar.ForeColor = Color.Red;
                Empid.Text = "";
                Empname.Text = "";
                Address.Text = "";
                DOB.Text = "";
                Salary.Text = "";
                Timein.Text = "";
            }
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            
                SqlConnection con = new SqlConnection(@"Data Source = RANA-MATEEN\SQLEXPRESS; Initial Catalog = CRUD_DB; Integrated Security = True");
                con.Open();

                SqlCommand sqc = new SqlCommand("INSERT INTO Employee (Emp_Id, Name, Address, DOB, Salary, Time_In) VALUES ('" + Empid.Text + "', '" + Empname.Text + "','" + Address.Text + "','" + DOB.Text.ToString() + "','" + Salary.Text + "','" + Timein.Text + "')", con);
                int a = sqc.ExecuteNonQuery();
            if (a > 0)
            {
                Statusbar.Text = "Record Inserted Successfully";
                Statusbar.ForeColor = Color.Green;
                Statusbar.Font = new Font(Statusbar.Font, FontStyle.Bold);
                con.Close();
            }
            else {
                Statusbar.Text = "Problem Occurred! Try Again";
                Statusbar.ForeColor = Color.Red;
                Statusbar.Font = new Font (Statusbar.Font, FontStyle.Bold ) ;
            }
            //MessageBox.Show("Record Inserted");
                
            
            
        }

        private void Updatebutton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = RANA-MATEEN\SQLEXPRESS; Initial Catalog = CRUD_DB; Integrated Security = True");
            con.Open();

            SqlCommand sqc = new SqlCommand("update Employee set Emp_Id = '"+ Empid.Text +"', Name='"+Empname.Text+"', Address='"+Address.Text+"', DOB='"+DOB.Text.ToString()+"', Salary = '"+Salary.Text+"', Time_In = '"+Timein.Text.ToString()+"' where Emp_Id = '"+Empid.Text+"'", con);
            int a = sqc.ExecuteNonQuery();
            if (a > 0)
            {
                Statusbar.Text = "Record Updated Successfully";
                Statusbar.ForeColor = Color.Green;
                Statusbar.Font = new Font(Statusbar.Font, FontStyle.Bold);
                con.Close();
            }
            else
            {
                Statusbar.Text = "Problem Occurred! Try Again";
                Statusbar.ForeColor = Color.Red;
                Statusbar.Font = new Font(Statusbar.Font, FontStyle.Bold);
                con.Close();
            }
            //MessageBox.Show("Record Updated");
            
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = RANA-MATEEN\SQLEXPRESS; Initial Catalog = CRUD_DB; Integrated Security = True");
            con.Open();

            SqlCommand sqc = new SqlCommand("DELETE FROM EMPLOYEE where Emp_Id = '" + Empid.Text + "'", con);
            int a = sqc.ExecuteNonQuery();
            if (a > 0)
            {
                Statusbar.Text = "Record Deleted";
                Statusbar.ForeColor = Color.Green;
                Statusbar.Font = new Font(Statusbar.Font, FontStyle.Bold);
                Empid.Text = "";
                Empname.Text = "";
                Address.Text = "";
                DOB.Text = "";
                Salary.Text = "";
                Timein.Text = "";
                con.Close();
            }
            else
            {
                Statusbar.Text = "Problem Occurred! Try Again";
                Statusbar.ForeColor = Color.Red;
                Statusbar.Font = new Font(Statusbar.Font, FontStyle.Bold);
                con.Close();
            }
            //MessageBox.Show("Record Deleted");
            //con.Close();
        }

        private void Clearbutton_Click(object sender, EventArgs e)
        {
            Statusbar.Text = "";
            Empid.Text = "";
            Empname.Text = "";
            Address.Text = "";
            DOB.Text = "";
            Salary.Text = "";
            Timein.Text = "";
            Searchbar.Text = "";
        }
    }
}

