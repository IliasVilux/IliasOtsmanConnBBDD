using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IliasOtsmanConnBBDD
{
    public partial class FormInsertUpdateJob : Form
    {
        private Job job;
        private int opc; // 0 for create 1 for update

        public FormInsertUpdateJob(Job job, int opc)
        {
            InitializeComponent();
            this.job = job;
            this.opc = opc;
            CheckOption();
            DialogResult = DialogResult.Cancel;
        }

        private void CheckOption()
        {
            if (opc == 0)
            {
                TitleLabel.Text = "Añadir un trabajo";
                InsertJobBtn.Text = "Crear";
            }
            else
            {
                TitleLabel.Text = $"Modificar trabajo";
                InsertJobBtn.Text = "Modificar";
                TitleTextBox.Text = job.JobTitle;
                MinNumeric.Value = (decimal)job.MinSalary;
                MaxNumeric.Value = (decimal)job.MaxSalary;
            }
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckData();
        }

        private void MinNumeric_ValueChanged(object sender, EventArgs e)
        {
            CheckData();
        }

        private void MaxNumeric_ValueChanged(object sender, EventArgs e)
        {
            CheckData();
        }

        private void CheckData()
        {
            bool verification = TitleTextBox.Text.Length > 0 && MinNumeric.Value > 0 && MaxNumeric.Value > 0 && MaxNumeric.Value >= MinNumeric.Value;
            InsertJobBtn.Enabled = verification ? true : false;
            InsertJobBtn.BackColor = verification ? SystemColors.Highlight : SystemColors.ActiveCaption;
        }

        private void InsertJobBtn_Click(object sender, EventArgs e)
        {
            if (opc == 0)
                CreateJob();
            else
                UpdateJob();
        }

        private void CreateJob()
        {
            job.JobTitle = TitleTextBox.Text;
            job.MinSalary = MinNumeric.Value;
            job.MaxSalary = MaxNumeric.Value;

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UpdateJob()
        {
            // CODE for update
        }
    }
}
