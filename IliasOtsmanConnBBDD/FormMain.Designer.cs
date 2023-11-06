namespace IliasOtsmanConnBBDD
{
    partial class FormMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConnBtn = new System.Windows.Forms.Button();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.NewJobBtn = new System.Windows.Forms.Button();
            this.ShowJobBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConnBtn
            // 
            this.ConnBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnBtn.Location = new System.Drawing.Point(56, 44);
            this.ConnBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConnBtn.Name = "ConnBtn";
            this.ConnBtn.Size = new System.Drawing.Size(205, 90);
            this.ConnBtn.TabIndex = 0;
            this.ConnBtn.Text = "Crear Conexión";
            this.ConnBtn.UseVisualStyleBackColor = true;
            this.ConnBtn.Click += new System.EventHandler(this.ConnBtn_Click);
            // 
            // InfoLabel
            // 
            this.InfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InfoLabel.Location = new System.Drawing.Point(0, 0);
            this.InfoLabel.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(324, 44);
            this.InfoLabel.TabIndex = 1;
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBtn.Location = new System.Drawing.Point(56, 44);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(205, 90);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "Cerrar Conexión";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Visible = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // NewJobBtn
            // 
            this.NewJobBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.NewJobBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewJobBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.NewJobBtn.Location = new System.Drawing.Point(56, 146);
            this.NewJobBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewJobBtn.Name = "NewJobBtn";
            this.NewJobBtn.Size = new System.Drawing.Size(205, 52);
            this.NewJobBtn.TabIndex = 3;
            this.NewJobBtn.Text = "Crear nuevo trabajo";
            this.NewJobBtn.UseVisualStyleBackColor = false;
            this.NewJobBtn.Visible = false;
            this.NewJobBtn.Click += new System.EventHandler(this.AddJobBtn_Click);
            // 
            // ShowJobBtn
            // 
            this.ShowJobBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.ShowJobBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowJobBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ShowJobBtn.Location = new System.Drawing.Point(56, 204);
            this.ShowJobBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShowJobBtn.Name = "ShowJobBtn";
            this.ShowJobBtn.Size = new System.Drawing.Size(205, 52);
            this.ShowJobBtn.TabIndex = 4;
            this.ShowJobBtn.Text = "Lista de trabajos";
            this.ShowJobBtn.UseVisualStyleBackColor = false;
            this.ShowJobBtn.Visible = false;
            this.ShowJobBtn.Click += new System.EventHandler(this.ShowJobsBtn_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 294);
            this.Controls.Add(this.ShowJobBtn);
            this.Controls.Add(this.NewJobBtn);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.ConnBtn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConnBtn;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button NewJobBtn;
        private System.Windows.Forms.Button ShowJobBtn;
    }
}

