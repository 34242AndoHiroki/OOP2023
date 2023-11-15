
namespace RssReader {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.btGet = new System.Windows.Forms.Button();
            this.lbRssTitle = new System.Windows.Forms.ListBox();
            this.wbBrowser = new System.Windows.Forms.WebBrowser();
            this.cbUrl = new System.Windows.Forms.ComboBox();
            this.btMyFavorite = new System.Windows.Forms.Button();
            this.chIsFavorite = new System.Windows.Forms.CheckBox();
            this.tbFavoriteName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTopics = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btGet
            // 
            this.btGet.Location = new System.Drawing.Point(1222, 12);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(90, 31);
            this.btGet.TabIndex = 1;
            this.btGet.Text = "取得";
            this.btGet.UseVisualStyleBackColor = true;
            this.btGet.Click += new System.EventHandler(this.btGet_Click);
            // 
            // lbRssTitle
            // 
            this.lbRssTitle.FormattingEnabled = true;
            this.lbRssTitle.ItemHeight = 12;
            this.lbRssTitle.Location = new System.Drawing.Point(299, 52);
            this.lbRssTitle.Name = "lbRssTitle";
            this.lbRssTitle.Size = new System.Drawing.Size(328, 616);
            this.lbRssTitle.TabIndex = 2;
            this.lbRssTitle.Click += new System.EventHandler(this.lbRssTitle_Click);
            // 
            // wbBrowser
            // 
            this.wbBrowser.Location = new System.Drawing.Point(633, 50);
            this.wbBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBrowser.Name = "wbBrowser";
            this.wbBrowser.Size = new System.Drawing.Size(679, 616);
            this.wbBrowser.TabIndex = 3;
            // 
            // cbUrl
            // 
            this.cbUrl.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cbUrl.FormattingEnabled = true;
            this.cbUrl.Location = new System.Drawing.Point(16, 12);
            this.cbUrl.Name = "cbUrl";
            this.cbUrl.Size = new System.Drawing.Size(1200, 32);
            this.cbUrl.TabIndex = 4;
            // 
            // btMyFavorite
            // 
            this.btMyFavorite.Location = new System.Drawing.Point(171, 153);
            this.btMyFavorite.Name = "btMyFavorite";
            this.btMyFavorite.Size = new System.Drawing.Size(122, 31);
            this.btMyFavorite.TabIndex = 5;
            this.btMyFavorite.Text = "☆お気に入り追加";
            this.btMyFavorite.UseVisualStyleBackColor = true;
            this.btMyFavorite.Click += new System.EventHandler(this.btMyFavorite_Click);
            // 
            // chIsFavorite
            // 
            this.chIsFavorite.AutoSize = true;
            this.chIsFavorite.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chIsFavorite.Location = new System.Drawing.Point(16, 50);
            this.chIsFavorite.Name = "chIsFavorite";
            this.chIsFavorite.Size = new System.Drawing.Size(145, 24);
            this.chIsFavorite.TabIndex = 6;
            this.chIsFavorite.Text = "お気に入りのみ表示";
            this.chIsFavorite.UseVisualStyleBackColor = true;
            // 
            // tbFavoriteName
            // 
            this.tbFavoriteName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbFavoriteName.Location = new System.Drawing.Point(74, 124);
            this.tbFavoriteName.Name = "tbFavoriteName";
            this.tbFavoriteName.Size = new System.Drawing.Size(219, 23);
            this.tbFavoriteName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "トピックス";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(27, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "名前:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "・名前を付けてお気に入り追加";
            // 
            // cbTopics
            // 
            this.cbTopics.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cbTopics.FormattingEnabled = true;
            this.cbTopics.Location = new System.Drawing.Point(16, 260);
            this.cbTopics.Name = "cbTopics";
            this.cbTopics.Size = new System.Drawing.Size(277, 28);
            this.cbTopics.TabIndex = 12;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 680);
            this.Controls.Add(this.cbTopics);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFavoriteName);
            this.Controls.Add(this.chIsFavorite);
            this.Controls.Add(this.btMyFavorite);
            this.Controls.Add(this.wbBrowser);
            this.Controls.Add(this.lbRssTitle);
            this.Controls.Add(this.btGet);
            this.Controls.Add(this.cbUrl);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btGet;
        private System.Windows.Forms.ListBox lbRssTitle;
        private System.Windows.Forms.WebBrowser wbBrowser;
        private System.Windows.Forms.ComboBox cbUrl;
        private System.Windows.Forms.Button btMyFavorite;
        private System.Windows.Forms.CheckBox chIsFavorite;
        private System.Windows.Forms.TextBox tbFavoriteName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTopics;
    }
}

