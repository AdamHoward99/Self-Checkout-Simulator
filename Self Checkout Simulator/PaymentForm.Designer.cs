namespace Self_Checkout_Simulator
{
    partial class PaymentForm
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
            this.btnPayByCash = new System.Windows.Forms.Button();
            this.btnPayByCard = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPayByCash
            // 
            this.btnPayByCash.Location = new System.Drawing.Point(30, 12);
            this.btnPayByCash.Name = "btnPayByCash";
            this.btnPayByCash.Size = new System.Drawing.Size(103, 71);
            this.btnPayByCash.TabIndex = 0;
            this.btnPayByCash.Text = "Pay By Cash";
            this.btnPayByCash.UseVisualStyleBackColor = true;
            this.btnPayByCash.Click += new System.EventHandler(this.btnPayByCash_Click);
            // 
            // btnPayByCard
            // 
            this.btnPayByCard.Location = new System.Drawing.Point(281, 12);
            this.btnPayByCard.Name = "btnPayByCard";
            this.btnPayByCard.Size = new System.Drawing.Size(103, 71);
            this.btnPayByCard.TabIndex = 1;
            this.btnPayByCard.Text = "Pay By Card";
            this.btnPayByCard.UseVisualStyleBackColor = true;
            this.btnPayByCard.Click += new System.EventHandler(this.btnPayByCard_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(131, 145);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(153, 41);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 226);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnPayByCard);
            this.Controls.Add(this.btnPayByCash);
            this.Name = "PaymentForm";
            this.Text = "PaymentForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPayByCash;
        private System.Windows.Forms.Button btnPayByCard;
        private System.Windows.Forms.Button btnConfirm;
    }
}