﻿namespace DX1Utility
{
    partial class ProfileProperties
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
            this.T_ProfileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.T_ProfilePath = new System.Windows.Forms.TextBox();
            this.C_Enabled = new System.Windows.Forms.CheckBox();
            this.B_OK = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_FindPath = new System.Windows.Forms.Button();
            this.C_QuickMenu = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.C_Blank = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // T_ProfileName
            // 
            this.T_ProfileName.Location = new System.Drawing.Point(108, 15);
            this.T_ProfileName.Name = "T_ProfileName";
            this.T_ProfileName.Size = new System.Drawing.Size(254, 20);
            this.T_ProfileName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Profile Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Application Path:";
            // 
            // T_ProfilePath
            // 
            this.T_ProfilePath.Location = new System.Drawing.Point(108, 46);
            this.T_ProfilePath.Name = "T_ProfilePath";
            this.T_ProfilePath.Size = new System.Drawing.Size(254, 20);
            this.T_ProfilePath.TabIndex = 1;
            // 
            // C_Enabled
            // 
            this.C_Enabled.AutoSize = true;
            this.C_Enabled.Checked = true;
            this.C_Enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.C_Enabled.Location = new System.Drawing.Point(118, 3);
            this.C_Enabled.Name = "C_Enabled";
            this.C_Enabled.Size = new System.Drawing.Size(97, 17);
            this.C_Enabled.TabIndex = 3;
            this.C_Enabled.Text = "Profile Enabled";
            this.C_Enabled.UseVisualStyleBackColor = true;
            // 
            // B_OK
            // 
            this.B_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.B_OK.Location = new System.Drawing.Point(210, 163);
            this.B_OK.Name = "B_OK";
            this.B_OK.Size = new System.Drawing.Size(75, 23);
            this.B_OK.TabIndex = 10;
            this.B_OK.Text = "OK";
            this.B_OK.UseVisualStyleBackColor = true;
            this.B_OK.Click += new System.EventHandler(this.B_OK_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.B_Cancel.Location = new System.Drawing.Point(129, 163);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(75, 23);
            this.B_Cancel.TabIndex = 11;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            // 
            // B_FindPath
            // 
            this.B_FindPath.Location = new System.Drawing.Point(371, 44);
            this.B_FindPath.Name = "B_FindPath";
            this.B_FindPath.Size = new System.Drawing.Size(28, 23);
            this.B_FindPath.TabIndex = 2;
            this.B_FindPath.Text = "...";
            this.B_FindPath.UseVisualStyleBackColor = true;
            this.B_FindPath.Click += new System.EventHandler(this.B_FindPath_Click);
            // 
            // C_QuickMenu
            // 
            this.C_QuickMenu.AutoSize = true;
            this.C_QuickMenu.Location = new System.Drawing.Point(118, 26);
            this.C_QuickMenu.Name = "C_QuickMenu";
            this.C_QuickMenu.Size = new System.Drawing.Size(125, 17);
            this.C_QuickMenu.TabIndex = 4;
            this.C_QuickMenu.Text = "Show in Quick Menu";
            this.C_QuickMenu.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.C_Blank);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.C_QuickMenu);
            this.panel1.Controls.Add(this.C_Enabled);
            this.panel1.Location = new System.Drawing.Point(12, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 74);
            this.panel1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Profile Options";
            // 
            // C_Blank
            // 
            this.C_Blank.AutoSize = true;
            this.C_Blank.Location = new System.Drawing.Point(118, 49);
            this.C_Blank.Name = "C_Blank";
            this.C_Blank.Size = new System.Drawing.Size(119, 17);
            this.C_Blank.TabIndex = 5;
            this.C_Blank.Text = "Create Blank Profile";
            this.C_Blank.UseVisualStyleBackColor = true;
            // 
            // ProfileProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 193);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.B_FindPath);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_OK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.T_ProfilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.T_ProfileName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ProfileProperties";
            this.Text = "ProfileProperties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProfileProperties_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox T_ProfileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox T_ProfilePath;
        private System.Windows.Forms.CheckBox C_Enabled;
        private System.Windows.Forms.Button B_OK;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_FindPath;
        private System.Windows.Forms.CheckBox C_QuickMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox C_Blank;
        private System.Windows.Forms.Label label3;
    }
}