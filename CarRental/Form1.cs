using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e) //EXIT
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e) //REFRESH FIELD
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e) //LOGIN
        {
            if (textBox1.Text == "Admin" && textBox2.Text == "Admin")
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Empty field!");
            }
            else
            {
                MessageBox.Show("Correct login or password");
            }
        }
    }
}
