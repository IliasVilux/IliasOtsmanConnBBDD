namespace IliasOtsmanConnBBDD
{
    partial class FormShowJobs
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
            this.label2 = new System.Windows.Forms.Label();
            this.JobsListBox = new System.Windows.Forms.ListBox();
            this.DelJobBtn = new System.Windows.Forms.Button();
            this.UpdateJobBtn = new System.Windows.Forms.Button();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(900, 71);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lista de trabajos";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // JobsListBox
            // 
            this.JobsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.JobsListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.JobsListBox.FormattingEnabled = true;
            this.JobsListBox.ItemHeight = 18;
            this.JobsListBox.Location = new System.Drawing.Point(0, 71);
            this.JobsListBox.Name = "JobsListBox";
            this.JobsListBox.Size = new System.Drawing.Size(589, 425);
            this.JobsListBox.TabIndex = 3;
            this.JobsListBox.SelectedIndexChanged += new System.EventHandler(this.JobsListBox_SelectedIndexChanged);
            // 
            // DelJobBtn
            // 
            this.DelJobBtn.BackColor = System.Drawing.Color.IndianRed;
            this.DelJobBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.DelJobBtn.Enabled = false;
            this.DelJobBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelJobBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.DelJobBtn.Location = new System.Drawing.Point(589, 71);
            this.DelJobBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DelJobBtn.Name = "DelJobBtn";
            this.DelJobBtn.Size = new System.Drawing.Size(311, 42);
            this.DelJobBtn.TabIndex = 4;
            this.DelJobBtn.Text = "Eliminar trabajo";
            this.DelJobBtn.UseVisualStyleBackColor = false;
            this.DelJobBtn.Click += new System.EventHandler(this.DelJobBtn_Click);
            // 
            // UpdateJobBtn
            // 
            this.UpdateJobBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.UpdateJobBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpdateJobBtn.Enabled = false;
            this.UpdateJobBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateJobBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.UpdateJobBtn.Location = new System.Drawing.Point(589, 113);
            this.UpdateJobBtn.Margin = new System.Windows.Forms.Padding(2);
            this.UpdateJobBtn.Name = "UpdateJobBtn";
            this.UpdateJobBtn.Size = new System.Drawing.Size(311, 42);
            this.UpdateJobBtn.TabIndex = 5;
            this.UpdateJobBtn.Text = "Modificar trabajo";
            this.UpdateJobBtn.UseVisualStyleBackColor = false;
            this.UpdateJobBtn.Click += new System.EventHandler(this.UpdateJobBtn_Click);
            // 
            // InfoLabel
            // 
            this.InfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InfoLabel.Location = new System.Drawing.Point(589, 155);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(311, 341);
            this.InfoLabel.TabIndex = 6;
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormShowJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 506);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.UpdateJobBtn);
            this.Controls.Add(this.DelJobBtn);
            this.Controls.Add(this.JobsListBox);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormShowJobs";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Text = "FormShowJobs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox JobsListBox;
        private System.Windows.Forms.Button DelJobBtn;
        private System.Windows.Forms.Button UpdateJobBtn;
        private System.Windows.Forms.Label InfoLabel;
    }
}