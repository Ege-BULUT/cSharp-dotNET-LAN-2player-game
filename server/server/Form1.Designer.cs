namespace server
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.attackCoords = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.player1Result = new System.Windows.Forms.Label();
            this.player2Result = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.player1Flags = new System.Windows.Forms.ListBox();
            this.capturedFlagCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.ErrorImage = null;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(6, 5);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(945, 465);
            this.pictureBox.TabIndex = 8;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(1069, 354);
            this.sendButton.Margin = new System.Windows.Forms.Padding(2);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(56, 20);
            this.sendButton.TabIndex = 9;
            this.sendButton.Text = "send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendbut_Click_1);
            // 
            // attackCoords
            // 
            this.attackCoords.Location = new System.Drawing.Point(962, 354);
            this.attackCoords.Margin = new System.Windows.Forms.Padding(2);
            this.attackCoords.Name = "attackCoords";
            this.attackCoords.Size = new System.Drawing.Size(105, 20);
            this.attackCoords.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(959, 339);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Attack Coordinates :";
            // 
            // player1Result
            // 
            this.player1Result.Location = new System.Drawing.Point(1009, 390);
            this.player1Result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.player1Result.Name = "player1Result";
            this.player1Result.Size = new System.Drawing.Size(98, 80);
            this.player1Result.TabIndex = 19;
            // 
            // player2Result
            // 
            this.player2Result.Location = new System.Drawing.Point(1008, 423);
            this.player2Result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.player2Result.Name = "player2Result";
            this.player2Result.Size = new System.Drawing.Size(99, 47);
            this.player2Result.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(957, 423);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Player 1 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(957, 390);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Player 2 : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(959, 158);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Captured Flag Count :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(956, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Your Flags :";
            // 
            // Player1Flags
            // 
            this.player1Flags.FormattingEnabled = true;
            this.player1Flags.Location = new System.Drawing.Point(959, 24);
            this.player1Flags.Margin = new System.Windows.Forms.Padding(2);
            this.player1Flags.Name = "Player1Flags";
            this.player1Flags.Size = new System.Drawing.Size(193, 95);
            this.player1Flags.TabIndex = 26;
            // 
            // capturedFlagCount
            // 
            this.capturedFlagCount.AutoSize = true;
            this.capturedFlagCount.Location = new System.Drawing.Point(1069, 158);
            this.capturedFlagCount.Name = "capturedFlagCount";
            this.capturedFlagCount.Size = new System.Drawing.Size(13, 13);
            this.capturedFlagCount.TabIndex = 29;
            this.capturedFlagCount.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 501);
            this.Controls.Add(this.capturedFlagCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.player1Flags);
            this.Controls.Add(this.player2Result);
            this.Controls.Add(this.player1Result);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.attackCoords);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox attackCoords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label player2Result;
        private System.Windows.Forms.Label player1Result;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox player1Flags;
        private System.Windows.Forms.Label capturedFlagCount;
    }
}

