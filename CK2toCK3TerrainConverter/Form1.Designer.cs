namespace CK2toCK3TerrainConverter
{
    partial class Form1
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
            this.buttonRun = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.textBoxTerrainImage = new System.Windows.Forms.TextBox();
            this.labelTerrainImage = new System.Windows.Forms.Label();
            this.textBoxTerrainText = new System.Windows.Forms.TextBox();
            this.labelTerrainText = new System.Windows.Forms.Label();
            this.textBoxProvinceMap = new System.Windows.Forms.TextBox();
            this.labelProvinceMap = new System.Windows.Forms.Label();
            this.textBoxProvinceDefinition = new System.Windows.Forms.TextBox();
            this.labelProvinceDefinition = new System.Windows.Forms.Label();
            this.labelDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(13, 14);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(100, 38);
            this.buttonRun.TabIndex = 0;
            this.buttonRun.Text = "実行";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.Location = new System.Drawing.Point(13, 293);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(1042, 445);
            this.textBoxLog.TabIndex = 1;
            // 
            // textBoxTerrainImage
            // 
            this.textBoxTerrainImage.AllowDrop = true;
            this.textBoxTerrainImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTerrainImage.Location = new System.Drawing.Point(12, 101);
            this.textBoxTerrainImage.Name = "textBoxTerrainImage";
            this.textBoxTerrainImage.Size = new System.Drawing.Size(1043, 27);
            this.textBoxTerrainImage.TabIndex = 2;
            this.textBoxTerrainImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.textBoxTerrainImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_DragEnter);
            // 
            // labelTerrainImage
            // 
            this.labelTerrainImage.AutoSize = true;
            this.labelTerrainImage.Location = new System.Drawing.Point(12, 78);
            this.labelTerrainImage.Name = "labelTerrainImage";
            this.labelTerrainImage.Size = new System.Drawing.Size(101, 20);
            this.labelTerrainImage.TabIndex = 3;
            this.labelTerrainImage.Text = "地形マップ画像";
            // 
            // textBoxTerrainText
            // 
            this.textBoxTerrainText.AllowDrop = true;
            this.textBoxTerrainText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTerrainText.Location = new System.Drawing.Point(12, 154);
            this.textBoxTerrainText.Name = "textBoxTerrainText";
            this.textBoxTerrainText.Size = new System.Drawing.Size(1043, 27);
            this.textBoxTerrainText.TabIndex = 2;
            this.textBoxTerrainText.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.textBoxTerrainText.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_DragEnter);
            // 
            // labelTerrainText
            // 
            this.labelTerrainText.AutoSize = true;
            this.labelTerrainText.Location = new System.Drawing.Point(12, 131);
            this.labelTerrainText.Name = "labelTerrainText";
            this.labelTerrainText.Size = new System.Drawing.Size(146, 20);
            this.labelTerrainText.TabIndex = 3;
            this.labelTerrainText.Text = "色-地形対応定義CSV";
            // 
            // textBoxProvinceMap
            // 
            this.textBoxProvinceMap.AllowDrop = true;
            this.textBoxProvinceMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProvinceMap.Location = new System.Drawing.Point(12, 207);
            this.textBoxProvinceMap.Name = "textBoxProvinceMap";
            this.textBoxProvinceMap.Size = new System.Drawing.Size(1043, 27);
            this.textBoxProvinceMap.TabIndex = 2;
            this.textBoxProvinceMap.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.textBoxProvinceMap.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_DragEnter);
            // 
            // labelProvinceMap
            // 
            this.labelProvinceMap.AutoSize = true;
            this.labelProvinceMap.Location = new System.Drawing.Point(12, 184);
            this.labelProvinceMap.Name = "labelProvinceMap";
            this.labelProvinceMap.Size = new System.Drawing.Size(143, 20);
            this.labelProvinceMap.TabIndex = 3;
            this.labelProvinceMap.Text = "プロヴィンス区割り画像";
            // 
            // textBoxProvinceDefinition
            // 
            this.textBoxProvinceDefinition.AllowDrop = true;
            this.textBoxProvinceDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProvinceDefinition.Location = new System.Drawing.Point(12, 260);
            this.textBoxProvinceDefinition.Name = "textBoxProvinceDefinition";
            this.textBoxProvinceDefinition.Size = new System.Drawing.Size(1043, 27);
            this.textBoxProvinceDefinition.TabIndex = 2;
            this.textBoxProvinceDefinition.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.textBoxProvinceDefinition.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_DragEnter);
            // 
            // labelProvinceDefinition
            // 
            this.labelProvinceDefinition.AutoSize = true;
            this.labelProvinceDefinition.Location = new System.Drawing.Point(12, 237);
            this.labelProvinceDefinition.Name = "labelProvinceDefinition";
            this.labelProvinceDefinition.Size = new System.Drawing.Size(184, 20);
            this.labelProvinceDefinition.TabIndex = 3;
            this.labelProvinceDefinition.Text = "色- プロヴィンス対応定義CSV";
            // 
            // labelDesc
            // 
            this.labelDesc.AutoSize = true;
            this.labelDesc.Location = new System.Drawing.Point(130, 23);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(464, 20);
            this.labelDesc.TabIndex = 4;
            this.labelDesc.Text = "ファイルパスは直接入力か、該当テキストボックスにドラッグ＆ドロップしてください";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 750);
            this.Controls.Add(this.labelDesc);
            this.Controls.Add(this.labelProvinceDefinition);
            this.Controls.Add(this.textBoxProvinceDefinition);
            this.Controls.Add(this.labelProvinceMap);
            this.Controls.Add(this.textBoxProvinceMap);
            this.Controls.Add(this.labelTerrainText);
            this.Controls.Add(this.textBoxTerrainText);
            this.Controls.Add(this.labelTerrainImage);
            this.Controls.Add(this.textBoxTerrainImage);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonRun);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "CK3地形変換";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.TextBox textBoxTerrainImage;
        private System.Windows.Forms.Label labelTerrainImage;
        private System.Windows.Forms.TextBox textBoxTerrainText;
        private System.Windows.Forms.Label labelTerrainText;
        private System.Windows.Forms.TextBox textBoxProvinceMap;
        private System.Windows.Forms.Label labelProvinceMap;
        private System.Windows.Forms.TextBox textBoxProvinceDefinition;
        private System.Windows.Forms.Label labelProvinceDefinition;
        private System.Windows.Forms.Label labelDesc;
    }
}

