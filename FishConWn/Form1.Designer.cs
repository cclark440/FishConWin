﻿namespace FishConWn
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.customRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnJsonLogin = new System.Windows.Forms.Button();
            this.sS1 = new System.Windows.Forms.StatusStrip();
            this.sslResultCode = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssSecondPanel = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslSmallPrinter = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslLargePrinter = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbSalesOrder = new System.Windows.Forms.TextBox();
            this.lblSalesOrder = new System.Windows.Forms.Label();
            this.btnSalesOrder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOdbc = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.PD = new System.Windows.Forms.PrintDialog();
            this.PD2 = new System.Windows.Forms.PrintDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Skip = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MultiLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.sS1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(93, 26);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(634, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem1
            // 
            this.fIleToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.customRequest,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fIleToolStripMenuItem1.Name = "fIleToolStripMenuItem1";
            this.fIleToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem1.Text = "&File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem2.Text = "Clear &Grid";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // customRequest
            // 
            this.customRequest.Name = "customRequest";
            this.customRequest.Size = new System.Drawing.Size(161, 22);
            this.customRequest.Text = "Custom &Request";
            this.customRequest.Click += new System.EventHandler(this.customRequest_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem1.Text = "Show &Log";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // btnJsonLogin
            // 
            this.btnJsonLogin.Location = new System.Drawing.Point(349, 6);
            this.btnJsonLogin.Name = "btnJsonLogin";
            this.btnJsonLogin.Size = new System.Drawing.Size(75, 23);
            this.btnJsonLogin.TabIndex = 8;
            this.btnJsonLogin.Text = "Json Con";
            this.btnJsonLogin.UseVisualStyleBackColor = true;
            this.btnJsonLogin.Visible = false;
            this.btnJsonLogin.Click += new System.EventHandler(this.button4_Click);
            // 
            // sS1
            // 
            this.sS1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslResultCode,
            this.ssSecondPanel,
            this.sslSmallPrinter,
            this.sslLargePrinter});
            this.sS1.Location = new System.Drawing.Point(0, 362);
            this.sS1.Name = "sS1";
            this.sS1.ShowItemToolTips = true;
            this.sS1.Size = new System.Drawing.Size(634, 24);
            this.sS1.TabIndex = 9;
            this.sS1.Text = "statusStrip1";
            // 
            // sslResultCode
            // 
            this.sslResultCode.BackColor = System.Drawing.SystemColors.Control;
            this.sslResultCode.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sslResultCode.Name = "sslResultCode";
            this.sslResultCode.Size = new System.Drawing.Size(35, 19);
            this.sslResultCode.Text = "0000";
            // 
            // ssSecondPanel
            // 
            this.ssSecondPanel.Name = "ssSecondPanel";
            this.ssSecondPanel.Size = new System.Drawing.Size(0, 19);
            // 
            // sslSmallPrinter
            // 
            this.sslSmallPrinter.BackColor = System.Drawing.Color.Red;
            this.sslSmallPrinter.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sslSmallPrinter.Name = "sslSmallPrinter";
            this.sslSmallPrinter.Size = new System.Drawing.Size(112, 19);
            this.sslSmallPrinter.Text = "No printer Selected";
            // 
            // sslLargePrinter
            // 
            this.sslLargePrinter.BackColor = System.Drawing.Color.Red;
            this.sslLargePrinter.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sslLargePrinter.Name = "sslLargePrinter";
            this.sslLargePrinter.Size = new System.Drawing.Size(111, 19);
            this.sslLargePrinter.Text = "No printer selected";
            this.sslLargePrinter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sslLargePrinter_MouseUp);
            // 
            // tbSalesOrder
            // 
            this.tbSalesOrder.Location = new System.Drawing.Point(81, 6);
            this.tbSalesOrder.Name = "tbSalesOrder";
            this.tbSalesOrder.Size = new System.Drawing.Size(100, 20);
            this.tbSalesOrder.TabIndex = 10;
            // 
            // lblSalesOrder
            // 
            this.lblSalesOrder.AutoSize = true;
            this.lblSalesOrder.Location = new System.Drawing.Point(3, 10);
            this.lblSalesOrder.Name = "lblSalesOrder";
            this.lblSalesOrder.Size = new System.Drawing.Size(72, 13);
            this.lblSalesOrder.TabIndex = 11;
            this.lblSalesOrder.Text = "Sales Order #";
            // 
            // btnSalesOrder
            // 
            this.btnSalesOrder.Location = new System.Drawing.Point(523, 6);
            this.btnSalesOrder.Name = "btnSalesOrder";
            this.btnSalesOrder.Size = new System.Drawing.Size(75, 23);
            this.btnSalesOrder.TabIndex = 12;
            this.btnSalesOrder.Text = "Get SO API";
            this.btnSalesOrder.UseVisualStyleBackColor = true;
            this.btnSalesOrder.Visible = false;
            this.btnSalesOrder.Click += new System.EventHandler(this.btnSalesOrder_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOdbc);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnJsonLogin);
            this.panel1.Controls.Add(this.btnSalesOrder);
            this.panel1.Controls.Add(this.lblSalesOrder);
            this.panel1.Controls.Add(this.tbSalesOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 32);
            this.panel1.TabIndex = 13;
            // 
            // btnOdbc
            // 
            this.btnOdbc.Location = new System.Drawing.Point(187, 5);
            this.btnOdbc.Name = "btnOdbc";
            this.btnOdbc.Size = new System.Drawing.Size(75, 23);
            this.btnOdbc.TabIndex = 14;
            this.btnOdbc.Text = "Get SO";
            this.btnOdbc.UseVisualStyleBackColor = true;
            this.btnOdbc.Click += new System.EventHandler(this.btnOdbc_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(268, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.btnPrint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPrint_MouseUp);
            // 
            // PD
            // 
            this.PD.UseEXDialog = true;
            // 
            // PD2
            // 
            this.PD2.UseEXDialog = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Skip,
            this.Item,
            this.Qty,
            this.MultiLabel});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(634, 280);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseUp);
            // 
            // Skip
            // 
            this.Skip.HeaderText = "Skip";
            this.Skip.Name = "Skip";
            this.Skip.Width = 55;
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.Width = 335;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            // 
            // MultiLabel
            // 
            this.MultiLabel.HeaderText = "MultiLabel";
            this.MultiLabel.Name = "MultiLabel";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblCustomer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 20);
            this.panel2.TabIndex = 15;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.Blue;
            this.lblCustomer.Location = new System.Drawing.Point(3, 3);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(14, 13);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = ">";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 386);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sS1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fishbowl Label Connect";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.sS1.ResumeLayout(false);
            this.sS1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnJsonLogin;
        private System.Windows.Forms.StatusStrip sS1;
        private System.Windows.Forms.ToolStripStatusLabel sslResultCode;
        private System.Windows.Forms.ToolStripStatusLabel ssSecondPanel;
        private System.Windows.Forms.TextBox tbSalesOrder;
        private System.Windows.Forms.Label lblSalesOrder;
        private System.Windows.Forms.Button btnSalesOrder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripStatusLabel sslSmallPrinter;
        private System.Windows.Forms.ToolStripStatusLabel sslLargePrinter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ToolStripMenuItem customRequest;
        public System.Windows.Forms.PrintDialog PD;
        public System.Windows.Forms.PrintDialog PD2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Skip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn MultiLabel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Button btnOdbc;
    }
}

