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
    public partial class CarList : Form
    {
        public CarList()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=CarRentalDataBase;Integrated Security=True");
        private void button5_Click(object sender, EventArgs e) //BACK
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e) //EXIT
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e) //REFRESH FIELDS
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e) //CREATE CAR
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Missing field");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Table2 " + "(Car_model, Price_per_hour) VALUES" + "('" + textBox1.Text + "'," + textBox2.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success");
                    conn.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

            conn.Open();
            string query1 = "SELECT Car_model AS 'Car Model', Price_per_hour AS 'Price per hour' FROM Table2";
            SqlDataAdapter sda = new SqlDataAdapter(query1, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //DATA BASE FIELD
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void CarList_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT Car_model AS 'Car Model', Price_per_hour AS 'Price per hour' FROM Table2";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e) //DELETE CAR
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Click row to delete");
            }
            else
            {
                //var temp = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Table2 WHERE Car_model = '" + textBox1.Text + "'; ";
                    SqlCommand sc = new SqlCommand(query, conn);
                    sc.ExecuteNonQuery();
                    MessageBox.Show("Success");
                    conn.Close();

                    conn.Open();
                    string query1 = "SELECT Car_model AS 'Car Model', Price_per_hour AS 'Price per hour' FROM Table2";
                    SqlDataAdapter sda = new SqlDataAdapter(query1, conn);
                    SqlCommandBuilder scb = new SqlCommandBuilder();
                    var ds = new DataSet();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    conn.Close();

                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //UPDATE CAR
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Click row to update");
            }
            else
            {
                var temp = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                try
                {
                    conn.Open();
                    string query = "UPDATE Table2 SET Car_model='" + textBox1.Text + "', Price_per_hour=" + textBox2.Text + " WHERE Car_model='" + textBox1.Text + "';";
                    SqlCommand sc = new SqlCommand(query, conn);
                    sc.ExecuteNonQuery();
                    MessageBox.Show("Success");
                    conn.Close();

                    conn.Open();
                    string query1 = "SELECT Car_model AS 'Car Model', Price_per_hour AS 'Price per hour' FROM Table2";
                    SqlDataAdapter sda = new SqlDataAdapter(query1, conn);
                    SqlCommandBuilder scb = new SqlCommandBuilder();
                    var ds = new DataSet();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    conn.Close();

                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e) //REFRESH SEARCH FIELD
        {
            conn.Open();
            string query1 = "SELECT Car_model AS 'Car Model', Price_per_hour AS 'Price per hour' FROM Table2";
            SqlDataAdapter sda = new SqlDataAdapter(query1, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

            textBox3.Text = "";
        }

        private void button7_Click(object sender, EventArgs e) //SEARCH
        {
            conn.Open();
            string query1 = "SELECT Car_model AS 'Car Model', Price_per_hour AS 'Price per hour' FROM Table2 WHERE Car_model='" + textBox3.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query1, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }
