namespace QuickHull
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
            this.builder = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.area)).BeginInit();
            this.SuspendLayout();
            // 
            // area
            // 
            this.area.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.area.Location = new System.Drawing.Point(31, 35);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(603, 440);
            this.area.TabIndex = 0;
            this.area.TabStop = false;
            this.area.MouseClick += new System.Windows.Forms.MouseEventHandler(this.area_MouseClick);
            // 
            // builder
            // 
            this.builder.Enabled = false;
            this.builder.Location = new System.Drawing.Point(662, 393);
            this.builder.Name = "builder";
            this.builder.Size = new System.Drawing.Size(131, 46);
            this.builder.TabIndex = 1;
            this.builder.Text = "Build the span";
            this.builder.UseVisualStyleBackColor = true;
            this.builder.Click += new System.EventHandler(this.builder_Click);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(662, 323);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(131, 45);
            this.refresh.TabIndex = 2;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 502);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.builder);
            this.Controls.Add(this.area);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.area)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox area;
        private System.Windows.Forms.Button builder;
        private System.Windows.Forms.Button refresh;
    }
}

