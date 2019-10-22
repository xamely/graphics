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
            this.text_rotate = new System.Windows.Forms.TextBox();
            this.rotateX_button = new System.Windows.Forms.Button();
            this.rotateY_button = new System.Windows.Forms.Button();
            this.rotateZ_button = new System.Windows.Forms.Button();
            this.scale_button = new System.Windows.Forms.Button();
            this.scaleZ_text = new System.Windows.Forms.TextBox();
            this.scaleY_text = new System.Windows.Forms.TextBox();
            this.scaleX_text = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.area)).BeginInit();
            this.SuspendLayout();
            // 
            // area
            // 
            this.area.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.area.Location = new System.Drawing.Point(12, 10);
            this.area.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(534, 395);
            this.area.TabIndex = 0;
            this.area.TabStop = false;
            // 
            // draw_button
            // 
            this.draw_button.Location = new System.Drawing.Point(566, 67);
            this.draw_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.draw_button.Name = "draw_button";
            this.draw_button.Size = new System.Drawing.Size(93, 28);
            this.draw_button.TabIndex = 1;
            this.draw_button.Text = "Draw figure";
            this.draw_button.UseVisualStyleBackColor = true;
            this.draw_button.Click += new System.EventHandler(this.draw_button_Click);
            // 
            // radioTetrahedron
            // 
            this.radioTetrahedron.AutoSize = true;
            this.radioTetrahedron.Location = new System.Drawing.Point(566, 23);
            this.radioTetrahedron.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioTetrahedron.Name = "radioTetrahedron";
            this.radioTetrahedron.Size = new System.Drawing.Size(83, 17);
            this.radioTetrahedron.TabIndex = 2;
            this.radioTetrahedron.TabStop = true;
            this.radioTetrahedron.Text = "Tetrahedron";
            this.radioTetrahedron.UseVisualStyleBackColor = true;
            // 
            // radioCube
            // 
            this.radioCube.AutoSize = true;
            this.radioCube.Location = new System.Drawing.Point(566, 45);
            this.radioCube.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioCube.Name = "radioCube";
            this.radioCube.Size = new System.Drawing.Size(50, 17);
            this.radioCube.TabIndex = 3;
            this.radioCube.TabStop = true;
            this.radioCube.Text = "Cube";
            this.radioCube.UseVisualStyleBackColor = true;
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(671, 67);
            this.clear_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(90, 28);
            this.clear_button.TabIndex = 4;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // shift_x
            // 
            this.shift_x.Cursor = System.Windows.Forms.Cursors.Default;
            this.shift_x.Location = new System.Drawing.Point(578, 128);
            this.shift_x.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.shift_x.Name = "shift_x";
            this.shift_x.Size = new System.Drawing.Size(41, 20);
            this.shift_x.TabIndex = 5;
            this.shift_x.Text = "0";
            // 
            // shift_y
            // 
            this.shift_y.Location = new System.Drawing.Point(641, 128);
            this.shift_y.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.shift_y.Name = "shift_y";
            this.shift_y.Size = new System.Drawing.Size(41, 20);
            this.shift_y.TabIndex = 6;
            this.shift_y.Text = "0";
            // 
            // shift_z
            // 
            this.shift_z.Location = new System.Drawing.Point(706, 128);
            this.shift_z.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.shift_z.Name = "shift_z";
            this.shift_z.Size = new System.Drawing.Size(41, 20);
            this.shift_z.TabIndex = 7;
            this.shift_z.Text = "0";
            // 
            // shift_button
            // 
            this.shift_button.Location = new System.Drawing.Point(691, 152);
            this.shift_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.shift_button.Name = "shift_button";
            this.shift_button.Size = new System.Drawing.Size(56, 19);
            this.shift_button.TabIndex = 8;
            this.shift_button.Text = "Shift";
            this.shift_button.UseVisualStyleBackColor = true;
            this.shift_button.Click += new System.EventHandler(this.shift_button_Click);
            // 
            // text_rotate
            // 
            this.text_rotate.Cursor = System.Windows.Forms.Cursors.Default;
            this.text_rotate.Location = new System.Drawing.Point(706, 185);
            this.text_rotate.Margin = new System.Windows.Forms.Padding(2);
            this.text_rotate.Name = "text_rotate";
            this.text_rotate.Size = new System.Drawing.Size(41, 20);
            this.text_rotate.TabIndex = 9;
            this.text_rotate.Text = "0";
            // 
            // rotateX_button
            // 
            this.rotateX_button.Location = new System.Drawing.Point(591, 209);
            this.rotateX_button.Margin = new System.Windows.Forms.Padding(2);
            this.rotateX_button.Name = "rotateX_button";
            this.rotateX_button.Size = new System.Drawing.Size(76, 19);
            this.rotateX_button.TabIndex = 10;
            this.rotateX_button.Text = "Rotate X";
            this.rotateX_button.UseVisualStyleBackColor = true;
            this.rotateX_button.Click += new System.EventHandler(this.RotateX_button_Click);
            // 
            // rotateY_button
            // 
            this.rotateY_button.Location = new System.Drawing.Point(671, 209);
            this.rotateY_button.Margin = new System.Windows.Forms.Padding(2);
            this.rotateY_button.Name = "rotateY_button";
            this.rotateY_button.Size = new System.Drawing.Size(76, 19);
            this.rotateY_button.TabIndex = 11;
            this.rotateY_button.Text = "Rotate Y";
            this.rotateY_button.UseVisualStyleBackColor = true;
            this.rotateY_button.Click += new System.EventHandler(this.RotateY_button_Click);
            // 
            // rotateZ_button
            // 
            this.rotateZ_button.Location = new System.Drawing.Point(671, 232);
            this.rotateZ_button.Margin = new System.Windows.Forms.Padding(2);
            this.rotateZ_button.Name = "rotateZ_button";
            this.rotateZ_button.Size = new System.Drawing.Size(76, 19);
            this.rotateZ_button.TabIndex = 12;
            this.rotateZ_button.Text = "Rotate Z";
            this.rotateZ_button.UseVisualStyleBackColor = true;
            this.rotateZ_button.Click += new System.EventHandler(this.RotateZ_button_Click);
            // 
            // scale_button
            // 
            this.scale_button.Location = new System.Drawing.Point(691, 292);
            this.scale_button.Margin = new System.Windows.Forms.Padding(2);
            this.scale_button.Name = "scale_button";
            this.scale_button.Size = new System.Drawing.Size(56, 19);
            this.scale_button.TabIndex = 16;
            this.scale_button.Text = "Scale";
            this.scale_button.UseVisualStyleBackColor = true;
            this.scale_button.Click += new System.EventHandler(this.Scale_button_Click);
            // 
            // scaleZ_text
            // 
            this.scaleZ_text.Location = new System.Drawing.Point(706, 268);
            this.scaleZ_text.Margin = new System.Windows.Forms.Padding(2);
            this.scaleZ_text.Name = "scaleZ_text";
            this.scaleZ_text.Size = new System.Drawing.Size(41, 20);
            this.scaleZ_text.TabIndex = 15;
            this.scaleZ_text.Text = "0";
            // 
            // scaleY_text
            // 
            this.scaleY_text.Location = new System.Drawing.Point(641, 268);
            this.scaleY_text.Margin = new System.Windows.Forms.Padding(2);
            this.scaleY_text.Name = "scaleY_text";
            this.scaleY_text.Size = new System.Drawing.Size(41, 20);
            this.scaleY_text.TabIndex = 14;
            this.scaleY_text.Text = "0";
            // 
            // scaleX_text
            // 
            this.scaleX_text.Cursor = System.Windows.Forms.Cursors.Default;
            this.scaleX_text.Location = new System.Drawing.Point(578, 268);
            this.scaleX_text.Margin = new System.Windows.Forms.Padding(2);
            this.scaleX_text.Name = "scaleX_text";
            this.scaleX_text.Size = new System.Drawing.Size(41, 20);
            this.scaleX_text.TabIndex = 13;
            this.scaleX_text.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 414);
            this.Controls.Add(this.scale_button);
            this.Controls.Add(this.scaleZ_text);
            this.Controls.Add(this.scaleY_text);
            this.Controls.Add(this.scaleX_text);
            this.Controls.Add(this.rotateZ_button);
            this.Controls.Add(this.rotateY_button);
            this.Controls.Add(this.rotateX_button);
            this.Controls.Add(this.text_rotate);
            this.Controls.Add(this.shift_button);
            this.Controls.Add(this.shift_z);
            this.Controls.Add(this.shift_y);
            this.Controls.Add(this.shift_x);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.radioCube);
            this.Controls.Add(this.radioTetrahedron);
            this.Controls.Add(this.draw_button);
            this.Controls.Add(this.area);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.TextBox text_rotate;
        private System.Windows.Forms.Button rotateX_button;
        private System.Windows.Forms.Button rotateY_button;
        private System.Windows.Forms.Button rotateZ_button;
        private System.Windows.Forms.Button scale_button;
        private System.Windows.Forms.TextBox scaleZ_text;
        private System.Windows.Forms.TextBox scaleY_text;
        private System.Windows.Forms.TextBox scaleX_text;
    }
}

