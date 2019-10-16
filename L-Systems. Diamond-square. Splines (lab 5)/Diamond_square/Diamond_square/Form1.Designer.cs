namespace Diamond_square
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
            this.draw = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Coefficient = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.area)).BeginInit();
            this.SuspendLayout();
            // 
            // area
            // 
            this.area.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.area.Location = new System.Drawing.Point(16, 14);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(659, 481);
            this.area.TabIndex = 0;
            this.area.TabStop = false;
            this.area.MouseDown += new System.Windows.Forms.MouseEventHandler(this.area_MouseDown);
            this.area.MouseUp += new System.Windows.Forms.MouseEventHandler(this.area_MouseUp);
            // 
            // draw
            // 
            this.draw.Location = new System.Drawing.Point(693, 68);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(178, 54);
            this.draw.TabIndex = 1;
            this.draw.Text = "Draw";
            this.draw.UseVisualStyleBackColor = true;
            this.draw.Click += new System.EventHandler(this.draw_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(693, 161);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(178, 54);
            this.clear.TabIndex = 2;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(709, 334);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(85, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "0,5";
            // 
            // Coefficient
            // 
            this.Coefficient.AutoSize = true;
            this.Coefficient.Location = new System.Drawing.Point(712, 309);
            this.Coefficient.Name = "Coefficient";
            this.Coefficient.Size = new System.Drawing.Size(78, 17);
            this.Coefficient.TabIndex = 4;
            this.Coefficient.Text = "Coefficient:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 511);
            this.Controls.Add(this.Coefficient);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.draw);
            this.Controls.Add(this.area);
            this.Name = "Form1";
            this.Text = "Diamond";
            ((System.ComponentModel.ISupportInitialize)(this.area)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox area;
        private System.Windows.Forms.Button draw;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Coefficient;
    }
}

