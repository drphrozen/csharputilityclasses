namespace ClipboardSniffer
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
      this.button1 = new System.Windows.Forms.Button();
      this.comboBoxAutoConvert = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.comboBoxNative = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.panel = new System.Windows.Forms.Panel();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(12, 14);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(125, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "Read Clipboard";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.Button1Click);
      // 
      // comboBoxAutoConvert
      // 
      this.comboBoxAutoConvert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxAutoConvert.FormattingEnabled = true;
      this.comboBoxAutoConvert.Location = new System.Drawing.Point(217, 16);
      this.comboBoxAutoConvert.Name = "comboBoxAutoConvert";
      this.comboBoxAutoConvert.Size = new System.Drawing.Size(202, 21);
      this.comboBoxAutoConvert.TabIndex = 3;
      this.comboBoxAutoConvert.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(425, 19);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(38, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Native";
      // 
      // comboBoxNative
      // 
      this.comboBoxNative.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxNative.FormattingEnabled = true;
      this.comboBoxNative.Location = new System.Drawing.Point(469, 16);
      this.comboBoxNative.Name = "comboBoxNative";
      this.comboBoxNative.Size = new System.Drawing.Size(202, 21);
      this.comboBoxNative.TabIndex = 5;
      this.comboBoxNative.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedIndexChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(143, 19);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(68, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Auto convert";
      // 
      // panel
      // 
      this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.panel.Location = new System.Drawing.Point(12, 43);
      this.panel.Name = "panel";
      this.panel.Size = new System.Drawing.Size(660, 498);
      this.panel.TabIndex = 7;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(684, 553);
      this.Controls.Add(this.panel);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.comboBoxNative);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.comboBoxAutoConvert);
      this.Controls.Add(this.button1);
      this.Name = "MainForm";
      this.Text = "Clipboard Sniffer";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ComboBox comboBoxAutoConvert;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox comboBoxNative;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Panel panel;
  }
}

