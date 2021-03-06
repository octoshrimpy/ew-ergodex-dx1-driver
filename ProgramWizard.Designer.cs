﻿namespace DX1Utility
{
    partial class ProgramWizard
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
            this.label1 = new System.Windows.Forms.Label();
            this.T_DXKey = new System.Windows.Forms.TextBox();
            this.B_OK = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Back = new System.Windows.Forms.Button();
            this.B_Next = new System.Windows.Forms.Button();
            this.TB_Wizard = new DX1Utility.WizardPages();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.R_Toggle = new System.Windows.Forms.RadioButton();
            this.R_Special = new System.Windows.Forms.RadioButton();
            this.R_Macro = new System.Windows.Forms.RadioButton();
            this.R_Multi = new System.Windows.Forms.RadioButton();
            this.R_Single = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.T_Key = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.L_MultiKey = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.MacroList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.RB_False = new System.Windows.Forms.RadioButton();
            this.RB_True = new System.Windows.Forms.RadioButton();
            this.G_Special = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.T_Description = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.T_Conf_Actual = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.T_Conf_Desc = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.T_Conf_Type = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.T_TKey = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.TB_Wizard.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.tabPage12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.G_Special)).BeginInit();
            this.tabPage13.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Assign Key";
            // 
            // T_DXKey
            // 
            this.T_DXKey.BackColor = System.Drawing.SystemColors.Control;
            this.T_DXKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.T_DXKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T_DXKey.Location = new System.Drawing.Point(115, 6);
            this.T_DXKey.Name = "T_DXKey";
            this.T_DXKey.Size = new System.Drawing.Size(36, 22);
            this.T_DXKey.TabIndex = 50;
            this.T_DXKey.TabStop = false;
            // 
            // B_OK
            // 
            this.B_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.B_OK.Enabled = false;
            this.B_OK.Location = new System.Drawing.Point(312, 359);
            this.B_OK.Name = "B_OK";
            this.B_OK.Size = new System.Drawing.Size(75, 23);
            this.B_OK.TabIndex = 3;
            this.B_OK.Text = "Finish";
            this.B_OK.UseVisualStyleBackColor = true;
            this.B_OK.Click += new System.EventHandler(this.B_OK_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.B_Cancel.Location = new System.Drawing.Point(231, 359);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(75, 23);
            this.B_Cancel.TabIndex = 4;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            // 
            // B_Back
            // 
            this.B_Back.Enabled = false;
            this.B_Back.Location = new System.Drawing.Point(393, 359);
            this.B_Back.Name = "B_Back";
            this.B_Back.Size = new System.Drawing.Size(75, 23);
            this.B_Back.TabIndex = 5;
            this.B_Back.Text = "Back";
            this.B_Back.UseVisualStyleBackColor = true;
            this.B_Back.Click += new System.EventHandler(this.B_Back_Click);
            // 
            // B_Next
            // 
            this.B_Next.Location = new System.Drawing.Point(474, 359);
            this.B_Next.Name = "B_Next";
            this.B_Next.Size = new System.Drawing.Size(75, 23);
            this.B_Next.TabIndex = 6;
            this.B_Next.Text = "Next";
            this.B_Next.UseVisualStyleBackColor = true;
            this.B_Next.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TB_Wizard
            // 
            this.TB_Wizard.Controls.Add(this.tabPage8);
            this.TB_Wizard.Controls.Add(this.tabPage9);
            this.TB_Wizard.Controls.Add(this.tabPage10);
            this.TB_Wizard.Controls.Add(this.tabPage11);
            this.TB_Wizard.Controls.Add(this.tabPage12);
            this.TB_Wizard.Controls.Add(this.tabPage13);
            this.TB_Wizard.Controls.Add(this.tabPage14);
            this.TB_Wizard.Controls.Add(this.tabPage1);
            this.TB_Wizard.Location = new System.Drawing.Point(12, 34);
            this.TB_Wizard.Name = "TB_Wizard";
            this.TB_Wizard.SelectedIndex = 0;
            this.TB_Wizard.Size = new System.Drawing.Size(537, 319);
            this.TB_Wizard.TabIndex = 7;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.R_Toggle);
            this.tabPage8.Controls.Add(this.R_Special);
            this.tabPage8.Controls.Add(this.R_Macro);
            this.tabPage8.Controls.Add(this.R_Multi);
            this.tabPage8.Controls.Add(this.R_Single);
            this.tabPage8.Controls.Add(this.label2);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(529, 293);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "Type";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // R_Toggle
            // 
            this.R_Toggle.AutoSize = true;
            this.R_Toggle.Location = new System.Drawing.Point(24, 146);
            this.R_Toggle.Name = "R_Toggle";
            this.R_Toggle.Size = new System.Drawing.Size(79, 17);
            this.R_Toggle.TabIndex = 13;
            this.R_Toggle.Text = "Toggle Key";
            this.R_Toggle.UseVisualStyleBackColor = true;
            // 
            // R_Special
            // 
            this.R_Special.AutoSize = true;
            this.R_Special.Location = new System.Drawing.Point(24, 123);
            this.R_Special.Name = "R_Special";
            this.R_Special.Size = new System.Drawing.Size(81, 17);
            this.R_Special.TabIndex = 12;
            this.R_Special.Text = "Special Key";
            this.R_Special.UseVisualStyleBackColor = true;
            // 
            // R_Macro
            // 
            this.R_Macro.AutoSize = true;
            this.R_Macro.Location = new System.Drawing.Point(24, 100);
            this.R_Macro.Name = "R_Macro";
            this.R_Macro.Size = new System.Drawing.Size(102, 17);
            this.R_Macro.TabIndex = 11;
            this.R_Macro.Text = "Macro Playback";
            this.R_Macro.UseVisualStyleBackColor = true;
            // 
            // R_Multi
            // 
            this.R_Multi.AutoSize = true;
            this.R_Multi.Location = new System.Drawing.Point(24, 77);
            this.R_Multi.Name = "R_Multi";
            this.R_Multi.Size = new System.Drawing.Size(61, 17);
            this.R_Multi.TabIndex = 10;
            this.R_Multi.Text = "MiltiKey";
            this.R_Multi.UseVisualStyleBackColor = true;
            // 
            // R_Single
            // 
            this.R_Single.AutoSize = true;
            this.R_Single.Checked = true;
            this.R_Single.Location = new System.Drawing.Point(24, 54);
            this.R_Single.Name = "R_Single";
            this.R_Single.Size = new System.Drawing.Size(75, 17);
            this.R_Single.TabIndex = 9;
            this.R_Single.TabStop = true;
            this.R_Single.Text = "Single Key";
            this.R_Single.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select Type";
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.label10);
            this.tabPage9.Controls.Add(this.T_Key);
            this.tabPage9.Controls.Add(this.label9);
            this.tabPage9.Controls.Add(this.label3);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(529, 293);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "SingleKey";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(66, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Pressed Key";
            // 
            // T_Key
            // 
            this.T_Key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.T_Key.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T_Key.Location = new System.Drawing.Point(10, 61);
            this.T_Key.Name = "T_Key";
            this.T_Key.Size = new System.Drawing.Size(184, 44);
            this.T_Key.TabIndex = 11;
            this.T_Key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(390, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Press the Key you want to be programmed or select a key from the list on the righ" +
    "t";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Single Key Assignment";
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.label18);
            this.tabPage10.Controls.Add(this.label17);
            this.tabPage10.Controls.Add(this.L_MultiKey);
            this.tabPage10.Controls.Add(this.label4);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(529, 293);
            this.tabPage10.TabIndex = 2;
            this.tabPage10.Text = "MultiKey";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(75, 168);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(240, 25);
            this.label18.TabIndex = 13;
            this.label18.Text = "Not Implemented Yet!!!!";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(7, 33);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(286, 13);
            this.label17.TabIndex = 12;
            this.label17.Text = "Press the Keys you want to be a part of the MultiKey Macro";
            // 
            // L_MultiKey
            // 
            this.L_MultiKey.FormattingEnabled = true;
            this.L_MultiKey.Location = new System.Drawing.Point(10, 49);
            this.L_MultiKey.Name = "L_MultiKey";
            this.L_MultiKey.Size = new System.Drawing.Size(148, 95);
            this.L_MultiKey.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(6, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "MultiKey Macro";
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.label15);
            this.tabPage11.Controls.Add(this.MacroList);
            this.tabPage11.Controls.Add(this.label5);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(529, 293);
            this.tabPage11.TabIndex = 3;
            this.tabPage11.Text = "Macro";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(7, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(253, 13);
            this.label15.TabIndex = 11;
            this.label15.Text = "Select the Macro you want to use from the list below";
            // 
            // MacroList
            // 
            this.MacroList.FormattingEnabled = true;
            this.MacroList.Location = new System.Drawing.Point(10, 49);
            this.MacroList.Name = "MacroList";
            this.MacroList.Size = new System.Drawing.Size(148, 238);
            this.MacroList.TabIndex = 10;
            this.MacroList.SelectedIndexChanged += new System.EventHandler(this.MacroList_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(6, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "User Macro";
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.RB_False);
            this.tabPage12.Controls.Add(this.RB_True);
            this.tabPage12.Controls.Add(this.G_Special);
            this.tabPage12.Controls.Add(this.label16);
            this.tabPage12.Controls.Add(this.label6);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Size = new System.Drawing.Size(529, 293);
            this.tabPage12.TabIndex = 4;
            this.tabPage12.Text = "Special";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // RB_False
            // 
            this.RB_False.AutoSize = true;
            this.RB_False.Location = new System.Drawing.Point(215, 72);
            this.RB_False.Name = "RB_False";
            this.RB_False.Size = new System.Drawing.Size(50, 17);
            this.RB_False.TabIndex = 18;
            this.RB_False.Text = "False";
            this.RB_False.UseVisualStyleBackColor = true;
            this.RB_False.Visible = false;
            // 
            // RB_True
            // 
            this.RB_True.AutoSize = true;
            this.RB_True.Checked = true;
            this.RB_True.Location = new System.Drawing.Point(215, 49);
            this.RB_True.Name = "RB_True";
            this.RB_True.Size = new System.Drawing.Size(47, 17);
            this.RB_True.TabIndex = 17;
            this.RB_True.TabStop = true;
            this.RB_True.Text = "True";
            this.RB_True.UseVisualStyleBackColor = true;
            this.RB_True.Visible = false;
            // 
            // G_Special
            // 
            this.G_Special.AllowUserToAddRows = false;
            this.G_Special.AllowUserToDeleteRows = false;
            this.G_Special.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.G_Special.Location = new System.Drawing.Point(10, 49);
            this.G_Special.MultiSelect = false;
            this.G_Special.Name = "G_Special";
            this.G_Special.RowHeadersVisible = false;
            this.G_Special.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.G_Special.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.G_Special.Size = new System.Drawing.Size(181, 241);
            this.G_Special.TabIndex = 16;
            this.G_Special.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.G_Special_CellMouseDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(7, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(184, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "Select a Special function from the list:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(6, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Special Functions";
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.label11);
            this.tabPage13.Controls.Add(this.T_Description);
            this.tabPage13.Controls.Add(this.label7);
            this.tabPage13.Location = new System.Drawing.Point(4, 22);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Size = new System.Drawing.Size(529, 293);
            this.tabPage13.TabIndex = 5;
            this.tabPage13.Text = "Description";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(182, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Type a Name of the programmed key";
            // 
            // T_Description
            // 
            this.T_Description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.T_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T_Description.Location = new System.Drawing.Point(10, 50);
            this.T_Description.Name = "T_Description";
            this.T_Description.Size = new System.Drawing.Size(308, 44);
            this.T_Description.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(6, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Description";
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.T_Conf_Actual);
            this.tabPage14.Controls.Add(this.label14);
            this.tabPage14.Controls.Add(this.T_Conf_Desc);
            this.tabPage14.Controls.Add(this.label13);
            this.tabPage14.Controls.Add(this.T_Conf_Type);
            this.tabPage14.Controls.Add(this.label12);
            this.tabPage14.Controls.Add(this.label8);
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Size = new System.Drawing.Size(529, 293);
            this.tabPage14.TabIndex = 6;
            this.tabPage14.Text = "Confirm";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // T_Conf_Actual
            // 
            this.T_Conf_Actual.BackColor = System.Drawing.SystemColors.Control;
            this.T_Conf_Actual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.T_Conf_Actual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T_Conf_Actual.Location = new System.Drawing.Point(76, 59);
            this.T_Conf_Actual.Name = "T_Conf_Actual";
            this.T_Conf_Actual.Size = new System.Drawing.Size(123, 20);
            this.T_Conf_Actual.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Actual Key:";
            // 
            // T_Conf_Desc
            // 
            this.T_Conf_Desc.BackColor = System.Drawing.SystemColors.Window;
            this.T_Conf_Desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.T_Conf_Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T_Conf_Desc.Location = new System.Drawing.Point(76, 85);
            this.T_Conf_Desc.Name = "T_Conf_Desc";
            this.T_Conf_Desc.Size = new System.Drawing.Size(171, 20);
            this.T_Conf_Desc.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Description:";
            // 
            // T_Conf_Type
            // 
            this.T_Conf_Type.BackColor = System.Drawing.SystemColors.Control;
            this.T_Conf_Type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.T_Conf_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T_Conf_Type.Location = new System.Drawing.Point(76, 33);
            this.T_Conf_Type.Name = "T_Conf_Type";
            this.T_Conf_Type.Size = new System.Drawing.Size(123, 20);
            this.T_Conf_Type.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Key Type:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(6, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Confirmation";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.T_TKey);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(529, 293);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "Toggle";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 166);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(377, 13);
            this.label23.TabIndex = 16;
            this.label23.Text = "only the affect will be visible.   It is advised to only use modifier keys as Tog" +
    "gle.";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(7, 153);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(406, 13);
            this.label22.TabIndex = 15;
            this.label22.Text = "Warning, there will be no visual or other indication a key is currently toggled o" +
    "n or off,";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(66, 108);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(66, 13);
            this.label21.TabIndex = 14;
            this.label21.Text = "Pressed Key";
            // 
            // T_TKey
            // 
            this.T_TKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.T_TKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T_TKey.Location = new System.Drawing.Point(10, 61);
            this.T_TKey.Name = "T_TKey";
            this.T_TKey.Size = new System.Drawing.Size(184, 44);
            this.T_TKey.TabIndex = 13;
            this.T_TKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(7, 33);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(183, 13);
            this.label20.TabIndex = 11;
            this.label20.Text = "Press the Key you want to be toggled";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label19.Location = new System.Drawing.Point(6, 3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(196, 20);
            this.label19.TabIndex = 10;
            this.label19.Text = "Toggle Key Assignment";
            // 
            // ProgramWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 394);
            this.ControlBox = false;
            this.Controls.Add(this.TB_Wizard);
            this.Controls.Add(this.B_Next);
            this.Controls.Add(this.B_Back);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_OK);
            this.Controls.Add(this.T_DXKey);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgramWizard";
            this.Text = "ProgramWizard";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProgramWizard_KeyDown);
            this.TB_Wizard.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            this.tabPage12.ResumeLayout(false);
            this.tabPage12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.G_Special)).EndInit();
            this.tabPage13.ResumeLayout(false);
            this.tabPage13.PerformLayout();
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox T_DXKey;
        private System.Windows.Forms.Button B_OK;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Back;
        private System.Windows.Forms.Button B_Next;
        private WizardPages TB_Wizard;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton R_Multi;
        private System.Windows.Forms.RadioButton R_Single;
        private System.Windows.Forms.RadioButton R_Special;
        private System.Windows.Forms.RadioButton R_Macro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox T_Key;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox T_Description;
        private System.Windows.Forms.TextBox T_Conf_Desc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox T_Conf_Type;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox T_Conf_Actual;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox MacroList;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView G_Special;
        private System.Windows.Forms.RadioButton RB_False;
        private System.Windows.Forms.RadioButton RB_True;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ListBox L_MultiKey;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RadioButton R_Toggle;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox T_TKey;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
    }
}