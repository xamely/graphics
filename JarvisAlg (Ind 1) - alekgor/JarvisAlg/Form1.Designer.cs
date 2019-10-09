namespace JarvisAlg
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
            this.area = new System.Windows.Forms.PictureBox();
            this.refresh = new System.Windows.Forms.Button();
            this.dotButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.area)).BeginInit();
            this.SuspendLayout();
            // 
            // area
            // 
            this.area.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.area.Location = new System.Drawing.Point(21, 26);
            this.area.Margin = new System.Windows.Forms.Padding(2);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(451, 386);
            this.area.TabIndex = 1;
            this.area.TabStop = false;
            this.area.MouseDown += new System.Windows.Forms.MouseEventHandler(this.area_MouseDown);
            this.area.MouseUp += new System.Windows.Forms.MouseEventHandler(this.area_MouseUp);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(526, 59);
            this.refresh.Margin = new System.Windows.Forms.Padding(2);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(108, 43);
            this.refresh.TabIndex = 2;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // dotButton
            // 
            this.dotButton.AutoSize = true;
            this.dotButton.Location = new System.Drawing.Point(558, 142);
            this.dotButton.Margin = new System.Windows.Forms.Padding(2);
            this.dotButton.Name = "dotButton";
            this.dotButton.Size = new System.Drawing.Size(42, 17);
            this.dotButton.TabIndex = 3;
            this.dotButton.TabStop = true;
            this.dotButton.Text = "Dot";
            this.dotButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(526, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 43);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(523, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 443);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dotButton);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.area);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.area)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox area;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.RadioButton dotButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

