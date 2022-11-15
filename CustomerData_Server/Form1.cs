using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerData_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection = "Data Source=DESKTOP-8HH4HHP;Initial Catalog=practice;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();

            string CustomerID = textBox1.Text;
            string CompanyName = textBox2.Text;
            string ContactName = textBox3.Text;
            string Phone = textBox4.Text;

            string query = "INSERT INTO SOFTTECH VALUES('"+CustomerID+"','"+CompanyName+"','" + ContactName+ "','"+Phone+"')";
            SqlCommand cmd = new SqlCommand(query, con);    
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Inserted");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connection = "Data Source=DESKTOP-8HH4HHP;Initial Catalog=practice;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            using (SqlCommand cmd=new SqlCommand("Select CompanyName,ContactName,Phone from SOFTTECH  where CustomerID=@cust_id", con))
            {
                cmd.Parameters.AddWithValue("@cust_id", textBox5.Text);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    textBox2.Text = sdr["CompanyName"].ToString();
                    textBox3.Text = sdr["ContactName"].ToString();
                    textBox4.Text = sdr["Phone"].ToString();
                }
                else
                {
                    MessageBox.Show("Data Not Found");
                }
                con.Close();
            };
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connection = "Data Source=DESKTOP-8HH4HHP;Initial Catalog=practice;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "select * from SOFTTECH";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connection = "Data Source=DESKTOP-8HH4HHP;Initial Catalog=practice;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Delete from SOFTTECH where CustomerID="+textBox7.Text;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
            MessageBox.Show("Data Deleted");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string connection = "Data Source=DESKTOP-8HH4HHP;Initial Catalog=practice;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Update SOFTTECH set CompanyName='"+textBox2.Text+"',ContactName='"+textBox3+"',Phone='"+textBox4.Text+"'where CustomerID='" + textBox1.Text +"'"; 
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
            MessageBox.Show("Data Updated");
        }
    }
}
