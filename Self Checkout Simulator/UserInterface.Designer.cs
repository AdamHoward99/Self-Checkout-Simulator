



namespace Self_Checkout_Simulator
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUserScansBarcodeProduct = new System.Windows.Forms.Button();
            this.lbBasket = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUserSelectsLooseProduct = new System.Windows.Forms.Button();
            this.btnUserPutsProductInBaggingAreaCorrect = new System.Windows.Forms.Button();
            this.btnUserWeighsLooseProduct = new System.Windows.Forms.Button();
            this.btnUserChooseToPay = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.lblScreen = new System.Windows.Forms.Label();
            this.btnUserPutsProductInBaggingAreaIncorrect = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBaggingAreaExpectedWeight = new System.Windows.Forms.Label();
            this.lblBaggingAreaCurrentWeight = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnAdminRemoveProduct = new System.Windows.Forms.Button();
            this.btnAdminOverridesWeight = new System.Windows.Forms.Button();
            this.btnScanClubcard = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblClubcardPoints = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUserScansBarcodeProduct
            // 
            this.btnUserScansBarcodeProduct.Enabled = false;
            this.btnUserScansBarcodeProduct.Location = new System.Drawing.Point(6, 91);
            this.btnUserScansBarcodeProduct.Name = "btnUserScansBarcodeProduct";
            this.btnUserScansBarcodeProduct.Size = new System.Drawing.Size(124, 41);
            this.btnUserScansBarcodeProduct.TabIndex = 0;
            this.btnUserScansBarcodeProduct.Text = "Scan a barcoded product";
            this.btnUserScansBarcodeProduct.UseVisualStyleBackColor = true;
            this.btnUserScansBarcodeProduct.Click += new System.EventHandler(this.UserScansProduct);
            // 
            // lbBasket
            // 
            this.lbBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBasket.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBasket.FormattingEnabled = true;
            this.lbBasket.Location = new System.Drawing.Point(6, 19);
            this.lbBasket.Name = "lbBasket";
            this.lbBasket.Size = new System.Drawing.Size(220, 264);
            this.lbBasket.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbBasket);
            this.groupBox1.Location = new System.Drawing.Point(532, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 296);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scanned Products";
            // 
            // btnUserSelectsLooseProduct
            // 
            this.btnUserSelectsLooseProduct.Enabled = false;
            this.btnUserSelectsLooseProduct.Location = new System.Drawing.Point(136, 91);
            this.btnUserSelectsLooseProduct.Name = "btnUserSelectsLooseProduct";
            this.btnUserSelectsLooseProduct.Size = new System.Drawing.Size(191, 41);
            this.btnUserSelectsLooseProduct.TabIndex = 0;
            this.btnUserSelectsLooseProduct.Text = "Select a loose product";
            this.btnUserSelectsLooseProduct.UseVisualStyleBackColor = true;
            this.btnUserSelectsLooseProduct.Click += new System.EventHandler(this.UserSelectsALooseProduct);
            // 
            // btnUserPutsProductInBaggingAreaCorrect
            // 
            this.btnUserPutsProductInBaggingAreaCorrect.Enabled = false;
            this.btnUserPutsProductInBaggingAreaCorrect.Location = new System.Drawing.Point(6, 185);
            this.btnUserPutsProductInBaggingAreaCorrect.Name = "btnUserPutsProductInBaggingAreaCorrect";
            this.btnUserPutsProductInBaggingAreaCorrect.Size = new System.Drawing.Size(157, 41);
            this.btnUserPutsProductInBaggingAreaCorrect.TabIndex = 0;
            this.btnUserPutsProductInBaggingAreaCorrect.Text = "Put product in bagging area (correct weight)";
            this.btnUserPutsProductInBaggingAreaCorrect.UseVisualStyleBackColor = true;
            this.btnUserPutsProductInBaggingAreaCorrect.Click += new System.EventHandler(this.UserPutsProductInBaggingAreaCorrect);
            // 
            // btnUserWeighsLooseProduct
            // 
            this.btnUserWeighsLooseProduct.Enabled = false;
            this.btnUserWeighsLooseProduct.Location = new System.Drawing.Point(136, 138);
            this.btnUserWeighsLooseProduct.Name = "btnUserWeighsLooseProduct";
            this.btnUserWeighsLooseProduct.Size = new System.Drawing.Size(191, 41);
            this.btnUserWeighsLooseProduct.TabIndex = 0;
            this.btnUserWeighsLooseProduct.Text = "Weigh loose product";
            this.btnUserWeighsLooseProduct.UseVisualStyleBackColor = true;
            this.btnUserWeighsLooseProduct.Click += new System.EventHandler(this.UserWeighsALooseProduct);
            // 
            // btnUserChooseToPay
            // 
            this.btnUserChooseToPay.Enabled = false;
            this.btnUserChooseToPay.Location = new System.Drawing.Point(6, 232);
            this.btnUserChooseToPay.Name = "btnUserChooseToPay";
            this.btnUserChooseToPay.Size = new System.Drawing.Size(321, 58);
            this.btnUserChooseToPay.TabIndex = 0;
            this.btnUserChooseToPay.Text = "Pay for products";
            this.btnUserChooseToPay.UseVisualStyleBackColor = true;
            this.btnUserChooseToPay.Click += new System.EventHandler(this.UserChoosesToPay);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemoveProduct);
            this.groupBox2.Controls.Add(this.lblScreen);
            this.groupBox2.Controls.Add(this.btnUserPutsProductInBaggingAreaIncorrect);
            this.groupBox2.Controls.Add(this.btnUserScansBarcodeProduct);
            this.groupBox2.Controls.Add(this.btnUserPutsProductInBaggingAreaCorrect);
            this.groupBox2.Controls.Add(this.btnUserWeighsLooseProduct);
            this.groupBox2.Controls.Add(this.btnUserChooseToPay);
            this.groupBox2.Controls.Add(this.btnUserSelectsLooseProduct);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 296);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Simulate a Customer";
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Enabled = false;
            this.btnRemoveProduct.Location = new System.Drawing.Point(6, 139);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(124, 40);
            this.btnRemoveProduct.TabIndex = 2;
            this.btnRemoveProduct.Text = "Remove Product";
            this.btnRemoveProduct.UseVisualStyleBackColor = true;
            this.btnRemoveProduct.Click += new System.EventHandler(this.UserWantsToRemoveItem);
            // 
            // lblScreen
            // 
            this.lblScreen.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblScreen.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblScreen.Location = new System.Drawing.Point(6, 19);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(321, 61);
            this.lblScreen.TabIndex = 1;
            this.lblScreen.Text = "[SCREEN SIMULATION]";
            this.lblScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUserPutsProductInBaggingAreaIncorrect
            // 
            this.btnUserPutsProductInBaggingAreaIncorrect.Enabled = false;
            this.btnUserPutsProductInBaggingAreaIncorrect.Location = new System.Drawing.Point(169, 185);
            this.btnUserPutsProductInBaggingAreaIncorrect.Name = "btnUserPutsProductInBaggingAreaIncorrect";
            this.btnUserPutsProductInBaggingAreaIncorrect.Size = new System.Drawing.Size(157, 41);
            this.btnUserPutsProductInBaggingAreaIncorrect.TabIndex = 1;
            this.btnUserPutsProductInBaggingAreaIncorrect.Text = "Put product in bagging area (incorrect weight)";
            this.btnUserPutsProductInBaggingAreaIncorrect.UseVisualStyleBackColor = true;
            this.btnUserPutsProductInBaggingAreaIncorrect.Click += new System.EventHandler(this.UserPutsProductInBaggingAreaIncorrect);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(351, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(170, 154);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Internal Data";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblTotalPrice);
            this.groupBox6.Location = new System.Drawing.Point(6, 113);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(158, 35);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Total Price";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(6, 16);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(83, 13);
            this.lblTotalPrice.TabIndex = 0;
            this.lblTotalPrice.Text = "[TOTAL PRICE]";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.lblBaggingAreaExpectedWeight);
            this.groupBox4.Controls.Add(this.lblBaggingAreaCurrentWeight);
            this.groupBox4.Location = new System.Drawing.Point(6, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(158, 88);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bagging Area";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Current Weight";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expected Weight";
            // 
            // lblBaggingAreaExpectedWeight
            // 
            this.lblBaggingAreaExpectedWeight.AutoSize = true;
            this.lblBaggingAreaExpectedWeight.Location = new System.Drawing.Point(6, 29);
            this.lblBaggingAreaExpectedWeight.Name = "lblBaggingAreaExpectedWeight";
            this.lblBaggingAreaExpectedWeight.Size = new System.Drawing.Size(117, 13);
            this.lblBaggingAreaExpectedWeight.TabIndex = 0;
            this.lblBaggingAreaExpectedWeight.Text = "[EXPECTED WEIGHT]";
            // 
            // lblBaggingAreaCurrentWeight
            // 
            this.lblBaggingAreaCurrentWeight.AutoSize = true;
            this.lblBaggingAreaCurrentWeight.Location = new System.Drawing.Point(6, 61);
            this.lblBaggingAreaCurrentWeight.Name = "lblBaggingAreaCurrentWeight";
            this.lblBaggingAreaCurrentWeight.Size = new System.Drawing.Size(113, 13);
            this.lblBaggingAreaCurrentWeight.TabIndex = 0;
            this.lblBaggingAreaCurrentWeight.Text = "[CURRENT WEIGHT]";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnAdminRemoveProduct);
            this.groupBox5.Controls.Add(this.btnAdminOverridesWeight);
            this.groupBox5.Location = new System.Drawing.Point(351, 172);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(170, 136);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Admin Controls";
            // 
            // btnAdminRemoveProduct
            // 
            this.btnAdminRemoveProduct.Enabled = false;
            this.btnAdminRemoveProduct.Location = new System.Drawing.Point(7, 72);
            this.btnAdminRemoveProduct.Name = "btnAdminRemoveProduct";
            this.btnAdminRemoveProduct.Size = new System.Drawing.Size(147, 46);
            this.btnAdminRemoveProduct.TabIndex = 3;
            this.btnAdminRemoveProduct.Text = "Confirm Remove";
            this.btnAdminRemoveProduct.UseVisualStyleBackColor = true;
            this.btnAdminRemoveProduct.Click += new System.EventHandler(this.btnAdminRemoveProduct_Click);
            // 
            // btnAdminOverridesWeight
            // 
            this.btnAdminOverridesWeight.Enabled = false;
            this.btnAdminOverridesWeight.Location = new System.Drawing.Point(6, 19);
            this.btnAdminOverridesWeight.Name = "btnAdminOverridesWeight";
            this.btnAdminOverridesWeight.Size = new System.Drawing.Size(148, 47);
            this.btnAdminOverridesWeight.TabIndex = 2;
            this.btnAdminOverridesWeight.Text = "Override weight";
            this.btnAdminOverridesWeight.UseVisualStyleBackColor = true;
            this.btnAdminOverridesWeight.Click += new System.EventHandler(this.AdminOverridesWeight);
            // 
            // btnScanClubcard
            // 
            this.btnScanClubcard.Enabled = false;
            this.btnScanClubcard.Location = new System.Drawing.Point(771, 12);
            this.btnScanClubcard.Name = "btnScanClubcard";
            this.btnScanClubcard.Size = new System.Drawing.Size(89, 254);
            this.btnScanClubcard.TabIndex = 6;
            this.btnScanClubcard.Text = "Swipe Clubcard";
            this.btnScanClubcard.UseVisualStyleBackColor = true;
            this.btnScanClubcard.Click += new System.EventHandler(this.btnScanClubcard_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblClubcardPoints);
            this.groupBox7.Location = new System.Drawing.Point(771, 272);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(89, 36);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Points";
            // 
            // lblClubcardPoints
            // 
            this.lblClubcardPoints.AutoSize = true;
            this.lblClubcardPoints.Location = new System.Drawing.Point(6, 16);
            this.lblClubcardPoints.Name = "lblClubcardPoints";
            this.lblClubcardPoints.Size = new System.Drawing.Size(53, 13);
            this.lblClubcardPoints.TabIndex = 1;
            this.lblClubcardPoints.Text = "[POINTS]";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 319);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnScanClubcard);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Self Checkout Simulator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUserScansBarcodeProduct;
        private System.Windows.Forms.ListBox lbBasket;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUserSelectsLooseProduct;
        private System.Windows.Forms.Button btnUserPutsProductInBaggingAreaCorrect;
        private System.Windows.Forms.Button btnUserWeighsLooseProduct;
        private System.Windows.Forms.Button btnUserChooseToPay;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblBaggingAreaExpectedWeight;
        private System.Windows.Forms.Label lblBaggingAreaCurrentWeight;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUserPutsProductInBaggingAreaIncorrect;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnAdminOverridesWeight;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.Button btnAdminRemoveProduct;
        private System.Windows.Forms.Button btnScanClubcard;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lblClubcardPoints;
    }
}

