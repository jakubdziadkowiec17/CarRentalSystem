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
    public partial class Payments : Form
    {
        public Payments()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=CarRentalDataBase;Integrated Security=True");
        private void Payments_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT DISTINCT A.Id, A.Name, A.Surname, A.PESEL, A.Car AS 'Car Model', (cast(A.Price as varchar(20)) + '/' + cast((B.Price_per_hour*A.Hours) as varchar(20))) as 'Payment Status', A.Payment_Date AS 'Payment Date' FROM Table0 AS A, Table2 AS B WHERE A.Car=B.Car_model AND A.Payment_Date IS NOT NULL";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

            conn.Open();
            SqlCommand sc = new SqlCommand("SELECT Id FROM Table0 WHERE Payment_Date IS NULL", conn);
            SqlDataReader sdr;
            sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Load(sdr);
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = dt;
            conn.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e) //REFRESH FIELD
        {
            dateTimePicker1.Text = "";
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e) //PAY
        {
            if (dateTimePicker1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Missing field");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Table0 SET Payment_Date='" + dateTimePicker1.Text + "', Price=" + textBox3.Text + " WHERE Id=" + comboBox1.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success");
                    conn.Close();

                    conn.Open();
                    string query1 = "SELECT DISTINCT A.Id, A.Name, A.Surname, A.PESEL, A.Car AS 'Car Model', (cast(A.Price as varchar(20)) + '/' + cast((B.Price_per_hour*A.Hours) as varchar(20))) as 'Payment Status', A.Payment_Date AS 'Payment Date' FROM Table0 AS A, Table2 AS B WHERE A.Car=B.Car_model AND A.Payment_Date IS NOT NULL";
                    SqlDataAdapter sda = new SqlDataAdapter(query1, conn);
                    SqlCommandBuilder scb = new SqlCommandBuilder();
                    var ds = new DataSet();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    conn.Close();

                    dateTimePicker1.Text = "";
                    textBox3.Text = "";

                    conn.Open();
                    SqlCommand sc = new SqlCommand("SELECT Id FROM Table0 WHERE Payment_Date IS NULL", conn);
                    SqlDataReader sdr;
                    sdr = sc.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Id", typeof(int));
                    dt.Load(sdr);
                    comboBox1.ValueMember = "Id";
                    comboBox1.DataSource = dt;
                    conn.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e) //REFRESH SEARCH FIELD
        {
            conn.Open();
            string query1 = "SELECT DISTINCT A.Id, A.Name, A.Surname, A.PESEL, A.Car AS 'Car Model', (cast(A.Price as varchar(20)) + '/' + cast((B.Price_per_hour*A.Hours) as varchar(20))) as 'Payment Status', A.Payment_Date AS 'Payment Date' FROM Table0 AS A, Table2 AS B WHERE A.Car=B.Car_model AND A.Payment_Date IS NOT NULL";
            SqlDataAdapter sda = new SqlDataAdapter(query1, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

            textBox8.Text = "";
        }

        private void button7_Click(object sender, EventArgs e) //SEARCH FIELD
        {
            conn.Open();
            string query1 = "SELECT DISTINCT A.Id, A.Name, A.Surname, A.PESEL, A.Car AS 'Car Model', (cast(A.Price as varchar(20)) + '/' + cast((B.Price_per_hour*A.Hours) as varchar(20))) as 'Payment Status', A.Payment_Date AS 'Payment Date' FROM Table0 AS A, Table2 AS B WHERE A.Car=B.Car_model AND A.Payment_Date IS NOT NULL AND Surname='" + textBox8.Text + "' AND Payment_Date IS NOT NULL";
            SqlDataAdapter sda = new SqlDataAdapter(query1, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        Bitmap bmp;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void button4_Click(object sender, EventArgs e) //PRINT
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            dataGridView1.Height = height;
            printPreviewDialog1.ShowDialog();

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
