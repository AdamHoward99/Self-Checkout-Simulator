namespace Self_Checkout_Simulator
{
    partial class CardInformationForm
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
            this.pinTxt = new System.Windows.Forms.TextBox();
            this.lblPin = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pinTxt
            // 
            this.pinTxt.Location = new System.Drawing.Point(68, 62);
            this.pinTxt.MaxLength = 4;
            this.pinTxt.Name = "pinTxt";
            this.pinTxt.Size = new System.Drawing.Size(119, 20);
            this.pinTxt.TabIndex = 0;
            this.pinTxt.UseSystemPasswordChar = true;
            this.pinTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pinTxt_KeyPress);
            // 
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.Location = new System.Drawing.Point(103, 36);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(50, 13);
            this.lblPin.TabIndex = 1;
            this.lblPin.Text = "Enter Pin";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CardInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 147);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPin);
            this.Controls.Add(this.pinTxt);
            this.Name = "CardInformationForm";
            this.Text = "CardInformationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pinTxt;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.Button button1;
    }
}