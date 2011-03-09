namespace msp430_bsl_GUI
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
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.comPortComboBox = new System.Windows.Forms.ComboBox();
      this.invertResetCheckBox = new System.Windows.Forms.CheckBox();
      this.invertTestCheckBox = new System.Windows.Forms.CheckBox();
      this.massEraseCheckBox = new System.Windows.Forms.CheckBox();
      this.eraseCheckCheckBox = new System.Windows.Forms.CheckBox();
      this.programFileCheckBox = new System.Windows.Forms.CheckBox();
      this.verifyFileCheckBox = new System.Windows.Forms.CheckBox();
      this.programFlowGroupBox = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.filenameTextBox = new System.Windows.Forms.TextBox();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.openFileButton = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.speedComboBox = new System.Windows.Forms.ComboBox();
      this.filenameLabel = new System.Windows.Forms.Label();
      this.generalOptionsGroupBox = new System.Windows.Forms.GroupBox();
      this.fileFormatComboBox = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.fileFormatLabel = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.consoleOutputRichTextBox = new System.Windows.Forms.RichTextBox();
      this.programFlowGroupBox.SuspendLayout();
      this.generalOptionsGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // imageList1
      // 
      this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
      this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // comPortComboBox
      // 
      this.comPortComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.comPortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comPortComboBox.FormattingEnabled = true;
      this.comPortComboBox.Location = new System.Drawing.Point(74, 40);
      this.comPortComboBox.Name = "comPortComboBox";
      this.comPortComboBox.Size = new System.Drawing.Size(268, 21);
      this.comPortComboBox.TabIndex = 0;
      this.comPortComboBox.DropDown += new System.EventHandler(this.ComPortComboBoxDropDown);
      // 
      // invertResetCheckBox
      // 
      this.invertResetCheckBox.AutoSize = true;
      this.invertResetCheckBox.Location = new System.Drawing.Point(6, 19);
      this.invertResetCheckBox.Name = "invertResetCheckBox";
      this.invertResetCheckBox.Size = new System.Drawing.Size(285, 17);
      this.invertResetCheckBox.TabIndex = 1;
      this.invertResetCheckBox.Text = "Invert signal on RST pin (used for some BSL hardware)";
      this.invertResetCheckBox.UseVisualStyleBackColor = true;
      // 
      // invertTestCheckBox
      // 
      this.invertTestCheckBox.AutoSize = true;
      this.invertTestCheckBox.Location = new System.Drawing.Point(6, 42);
      this.invertTestCheckBox.Name = "invertTestCheckBox";
      this.invertTestCheckBox.Size = new System.Drawing.Size(317, 17);
      this.invertTestCheckBox.TabIndex = 2;
      this.invertTestCheckBox.Text = "Invert signal on TEST/TCK pin (used for some BSL hardware)";
      this.invertTestCheckBox.UseVisualStyleBackColor = true;
      // 
      // massEraseCheckBox
      // 
      this.massEraseCheckBox.AutoSize = true;
      this.massEraseCheckBox.Location = new System.Drawing.Point(6, 19);
      this.massEraseCheckBox.Name = "massEraseCheckBox";
      this.massEraseCheckBox.Size = new System.Drawing.Size(190, 17);
      this.massEraseCheckBox.TabIndex = 3;
      this.massEraseCheckBox.Text = "Mass Erase (clear all flash memory)";
      this.massEraseCheckBox.UseVisualStyleBackColor = true;
      // 
      // eraseCheckCheckBox
      // 
      this.eraseCheckCheckBox.AutoSize = true;
      this.eraseCheckCheckBox.Location = new System.Drawing.Point(6, 42);
      this.eraseCheckCheckBox.Name = "eraseCheckCheckBox";
      this.eraseCheckCheckBox.Size = new System.Drawing.Size(117, 17);
      this.eraseCheckCheckBox.TabIndex = 4;
      this.eraseCheckCheckBox.Text = "Erase Check by file";
      this.eraseCheckCheckBox.UseVisualStyleBackColor = true;
      // 
      // programFileCheckBox
      // 
      this.programFileCheckBox.AutoSize = true;
      this.programFileCheckBox.Location = new System.Drawing.Point(6, 65);
      this.programFileCheckBox.Name = "programFileCheckBox";
      this.programFileCheckBox.Size = new System.Drawing.Size(81, 17);
      this.programFileCheckBox.TabIndex = 5;
      this.programFileCheckBox.Text = "Program file";
      this.programFileCheckBox.UseVisualStyleBackColor = true;
      // 
      // verifyFileCheckBox
      // 
      this.verifyFileCheckBox.AutoSize = true;
      this.verifyFileCheckBox.Location = new System.Drawing.Point(6, 88);
      this.verifyFileCheckBox.Name = "verifyFileCheckBox";
      this.verifyFileCheckBox.Size = new System.Drawing.Size(82, 17);
      this.verifyFileCheckBox.TabIndex = 6;
      this.verifyFileCheckBox.Text = "Verify by file";
      this.verifyFileCheckBox.UseVisualStyleBackColor = true;
      // 
      // programFlowGroupBox
      // 
      this.programFlowGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.programFlowGroupBox.Controls.Add(this.massEraseCheckBox);
      this.programFlowGroupBox.Controls.Add(this.verifyFileCheckBox);
      this.programFlowGroupBox.Controls.Add(this.eraseCheckCheckBox);
      this.programFlowGroupBox.Controls.Add(this.programFileCheckBox);
      this.programFlowGroupBox.Location = new System.Drawing.Point(12, 140);
      this.programFlowGroupBox.Name = "programFlowGroupBox";
      this.programFlowGroupBox.Size = new System.Drawing.Size(600, 112);
      this.programFlowGroupBox.TabIndex = 7;
      this.programFlowGroupBox.TabStop = false;
      this.programFlowGroupBox.Text = "Program Flow Specifiers";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 43);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(56, 13);
      this.label1.TabIndex = 8;
      this.label1.Text = "COM Port:";
      // 
      // filenameTextBox
      // 
      this.filenameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.filenameTextBox.Location = new System.Drawing.Point(74, 15);
      this.filenameTextBox.Name = "filenameTextBox";
      this.filenameTextBox.Size = new System.Drawing.Size(419, 20);
      this.filenameTextBox.TabIndex = 9;
      this.filenameTextBox.TextChanged += new System.EventHandler(this.FilenameTextBoxTextChanged);
      // 
      // openFileDialog
      // 
      this.openFileDialog.Filter = "Intel HEX|*.hex;*.a43|TIText|*.txt|All files|*.*";
      // 
      // openFileButton
      // 
      this.openFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.openFileButton.Location = new System.Drawing.Point(499, 12);
      this.openFileButton.Name = "openFileButton";
      this.openFileButton.Size = new System.Drawing.Size(26, 23);
      this.openFileButton.TabIndex = 10;
      this.openFileButton.Text = "...";
      this.openFileButton.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(348, 43);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(53, 13);
      this.label2.TabIndex = 11;
      this.label2.Text = "Baud rate";
      // 
      // speedComboBox
      // 
      this.speedComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.speedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.speedComboBox.FormattingEnabled = true;
      this.speedComboBox.Location = new System.Drawing.Point(407, 40);
      this.speedComboBox.Name = "speedComboBox";
      this.speedComboBox.Size = new System.Drawing.Size(69, 21);
      this.speedComboBox.TabIndex = 12;
      // 
      // filenameLabel
      // 
      this.filenameLabel.AutoSize = true;
      this.filenameLabel.Location = new System.Drawing.Point(12, 17);
      this.filenameLabel.Name = "filenameLabel";
      this.filenameLabel.Size = new System.Drawing.Size(52, 13);
      this.filenameLabel.TabIndex = 13;
      this.filenameLabel.Text = "Filename:";
      // 
      // generalOptionsGroupBox
      // 
      this.generalOptionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.generalOptionsGroupBox.Controls.Add(this.invertResetCheckBox);
      this.generalOptionsGroupBox.Controls.Add(this.invertTestCheckBox);
      this.generalOptionsGroupBox.Location = new System.Drawing.Point(12, 67);
      this.generalOptionsGroupBox.Name = "generalOptionsGroupBox";
      this.generalOptionsGroupBox.Size = new System.Drawing.Size(600, 67);
      this.generalOptionsGroupBox.TabIndex = 15;
      this.generalOptionsGroupBox.TabStop = false;
      this.generalOptionsGroupBox.Text = "General options";
      // 
      // fileFormatComboBox
      // 
      this.fileFormatComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.fileFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.fileFormatComboBox.FormattingEnabled = true;
      this.fileFormatComboBox.Location = new System.Drawing.Point(543, 40);
      this.fileFormatComboBox.Name = "fileFormatComboBox";
      this.fileFormatComboBox.Size = new System.Drawing.Size(69, 21);
      this.fileFormatComboBox.TabIndex = 17;
      this.fileFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.FileFormatComboBoxSelectedIndexChanged);
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(482, 43);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(55, 13);
      this.label3.TabIndex = 16;
      this.label3.Text = "File format";
      // 
      // fileFormatLabel
      // 
      this.fileFormatLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.fileFormatLabel.AutoSize = true;
      this.fileFormatLabel.Location = new System.Drawing.Point(531, 18);
      this.fileFormatLabel.Name = "fileFormatLabel";
      this.fileFormatLabel.Size = new System.Drawing.Size(0, 13);
      this.fileFormatLabel.TabIndex = 18;
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.Location = new System.Drawing.Point(12, 258);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(600, 23);
      this.button1.TabIndex = 19;
      this.button1.Text = "Program";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.ProgramButtonClick);
      // 
      // consoleOutputRichTextBox
      // 
      this.consoleOutputRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.consoleOutputRichTextBox.BackColor = System.Drawing.Color.Black;
      this.consoleOutputRichTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.consoleOutputRichTextBox.ForeColor = System.Drawing.Color.White;
      this.consoleOutputRichTextBox.Location = new System.Drawing.Point(12, 287);
      this.consoleOutputRichTextBox.Name = "consoleOutputRichTextBox";
      this.consoleOutputRichTextBox.ReadOnly = true;
      this.consoleOutputRichTextBox.Size = new System.Drawing.Size(600, 270);
      this.consoleOutputRichTextBox.TabIndex = 20;
      this.consoleOutputRichTextBox.Text = "Log Window";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(624, 569);
      this.Controls.Add(this.consoleOutputRichTextBox);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.fileFormatLabel);
      this.Controls.Add(this.fileFormatComboBox);
      this.Controls.Add(this.speedComboBox);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.generalOptionsGroupBox);
      this.Controls.Add(this.filenameLabel);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.openFileButton);
      this.Controls.Add(this.filenameTextBox);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.programFlowGroupBox);
      this.Controls.Add(this.comPortComboBox);
      this.MinimumSize = new System.Drawing.Size(480, 332);
      this.Name = "MainForm";
      this.Text = "msp430-bsl GUI";
      this.programFlowGroupBox.ResumeLayout(false);
      this.programFlowGroupBox.PerformLayout();
      this.generalOptionsGroupBox.ResumeLayout(false);
      this.generalOptionsGroupBox.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.ComboBox comPortComboBox;
    private System.Windows.Forms.CheckBox invertResetCheckBox;
    private System.Windows.Forms.CheckBox invertTestCheckBox;
    private System.Windows.Forms.CheckBox massEraseCheckBox;
    private System.Windows.Forms.CheckBox eraseCheckCheckBox;
    private System.Windows.Forms.CheckBox programFileCheckBox;
    private System.Windows.Forms.CheckBox verifyFileCheckBox;
    private System.Windows.Forms.GroupBox programFlowGroupBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox filenameTextBox;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.Button openFileButton;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox speedComboBox;
    private System.Windows.Forms.Label filenameLabel;
    private System.Windows.Forms.GroupBox generalOptionsGroupBox;
    private System.Windows.Forms.ComboBox fileFormatComboBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label fileFormatLabel;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.RichTextBox consoleOutputRichTextBox;
  }
}

