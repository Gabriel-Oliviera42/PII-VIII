﻿namespace PII_VIII
{
    partial class TesteConexaoNeo4j
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewResultados = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvAtividades = new System.Windows.Forms.DataGridView();
            this.comboBoxTreinos = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridViewregiao = new System.Windows.Forms.DataGridView();
            this.comboBoxAtividades = new System.Windows.Forms.ComboBox();
            this.btnbuscarregioes = new System.Windows.Forms.Button();
            this.comboBoxobjetivo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtividades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewregiao)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(659, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "Testar Conexão";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewResultados
            // 
            this.dataGridViewResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResultados.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewResultados.Name = "dataGridViewResultados";
            this.dataGridViewResultados.RowHeadersWidth = 51;
            this.dataGridViewResultados.RowTemplate.Height = 24;
            this.dataGridViewResultados.Size = new System.Drawing.Size(620, 361);
            this.dataGridViewResultados.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(659, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 48);
            this.button2.TabIndex = 2;
            this.button2.Text = "Preencher Tabela";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvAtividades
            // 
            this.dgvAtividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAtividades.Location = new System.Drawing.Point(25, 397);
            this.dgvAtividades.Name = "dgvAtividades";
            this.dgvAtividades.RowHeadersWidth = 51;
            this.dgvAtividades.RowTemplate.Height = 24;
            this.dgvAtividades.Size = new System.Drawing.Size(444, 239);
            this.dgvAtividades.TabIndex = 3;
            // 
            // comboBoxTreinos
            // 
            this.comboBoxTreinos.FormattingEnabled = true;
            this.comboBoxTreinos.Location = new System.Drawing.Point(535, 412);
            this.comboBoxTreinos.Name = "comboBoxTreinos";
            this.comboBoxTreinos.Size = new System.Drawing.Size(121, 24);
            this.comboBoxTreinos.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(612, 565);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridViewregiao
            // 
            this.dataGridViewregiao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewregiao.Location = new System.Drawing.Point(843, 179);
            this.dataGridViewregiao.Name = "dataGridViewregiao";
            this.dataGridViewregiao.RowHeadersWidth = 51;
            this.dataGridViewregiao.RowTemplate.Height = 24;
            this.dataGridViewregiao.Size = new System.Drawing.Size(467, 361);
            this.dataGridViewregiao.TabIndex = 6;
            // 
            // comboBoxAtividades
            // 
            this.comboBoxAtividades.FormattingEnabled = true;
            this.comboBoxAtividades.Location = new System.Drawing.Point(941, 130);
            this.comboBoxAtividades.Name = "comboBoxAtividades";
            this.comboBoxAtividades.Size = new System.Drawing.Size(121, 24);
            this.comboBoxAtividades.TabIndex = 7;
            // 
            // btnbuscarregioes
            // 
            this.btnbuscarregioes.Location = new System.Drawing.Point(1115, 131);
            this.btnbuscarregioes.Name = "btnbuscarregioes";
            this.btnbuscarregioes.Size = new System.Drawing.Size(75, 23);
            this.btnbuscarregioes.TabIndex = 8;
            this.btnbuscarregioes.Text = "button4";
            this.btnbuscarregioes.UseVisualStyleBackColor = true;
            this.btnbuscarregioes.Click += new System.EventHandler(this.btnbuscarregioes_Click);
            // 
            // comboBoxobjetivo
            // 
            this.comboBoxobjetivo.FormattingEnabled = true;
            this.comboBoxobjetivo.Location = new System.Drawing.Point(751, 657);
            this.comboBoxobjetivo.Name = "comboBoxobjetivo";
            this.comboBoxobjetivo.Size = new System.Drawing.Size(201, 24);
            this.comboBoxobjetivo.TabIndex = 9;
            this.comboBoxobjetivo.SelectedIndexChanged += new System.EventHandler(this.comboBoxobjetivo_SelectedIndexChanged);
            // 
            // TesteConexaoNeo4j
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 728);
            this.Controls.Add(this.comboBoxobjetivo);
            this.Controls.Add(this.btnbuscarregioes);
            this.Controls.Add(this.comboBoxAtividades);
            this.Controls.Add(this.dataGridViewregiao);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBoxTreinos);
            this.Controls.Add(this.dgvAtividades);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridViewResultados);
            this.Controls.Add(this.button1);
            this.Name = "TesteConexaoNeo4j";
            this.Text = "TesteConexaoNeo4j";
            this.Load += new System.EventHandler(this.TesteConexaoNeo4j_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtividades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewregiao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewResultados;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvAtividades;
        private System.Windows.Forms.ComboBox comboBoxTreinos;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridViewregiao;
        private System.Windows.Forms.ComboBox comboBoxAtividades;
        private System.Windows.Forms.Button btnbuscarregioes;
        private System.Windows.Forms.ComboBox comboBoxobjetivo;
    }
}