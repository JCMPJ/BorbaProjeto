﻿namespace BorbaProjeto
{
    partial class SearchForm
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
            this.rbtnReclamada = new System.Windows.Forms.RadioButton();
            this.rbtnReclamante = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNomeProcurado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvLaudos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numProcesso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeReclamante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeReclamada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataEmissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditarLaudo = new System.Windows.Forms.Button();
            this.LB_Voltar = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaudos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbtnReclamada
            // 
            this.rbtnReclamada.AutoSize = true;
            this.rbtnReclamada.Location = new System.Drawing.Point(110, 0);
            this.rbtnReclamada.Name = "rbtnReclamada";
            this.rbtnReclamada.Size = new System.Drawing.Size(97, 21);
            this.rbtnReclamada.TabIndex = 11;
            this.rbtnReclamada.TabStop = true;
            this.rbtnReclamada.Text = "Reclamada";
            this.rbtnReclamada.UseVisualStyleBackColor = true;
            this.rbtnReclamada.Click += new System.EventHandler(this.BTN_BuscarPor_Alterado);
            // 
            // rbtnReclamante
            // 
            this.rbtnReclamante.AutoSize = true;
            this.rbtnReclamante.Location = new System.Drawing.Point(0, 2);
            this.rbtnReclamante.Name = "rbtnReclamante";
            this.rbtnReclamante.Size = new System.Drawing.Size(101, 21);
            this.rbtnReclamante.TabIndex = 10;
            this.rbtnReclamante.TabStop = true;
            this.rbtnReclamante.Text = "Reclamante";
            this.rbtnReclamante.UseVisualStyleBackColor = true;
            this.rbtnReclamante.Click += new System.EventHandler(this.BTN_BuscarPor_Alterado);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Procura por:";
            // 
            // tbNomeProcurado
            // 
            this.tbNomeProcurado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNomeProcurado.Location = new System.Drawing.Point(65, 90);
            this.tbNomeProcurado.Name = "tbNomeProcurado";
            this.tbNomeProcurado.Size = new System.Drawing.Size(240, 23);
            this.tbNomeProcurado.TabIndex = 8;
            this.tbNomeProcurado.TextChanged += new System.EventHandler(this.TB_NomeProcurado_TextChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nome:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnReclamada);
            this.groupBox1.Controls.Add(this.rbtnReclamante);
            this.groupBox1.Location = new System.Drawing.Point(100, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 29);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dgvLaudos
            // 
            this.dgvLaudos.AllowUserToAddRows = false;
            this.dgvLaudos.AllowUserToDeleteRows = false;
            this.dgvLaudos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLaudos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLaudos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaudos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.numProcesso,
            this.nomeReclamante,
            this.nomeReclamada,
            this.dataEmissao});
            this.dgvLaudos.Location = new System.Drawing.Point(319, 60);
            this.dgvLaudos.MaximumSize = new System.Drawing.Size(1600, 900);
            this.dgvLaudos.MultiSelect = false;
            this.dgvLaudos.Name = "dgvLaudos";
            this.dgvLaudos.ReadOnly = true;
            this.dgvLaudos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLaudos.Size = new System.Drawing.Size(623, 363);
            this.dgvLaudos.TabIndex = 15;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // numProcesso
            // 
            this.numProcesso.DataPropertyName = "numProcesso";
            this.numProcesso.HeaderText = "Nº Processo";
            this.numProcesso.Name = "numProcesso";
            this.numProcesso.ReadOnly = true;
            // 
            // nomeReclamante
            // 
            this.nomeReclamante.DataPropertyName = "nomeReclamante";
            this.nomeReclamante.HeaderText = "Reclamante";
            this.nomeReclamante.Name = "nomeReclamante";
            this.nomeReclamante.ReadOnly = true;
            // 
            // nomeReclamada
            // 
            this.nomeReclamada.DataPropertyName = "nomeReclamada";
            this.nomeReclamada.HeaderText = "Reclamada";
            this.nomeReclamada.Name = "nomeReclamada";
            this.nomeReclamada.ReadOnly = true;
            // 
            // dataEmissao
            // 
            this.dataEmissao.DataPropertyName = "dataEmissao";
            this.dataEmissao.HeaderText = "Emissão";
            this.dataEmissao.Name = "dataEmissao";
            this.dataEmissao.ReadOnly = true;
            // 
            // btnEditarLaudo
            // 
            this.btnEditarLaudo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEditarLaudo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarLaudo.Location = new System.Drawing.Point(578, 429);
            this.btnEditarLaudo.Name = "btnEditarLaudo";
            this.btnEditarLaudo.Size = new System.Drawing.Size(180, 40);
            this.btnEditarLaudo.TabIndex = 16;
            this.btnEditarLaudo.Text = "Editar Laudo";
            this.btnEditarLaudo.UseVisualStyleBackColor = false;
            this.btnEditarLaudo.Click += new System.EventHandler(this.btnEditarLaudo_Click);
            // 
            // LB_Voltar
            // 
            this.LB_Voltar.AutoSize = true;
            this.LB_Voltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LB_Voltar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.LB_Voltar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Voltar.Location = new System.Drawing.Point(10, 440);
            this.LB_Voltar.Name = "LB_Voltar";
            this.LB_Voltar.Size = new System.Drawing.Size(73, 19);
            this.LB_Voltar.TabIndex = 39;
            this.LB_Voltar.Text = "VOLTAR";
            this.LB_Voltar.Click += new System.EventHandler(this.LB_Voltar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BorbaProjeto.Properties.Resources.logo_JC_3x4;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 39);
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(300, 10);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Size = new System.Drawing.Size(379, 26);
            this.label3.TabIndex = 41;
            this.label3.Text = "Pesquisar em Laudos Cadastrados";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(944, 481);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LB_Voltar);
            this.Controls.Add(this.btnEditarLaudo);
            this.Controls.Add(this.dgvLaudos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNomeProcurado);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laudo Pericial - Pesquizar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaudos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnReclamada;
        private System.Windows.Forms.RadioButton rbtnReclamante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNomeProcurado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvLaudos;
        private System.Windows.Forms.Button btnEditarLaudo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn numProcesso;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeReclamante;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeReclamada;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataEmissao;
        private System.Windows.Forms.Label LB_Voltar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}