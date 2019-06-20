namespace Wlx2Explorer.Forms
{
    partial class SearchForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.lblSearchText = new System.Windows.Forms.Label();
            this.chbWholeWordsOnly = new System.Windows.Forms.CheckBox();
            this.chbCaseSensitive = new System.Windows.Forms.CheckBox();
            this.chbSearchBackwards = new System.Windows.Forms.CheckBox();
            this.chbSearchFromBeginning = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(208, 120);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.OkClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(289, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // txtSearchText
            // 
            this.txtSearchText.Location = new System.Drawing.Point(12, 31);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(354, 20);
            this.txtSearchText.TabIndex = 1;
            // 
            // lblSearchText
            // 
            this.lblSearchText.AutoSize = true;
            this.lblSearchText.Location = new System.Drawing.Point(9, 15);
            this.lblSearchText.Name = "lblSearchText";
            this.lblSearchText.Size = new System.Drawing.Size(56, 13);
            this.lblSearchText.TabIndex = 0;
            this.lblSearchText.Text = "Find what:";
            // 
            // chbWholeWordsOnly
            // 
            this.chbWholeWordsOnly.AutoSize = true;
            this.chbWholeWordsOnly.Location = new System.Drawing.Point(12, 67);
            this.chbWholeWordsOnly.Name = "chbWholeWordsOnly";
            this.chbWholeWordsOnly.Size = new System.Drawing.Size(110, 17);
            this.chbWholeWordsOnly.TabIndex = 2;
            this.chbWholeWordsOnly.Text = "Whole words only";
            this.chbWholeWordsOnly.UseVisualStyleBackColor = true;
            // 
            // chbCaseSensitive
            // 
            this.chbCaseSensitive.AutoSize = true;
            this.chbCaseSensitive.Location = new System.Drawing.Point(12, 90);
            this.chbCaseSensitive.Name = "chbCaseSensitive";
            this.chbCaseSensitive.Size = new System.Drawing.Size(94, 17);
            this.chbCaseSensitive.TabIndex = 3;
            this.chbCaseSensitive.Text = "Case sensitive";
            this.chbCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // chbSearchBackwards
            // 
            this.chbSearchBackwards.AutoSize = true;
            this.chbSearchBackwards.Location = new System.Drawing.Point(150, 90);
            this.chbSearchBackwards.Name = "chbSearchBackwards";
            this.chbSearchBackwards.Size = new System.Drawing.Size(115, 17);
            this.chbSearchBackwards.TabIndex = 5;
            this.chbSearchBackwards.Text = "Search backwards";
            this.chbSearchBackwards.UseVisualStyleBackColor = true;
            // 
            // chbSearchFromBeginning
            // 
            this.chbSearchFromBeginning.AutoSize = true;
            this.chbSearchFromBeginning.Location = new System.Drawing.Point(150, 67);
            this.chbSearchFromBeginning.Name = "chbSearchFromBeginning";
            this.chbSearchFromBeginning.Size = new System.Drawing.Size(150, 17);
            this.chbSearchFromBeginning.TabIndex = 4;
            this.chbSearchFromBeginning.Text = "Search from the beginning";
            this.chbSearchFromBeginning.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 155);
            this.Controls.Add(this.chbSearchFromBeginning);
            this.Controls.Add(this.chbSearchBackwards);
            this.Controls.Add(this.chbCaseSensitive);
            this.Controls.Add(this.chbWholeWordsOnly);
            this.Controls.Add(this.lblSearchText);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search text";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Label lblSearchText;
        private System.Windows.Forms.CheckBox chbWholeWordsOnly;
        private System.Windows.Forms.CheckBox chbCaseSensitive;
        private System.Windows.Forms.CheckBox chbSearchBackwards;
        private System.Windows.Forms.CheckBox chbSearchFromBeginning;
    }
}