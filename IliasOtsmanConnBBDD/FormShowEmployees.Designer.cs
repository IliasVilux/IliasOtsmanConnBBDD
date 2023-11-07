namespace IliasOtsmanConnBBDD
{
    partial class FormShowEmployees
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.CitiesComboBox = new System.Windows.Forms.ComboBox();
            this.EmployeesListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ApellidoTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.SystemColors.HotTrack;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(800, 71);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Lista de Empleados";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CitiesComboBox
            // 
            this.CitiesComboBox.FormattingEnabled = true;
            this.CitiesComboBox.Location = new System.Drawing.Point(474, 109);
            this.CitiesComboBox.Name = "CitiesComboBox";
            this.CitiesComboBox.Size = new System.Drawing.Size(121, 24);
            this.CitiesComboBox.TabIndex = 6;
            this.CitiesComboBox.SelectedIndexChanged += new System.EventHandler(this.CitiesComboBox_SelectedIndexChanged);
            // 
            // EmployeesListBox
            // 
            this.EmployeesListBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EmployeesListBox.FormattingEnabled = true;
            this.EmployeesListBox.ItemHeight = 16;
            this.EmployeesListBox.Location = new System.Drawing.Point(0, 164);
            this.EmployeesListBox.Name = "EmployeesListBox";
            this.EmployeesListBox.Size = new System.Drawing.Size(800, 404);
            this.EmployeesListBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(471, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ciudad";
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NombreTextBox.Location = new System.Drawing.Point(15, 111);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(202, 22);
            this.NombreTextBox.TabIndex = 9;
            this.NombreTextBox.TextChanged += new System.EventHandler(this.NombreTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Apellido";
            // 
            // ApellidoTextBox
            // 
            this.ApellidoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ApellidoTextBox.Location = new System.Drawing.Point(246, 111);
            this.ApellidoTextBox.Name = "ApellidoTextBox";
            this.ApellidoTextBox.Size = new System.Drawing.Size(202, 22);
            this.ApellidoTextBox.TabIndex = 11;
            this.ApellidoTextBox.TextChanged += new System.EventHandler(this.ApellidoTextBox_TextChanged);
            // 
            // FormShowEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 568);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ApellidoTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NombreTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EmployeesListBox);
            this.Controls.Add(this.CitiesComboBox);
            this.Controls.Add(this.labelTitle);
            this.Name = "FormShowEmployees";
            this.Text = "FormShowEmployees";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ComboBox CitiesComboBox;
        private System.Windows.Forms.ListBox EmployeesListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ApellidoTextBox;
    }
}