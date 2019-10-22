namespace AffineTransformations3D
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
            this.draw_button = new System.Windows.Forms.Button();
            this.radioTetrahedron = new System.Windows.Forms.RadioButton();
            this.radioCube = new System.Windows.Forms.RadioButton();
            this.clear_button = new System.Windows.Forms.Button();
            this.shift_x = new System.Windows.Forms.TextBox();
            this.shift_y = new System.Windows.Forms.TextBox();
            this.shift_z = new System.Windows.Forms.TextBox();
            this.shift_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.area)).BeginInit();
            this.SuspendLayout();
            // 
            // area
            // 
            this.area.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.area.Location = new System.Drawing.Point(16, 12);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(712, 486);
            this.area.TabIndex = 0;
            this.area.TabStop = false;
            // 
            // draw_button
            // 
            this.draw_button.Location = new System.Drawing.Point(755, 82);
            this.draw_button.Name = "draw_button";
            this.draw_button.Size = new System.Drawing.Size(124, 34);
            this.draw_button.TabIndex = 1;
            this.draw_button.Text = "Draw figure";
            this.draw_button.UseVisualStyleBackColor = true;
            this.draw_button.Click += new System.EventHandler(this.draw_button_Click);
            // 
            // radioTetrahedron
            // 
            this.radioTetrahedron.AutoSize = true;
            this.radioTetrahedron.Location = new System.Drawing.Point(755, 28);
            this.radioTetrahedron.Name = "radioTetrahedron";
            this.radioTetrahedron.Size = new System.Drawing.Size(108, 21);
            this.radioTetrahedron.TabIndex = 2;
            this.radioTetrahedron.TabStop = true;
            this.radioTetrahedron.Text = "Tetrahedron";
            this.radioTetrahedron.UseVisualStyleBackColor = true;
            // 
            // radioCube
            // 
            this.radioCube.AutoSize = true;
            this.radioCube.Location = new System.Drawing.Point(755, 55);
            this.radioCube.Name = "radioCube";
            this.radioCube.Size = new System.Drawing.Size(62, 21);
            this.radioCube.TabIndex = 3;
            this.radioCube.TabStop = true;
            this.radioCube.Text = "Cube";
            this.radioCube.UseVisualStyleBackColor = true;
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(895, 82);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(120, 34);
            this.clear_button.TabIndex = 4;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // shift_x
            // 
            this.shift_x.Cursor = System.Windows.Forms.Cursors.Default;
            this.shift_x.Location = new System.Drawing.Point(770, 158);
            this.shift_x.Name = "shift_x";
            this.shift_x.Size = new System.Drawing.Size(53, 22);
            this.shift_x.TabIndex = 5;
            this.shift_x.Text = "0";
            // 
            // shift_y
            // 
            this.shift_y.Location = new System.Drawing.Point(855, 158);
            this.shift_y.Name = "shift_y";
            this.shift_y.Size = new System.Drawing.Size(53, 22);
            this.shift_y.TabIndex = 6;
            this.shift_y.Text = "0";
            // 
            // shift_z
            // 
            this.shift_z.Location = new System.Drawing.Point(942, 158);
            this.shift_z.Name = "shift_z";
            this.shift_z.Size = new System.Drawing.Size(53, 22);
            this.shift_z.TabIndex = 7;
            this.shift_z.Text = "0";
            // 
            // shift_button
            // 
            this.shift_button.Location = new System.Drawing.Point(920, 186);
            this.shift_button.Name = "shift_button";
            this.shift_button.Size = new System.Drawing.Size(75, 23);
            this.shift_button.TabIndex = 8;
            this.shift_button.Text = "Shift";
            this.shift_button.UseVisualStyleBackColor = true;
            this.shift_button.Click += new System.EventHandler(this.shift_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 510);
            this.Controls.Add(this.shift_button);
            this.Controls.Add(this.shift_z);
            this.Controls.Add(this.shift_y);
            this.Controls.Add(this.shift_x);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.radioCube);
            this.Controls.Add(this.radioTetrahedron);
            this.Controls.Add(this.draw_button);
            this.Controls.Add(this.area);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.area)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox area;
        private System.Windows.Forms.Button draw_button;
        private System.Windows.Forms.RadioButton radioTetrahedron;
        private System.Windows.Forms.RadioButton radioCube;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.TextBox shift_x;
        private System.Windows.Forms.TextBox shift_y;
        private System.Windows.Forms.TextBox shift_z;
        private System.Windows.Forms.Button shift_button;
    }
}

