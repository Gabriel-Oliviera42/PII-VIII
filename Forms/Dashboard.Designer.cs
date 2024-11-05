namespace PII_VIII.Forms
{
    partial class Dashboard
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
            this.lblnome = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelsexo = new System.Windows.Forms.Label();
            this.labelnascimento = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelobjetivo = new System.Windows.Forms.Label();
            this.labelaltura = new System.Windows.Forms.Label();
            this.labelpeso = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblemail);
            this.panel1.Controls.Add(this.lblnome);
            this.panel1.Location = new System.Drawing.Point(86, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 498);
            this.panel1.TabIndex = 0;
            // 
            // lblnome
            // 
            this.lblnome.AutoSize = true;
            this.lblnome.Location = new System.Drawing.Point(20, 50);
            this.lblnome.Name = "lblnome";
            this.lblnome.Size = new System.Drawing.Size(44, 16);
            this.lblnome.TabIndex = 0;
            this.lblnome.Text = "label1";
            this.lblnome.Click += new System.EventHandler(this.lblnome_Click);
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Location = new System.Drawing.Point(20, 86);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(44, 16);
            this.lblemail.TabIndex = 1;
            this.lblemail.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Controls.Add(this.labelpeso);
            this.panel2.Controls.Add(this.labelaltura);
            this.panel2.Controls.Add(this.labelsexo);
            this.panel2.Controls.Add(this.labelnascimento);
            this.panel2.Location = new System.Drawing.Point(23, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(133, 128);
            this.panel2.TabIndex = 2;
            // 
            // labelsexo
            // 
            this.labelsexo.AutoSize = true;
            this.labelsexo.Location = new System.Drawing.Point(56, 46);
            this.labelsexo.Name = "labelsexo";
            this.labelsexo.Size = new System.Drawing.Size(44, 16);
            this.labelsexo.TabIndex = 1;
            this.labelsexo.Text = "label1";
            // 
            // labelnascimento
            // 
            this.labelnascimento.AutoSize = true;
            this.labelnascimento.Location = new System.Drawing.Point(56, 14);
            this.labelnascimento.Name = "labelnascimento";
            this.labelnascimento.Size = new System.Drawing.Size(44, 16);
            this.labelnascimento.TabIndex = 0;
            this.labelnascimento.Text = "label1";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel3.Controls.Add(this.labelobjetivo);
            this.panel3.Location = new System.Drawing.Point(23, 286);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(133, 128);
            this.panel3.TabIndex = 3;
            // 
            // labelobjetivo
            // 
            this.labelobjetivo.AutoSize = true;
            this.labelobjetivo.Location = new System.Drawing.Point(20, 50);
            this.labelobjetivo.Name = "labelobjetivo";
            this.labelobjetivo.Size = new System.Drawing.Size(44, 16);
            this.labelobjetivo.TabIndex = 0;
            this.labelobjetivo.Text = "label1";
            // 
            // labelaltura
            // 
            this.labelaltura.AutoSize = true;
            this.labelaltura.Location = new System.Drawing.Point(56, 72);
            this.labelaltura.Name = "labelaltura";
            this.labelaltura.Size = new System.Drawing.Size(44, 16);
            this.labelaltura.TabIndex = 2;
            this.labelaltura.Text = "label1";
            // 
            // labelpeso
            // 
            this.labelpeso.AutoSize = true;
            this.labelpeso.Location = new System.Drawing.Point(56, 97);
            this.labelpeso.Name = "labelpeso";
            this.labelpeso.Size = new System.Drawing.Size(44, 16);
            this.labelpeso.TabIndex = 3;
            this.labelpeso.Text = "label1";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 625);
            this.Controls.Add(this.panel1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lblnome;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelobjetivo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelsexo;
        private System.Windows.Forms.Label labelnascimento;
        private System.Windows.Forms.Label labelpeso;
        private System.Windows.Forms.Label labelaltura;
    }
}