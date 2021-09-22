using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Self_Checkout_Simulator
{
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void btnPayByCash_Click(object sender, EventArgs e)
        {
            btnPayByCard.Enabled = false;           //Disables the Pay by card button as the customer chose to pay with cash
            btnPayByCash.Enabled = false;           // same as above but with cash, prevents user from pressing multiple times
        }

        private void btnPayByCard_Click(object sender, EventArgs e)
        {
            btnPayByCash.Enabled = false;
            btnPayByCard.Enabled = false;           //Disables the other method to pay as the customer chose to pay by card
            string input = Interaction.InputBox("Enter Your Pin", "Payment", "Enter Your Pin", -1, -1);         //Way for customer to input their pin
        }
    }
}
