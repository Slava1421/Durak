namespace DurakGame
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.StatusHod = new System.Windows.Forms.Label();
            this.KardsAdd = new System.Windows.Forms.Button();
            this.Otboy = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.MessageBot = new System.Windows.Forms.Label();
            this.Zabrat = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusHod
            // 
            this.StatusHod.AutoSize = true;
            this.StatusHod.Location = new System.Drawing.Point(34, 478);
            this.StatusHod.Name = "StatusHod";
            this.StatusHod.Size = new System.Drawing.Size(35, 13);
            this.StatusHod.TabIndex = 0;
            this.StatusHod.Text = "label1";
            // 
            // KardsAdd
            // 
            this.KardsAdd.Enabled = false;
            this.KardsAdd.Location = new System.Drawing.Point(756, 478);
            this.KardsAdd.Name = "KardsAdd";
            this.KardsAdd.Size = new System.Drawing.Size(117, 23);
            this.KardsAdd.TabIndex = 1;
            this.KardsAdd.Text = "Карты кинул!";
            this.KardsAdd.UseVisualStyleBackColor = true;
            this.KardsAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // Otboy
            // 
            this.Otboy.Enabled = false;
            this.Otboy.Location = new System.Drawing.Point(879, 478);
            this.Otboy.Name = "Otboy";
            this.Otboy.Size = new System.Drawing.Size(75, 23);
            this.Otboy.TabIndex = 2;
            this.Otboy.Text = "Отбой!";
            this.Otboy.UseVisualStyleBackColor = true;
            this.Otboy.Click += new System.EventHandler(this.Otboy_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Enabled = false;
            this.CancelButton.Location = new System.Drawing.Point(879, 449);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // MessageBot
            // 
            this.MessageBot.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MessageBot.Location = new System.Drawing.Point(807, 10);
            this.MessageBot.Name = "MessageBot";
            this.MessageBot.Size = new System.Drawing.Size(153, 41);
            this.MessageBot.TabIndex = 4;
            this.MessageBot.Text = "Привет! Го партейку?";
            this.MessageBot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Zabrat
            // 
            this.Zabrat.Enabled = false;
            this.Zabrat.Location = new System.Drawing.Point(756, 449);
            this.Zabrat.Name = "Zabrat";
            this.Zabrat.Size = new System.Drawing.Size(117, 23);
            this.Zabrat.TabIndex = 5;
            this.Zabrat.Text = "Забрать";
            this.Zabrat.UseVisualStyleBackColor = true;
            this.Zabrat.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::DurakGame.Properties.Resources.Dialog;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(795, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(178, 74);
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::DurakGame.Properties.Resources.BotSmile;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(814, 84);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(146, 94);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::DurakGame.Properties.Resources.Strelka;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(26, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 94);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(989, 517);
            this.Controls.Add(this.MessageBot);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Zabrat);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.Otboy);
            this.Controls.Add(this.KardsAdd);
            this.Controls.Add(this.StatusHod);
            this.Controls.Add(this.pictureBox3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StatusHod;
        private System.Windows.Forms.Button KardsAdd;
        private System.Windows.Forms.Button Otboy;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label MessageBot;
        private System.Windows.Forms.Button Zabrat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

