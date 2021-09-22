using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    public partial class UserInterface : Form
    {
        // Attributes
        SelfCheckout selfCheckout;
        PaymentForm paymentForm;            //Enables the User interface to get variables used in the Payment form

        // Constructor

        public UserInterface()
        {
            InitializeComponent();

            // NOTE: This is where we set up all the objects,
            // and create the various relationships between them.

            paymentForm = new PaymentForm();
            selfCheckout = new SelfCheckout();
            UpdateDisplay();
        }

        // Operations

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
            // NOTE: We are pretending to put down an item with the wrong weight.
            // To simulate this we'll use a random number, here's one for you to use.
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
            // NOTE: We are pretending to weigh a banana or whatever here.
            // To simulate this we'll use a random number, here's one for you to use.
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
            PaymentForm f2 = new PaymentForm();             //Creates a new form
            f2.ShowDialog();                                //Opens the new form
            selfCheckout.UserPaid();                        //Clears the weight and products from the list
            UpdateDisplay();
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

        private void RemoveAndPayButtonsToggle(bool toggle)     //btnUserChooseToPay && btnRemoveProduct
        {
            btnUserChooseToPay.Enabled = toggle;
            btnRemoveProduct.Enabled = toggle;
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

                    lbBasket.Items.Add((selfCheckout.GetCurrentProduct().CalculatePrice() * 0.01D).ToString("c2") + " " + selfCheckout.GetCurrentProduct().GetName());
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

                    lbBasket.Items.Add((selfCheckout.GetCurrentProduct().CalculatePrice() * 0.01D).ToString("c2") + " " + selfCheckout.GetCurrentProduct().GetName());
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


            }

                //UI Labels
            lblBaggingAreaCurrentWeight.Text = selfCheckout.GetBaggingScale().Weight.ToString("n2");            //Outputs as doubles
            lblBaggingAreaExpectedWeight.Text = selfCheckout.GetBaggingScale().GetExpectedWeightWithDifference().ToString("n2");
            lblTotalPrice.Text = selfCheckout.GetTotal().ToString("c2");
            lblScreen.Text = UserPrompt;

            lblClubcardPoints.ResetText();
            //btnScanClubcard.Enabled = (selfCheckout.IsScaleWeightCorrect() && scannedProducts.HasItems() && !looseItemScale.IsEnabled() && !selfCheckout.CanRemove());

        }

        private void UserWantsToRemoveItem(object sender, EventArgs e)
        {
            selfCheckout.EnableAdminRemove();           //Enables the Admin button to remove the product
            selfCheckout.GetPromptForUser();            //Gets the correct prompt for the current situation
            UpdateDisplay(6);
        }

        private void btnAdminRemoveProduct_Click(object sender, EventArgs e)
        {
            selfCheckout.AdminRemoveProduct();          //Removes the last product from the list of products
            //selfCheckout.DisableAdminRemove();          //Disables the admin remove button        TODO ENABLED VAR MAY NOT BE NEEDED ANYMORE
            UpdateDisplay(7);
        }

        private void btnScanClubcard_Click(object sender, EventArgs e)
        {
            double points = selfCheckout.ClubcardWasSwiped();   
            lblClubcardPoints.Text = points.ToString(); //Updates the label which holds the amount of clubcard points
        }
    }
}