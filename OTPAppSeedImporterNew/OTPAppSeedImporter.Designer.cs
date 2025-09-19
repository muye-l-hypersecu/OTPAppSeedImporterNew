namespace OTPAppSeedImporterNew
{
    partial class OTPAppSeedImporter
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OTPAppSeedImporter));
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            button1 = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            pictureBox2 = new PictureBox();
            button2 = new Button();
            button3 = new Button();
            label2 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            listBox1 = new ListBox();
            label6 = new Label();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel4.Controls.Add(listBox1, 0, 2);
            tableLayoutPanel4.Controls.Add(label6, 0, 3);
            tableLayoutPanel4.Location = new Point(3, 8);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 4;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 13.333333F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 22.3809528F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 52.4024F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 12.1621618F));
            tableLayoutPanel4.Size = new Size(1091, 666);
            tableLayoutPanel4.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.9373856F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.06261F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 294F));
            tableLayoutPanel1.Controls.Add(button1, 2, 0);
            tableLayoutPanel1.Controls.Add(comboBox1, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1085, 82);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = SystemColors.ControlLightLight;
            button1.Font = new Font("Segoe UI", 15F);
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(832, 18);
            button1.Name = "button1";
            button1.Size = new Size(211, 45);
            button1.TabIndex = 1;
            button1.Text = "Import to database";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.None;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 15F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Select token spec", "HOTP", "TOTP30", "TOTP60" });
            comboBox1.Location = new Point(516, 23);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(271, 36);
            comboBox1.TabIndex = 2;
            comboBox1.Tag = "";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(3, 25);
            label1.Name = "label1";
            label1.Size = new Size(488, 32);
            label1.TabIndex = 0;
            label1.Text = "OTPAppSeedImporter by Mu Ye and Sakura";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.2589931F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.7410049F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 230F));
            tableLayoutPanel2.Controls.Add(pictureBox2, 2, 1);
            tableLayoutPanel2.Controls.Add(button2, 0, 0);
            tableLayoutPanel2.Controls.Add(button3, 0, 1);
            tableLayoutPanel2.Controls.Add(label2, 1, 0);
            tableLayoutPanel2.Controls.Add(label3, 1, 1);
            tableLayoutPanel2.Controls.Add(pictureBox1, 2, 0);
            tableLayoutPanel2.Location = new Point(3, 91);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1085, 142);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Left;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(857, 90);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(34, 33);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Left;
            button2.Font = new Font("Segoe UI", 15F);
            button2.Location = new Point(3, 16);
            button2.Name = "button2";
            button2.Size = new Size(200, 39);
            button2.TabIndex = 0;
            button2.Text = "Select a seed file";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Left;
            button3.Font = new Font("Segoe UI", 15F);
            button3.Location = new Point(3, 87);
            button3.Name = "button3";
            button3.Size = new Size(200, 39);
            button3.TabIndex = 1;
            button3.Text = "Select database";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(227, 21);
            label2.Name = "label2";
            label2.Size = new Size(131, 28);
            label2.TabIndex = 2;
            label2.Text = "Seed file path";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(227, 92);
            label3.Name = "label3";
            label3.Size = new Size(138, 28);
            label3.TabIndex = 3;
            label3.Text = "Database path";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(857, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(34, 33);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.Font = new Font("Segoe UI", 15F);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 28;
            listBox1.Location = new Point(3, 239);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(1085, 340);
            listBox1.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F);
            label6.Location = new Point(3, 584);
            label6.Name = "label6";
            label6.Size = new Size(0, 28);
            label6.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // OTPAppSeedImporter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1099, 686);
            Controls.Add(tableLayoutPanel4);
            MinimumSize = new Size(910, 600);
            Name = "OTPAppSeedImporter";
            Text = "OTPAppSeedImporter";
            Load += OTPAppSeedImporter_Load;
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Button button1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button button2;
        private Button button3;
        private Label label2;
        private Label label3;
        private Label label6;
        private ComboBox comboBox1;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private ListBox listBox1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}
