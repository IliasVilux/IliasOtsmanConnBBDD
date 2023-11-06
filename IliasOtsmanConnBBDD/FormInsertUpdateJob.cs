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
            int countSalaries = 0;
            if (TitleTextBox.Text.Length > 0)
            {
                if (MinNumeric.Enabled && MinNumeric.Value > 0)
                    countSalaries++;
                if (MaxNumeric.Enabled && MaxNumeric.Value > 0)
                    countSalaries++;

                if (countSalaries == 2 && MaxNumeric.Value >= MinNumeric.Value)
                    InsertButtonOn();
                else
                    InsertButtonOff();

                if (MinNumeric.Enabled && !MaxNumeric.Enabled)
                {
                    if (MinNumeric.Value > 0)
                        InsertButtonOn();
                    else
                        InsertButtonOff();
                }
                if (MaxNumeric.Enabled && !MinNumeric.Enabled)
                {
                    if (MaxNumeric.Value > 0)
                        InsertButtonOn();
                    else
                        InsertButtonOff();
                }

                if (!MinNumeric.Enabled && !MaxNumeric.Enabled)
                    InsertButtonOn();
            }
            else
                InsertButtonOff();
        }

        private void MaxSalNullBtn_Click(object sender, EventArgs e)
        {
            if (MaxSalNullBtn.Text == "Sin valor")
            {
                MaxNumeric.Enabled = false;
                MaxSalNullBtn.Text = "Asignar valor";
            }
            else
            {
                MaxNumeric.Enabled = true;
                MaxSalNullBtn.Text = "Sin valor";
            }
            CheckData();
        }

        private void MinSalNullBtn_Click(object sender, EventArgs e)
        {
            if (MinSalNullBtn.Text == "Sin valor")
            {
                MinNumeric.Enabled = false;
                MinSalNullBtn.Text = "Asignar valor";
            }
            else
            {
                MinNumeric.Enabled = true;
                MinSalNullBtn.Text = "Sin valor";
            }
            CheckData();
        }

        private void InsertButtonOn()
        {
            InsertJobBtn.Enabled = true;
            InsertJobBtn.BackColor = SystemColors.Highlight;
        }

        private void InsertButtonOff()
        {
            InsertJobBtn.Enabled = false;
            InsertJobBtn.BackColor = SystemColors.ActiveCaption;
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
            job.MinSalary = MinNumeric.Enabled ? MinNumeric.Value : (decimal?)null;
            job.MaxSalary = MaxNumeric.Enabled ? MaxNumeric.Value : (decimal?)null;

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UpdateJob()
        {
            // CODE for update
        }
    }
}
