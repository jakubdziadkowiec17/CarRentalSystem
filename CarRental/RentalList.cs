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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarRental
{
    public partial class RentalList : Form
    {
        public RentalList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //BACK
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e) //EXIT
        {
            Application.Exit();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=CarRentalDataBase;Integrated Security=True");
        private void RentalList_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT DISTINCT A.Id, A.Name, A.Surname, A.PESEL, A.Phone_number AS 'Phone Number', A.Email AS 'E-mail', A.Address, A.Car AS 'Car Model', A.Hours, (cast(A.Price as varchar(20)) + '/' + cast((B.Price_per_hour*A.Hours) as varchar(20))) as 'Payment Status', A.Payment_Date AS 'Payment Date' FROM Table0 AS A, Table2 AS B WHERE A.Car=B.Car_model";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e) //SEARCH FIELD
        {
            conn.Open();
            string query1 = "SELECT DISTINCT A.Id, A.Name, A.Surname, A.PESEL, A.Phone_number AS 'Phone Number', A.Email AS 'E-mail', A.Address, A.Car AS 'Car Model', A.Hours, (cast(A.Price as varchar(20)) + '/' + cast((B.Price_per_hour*A.Hours) as varchar(20))) as 'Payment Status', A.Payment_Date AS 'Payment Date' FROM Table0 AS A, Table2 AS B WHERE A.Car=B.Car_model AND Surname='" + textBox1.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query1, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e) //REFRESH SEARCH FIELD
        {
            conn.Open();
            string query = "SELECT DISTINCT A.Id, A.Name, A.Surname, A.PESEL, A.Phone_number AS 'Phone Number', A.Email AS 'E-mail', A.Address, A.Car AS 'Car Model', A.Hours, (cast(A.Price as varchar(20)) + '/' + cast((B.Price_per_hour*A.Hours) as varchar(20))) as 'Payment Status', A.Payment_Date AS 'Payment Date' FROM Table0 AS A, Table2 AS B WHERE A.Car=B.Car_model";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) //ALL FILTER
        {
            conn.Open();
            string query = "SELECT DISTINCT A.Id, A.Name, A.Surname, A.PESEL, A.Phone_number AS 'Phone Number', A.Email AS 'E-mail', A.Address, A.Car AS 'Car Model', A.Hours, (cast(A.Price as varchar(20)) + '/' + cast((B.Price_per_hour*A.Hours) as varchar(20))) as 'Payment Status', A.Payment_Date AS 'Payment Date' FROM Table0 AS A, Table2 AS B WHERE A.Car=B.Car_model";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e) //PAID FILTER
        {
            conn.Open();
            string query = "SELECT DISTINCT A.Id, A.Name, A.Surname, A.PESEL, A.Phone_number AS 'Phone Number', A.Email AS 'E-mail', A.Address, A.Car AS 'Car Model', A.Hours, (cast(A.Price as varchar(20)) + '/' + cast((B.Price_per_hour*A.Hours) as varchar(20))) as 'Payment Status', A.Payment_Date AS 'Payment Date' FROM Table0 AS A, Table2 AS B WHERE A.Car=B.Car_model AND A.Payment_Date IS NOT NULL";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e) //UNPAID FILTER
        {
            conn.Open();
            string query = "SELECT DISTINCT A.Id, A.Name, A.Surname, A.PESEL, A.Phone_number AS 'Phone Number', A.Email AS 'E-mail', A.Address, A.Car AS 'Car Model', A.Hours, (cast(A.Price as varchar(20)) + '/' + cast((B.Price_per_hour*A.Hours) as varchar(20))) as 'Payment Status' FROM Table0 AS A, Table2 AS B WHERE A.Car=B.Car_model AND A.Payment_Date IS NULL";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
