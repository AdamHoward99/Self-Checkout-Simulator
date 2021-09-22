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
        SelfCheckout selfCheckout;
        BaggingAreaScale baggingAreaScale;

        public PaymentForm()
        {
            InitializeComponent();
            baggingAreaScale = new BaggingAreaScale();
            selfCheckout = new SelfCheckout();
        }



        private void btnPayByCash_Click(object sender, EventArgs e)
        {
            btnPayByCard.Enabled = false;           //Disables the Pay by card button as the customer chose to pay with cash
            btnPayByCash.Enabled = false;           // same as above but with cash, prevents user from pressing multiple times
            btnConfirm.Enabled = true;              //Once the cash has been entered, the customer can confirm the purchase 

        }

        private void btnPayByCard_Click(object sender, EventArgs e)
        {
            btnPayByCash.Enabled = false;
            btnPayByCard.Enabled = false;           //Disables the other method to pay as the customer chose to pay by card
            btnConfirm.Enabled = true;              //Enables the customer to confirm their purchase
            string input = Interaction.InputBox("Enter Your Pin", "Payment", "Enter Your Pin", -1, -1);         //Way for customer to input their pin
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Close();            //Closes the payment form
        }

    }
}
