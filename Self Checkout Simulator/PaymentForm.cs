using System;
using System.Windows.Forms;

namespace Self_Checkout_Simulator
{
    public partial class PaymentForm : Form
    {
        CardInformationForm pinForm;

        public PaymentForm()
        {
            InitializeComponent();
        }

        private void CreatePinForm()
        {
            pinForm = new CardInformationForm();
            pinForm.ShowDialog();
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
            CreatePinForm();
        }
    }
}
