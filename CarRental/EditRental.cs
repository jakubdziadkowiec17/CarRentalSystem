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
using System.Windows.Input;

namespace CarRental
{
    public partial class EditRental : Form
    {
        public EditRental()
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
        private void EditRental_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT Id, Name, Surname, PESEL, Phone_number AS 'Phone Number', Email AS 'E-mail', Address, Car AS 'Car Model', Hours FROM Table0 WHERE Payment_Date IS NULL";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

            conn.Open();
            SqlCommand sc = new SqlCommand("SELECT Car_model FROM Table2", conn);
            SqlDataReader sdr;
            sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Car_model", typeof(string));
            dt.Load(sdr);
            comboBox1.ValueMember = "Car_model";
            comboBox1.DataSource = dt;
            conn.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //DATA BASE FIELD
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e) //REFRESH FIELDS
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e) //DELETE
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Click row to delete");
            }
            else
            {
                var temp = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Table0 WHERE Id=" + temp + ";";
                    SqlCommand sc = new SqlCommand(query, conn);
                    sc.ExecuteNonQuery();
                    MessageBox.Show("Success");
                    conn.Close();

                    conn.Open();
                    string query1 = "SELECT Id, Name, Surname, PESEL, Phone_number AS 'Phone Number', Email AS 'E-mail', Address, Car AS 'Car Model', Hours FROM Table0 WHERE Payment_Date IS NULL";
                    SqlDataAdapter sda = new SqlDataAdapter(query1, conn);
                    SqlCommandBuilder scb = new SqlCommandBuilder();
                    var ds = new DataSet();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    conn.Close();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    comboBox1.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //UPDATE
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Click row to update");
            }
            else
            {
                var temp = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                try
                {
                    conn.Open();
                    string query = "UPDATE Table0 SET Name='" + textBox1.Text + "', Surname='" + textBox2.Text + "', PESEL=" + textBox3.Text + ", Phone_number=" + textBox4.Text + ", Email='" + textBox5.Text + "', Address='" + textBox6.Text + "', Car='" + comboBox1.Text + "', Hours=" + textBox7.Text + " WHERE Id=" + temp + ";";
                    SqlCommand sc = new SqlCommand(query, conn);
                    sc.ExecuteNonQuery();
                    MessageBox.Show("Success");
                    conn.Close();

                    conn.Open();
                    string query1 = "SELECT Id, Name, Surname, PESEL, Phone_number AS 'Phone Number', Email AS 'E-mail', Address, Car AS 'Car Model', Hours FROM Table0 WHERE Payment_Date IS NULL";
                    SqlDataAdapter sda = new SqlDataAdapter(query1, conn);
                    SqlCommandBuilder scb = new SqlCommandBuilder();
                    var ds = new DataSet();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    conn.Close();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    comboBox1.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void button5_Click(object sender, EventArgs e) //CREATE
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Missing field");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Table0 " + "(Name, Surname, PESEL, Phone_number, Email, Address, Car, Hours, Price) VALUES" + "('" + textBox1.Text + "','" + textBox2.Text + "'," + textBox3.Text + "," + textBox4.Text + ",'" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "'," + textBox7.Text + "," + 0 + ")";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success");
                    conn.Close();

                    conn.Open();
                    string query1 = "SELECT Id, Name, Surname, PESEL, Phone_number AS 'Phone Number', Email AS 'E-mail', Address, Car AS 'Car Model', Hours FROM Table0 WHERE Payment_Date IS NULL";
                    SqlDataAdapter sda = new SqlDataAdapter(query1, conn);
                    SqlCommandBuilder scb = new SqlCommandBuilder();
                    var ds = new DataSet();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    conn.Close();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    comboBox1.Text = "";
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
            string query1 = "SELECT Id, Name, Surname, PESEL, Phone_number AS 'Phone Number', Email AS 'E-mail', Address, Car AS 'Car Model', Hours FROM Table0 WHERE Payment_Date IS NULL";
            SqlDataAdapter sda = new SqlDataAdapter(query1, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

            textBox8.Text = "";
        }

        private void button7_Click(object sender, EventArgs e) //SEARCH
        {
            conn.Open();
            string query1 = "SELECT Id, Name, Surname, PESEL, Phone_number AS 'Phone Number', Email AS 'E-mail', Address, Car AS 'Car Model', Hours FROM Table0 WHERE Surname='" + textBox8.Text + "' AND Payment_Date IS NULL";
            SqlDataAdapter sda = new SqlDataAdapter(query1, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
    }
}
