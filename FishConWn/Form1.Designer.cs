namespace FishConWn
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.cbFormat = new System.Windows.Forms.CheckBox();
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
            this.PD = new System.Windows.Forms.PrintDialog();
            this.PD2 = new System.Windows.Forms.PrintDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Skip = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MultiLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.sS1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 85);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(848, 126);
            this.textBox1.TabIndex = 0;
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
            this.menuStrip1.Size = new System.Drawing.Size(848, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem1
            // 
            this.fIleToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fIleToolStripMenuItem1.Name = "fIleToolStripMenuItem1";
            this.fIleToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem1.Text = "&File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Show &Log";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.Location = new System.Drawing.Point(689, 5);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(75, 23);
            this.btnSendRequest.TabIndex = 5;
            this.btnSendRequest.Text = "Request";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbFormat
            // 
            this.cbFormat.AutoSize = true;
            this.cbFormat.Location = new System.Drawing.Point(582, 8);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(101, 17);
            this.cbFormat.TabIndex = 7;
            this.cbFormat.Text = "Format Request";
            this.cbFormat.UseVisualStyleBackColor = true;
            // 
            // btnJsonLogin
            // 
            this.btnJsonLogin.Location = new System.Drawing.Point(770, 4);
            this.btnJsonLogin.Name = "btnJsonLogin";
            this.btnJsonLogin.Size = new System.Drawing.Size(75, 23);
            this.btnJsonLogin.TabIndex = 8;
            this.btnJsonLogin.Text = "Json Con";
            this.btnJsonLogin.UseVisualStyleBackColor = true;
            this.btnJsonLogin.Click += new System.EventHandler(this.button4_Click);
            // 
            // sS1
            // 
            this.sS1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslResultCode,
            this.ssSecondPanel,
            this.sslSmallPrinter,
            this.sslLargePrinter});
            this.sS1.Location = new System.Drawing.Point(0, 531);
            this.sS1.Name = "sS1";
            this.sS1.ShowItemToolTips = true;
            this.sS1.Size = new System.Drawing.Size(848, 24);
            this.sS1.TabIndex = 9;
            this.sS1.Text = "statusStrip1";
            // 
            // sslResultCode
            // 
            this.sslResultCode.BackColor = System.Drawing.Color.Red;
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
            this.btnSalesOrder.Location = new System.Drawing.Point(187, 4);
            this.btnSalesOrder.Name = "btnSalesOrder";
            this.btnSalesOrder.Size = new System.Drawing.Size(75, 23);
            this.btnSalesOrder.TabIndex = 12;
            this.btnSalesOrder.Text = "Get SO";
            this.btnSalesOrder.UseVisualStyleBackColor = true;
            this.btnSalesOrder.Click += new System.EventHandler(this.btnSalesOrder_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnJsonLogin);
            this.panel1.Controls.Add(this.btnSendRequest);
            this.panel1.Controls.Add(this.btnSalesOrder);
            this.panel1.Controls.Add(this.cbFormat);
            this.panel1.Controls.Add(this.lblSalesOrder);
            this.panel1.Controls.Add(this.tbSalesOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 32);
            this.panel1.TabIndex = 13;
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Skip,
            this.Item,
            this.Qty,
            this.MultiLabel});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 217);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(848, 314);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Skip
            // 
            this.Skip.HeaderText = "Skip";
            this.Skip.Name = "Skip";
            this.Skip.ReadOnly = true;
            this.Skip.Width = 50;
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 250;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // MultiLabel
            // 
            this.MultiLabel.HeaderText = "MultiLabel";
            this.MultiLabel.Name = "MultiLabel";
            this.MultiLabel.ReadOnly = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(387, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.btnPrint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPrint_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 555);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sS1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Fishbowl Label Connect";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.sS1.ResumeLayout(false);
            this.sS1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.CheckBox cbFormat;
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
        private System.Windows.Forms.PrintDialog PD;
        private System.Windows.Forms.PrintDialog PD2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Skip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn MultiLabel;
    }
}

