namespace AffineTransformations
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
            this.lineButton = new System.Windows.Forms.RadioButton();
            this.polygonButton = new System.Windows.Forms.RadioButton();
            this.lineOptionsBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.polygonOptionsBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RadioOrientationButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.area.TabIndex = 0;
            this.area.TabStop = false;
            this.area.MouseDown += new System.Windows.Forms.MouseEventHandler(this.area_MouseDown);
            this.area.MouseUp += new System.Windows.Forms.MouseEventHandler(this.area_MouseUp);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(511, 79);
            this.refresh.Margin = new System.Windows.Forms.Padding(2);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(108, 43);
            this.refresh.TabIndex = 1;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // dotButton
            // 
            this.dotButton.AutoSize = true;
            this.dotButton.Location = new System.Drawing.Point(516, 146);
            this.dotButton.Margin = new System.Windows.Forms.Padding(2);
            this.dotButton.Name = "dotButton";
            this.dotButton.Size = new System.Drawing.Size(42, 17);
            this.dotButton.TabIndex = 2;
            this.dotButton.TabStop = true;
            this.dotButton.Text = "Dot";
            this.dotButton.UseVisualStyleBackColor = true;
            // 
            // lineButton
            // 
            this.lineButton.AutoSize = true;
            this.lineButton.Location = new System.Drawing.Point(516, 168);
            this.lineButton.Margin = new System.Windows.Forms.Padding(2);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(45, 17);
            this.lineButton.TabIndex = 3;
            this.lineButton.TabStop = true;
            this.lineButton.Text = "Line";
            this.lineButton.UseVisualStyleBackColor = true;
            // 
            // polygonButton
            // 
            this.polygonButton.AutoSize = true;
            this.polygonButton.Location = new System.Drawing.Point(516, 190);
            this.polygonButton.Margin = new System.Windows.Forms.Padding(2);
            this.polygonButton.Name = "polygonButton";
            this.polygonButton.Size = new System.Drawing.Size(63, 17);
            this.polygonButton.TabIndex = 4;
            this.polygonButton.TabStop = true;
            this.polygonButton.Text = "Polygon";
            this.polygonButton.UseVisualStyleBackColor = true;
            // 
            // lineOptionsBox
            // 
            this.lineOptionsBox.FormattingEnabled = true;
            this.lineOptionsBox.Items.AddRange(new object[] {
            "Move",
            "Rotate 90 dgr around center",
            "Search for the intersection point of two lines",
            "Search orientation of point ",
            "Search orientation of point (Filling)"});
            this.lineOptionsBox.Location = new System.Drawing.Point(511, 245);
            this.lineOptionsBox.Margin = new System.Windows.Forms.Padding(2);
            this.lineOptionsBox.Name = "lineOptionsBox";
            this.lineOptionsBox.Size = new System.Drawing.Size(168, 21);
            this.lineOptionsBox.TabIndex = 5;
            this.lineOptionsBox.SelectedIndexChanged += new System.EventHandler(this.lineOptionsBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(514, 229);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Choose line option:";
            // 
            // polygonOptionsBox
            // 
            this.polygonOptionsBox.FormattingEnabled = true;
            this.polygonOptionsBox.Items.AddRange(new object[] {
            "Move",
            "Rotate around center",
            "Rotate around point",
            "Center scaling ",
            "Point scaling",
            "Check convex polygon(RightCheck)",
            "Check convex polygon(FillingRightCheck)"});
            this.polygonOptionsBox.Location = new System.Drawing.Point(511, 323);
            this.polygonOptionsBox.Margin = new System.Windows.Forms.Padding(2);
            this.polygonOptionsBox.Name = "polygonOptionsBox";
            this.polygonOptionsBox.Size = new System.Drawing.Size(168, 21);
            this.polygonOptionsBox.TabIndex = 7;
            this.polygonOptionsBox.SelectedIndexChanged += new System.EventHandler(this.PolygonOptionsBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(514, 306);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Choose polygon option:";
            // 
            // RadioOrientationButton
            // 
            this.RadioOrientationButton.AutoSize = true;
            this.RadioOrientationButton.Location = new System.Drawing.Point(582, 146);
            this.RadioOrientationButton.Name = "RadioOrientationButton";
            this.RadioOrientationButton.Size = new System.Drawing.Size(130, 17);
            this.RadioOrientationButton.TabIndex = 9;
            this.RadioOrientationButton.TabStop = true;
            this.RadioOrientationButton.Text = "Dot Orientation Check";
            this.RadioOrientationButton.UseVisualStyleBackColor = true;
            this.RadioOrientationButton.CheckedChanged += new System.EventHandler(this.RadioOrientationButton_CheckedChange);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(437, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 414);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 443);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RadioOrientationButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.polygonOptionsBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lineOptionsBox);
            this.Controls.Add(this.polygonButton);
            this.Controls.Add(this.lineButton);
            this.Controls.Add(this.dotButton);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.area);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.RadioButton lineButton;
        private System.Windows.Forms.RadioButton polygonButton;
        private System.Windows.Forms.ComboBox lineOptionsBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox polygonOptionsBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RadioOrientationButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

