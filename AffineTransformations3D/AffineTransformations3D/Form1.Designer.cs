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
            this.reflectZ_button = new System.Windows.Forms.Button();
            this.reflectY_button = new System.Windows.Forms.Button();
            this.reflectX_button = new System.Windows.Forms.Button();
            this.centerScale_button = new System.Windows.Forms.Button();
            this.rotateCenterZ_button = new System.Windows.Forms.Button();
            this.rotateCenterY_button = new System.Windows.Forms.Button();
            this.rotateCenterX_button = new System.Windows.Forms.Button();
            this.point2Y_text = new System.Windows.Forms.TextBox();
            this.point2X_text = new System.Windows.Forms.TextBox();
            this.point1Y_text = new System.Windows.Forms.TextBox();
            this.point1X_text = new System.Windows.Forms.TextBox();
            this.lineRotate_button = new System.Windows.Forms.Button();
            this.point1Z_text = new System.Windows.Forms.TextBox();
            this.point2Z_text = new System.Windows.Forms.TextBox();
            this.button_ortX = new System.Windows.Forms.Button();
            this.button_ortY = new System.Windows.Forms.Button();
            this.button_ortZ = new System.Windows.Forms.Button();
            this.radioButton_ortX = new System.Windows.Forms.RadioButton();
            this.radioButton_ortY = new System.Windows.Forms.RadioButton();
            this.radioButton_ortZ = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_perspect = new System.Windows.Forms.RadioButton();
            this.radioButton_isometr = new System.Windows.Forms.RadioButton();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.icosahedron_radioButton = new System.Windows.Forms.RadioButton();
            this.radioDodecahedron = new System.Windows.Forms.RadioButton();
            this.fragmentation_text = new System.Windows.Forms.TextBox();
            this.range1_text = new System.Windows.Forms.TextBox();
            this.range0_text = new System.Windows.Forms.TextBox();
            this.draw_func_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.load_figure_button = new System.Windows.Forms.Button();
            this.drawLine_button = new System.Windows.Forms.Button();
            this.axes_checkBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.area)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
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
            this.shift_x.Location = new System.Drawing.Point(578, 112);
            this.shift_x.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.shift_x.Name = "shift_x";
            this.shift_x.Size = new System.Drawing.Size(39, 20);
            this.shift_x.TabIndex = 5;
            this.shift_x.Text = "0";
            // 
            // shift_y
            // 
            this.shift_y.Location = new System.Drawing.Point(641, 112);
            this.shift_y.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.shift_y.Name = "shift_y";
            this.shift_y.Size = new System.Drawing.Size(41, 20);
            this.shift_y.TabIndex = 6;
            this.shift_y.Text = "0";
            // 
            // shift_z
            // 
            this.shift_z.Location = new System.Drawing.Point(707, 112);
            this.shift_z.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.shift_z.Name = "shift_z";
            this.shift_z.Size = new System.Drawing.Size(41, 20);
            this.shift_z.TabIndex = 7;
            this.shift_z.Text = "0";
            // 
            // shift_button
            // 
            this.shift_button.Location = new System.Drawing.Point(631, 141);
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
            this.text_rotate.Location = new System.Drawing.Point(608, 170);
            this.text_rotate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_rotate.Name = "text_rotate";
            this.text_rotate.Size = new System.Drawing.Size(30, 20);
            this.text_rotate.TabIndex = 9;
            this.text_rotate.Text = "0";
            // 
            // rotateX_button
            // 
            this.rotateX_button.Location = new System.Drawing.Point(566, 199);
            this.rotateX_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rotateX_button.Name = "rotateX_button";
            this.rotateX_button.Size = new System.Drawing.Size(76, 19);
            this.rotateX_button.TabIndex = 10;
            this.rotateX_button.Text = "Rotate X";
            this.rotateX_button.UseVisualStyleBackColor = true;
            this.rotateX_button.Click += new System.EventHandler(this.RotateX_button_Click);
            // 
            // rotateY_button
            // 
            this.rotateY_button.Location = new System.Drawing.Point(566, 221);
            this.rotateY_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rotateY_button.Name = "rotateY_button";
            this.rotateY_button.Size = new System.Drawing.Size(76, 19);
            this.rotateY_button.TabIndex = 11;
            this.rotateY_button.Text = "Rotate Y";
            this.rotateY_button.UseVisualStyleBackColor = true;
            this.rotateY_button.Click += new System.EventHandler(this.RotateY_button_Click);
            // 
            // rotateZ_button
            // 
            this.rotateZ_button.Location = new System.Drawing.Point(566, 243);
            this.rotateZ_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rotateZ_button.Name = "rotateZ_button";
            this.rotateZ_button.Size = new System.Drawing.Size(76, 19);
            this.rotateZ_button.TabIndex = 12;
            this.rotateZ_button.Text = "Rotate Z";
            this.rotateZ_button.UseVisualStyleBackColor = true;
            this.rotateZ_button.Click += new System.EventHandler(this.RotateZ_button_Click);
            // 
            // scale_button
            // 
            this.scale_button.Location = new System.Drawing.Point(566, 305);
            this.scale_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.scale_button.Name = "scale_button";
            this.scale_button.Size = new System.Drawing.Size(76, 19);
            this.scale_button.TabIndex = 16;
            this.scale_button.Text = "Scale";
            this.scale_button.UseVisualStyleBackColor = true;
            this.scale_button.Click += new System.EventHandler(this.Scale_button_Click);
            // 
            // scaleZ_text
            // 
            this.scaleZ_text.Location = new System.Drawing.Point(707, 276);
            this.scaleZ_text.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.scaleZ_text.Name = "scaleZ_text";
            this.scaleZ_text.Size = new System.Drawing.Size(41, 20);
            this.scaleZ_text.TabIndex = 15;
            this.scaleZ_text.Text = "1,5";
            // 
            // scaleY_text
            // 
            this.scaleY_text.Location = new System.Drawing.Point(641, 275);
            this.scaleY_text.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.scaleY_text.Name = "scaleY_text";
            this.scaleY_text.Size = new System.Drawing.Size(41, 20);
            this.scaleY_text.TabIndex = 14;
            this.scaleY_text.Text = "1,5";
            // 
            // scaleX_text
            // 
            this.scaleX_text.Cursor = System.Windows.Forms.Cursors.Default;
            this.scaleX_text.Location = new System.Drawing.Point(578, 275);
            this.scaleX_text.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.scaleX_text.Name = "scaleX_text";
            this.scaleX_text.Size = new System.Drawing.Size(39, 20);
            this.scaleX_text.TabIndex = 13;
            this.scaleX_text.Text = "1,5";
            // 
            // reflectZ_button
            // 
            this.reflectZ_button.Location = new System.Drawing.Point(566, 386);
            this.reflectZ_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reflectZ_button.Name = "reflectZ_button";
            this.reflectZ_button.Size = new System.Drawing.Size(76, 19);
            this.reflectZ_button.TabIndex = 19;
            this.reflectZ_button.Text = "Reflect Z";
            this.reflectZ_button.UseVisualStyleBackColor = true;
            this.reflectZ_button.Click += new System.EventHandler(this.ReflectZ_button_Click);
            // 
            // reflectY_button
            // 
            this.reflectY_button.Location = new System.Drawing.Point(566, 364);
            this.reflectY_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reflectY_button.Name = "reflectY_button";
            this.reflectY_button.Size = new System.Drawing.Size(76, 19);
            this.reflectY_button.TabIndex = 18;
            this.reflectY_button.Text = "Reflect Y";
            this.reflectY_button.UseVisualStyleBackColor = true;
            this.reflectY_button.Click += new System.EventHandler(this.ReflectY_button_Click);
            // 
            // reflectX_button
            // 
            this.reflectX_button.Location = new System.Drawing.Point(566, 342);
            this.reflectX_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reflectX_button.Name = "reflectX_button";
            this.reflectX_button.Size = new System.Drawing.Size(76, 19);
            this.reflectX_button.TabIndex = 17;
            this.reflectX_button.Text = "Reflect X";
            this.reflectX_button.UseVisualStyleBackColor = true;
            this.reflectX_button.Click += new System.EventHandler(this.ReflectX_button_Click);
            // 
            // centerScale_button
            // 
            this.centerScale_button.Location = new System.Drawing.Point(668, 305);
            this.centerScale_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.centerScale_button.Name = "centerScale_button";
            this.centerScale_button.Size = new System.Drawing.Size(101, 19);
            this.centerScale_button.TabIndex = 20;
            this.centerScale_button.Text = "Center scale";
            this.centerScale_button.UseVisualStyleBackColor = true;
            this.centerScale_button.Click += new System.EventHandler(this.CenterScale_button_Click);
            // 
            // rotateCenterZ_button
            // 
            this.rotateCenterZ_button.Location = new System.Drawing.Point(668, 243);
            this.rotateCenterZ_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rotateCenterZ_button.Name = "rotateCenterZ_button";
            this.rotateCenterZ_button.Size = new System.Drawing.Size(101, 19);
            this.rotateCenterZ_button.TabIndex = 23;
            this.rotateCenterZ_button.Text = "Rotate center Z";
            this.rotateCenterZ_button.UseVisualStyleBackColor = true;
            this.rotateCenterZ_button.Click += new System.EventHandler(this.RotateCenterZ_button_Click);
            // 
            // rotateCenterY_button
            // 
            this.rotateCenterY_button.Location = new System.Drawing.Point(668, 221);
            this.rotateCenterY_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rotateCenterY_button.Name = "rotateCenterY_button";
            this.rotateCenterY_button.Size = new System.Drawing.Size(101, 19);
            this.rotateCenterY_button.TabIndex = 22;
            this.rotateCenterY_button.Text = "Rotate center Y";
            this.rotateCenterY_button.UseVisualStyleBackColor = true;
            this.rotateCenterY_button.Click += new System.EventHandler(this.RotateCenterY_button_Click);
            // 
            // rotateCenterX_button
            // 
            this.rotateCenterX_button.Location = new System.Drawing.Point(668, 199);
            this.rotateCenterX_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rotateCenterX_button.Name = "rotateCenterX_button";
            this.rotateCenterX_button.Size = new System.Drawing.Size(101, 19);
            this.rotateCenterX_button.TabIndex = 21;
            this.rotateCenterX_button.Text = "Rotate center X";
            this.rotateCenterX_button.UseVisualStyleBackColor = true;
            this.rotateCenterX_button.Click += new System.EventHandler(this.RotateCenterX_button_Click);
            // 
            // point2Y_text
            // 
            this.point2Y_text.Location = new System.Drawing.Point(660, 450);
            this.point2Y_text.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.point2Y_text.Name = "point2Y_text";
            this.point2Y_text.Size = new System.Drawing.Size(41, 20);
            this.point2Y_text.TabIndex = 104;
            this.point2Y_text.Text = "100";
            // 
            // point2X_text
            // 
            this.point2X_text.Location = new System.Drawing.Point(616, 450);
            this.point2X_text.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.point2X_text.Name = "point2X_text";
            this.point2X_text.Size = new System.Drawing.Size(41, 20);
            this.point2X_text.TabIndex = 103;
            this.point2X_text.Text = "0";
            // 
            // point1Y_text
            // 
            this.point1Y_text.Cursor = System.Windows.Forms.Cursors.Default;
            this.point1Y_text.Location = new System.Drawing.Point(661, 429);
            this.point1Y_text.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.point1Y_text.Name = "point1Y_text";
            this.point1Y_text.Size = new System.Drawing.Size(41, 20);
            this.point1Y_text.TabIndex = 101;
            this.point1Y_text.Text = "0";
            // 
            // point1X_text
            // 
            this.point1X_text.Cursor = System.Windows.Forms.Cursors.Default;
            this.point1X_text.Location = new System.Drawing.Point(616, 429);
            this.point1X_text.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.point1X_text.Name = "point1X_text";
            this.point1X_text.Size = new System.Drawing.Size(41, 20);
            this.point1X_text.TabIndex = 100;
            this.point1X_text.Text = "0";
            // 
            // lineRotate_button
            // 
            this.lineRotate_button.Location = new System.Drawing.Point(616, 474);
            this.lineRotate_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lineRotate_button.Name = "lineRotate_button";
            this.lineRotate_button.Size = new System.Drawing.Size(66, 19);
            this.lineRotate_button.TabIndex = 107;
            this.lineRotate_button.Text = "Line rotate";
            this.lineRotate_button.UseVisualStyleBackColor = true;
            this.lineRotate_button.Click += new System.EventHandler(this.LineRotate_button_Click);
            // 
            // point1Z_text
            // 
            this.point1Z_text.Cursor = System.Windows.Forms.Cursors.Default;
            this.point1Z_text.Location = new System.Drawing.Point(706, 429);
            this.point1Z_text.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.point1Z_text.Name = "point1Z_text";
            this.point1Z_text.Size = new System.Drawing.Size(41, 20);
            this.point1Z_text.TabIndex = 102;
            this.point1Z_text.Text = "200";
            // 
            // point2Z_text
            // 
            this.point2Z_text.Cursor = System.Windows.Forms.Cursors.Default;
            this.point2Z_text.Location = new System.Drawing.Point(704, 450);
            this.point2Z_text.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.point2Z_text.Name = "point2Z_text";
            this.point2Z_text.Size = new System.Drawing.Size(41, 20);
            this.point2Z_text.TabIndex = 105;
            this.point2Z_text.Text = "200";
            // 
            // button_ortX
            // 
            this.button_ortX.Location = new System.Drawing.Point(12, 410);
            this.button_ortX.Name = "button_ortX";
            this.button_ortX.Size = new System.Drawing.Size(69, 22);
            this.button_ortX.TabIndex = 31;
            this.button_ortX.Text = "ortX";
            this.button_ortX.UseVisualStyleBackColor = true;
            this.button_ortX.Click += new System.EventHandler(this.button_ortX_Click);
            // 
            // button_ortY
            // 
            this.button_ortY.Location = new System.Drawing.Point(87, 410);
            this.button_ortY.Name = "button_ortY";
            this.button_ortY.Size = new System.Drawing.Size(69, 22);
            this.button_ortY.TabIndex = 32;
            this.button_ortY.Text = "ortY";
            this.button_ortY.UseVisualStyleBackColor = true;
            this.button_ortY.Click += new System.EventHandler(this.button_ortY_Click);
            // 
            // button_ortZ
            // 
            this.button_ortZ.Location = new System.Drawing.Point(162, 410);
            this.button_ortZ.Name = "button_ortZ";
            this.button_ortZ.Size = new System.Drawing.Size(69, 22);
            this.button_ortZ.TabIndex = 33;
            this.button_ortZ.Text = "ortZ";
            this.button_ortZ.UseVisualStyleBackColor = true;
            this.button_ortZ.Click += new System.EventHandler(this.button_ortZ_Click);
            // 
            // radioButton_ortX
            // 
            this.radioButton_ortX.AutoSize = true;
            this.radioButton_ortX.Location = new System.Drawing.Point(6, 19);
            this.radioButton_ortX.Name = "radioButton_ortX";
            this.radioButton_ortX.Size = new System.Drawing.Size(44, 17);
            this.radioButton_ortX.TabIndex = 34;
            this.radioButton_ortX.TabStop = true;
            this.radioButton_ortX.Text = "ortX";
            this.radioButton_ortX.UseVisualStyleBackColor = true;
            // 
            // radioButton_ortY
            // 
            this.radioButton_ortY.AutoSize = true;
            this.radioButton_ortY.Location = new System.Drawing.Point(75, 19);
            this.radioButton_ortY.Name = "radioButton_ortY";
            this.radioButton_ortY.Size = new System.Drawing.Size(44, 17);
            this.radioButton_ortY.TabIndex = 35;
            this.radioButton_ortY.TabStop = true;
            this.radioButton_ortY.Text = "ortY";
            this.radioButton_ortY.UseVisualStyleBackColor = true;
            // 
            // radioButton_ortZ
            // 
            this.radioButton_ortZ.AutoSize = true;
            this.radioButton_ortZ.Location = new System.Drawing.Point(150, 18);
            this.radioButton_ortZ.Name = "radioButton_ortZ";
            this.radioButton_ortZ.Size = new System.Drawing.Size(44, 17);
            this.radioButton_ortZ.TabIndex = 36;
            this.radioButton_ortZ.TabStop = true;
            this.radioButton_ortZ.Text = "ortZ";
            this.radioButton_ortZ.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_perspect);
            this.groupBox1.Controls.Add(this.radioButton_isometr);
            this.groupBox1.Controls.Add(this.radioButton_ortZ);
            this.groupBox1.Controls.Add(this.radioButton_ortX);
            this.groupBox1.Controls.Add(this.radioButton_ortY);
            this.groupBox1.Location = new System.Drawing.Point(12, 438);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 54);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ort";
            // 
            // radioButton_perspect
            // 
            this.radioButton_perspect.AutoSize = true;
            this.radioButton_perspect.Location = new System.Drawing.Point(298, 19);
            this.radioButton_perspect.Name = "radioButton_perspect";
            this.radioButton_perspect.Size = new System.Drawing.Size(66, 17);
            this.radioButton_perspect.TabIndex = 38;
            this.radioButton_perspect.TabStop = true;
            this.radioButton_perspect.Text = "perspect";
            this.radioButton_perspect.UseVisualStyleBackColor = true;
            // 
            // radioButton_isometr
            // 
            this.radioButton_isometr.AutoSize = true;
            this.radioButton_isometr.Location = new System.Drawing.Point(218, 18);
            this.radioButton_isometr.Name = "radioButton_isometr";
            this.radioButton_isometr.Size = new System.Drawing.Size(58, 17);
            this.radioButton_isometr.TabIndex = 37;
            this.radioButton_isometr.TabStop = true;
            this.radioButton_isometr.Text = "isometr";
            this.radioButton_isometr.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(334, 410);
            this.trackBar1.Maximum = 200;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(211, 45);
            this.trackBar1.TabIndex = 39;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // icosahedron_radioButton
            // 
            this.icosahedron_radioButton.AutoSize = true;
            this.icosahedron_radioButton.Location = new System.Drawing.Point(671, 23);
            this.icosahedron_radioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.icosahedron_radioButton.Name = "icosahedron_radioButton";
            this.icosahedron_radioButton.Size = new System.Drawing.Size(84, 17);
            this.icosahedron_radioButton.TabIndex = 40;
            this.icosahedron_radioButton.TabStop = true;
            this.icosahedron_radioButton.Text = "Icosahedron";
            this.icosahedron_radioButton.UseVisualStyleBackColor = true;
            // 
            // radioDodecahedron
            // 
            this.radioDodecahedron.AutoSize = true;
            this.radioDodecahedron.Location = new System.Drawing.Point(671, 45);
            this.radioDodecahedron.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioDodecahedron.Name = "radioDodecahedron";
            this.radioDodecahedron.Size = new System.Drawing.Size(96, 17);
            this.radioDodecahedron.TabIndex = 41;
            this.radioDodecahedron.TabStop = true;
            this.radioDodecahedron.Text = "Dodecahedron";
            this.radioDodecahedron.UseVisualStyleBackColor = true;
            // 
            // fragmentation_text
            // 
            this.fragmentation_text.Cursor = System.Windows.Forms.Cursors.Default;
            this.fragmentation_text.Location = new System.Drawing.Point(101, 497);
            this.fragmentation_text.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fragmentation_text.Name = "fragmentation_text";
            this.fragmentation_text.Size = new System.Drawing.Size(41, 20);
            this.fragmentation_text.TabIndex = 44;
            this.fragmentation_text.Text = "0";
            // 
            // range1_text
            // 
            this.range1_text.Location = new System.Drawing.Point(56, 497);
            this.range1_text.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.range1_text.Name = "range1_text";
            this.range1_text.Size = new System.Drawing.Size(41, 20);
            this.range1_text.TabIndex = 43;
            this.range1_text.Text = "0";
            // 
            // range0_text
            // 
            this.range0_text.Location = new System.Drawing.Point(11, 497);
            this.range0_text.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.range0_text.Name = "range0_text";
            this.range0_text.Size = new System.Drawing.Size(41, 20);
            this.range0_text.TabIndex = 42;
            this.range0_text.Text = "0";
            // 
            // draw_func_button
            // 
            this.draw_func_button.Location = new System.Drawing.Point(24, 526);
            this.draw_func_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.draw_func_button.Name = "draw_func_button";
            this.draw_func_button.Size = new System.Drawing.Size(104, 19);
            this.draw_func_button.TabIndex = 45;
            this.draw_func_button.Text = "Draw function";
            this.draw_func_button.UseVisualStyleBackColor = true;
            this.draw_func_button.Click += new System.EventHandler(this.Draw_func_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(558, 115);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(621, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(687, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Z:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(564, 172);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Angle:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(558, 275);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "X:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(621, 277);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Y:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(687, 277);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Z:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(550, 431);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "First point:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(540, 450);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 54;
            this.label9.Text = "Second point:";
            // 
            // load_figure_button
            // 
            this.load_figure_button.Location = new System.Drawing.Point(182, 497);
            this.load_figure_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.load_figure_button.Name = "load_figure_button";
            this.load_figure_button.Size = new System.Drawing.Size(105, 26);
            this.load_figure_button.TabIndex = 55;
            this.load_figure_button.Text = "Load figure";
            this.load_figure_button.UseVisualStyleBackColor = true;
            this.load_figure_button.Click += new System.EventHandler(this.load_figure_button_Click);
            // 
            // drawLine_button
            // 
            this.drawLine_button.Location = new System.Drawing.Point(688, 474);
            this.drawLine_button.Name = "drawLine_button";
            this.drawLine_button.Size = new System.Drawing.Size(59, 19);
            this.drawLine_button.TabIndex = 106;
            this.drawLine_button.Text = "Draw line";
            this.drawLine_button.UseVisualStyleBackColor = true;
            this.drawLine_button.Click += new System.EventHandler(this.drawLine_button_Click);
            // 
            // axes_checkBox
            // 
            this.axes_checkBox.AutoSize = true;
            this.axes_checkBox.Checked = true;
            this.axes_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.axes_checkBox.Location = new System.Drawing.Point(543, 474);
            this.axes_checkBox.Name = "axes_checkBox";
            this.axes_checkBox.Size = new System.Drawing.Size(46, 17);
            this.axes_checkBox.TabIndex = 108;
            this.axes_checkBox.Text = "Оси";
            this.axes_checkBox.UseVisualStyleBackColor = true;
            this.axes_checkBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 562);
            this.Controls.Add(this.axes_checkBox);
            this.Controls.Add(this.drawLine_button);
            this.Controls.Add(this.load_figure_button);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.draw_func_button);
            this.Controls.Add(this.fragmentation_text);
            this.Controls.Add(this.range1_text);
            this.Controls.Add(this.range0_text);
            this.Controls.Add(this.radioDodecahedron);
            this.Controls.Add(this.icosahedron_radioButton);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_ortZ);
            this.Controls.Add(this.button_ortY);
            this.Controls.Add(this.button_ortX);
            this.Controls.Add(this.point2Z_text);
            this.Controls.Add(this.point1Z_text);
            this.Controls.Add(this.lineRotate_button);
            this.Controls.Add(this.point1X_text);
            this.Controls.Add(this.point2Y_text);
            this.Controls.Add(this.point2X_text);
            this.Controls.Add(this.point1Y_text);
            this.Controls.Add(this.rotateCenterZ_button);
            this.Controls.Add(this.rotateCenterY_button);
            this.Controls.Add(this.rotateCenterX_button);
            this.Controls.Add(this.centerScale_button);
            this.Controls.Add(this.reflectZ_button);
            this.Controls.Add(this.reflectY_button);
            this.Controls.Add(this.reflectX_button);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
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
        private System.Windows.Forms.Button reflectZ_button;
        private System.Windows.Forms.Button reflectY_button;
        private System.Windows.Forms.Button reflectX_button;
        private System.Windows.Forms.Button centerScale_button;
        private System.Windows.Forms.Button rotateCenterZ_button;
        private System.Windows.Forms.Button rotateCenterY_button;
        private System.Windows.Forms.Button rotateCenterX_button;
        private System.Windows.Forms.TextBox point2Y_text;
        private System.Windows.Forms.TextBox point2X_text;
        private System.Windows.Forms.TextBox point1Y_text;
        private System.Windows.Forms.TextBox point1X_text;
        private System.Windows.Forms.Button lineRotate_button;
        private System.Windows.Forms.TextBox point1Z_text;
        private System.Windows.Forms.TextBox point2Z_text;
        private System.Windows.Forms.Button button_ortX;
        private System.Windows.Forms.Button button_ortY;
        private System.Windows.Forms.Button button_ortZ;
        private System.Windows.Forms.RadioButton radioButton_ortX;
        private System.Windows.Forms.RadioButton radioButton_ortY;
        private System.Windows.Forms.RadioButton radioButton_ortZ;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_isometr;
        private System.Windows.Forms.RadioButton radioButton_perspect;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.RadioButton icosahedron_radioButton;
        private System.Windows.Forms.RadioButton radioDodecahedron;
        private System.Windows.Forms.TextBox fragmentation_text;
        private System.Windows.Forms.TextBox range1_text;
        private System.Windows.Forms.TextBox range0_text;
        private System.Windows.Forms.Button draw_func_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button load_figure_button;
        private System.Windows.Forms.Button drawLine_button;
        private System.Windows.Forms.CheckBox axes_checkBox;
    }
}

