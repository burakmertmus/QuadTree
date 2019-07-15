namespace Quadtree
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.Rastgele = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.sorgu = new System.Windows.Forms.Button();
            this.textbox_dugum = new System.Windows.Forms.TextBox();
            this.cemberBoyut = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.radioSorgu = new System.Windows.Forms.RadioButton();
            this.radioDugum = new System.Windows.Forms.RadioButton();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dugumBasla = new System.Windows.Forms.Button();
            this.rastgeleBasla = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 512);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // Rastgele
            // 
            this.Rastgele.Location = new System.Drawing.Point(558, 90);
            this.Rastgele.Name = "Rastgele";
            this.Rastgele.Size = new System.Drawing.Size(75, 23);
            this.Rastgele.TabIndex = 1;
            this.Rastgele.Text = "Rastgele";
            this.Rastgele.UseVisualStyleBackColor = true;
            this.Rastgele.Click += new System.EventHandler(this.Rastgele_Click);
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.Color.DarkRed;
            this.reset.Cursor = System.Windows.Forms.Cursors.Default;
            this.reset.ForeColor = System.Drawing.SystemColors.Control;
            this.reset.Location = new System.Drawing.Point(715, 499);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 2;
            this.reset.Text = "Sıfırla";
            this.reset.UseVisualStyleBackColor = false;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // sorgu
            // 
            this.sorgu.Location = new System.Drawing.Point(558, 59);
            this.sorgu.Name = "sorgu";
            this.sorgu.Size = new System.Drawing.Size(75, 23);
            this.sorgu.TabIndex = 3;
            this.sorgu.Text = "Sorgu Yap";
            this.sorgu.UseVisualStyleBackColor = true;
            this.sorgu.Click += new System.EventHandler(this.sorgu_Click);
            // 
            // textbox_dugum
            // 
            this.textbox_dugum.BackColor = System.Drawing.Color.AliceBlue;
            this.textbox_dugum.Location = new System.Drawing.Point(643, 92);
            this.textbox_dugum.Name = "textbox_dugum";
            this.textbox_dugum.Size = new System.Drawing.Size(55, 20);
            this.textbox_dugum.TabIndex = 5;
            this.textbox_dugum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_dugum_KeyDown);
            this.textbox_dugum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // cemberBoyut
            // 
            this.cemberBoyut.BackColor = System.Drawing.Color.AliceBlue;
            this.cemberBoyut.Location = new System.Drawing.Point(644, 62);
            this.cemberBoyut.Name = "cemberBoyut";
            this.cemberBoyut.Size = new System.Drawing.Size(54, 20);
            this.cemberBoyut.TabIndex = 6;
            this.cemberBoyut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cemberBoyut_KeyDown);
            this.cemberBoyut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cemberBoyut_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(555, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dugumler:";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listBox1.Font = new System.Drawing.Font("Viner Hand ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(558, 131);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(151, 186);
            this.listBox1.TabIndex = 8;
            // 
            // radioSorgu
            // 
            this.radioSorgu.AutoSize = true;
            this.radioSorgu.Location = new System.Drawing.Point(644, 12);
            this.radioSorgu.Name = "radioSorgu";
            this.radioSorgu.Size = new System.Drawing.Size(75, 17);
            this.radioSorgu.TabIndex = 9;
            this.radioSorgu.TabStop = true;
            this.radioSorgu.Text = "Sorgu Yap";
            this.radioSorgu.UseVisualStyleBackColor = true;
            this.radioSorgu.CheckedChanged += new System.EventHandler(this.radioSorgu_CheckedChanged);
            // 
            // radioDugum
            // 
            this.radioDugum.AutoSize = true;
            this.radioDugum.Location = new System.Drawing.Point(548, 12);
            this.radioDugum.Name = "radioDugum";
            this.radioDugum.Size = new System.Drawing.Size(76, 17);
            this.radioDugum.TabIndex = 10;
            this.radioDugum.TabStop = true;
            this.radioDugum.Text = "Dugum Ciz";
            this.radioDugum.UseVisualStyleBackColor = true;
            this.radioDugum.CheckedChanged += new System.EventHandler(this.radioDugum_CheckedChanged);
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.listBox2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(558, 342);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(151, 180);
            this.listBox2.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(545, 326);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Sorgulanan Dugumler:";
            // 
            // dugumBasla
            // 
            this.dugumBasla.Location = new System.Drawing.Point(128, 80);
            this.dugumBasla.Name = "dugumBasla";
            this.dugumBasla.Size = new System.Drawing.Size(75, 23);
            this.dugumBasla.TabIndex = 0;
            this.dugumBasla.Text = "Dugum Ciz";
            this.dugumBasla.UseVisualStyleBackColor = true;
            this.dugumBasla.Click += new System.EventHandler(this.dugumBasla_Click);
            // 
            // rastgeleBasla
            // 
            this.rastgeleBasla.Location = new System.Drawing.Point(266, 80);
            this.rastgeleBasla.Name = "rastgeleBasla";
            this.rastgeleBasla.Size = new System.Drawing.Size(75, 23);
            this.rastgeleBasla.TabIndex = 1;
            this.rastgeleBasla.Text = "Rastgele Ciz";
            this.rastgeleBasla.UseVisualStyleBackColor = true;
            this.rastgeleBasla.Click += new System.EventHandler(this.rastgeleBasla_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(946, 540);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.radioDugum);
            this.Controls.Add(this.radioSorgu);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cemberBoyut);
            this.Controls.Add(this.textbox_dugum);
            this.Controls.Add(this.sorgu);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.Rastgele);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rastgeleBasla);
            this.Controls.Add(this.dugumBasla);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Rastgele;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button sorgu;
        private System.Windows.Forms.TextBox textbox_dugum;
        private System.Windows.Forms.TextBox cemberBoyut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioSorgu;
        private System.Windows.Forms.RadioButton radioDugum;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button rastgeleBasla;
        private System.Windows.Forms.Button dugumBasla;

    }
}

