namespace GRY_Projekt
{
    partial class Waz
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
            this.components = new System.ComponentModel.Container();
            this.pictureBoxW = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxW)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxW
            // 
            this.pictureBoxW.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBoxW.Location = new System.Drawing.Point(12, 24);
            this.pictureBoxW.Name = "pictureBoxW";
            this.pictureBoxW.Size = new System.Drawing.Size(306, 256);
            this.pictureBoxW.TabIndex = 0;
            this.pictureBoxW.TabStop = false;
            this.pictureBoxW.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxW_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Punkty: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // Waz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 314);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxW);
            this.Name = "Waz";
            this.Text = "Waz";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Waz_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Waz_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxW)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
    }
}