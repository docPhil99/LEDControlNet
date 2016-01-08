namespace LEDControlNet
{
    partial class Form1
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
            this.ledUserControl11 = new LEDControlNet.LEDUserControl1();
            this.SuspendLayout();
            // 
            // ledUserControl11
            // 
            this.ledUserControl11.Location = new System.Drawing.Point(57, 68);
            this.ledUserControl11.Name = "ledUserControl11";
            this.ledUserControl11.Size = new System.Drawing.Size(421, 142);
            this.ledUserControl11.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 262);
            this.Controls.Add(this.ledUserControl11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private LEDUserControl1 ledUserControl11;
    }
}

