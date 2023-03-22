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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) //EDIT ACTIVE RENTAL BUTTON
        {
            EditRental editRental = new EditRental();
            editRental.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e) //RENTAL LIST BUTTON
        {
            RentalList rentalList = new RentalList();
            rentalList.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e) //PAYMENTS BUTTON
        {
            Payments payments = new Payments();
            payments.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e) //CAR LIST BUTTON
        {
            CarList carList = new CarList();
            carList.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e) //LOGOUT
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e) //EXIT
        {
            Application.Exit();
        }
    }
}
