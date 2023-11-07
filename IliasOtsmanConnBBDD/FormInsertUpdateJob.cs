using IliasOtsmanConnBBDD.Models;
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

        public FormInsertUpdateJob(Job job, int opc)
        {
            InitializeComponent();
            this.job = job;
            CheckOption(opc); // 0 for create 1 for update
            DialogResult = DialogResult.Cancel;
        }

        private void CheckOption(int opc)
        {
            if (opc == 0)
            {
                TitleLabel.Text = "Añadir un trabajo";
                ActionJobBtn.Text = "Crear";
            }
            else
            {
                TitleLabel.Text = $"Modificar trabajo";
                ActionJobBtn.Text = "Modificar";
                TitleTextBox.Text = job.JobTitle;

                if (job.MinSalary == null)
                {
                    MinNumeric.Value = 0;
                    MinNumeric.Enabled = false;
                }
                else
                    MinNumeric.Value = (decimal)job.MinSalary;

                if (job.MaxSalary == null)
                {
                    MaxNumeric.Value = 0;
                    MaxNumeric.Enabled = false;
                }
                else
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
            if (TitleTextBox.Text.Length > 0)
                InsertButtonOn();
            else
                InsertButtonOff();
        }

        private void InsertButtonOn()
        {
            ActionJobBtn.Enabled = true;
            ActionJobBtn.BackColor = SystemColors.Highlight;
        }

        private void InsertButtonOff()
        {
            ActionJobBtn.Enabled = false;
            ActionJobBtn.BackColor = SystemColors.ActiveCaption;
        }

        private void ActionJobBtn_Click(object sender, EventArgs e)
        {
            PassJobData();
        }

        private void PassJobData()
        {
            job.JobTitle = TitleTextBox.Text;
            job.MinSalary = MinNumeric.Enabled ? MinNumeric.Value : (decimal?)null;
            job.MaxSalary = MaxNumeric.Enabled ? MaxNumeric.Value : (decimal?)null;

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
