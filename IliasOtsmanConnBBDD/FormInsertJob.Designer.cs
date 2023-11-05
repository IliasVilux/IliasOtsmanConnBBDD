namespace IliasOtsmanConnBBDD
{
    partial class FormInsertJob
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
            this.label1 = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MinNumeric = new System.Windows.Forms.NumericUpDown();
            this.MaxNumeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.InsertJobBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MinNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del trabajo";
            // 
            // TitleLabel
            // 
            this.TitleLabel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.TitleLabel.Location = new System.Drawing.Point(0, 0);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(262, 51);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitleTextBox.Location = new System.Drawing.Point(11, 77);
            this.TitleTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(240, 20);
            this.TitleTextBox.TabIndex = 2;
            this.TitleTextBox.TextChanged += new System.EventHandler(this.TitleTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Salario mínimo";
            // 
            // MinNumeric
            // 
            this.MinNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MinNumeric.DecimalPlaces = 2;
            this.MinNumeric.Location = new System.Drawing.Point(11, 124);
            this.MinNumeric.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinNumeric.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.MinNumeric.Name = "MinNumeric";
            this.MinNumeric.Size = new System.Drawing.Size(112, 20);
            this.MinNumeric.TabIndex = 4;
            this.MinNumeric.ValueChanged += new System.EventHandler(this.MinNumeric_ValueChanged);
            // 
            // MaxNumeric
            // 
            this.MaxNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MaxNumeric.DecimalPlaces = 2;
            this.MaxNumeric.Location = new System.Drawing.Point(140, 124);
            this.MaxNumeric.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaxNumeric.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.MaxNumeric.Name = "MaxNumeric";
            this.MaxNumeric.Size = new System.Drawing.Size(112, 20);
            this.MaxNumeric.TabIndex = 6;
            this.MaxNumeric.ValueChanged += new System.EventHandler(this.MaxNumeric_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(137, 107);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Salario máximo";
            // 
            // InsertJobBtn
            // 
            this.InsertJobBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.InsertJobBtn.Enabled = false;
            this.InsertJobBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertJobBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.InsertJobBtn.Location = new System.Drawing.Point(11, 182);
            this.InsertJobBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InsertJobBtn.Name = "InsertJobBtn";
            this.InsertJobBtn.Size = new System.Drawing.Size(240, 42);
            this.InsertJobBtn.TabIndex = 7;
            this.InsertJobBtn.UseVisualStyleBackColor = false;
            this.InsertJobBtn.Click += new System.EventHandler(this.InsertJobBtn_Click);
            // 
            // FormInsertJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 234);
            this.Controls.Add(this.InsertJobBtn);
            this.Controls.Add(this.MaxNumeric);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MinNumeric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormInsertJob";
            this.Text = "Añadir trabajo";
            ((System.ComponentModel.ISupportInitialize)(this.MinNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown MinNumeric;
        private System.Windows.Forms.NumericUpDown MaxNumeric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button InsertJobBtn;
    }
}