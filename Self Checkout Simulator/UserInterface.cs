using System;
using System.Windows.Forms;

namespace Self_Checkout_Simulator
{
    public partial class UserInterface : Form
    {
        // Attributes
        SelfCheckout selfCheckout;
        PaymentForm paymentForm;

        public UserInterface()
        {
            InitializeComponent();
            paymentForm = new PaymentForm();
            selfCheckout = new SelfCheckout();
            UpdateDisplay();
        }

        private void UserScansProduct(object sender, EventArgs e)
        {
            selfCheckout.BarcodeWasScanned(ProductsDAO.GetRandomProductBarcode());
            UpdateDisplay(1);
        }

        private void UserPutsProductInBaggingAreaCorrect(object sender, EventArgs e)
        {
            selfCheckout.BaggingAreaWeightChanged(true);        //Uses correct weight of item
            UpdateDisplay(4);
        }

        private void UserPutsProductInBaggingAreaIncorrect(object sender, EventArgs e)
        {
            selfCheckout.BaggingAreaWeightChanged(false);
            UpdateDisplay(5);
        }

        private void UserSelectsALooseProduct(object sender, EventArgs e)
        {
            selfCheckout.LooseProductSelected();
            UpdateDisplay(2);
        }

        private void UserWeighsALooseProduct(object sender, EventArgs e)
        {
            selfCheckout.LooseItemAreaWeightChanged(new Random().Next(20, 100));
            UpdateDisplay(3);
        }

        private void AdminOverridesWeight(object sender, EventArgs e)
        {
            selfCheckout.AdminWeightOverride();
            UpdateDisplay(8);
        }

        private void UserChoosesToPay(object sender, EventArgs e)
        {
            PaymentForm payForm = new PaymentForm();             //Creates a new form
            payForm.ShowDialog();                                //Opens the new form
            selfCheckout.UserPaid();                        //Clears the weight and products from the list
            UpdateDisplay(10);
        }

        private void ScanProductButtonsToggle(bool toggle)      //btnUserScansBarcodeProduct && btnUserSelectsLooseProduct
        {
            btnUserScansBarcodeProduct.Enabled = toggle;
            btnUserSelectsLooseProduct.Enabled = toggle;
        }

        private void BaggingAreaButtonsToggle(bool toggle)      //btnUserPutsProductInBaggingAreaCorrect && btnUserPutsProductInBaggingAreaIncorrect
        {
            btnUserPutsProductInBaggingAreaCorrect.Enabled = toggle;
            btnUserPutsProductInBaggingAreaIncorrect.Enabled = toggle;
        }

        private void RemoveAndPayButtonsToggle(bool toggle)     //btnUserChooseToPay && btnRemoveProduct && btnScanClubcard
        {
            btnUserChooseToPay.Enabled = toggle;
            btnRemoveProduct.Enabled = toggle;
            btnScanClubcard.Enabled = toggle;
        }

        void UpdateDisplay(int state = 0)
        {
            string UserPrompt = "";

            if(selfCheckout.ContainsProduct())
                RemoveAndPayButtonsToggle(true);

            switch (state)
            {
                case 0:     //Starting State
                    ScanProductButtonsToggle(true);
                    UserPrompt = "Scan an item";
                    break;

                case 1:     //Selected to scan a barcoded product
                    ScanProductButtonsToggle(false);
                    RemoveAndPayButtonsToggle(false);

                    BaggingAreaButtonsToggle(true);

                    lbBasket.Items.Add((selfCheckout.GetCurrentProduct().CalculatePrice() * 0.01D).ToString("c2") + " " + selfCheckout.GetCurrentProduct().Name);
                    UserPrompt = "Place the item in the bagging area";
                    break;

                case 2:     //Selected loose product
                    ScanProductButtonsToggle(false);
                    RemoveAndPayButtonsToggle(false);

                    btnUserWeighsLooseProduct.Enabled = true;
                    UserPrompt = "Place item on scale";
                    break;

                case 3:     //Weighs Loose product
                    btnUserWeighsLooseProduct.Enabled = false;
                    RemoveAndPayButtonsToggle(false);

                    BaggingAreaButtonsToggle(true);

                    lbBasket.Items.Add((selfCheckout.GetCurrentProduct().CalculatePrice() * 0.01D).ToString("c2") + " " + selfCheckout.GetCurrentProduct().Name);
                    UserPrompt = "Place the item in the bagging area";
                    break;

                case 4:     //Item is weighed correctly
                    BaggingAreaButtonsToggle(false);

                    ScanProductButtonsToggle(true);
                    RemoveAndPayButtonsToggle(true);
                    UserPrompt = "Scan an item or pay";
                    break;

                case 5:     //Item is weighed incorrectly
                    BaggingAreaButtonsToggle(false);
                    RemoveAndPayButtonsToggle(false);

                    btnAdminOverridesWeight.Enabled = true;
                    UserPrompt = "Please wait, assistant is on the way";
                    break;

                case 6:     //Customer wants to remove item
                    RemoveAndPayButtonsToggle(false);
                    ScanProductButtonsToggle(false);

                    btnAdminRemoveProduct.Enabled = true;
                    UserPrompt = "Please wait, assistant is on the way";
                    break;

                case 7:     //Admin confirms remove item query
                    btnAdminRemoveProduct.Enabled = false;

                    ScanProductButtonsToggle(true);

                    lbBasket.Items.RemoveAt(lbBasket.Items.Count - 1);
                    UserPrompt = "Scan an item";
                    break;

                case 8:     //Admin overrides weight
                    btnAdminOverridesWeight.Enabled = false;

                    ScanProductButtonsToggle(true);
                    UserPrompt = "Scan an item or pay";
                    break;

                case 9:     //Clubcard
                    ScanProductButtonsToggle(false);
                    RemoveAndPayButtonsToggle(false);

                    btnUserChooseToPay.Enabled = true;
                    UserPrompt = "Clubcard points have been saved, Click to pay";
                    break;

                case 10:    //Pay
                    RemoveAndPayButtonsToggle(false);

                    ScanProductButtonsToggle(true);
                    lbBasket.Items.Clear();
                    lblClubcardPoints.Text = "0";
                    UserPrompt = "Scan an item";
                    break;
            }

            //UI Labels
            lblBaggingAreaCurrentWeight.Text = selfCheckout.GetBaggingScale().Weight.ToString("n2");            //Outputs as doubles
            lblBaggingAreaExpectedWeight.Text = selfCheckout.GetBaggingScale().ExpectedWeight.ToString("n2");
            lblTotalPrice.Text = selfCheckout.GetTotal().ToString("c2");
            lblScreen.Text = UserPrompt;
        }

        private void UserWantsToRemoveItem(object sender, EventArgs e) => UpdateDisplay(6);

        private void btnScanClubcard_Click(object sender, EventArgs e)
        {
            lblClubcardPoints.Text = Math.Floor(selfCheckout.GetTotal()).ToString();
            UpdateDisplay(9);
        }

        private void btnAdminRemoveProduct_Click(object sender, EventArgs e)
        {
            selfCheckout.AdminRemoveProduct();          //Removes the last product from the list of products
            UpdateDisplay(7);
        }

    }
}