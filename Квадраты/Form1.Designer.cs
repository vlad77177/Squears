namespace Квадраты
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Pole = new System.Windows.Forms.PictureBox();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.buttonInf = new System.Windows.Forms.Button();
            this.labelGamerChips = new System.Windows.Forms.Label();
            this.labelComputerChips = new System.Windows.Forms.Label();
            this.buttonGuid = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxNice = new System.Windows.Forms.PictureBox();
            this.TimerMini = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Pole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNice)).BeginInit();
            this.SuspendLayout();
            // 
            // Pole
            // 
            this.Pole.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Pole.Location = new System.Drawing.Point(30, 30);
            this.Pole.Name = "Pole";
            this.Pole.Size = new System.Drawing.Size(500, 500);
            this.Pole.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Pole.TabIndex = 0;
            this.Pole.TabStop = false;
            this.Pole.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Pole_MouseClick);
            this.Pole.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pole_MouseMove);
            // 
            // labelX
            // 
            this.labelX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(551, 30);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(33, 17);
            this.labelX.TabIndex = 1;
            this.labelX.Text = "X: 0";
            // 
            // labelY
            // 
            this.labelY.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(551, 60);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(33, 17);
            this.labelY.TabIndex = 2;
            this.labelY.Text = "Y: 0";
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNewGame.Location = new System.Drawing.Point(557, 253);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(186, 53);
            this.buttonNewGame.TabIndex = 3;
            this.buttonNewGame.Text = "Новая игра";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // buttonInf
            // 
            this.buttonInf.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonInf.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonInf.Location = new System.Drawing.Point(557, 365);
            this.buttonInf.Name = "buttonInf";
            this.buttonInf.Size = new System.Drawing.Size(186, 32);
            this.buttonInf.TabIndex = 4;
            this.buttonInf.Text = "Информация";
            this.buttonInf.UseVisualStyleBackColor = true;
            this.buttonInf.Click += new System.EventHandler(this.buttonInf_Click);
            // 
            // labelGamerChips
            // 
            this.labelGamerChips.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelGamerChips.AutoSize = true;
            this.labelGamerChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGamerChips.Location = new System.Drawing.Point(30, 570);
            this.labelGamerChips.Name = "labelGamerChips";
            this.labelGamerChips.Size = new System.Drawing.Size(147, 20);
            this.labelGamerChips.TabIndex = 5;
            this.labelGamerChips.Text = "Ваши фишки: 32";
            // 
            // labelComputerChips
            // 
            this.labelComputerChips.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelComputerChips.AutoSize = true;
            this.labelComputerChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelComputerChips.Location = new System.Drawing.Point(325, 570);
            this.labelComputerChips.Name = "labelComputerChips";
            this.labelComputerChips.Size = new System.Drawing.Size(205, 20);
            this.labelComputerChips.TabIndex = 5;
            this.labelComputerChips.Text = "Фишки противника : 32";
            // 
            // buttonGuid
            // 
            this.buttonGuid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonGuid.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGuid.Location = new System.Drawing.Point(632, 30);
            this.buttonGuid.Name = "buttonGuid";
            this.buttonGuid.Size = new System.Drawing.Size(111, 47);
            this.buttonGuid.TabIndex = 6;
            this.buttonGuid.Text = "Правила";
            this.buttonGuid.UseVisualStyleBackColor = true;
            this.buttonGuid.Click += new System.EventHandler(this.buttonGuid_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Легко",
            "Нормально",
            "Сложно"});
            this.comboBox1.Location = new System.Drawing.Point(557, 214);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(186, 33);
            this.comboBox1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Location = new System.Drawing.Point(557, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 91);
            this.label1.TabIndex = 8;
            this.label1.Text = "Выберете сложность и нажмите \"Новая игра\". Вы не сможете изменить сложность в про" +
    "цессе игры.";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Location = new System.Drawing.Point(557, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 38);
            this.label2.TabIndex = 9;
            this.label2.Text = "Информация о собранных квадратах";
            // 
            // pictureBoxNice
            // 
            this.pictureBoxNice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxNice.Location = new System.Drawing.Point(599, 430);
            this.pictureBoxNice.Name = "pictureBoxNice";
            this.pictureBoxNice.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxNice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxNice.TabIndex = 10;
            this.pictureBoxNice.TabStop = false;
            // 
            // TimerMini
            // 
            this.TimerMini.Interval = 3000;
            this.TimerMini.Tick += new System.EventHandler(this.Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(782, 653);
            this.Controls.Add(this.pictureBoxNice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonGuid);
            this.Controls.Add(this.labelComputerChips);
            this.Controls.Add(this.labelGamerChips);
            this.Controls.Add(this.buttonInf);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.Pole);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Pole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Pole;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Button buttonInf;
        private System.Windows.Forms.Label labelGamerChips;
        private System.Windows.Forms.Label labelComputerChips;
        private System.Windows.Forms.Button buttonGuid;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxNice;
        private System.Windows.Forms.Timer TimerMini;
    }
}

