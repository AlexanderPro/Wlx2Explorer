namespace Wlx2Explorer.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.miStartStop = new System.Windows.Forms.ToolStripMenuItem();
            this.miSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.miSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.iconSystemTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuSystemTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSystemTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // miStartStop
            // 
            this.miStartStop.Image = global::Wlx2Explorer.Properties.Resources.Start;
            this.miStartStop.Name = "miStartStop";
            this.miStartStop.Size = new System.Drawing.Size(125, 22);
            this.miStartStop.Text = "Stop";
            this.miStartStop.Click += new System.EventHandler(this.MenuItemStartStopClick);
            // 
            // miSettings
            // 
            this.miSettings.Name = "miSettings";
            this.miSettings.Size = new System.Drawing.Size(125, 22);
            this.miSettings.Text = "Settings...";
            this.miSettings.Click += new System.EventHandler(this.MenuItemSettingsClick);
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(125, 22);
            this.miAbout.Text = "About";
            this.miAbout.Click += new System.EventHandler(this.MenuItemAboutClick);
            // 
            // miSeparator
            // 
            this.miSeparator.Name = "miSeparator";
            this.miSeparator.Size = new System.Drawing.Size(122, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(125, 22);
            this.miExit.Text = "Exit";
            this.miExit.Click += new System.EventHandler(this.MenuItemExitClick);
            // 
            // iconSystemTray
            // 
            this.iconSystemTray.ContextMenuStrip = this.menuSystemTray;
            this.iconSystemTray.Icon = ((System.Drawing.Icon)(resources.GetObject("iconSystemTray.Icon")));
            this.iconSystemTray.Visible = true;
            // 
            // menuSystemTray
            // 
            this.menuSystemTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miStartStop,
            this.miSettings,
            this.miAbout,
            this.miSeparator,
            this.miExit});
            this.menuSystemTray.Name = "menuSystemTray";
            this.menuSystemTray.Size = new System.Drawing.Size(126, 98);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(32, 19);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 147);
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.Text = "Wlx2Explorer";
            this.menuSystemTray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon iconSystemTray;
        private System.Windows.Forms.ToolStripMenuItem miStartStop;
        private System.Windows.Forms.ToolStripMenuItem miSettings;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripSeparator miSeparator;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ContextMenuStrip menuSystemTray;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;

    }
}