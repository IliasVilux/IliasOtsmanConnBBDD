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
            this.JobsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JobsListBox.FormattingEnabled = true;
            this.JobsListBox.ItemHeight = 18;
            this.JobsListBox.Location = new System.Drawing.Point(0, 71);
            this.JobsListBox.Name = "JobsListBox";
            this.JobsListBox.Size = new System.Drawing.Size(900, 425);
            this.JobsListBox.TabIndex = 3;
            // 
            // FormShowJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 506);
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
    }
}