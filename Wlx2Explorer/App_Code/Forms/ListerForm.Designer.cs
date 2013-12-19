namespace Wlx2Explorer.App_Code.Forms
{
    partial class ListerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListerForm));
            this.pnlLister = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlLister
            // 
            this.pnlLister.BackColor = System.Drawing.SystemColors.Control;
            this.pnlLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLister.Location = new System.Drawing.Point(0, 0);
            this.pnlLister.Name = "pnlLister";
            this.pnlLister.Size = new System.Drawing.Size(715, 603);
            this.pnlLister.TabIndex = 0;
            // 
            // ListerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(715, 603);
            this.Controls.Add(this.pnlLister);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListerForm";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Lister";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLister;
    }
}

