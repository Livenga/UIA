namespace UIA.ControlGallery
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.textBoxLabel = new System.Windows.Forms.Label();
      this.exampleText = new System.Windows.Forms.TextBox();
      this.comboBoxLabel = new System.Windows.Forms.Label();
      this.exampleSelector = new System.Windows.Forms.ComboBox();
      this.checkBoxLabel = new System.Windows.Forms.Label();
      this.exampleCheckBox = new System.Windows.Forms.CheckBox();
      this.decideButton = new System.Windows.Forms.Button();
      this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
      this.messageStrip = new System.Windows.Forms.ToolStripStatusLabel();
      this.clearMessageButton = new System.Windows.Forms.Button();
      this.disabledButton = new System.Windows.Forms.Button();
      this.mainStatusStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // textBoxLabel
      // 
      this.textBoxLabel.AutoSize = true;
      this.textBoxLabel.Location = new System.Drawing.Point(13, 13);
      this.textBoxLabel.Name = "textBoxLabel";
      this.textBoxLabel.Size = new System.Drawing.Size(110, 18);
      this.textBoxLabel.TabIndex = 0;
      this.textBoxLabel.Text = "Example &TextBox";
      this.textBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // exampleText
      // 
      this.exampleText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.exampleText.Location = new System.Drawing.Point(152, 9);
      this.exampleText.Name = "exampleText";
      this.exampleText.Size = new System.Drawing.Size(393, 25);
      this.exampleText.TabIndex = 1;
      this.exampleText.TextChanged += new System.EventHandler(this.OnExampleTextChanged);
      // 
      // comboBoxLabel
      // 
      this.comboBoxLabel.AutoSize = true;
      this.comboBoxLabel.Location = new System.Drawing.Point(12, 48);
      this.comboBoxLabel.Name = "comboBoxLabel";
      this.comboBoxLabel.Size = new System.Drawing.Size(125, 18);
      this.comboBoxLabel.TabIndex = 2;
      this.comboBoxLabel.Text = "Example &ComboBox";
      // 
      // exampleSelector
      // 
      this.exampleSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.exampleSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.exampleSelector.FormattingEnabled = true;
      this.exampleSelector.Items.AddRange(new object[] {
            "Item No.0",
            "Item No.1",
            "Item No.2"});
      this.exampleSelector.Location = new System.Drawing.Point(152, 45);
      this.exampleSelector.Name = "exampleSelector";
      this.exampleSelector.Size = new System.Drawing.Size(390, 26);
      this.exampleSelector.TabIndex = 3;
      this.exampleSelector.SelectedIndexChanged += new System.EventHandler(this.OnExampleSelectorSelectedIndexChanged);
      // 
      // checkBoxLabel
      // 
      this.checkBoxLabel.AutoSize = true;
      this.checkBoxLabel.Location = new System.Drawing.Point(12, 89);
      this.checkBoxLabel.Name = "checkBoxLabel";
      this.checkBoxLabel.Size = new System.Drawing.Size(119, 18);
      this.checkBoxLabel.TabIndex = 4;
      this.checkBoxLabel.Text = "Example C&heckBox";
      this.checkBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // exampleCheckBox
      // 
      this.exampleCheckBox.AutoSize = true;
      this.exampleCheckBox.Location = new System.Drawing.Point(152, 89);
      this.exampleCheckBox.Name = "exampleCheckBox";
      this.exampleCheckBox.Size = new System.Drawing.Size(115, 22);
      this.exampleCheckBox.TabIndex = 5;
      this.exampleCheckBox.Text = "CheckBox No.1";
      this.exampleCheckBox.UseVisualStyleBackColor = true;
      this.exampleCheckBox.CheckedChanged += new System.EventHandler(this.OnExampleCheckBoxCheckedChanged);
      // 
      // decideButton
      // 
      this.decideButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.decideButton.Location = new System.Drawing.Point(457, 159);
      this.decideButton.Name = "decideButton";
      this.decideButton.Size = new System.Drawing.Size(85, 28);
      this.decideButton.TabIndex = 6;
      this.decideButton.Text = "&OK";
      this.decideButton.UseVisualStyleBackColor = true;
      this.decideButton.Click += new System.EventHandler(this.OnDecideClick);
      // 
      // mainStatusStrip
      // 
      this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageStrip});
      this.mainStatusStrip.Location = new System.Drawing.Point(0, 193);
      this.mainStatusStrip.Name = "mainStatusStrip";
      this.mainStatusStrip.Size = new System.Drawing.Size(554, 22);
      this.mainStatusStrip.TabIndex = 7;
      this.mainStatusStrip.Text = "statusStrip1";
      // 
      // messageStrip
      // 
      this.messageStrip.ForeColor = System.Drawing.Color.Blue;
      this.messageStrip.Name = "messageStrip";
      this.messageStrip.Size = new System.Drawing.Size(28, 17);
      this.messageStrip.Text = "###";
      // 
      // clearMessageButton
      // 
      this.clearMessageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.clearMessageButton.Location = new System.Drawing.Point(12, 159);
      this.clearMessageButton.Name = "clearMessageButton";
      this.clearMessageButton.Size = new System.Drawing.Size(148, 28);
      this.clearMessageButton.TabIndex = 8;
      this.clearMessageButton.TabStop = false;
      this.clearMessageButton.Text = "メッセージクリア(&M)";
      this.clearMessageButton.UseVisualStyleBackColor = true;
      this.clearMessageButton.Click += new System.EventHandler(this.OnMessageClearClick);
      // 
      // disabledButton
      // 
      this.disabledButton.Enabled = false;
      this.disabledButton.Location = new System.Drawing.Point(152, 117);
      this.disabledButton.Name = "disabledButton";
      this.disabledButton.Size = new System.Drawing.Size(208, 28);
      this.disabledButton.TabIndex = 9;
      this.disabledButton.Text = "&Disabled Button";
      this.disabledButton.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(554, 215);
      this.Controls.Add(this.disabledButton);
      this.Controls.Add(this.clearMessageButton);
      this.Controls.Add(this.mainStatusStrip);
      this.Controls.Add(this.decideButton);
      this.Controls.Add(this.exampleCheckBox);
      this.Controls.Add(this.checkBoxLabel);
      this.Controls.Add(this.exampleSelector);
      this.Controls.Add(this.comboBoxLabel);
      this.Controls.Add(this.exampleText);
      this.Controls.Add(this.textBoxLabel);
      this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.MinimumSize = new System.Drawing.Size(570, 230);
      this.Name = "MainForm";
      this.Text = "UIA Example Window";
      this.mainStatusStrip.ResumeLayout(false);
      this.mainStatusStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textBoxLabel;
        private System.Windows.Forms.TextBox exampleText;
        private System.Windows.Forms.Label comboBoxLabel;
        private System.Windows.Forms.ComboBox exampleSelector;
        private System.Windows.Forms.Label checkBoxLabel;
        private System.Windows.Forms.CheckBox exampleCheckBox;
        private System.Windows.Forms.Button decideButton;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel messageStrip;
        private System.Windows.Forms.Button clearMessageButton;
        private System.Windows.Forms.Button disabledButton;
    }
}

