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
            tableLayoutPanel3 = new TableLayoutPanel();
            button4 = new Button();
            button6 = new Button();
            button5 = new Button();
            label4 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            importToDatabaseButton = new Button();
            specComboBox = new ComboBox();
            titleFlowLayoutPanel = new FlowLayoutPanel();
            hypersecuLogoPictureBox = new PictureBox();
            titleLabel = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            pictureBox2 = new PictureBox();
            button2 = new Button();
            button3 = new Button();
            label2 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            outputLogListBox = new ListBox();
            entriesListView = new ListView();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            titleFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)hypersecuLogoPictureBox).BeginInit();
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
            tableLayoutPanel4.Controls.Add(tableLayoutPanel3, 0, 4);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel4.Controls.Add(outputLogListBox, 0, 3);
            tableLayoutPanel4.Controls.Add(entriesListView, 0, 2);
            tableLayoutPanel4.Location = new Point(3, 8);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 5;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 72.7848053F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 27.21519F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel4.Size = new Size(976, 641);
            tableLayoutPanel4.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 178F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 146F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel3.Controls.Add(button4, 1, 0);
            tableLayoutPanel3.Controls.Add(button6, 3, 0);
            tableLayoutPanel3.Controls.Add(button5, 0, 0);
            tableLayoutPanel3.Controls.Add(label4, 2, 0);
            tableLayoutPanel3.Location = new Point(3, 598);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(970, 40);
            tableLayoutPanel3.TabIndex = 6;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button4.AutoSize = true;
            button4.BackColor = Color.Red;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            button4.ForeColor = SystemColors.Control;
            button4.Location = new Point(181, 3);
            button4.Name = "button4";
            button4.Size = new Size(140, 34);
            button4.TabIndex = 0;
            button4.Text = "Remove Entry";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button6.BackColor = Color.Red;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = SystemColors.Control;
            button6.Location = new Point(773, 3);
            button6.Name = "button6";
            button6.Size = new Size(194, 34);
            button6.TabIndex = 3;
            button6.Text = "Remove Duplicates";
            button6.UseVisualStyleBackColor = false;
            button6.Visible = false;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button5.BackColor = SystemColors.Highlight;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = SystemColors.Control;
            button5.Location = new Point(3, 3);
            button5.Name = "button5";
            button5.Size = new Size(172, 34);
            button5.TabIndex = 2;
            button5.Text = "Download Entries";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(327, 0);
            label4.Name = "label4";
            label4.Size = new Size(440, 40);
            label4.TabIndex = 1;
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 225F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.Controls.Add(importToDatabaseButton, 2, 0);
            tableLayoutPanel1.Controls.Add(specComboBox, 1, 0);
            tableLayoutPanel1.Controls.Add(titleFlowLayoutPanel, 0, 0);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(970, 56);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // importToDatabaseButton
            // 
            importToDatabaseButton.Anchor = AnchorStyles.None;
            importToDatabaseButton.BackColor = SystemColors.ControlLightLight;
            importToDatabaseButton.Font = new Font("Segoe UI", 15F);
            importToDatabaseButton.ForeColor = SystemColors.ControlText;
            importToDatabaseButton.Location = new Point(773, 6);
            importToDatabaseButton.Name = "importToDatabaseButton";
            importToDatabaseButton.Size = new Size(194, 44);
            importToDatabaseButton.TabIndex = 1;
            importToDatabaseButton.Text = "Import to database";
            importToDatabaseButton.UseVisualStyleBackColor = false;
            importToDatabaseButton.Click += button1_Click;
            // 
            // specComboBox
            // 
            specComboBox.Anchor = AnchorStyles.None;
            specComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            specComboBox.Font = new Font("Segoe UI", 15F);
            specComboBox.FormattingEnabled = true;
            specComboBox.Items.AddRange(new object[] { "Select token spec", "HOTP", "TOTP30", "TOTP60" });
            specComboBox.Location = new Point(548, 10);
            specComboBox.Name = "specComboBox";
            specComboBox.Size = new Size(219, 36);
            specComboBox.TabIndex = 2;
            specComboBox.Tag = "";
            // 
            // titleFlowLayoutPanel
            // 
            titleFlowLayoutPanel.AutoSize = true;
            titleFlowLayoutPanel.Controls.Add(hypersecuLogoPictureBox);
            titleFlowLayoutPanel.Controls.Add(titleLabel);
            titleFlowLayoutPanel.Location = new Point(0, 3);
            titleFlowLayoutPanel.Margin = new Padding(0, 3, 0, 0);
            titleFlowLayoutPanel.Name = "titleFlowLayoutPanel";
            titleFlowLayoutPanel.Size = new Size(398, 50);
            titleFlowLayoutPanel.TabIndex = 3;
            // 
            // hypersecuLogoPictureBox
            // 
            hypersecuLogoPictureBox.Image = (Image)resources.GetObject("hypersecuLogoPictureBox.Image");
            hypersecuLogoPictureBox.Location = new Point(10, 0);
            hypersecuLogoPictureBox.Margin = new Padding(10, 0, 10, 0);
            hypersecuLogoPictureBox.Name = "hypersecuLogoPictureBox";
            hypersecuLogoPictureBox.Size = new Size(50, 50);
            hypersecuLogoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            hypersecuLogoPictureBox.TabIndex = 0;
            hypersecuLogoPictureBox.TabStop = false;
            // 
            // titleLabel
            // 
            titleLabel.Anchor = AnchorStyles.Left;
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.FromArgb(0, 146, 188);
            titleLabel.Location = new Point(73, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(322, 32);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "OTP App Seed Importer 2.1.0";
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 45F));
            tableLayoutPanel2.Controls.Add(pictureBox2, 2, 1);
            tableLayoutPanel2.Controls.Add(button2, 0, 0);
            tableLayoutPanel2.Controls.Add(button3, 0, 1);
            tableLayoutPanel2.Controls.Add(label2, 1, 0);
            tableLayoutPanel2.Controls.Add(label3, 1, 1);
            tableLayoutPanel2.Controls.Add(pictureBox1, 2, 0);
            tableLayoutPanel2.Location = new Point(3, 65);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(970, 94);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(928, 50);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(39, 41);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.Font = new Font("Segoe UI", 15F);
            button2.Location = new Point(3, 3);
            button2.Name = "button2";
            button2.Size = new Size(194, 41);
            button2.TabIndex = 0;
            button2.Text = "Select seed file";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button3.Font = new Font("Segoe UI", 15F);
            button3.Location = new Point(3, 50);
            button3.Name = "button3";
            button3.Size = new Size(194, 41);
            button3.TabIndex = 1;
            button3.Text = "Select database";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(203, 16);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 2;
            label2.Text = "Seed file path";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(203, 63);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 3;
            label3.Text = "Database path";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(928, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 41);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // outputLogListBox
            // 
            outputLogListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            outputLogListBox.BackColor = SystemColors.MenuBar;
            outputLogListBox.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            outputLogListBox.FormattingEnabled = true;
            outputLogListBox.ItemHeight = 17;
            outputLogListBox.Location = new Point(3, 480);
            outputLogListBox.Name = "outputLogListBox";
            outputLogListBox.Size = new Size(970, 106);
            outputLogListBox.TabIndex = 6;
            // 
            // entriesListView
            // 
            entriesListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            entriesListView.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            entriesListView.FullRowSelect = true;
            entriesListView.Location = new Point(3, 165);
            entriesListView.MultiSelect = false;
            entriesListView.Name = "entriesListView";
            entriesListView.Size = new Size(970, 309);
            entriesListView.TabIndex = 7;
            entriesListView.UseCompatibleStateImageBehavior = false;
            entriesListView.View = View.Details;
            entriesListView.Resize += entriesListView_Resize;
            // 
            // OTPAppSeedImporter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(tableLayoutPanel4);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 700);
            Name = "OTPAppSeedImporter";
            Text = "OTPAppSeedImporter";
            Load += OTPAppSeedImporter_Load;
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            titleFlowLayoutPanel.ResumeLayout(false);
            titleFlowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)hypersecuLogoPictureBox).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel1;
        private Label titleLabel;
        private Button importToDatabaseButton;
        private TableLayoutPanel tableLayoutPanel2;
        private Button button2;
        private Button button3;
        private Label label2;
        private Label label3;
        private ComboBox specComboBox;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button4;
        private Label label4;
        private ListBox outputLogListBox;
        private Button button5;
        private Button button6;
        private TableLayoutPanel tableLayoutPanel3;
        private FlowLayoutPanel titleFlowLayoutPanel;
        private PictureBox hypersecuLogoPictureBox;
        private ListView entriesListView;

        // Event handler to resize the listview
        private void entriesListView_Resize(object sender, EventArgs e)
        {
            if (suppressResize) return;

            int total = entriesListView.ClientSize.Width;
            entriesListView.Columns[0].Width = (int)(total * 0.25);
            entriesListView.Columns[1].Width = (int)(total * 0.75);
        }
    }
}
