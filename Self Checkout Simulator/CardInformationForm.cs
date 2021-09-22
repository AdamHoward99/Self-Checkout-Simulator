using System;
using System.Windows.Forms;

namespace Self_Checkout_Simulator
{
    public partial class CardInformationForm : Form
    {
        public CardInformationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pinTxt.TextLength == 4)
                Close();
            else
            {
                lblPin.Text = "Incorrect Pin";
                pinTxt.Text = "";
            }
        }

        private void pinTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
