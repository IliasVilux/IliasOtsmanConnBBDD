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
    public partial class FormInsertJob : Form
    {
        private Job job;

        public FormInsertJob(Job job)
        {
            InitializeComponent();
            this.job = job;
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
            InsertJobBtn.Enabled = (TitleTextBox.Text.Length > 0 && MinNumeric.Value > 0 && (float)MaxNumeric.Value > 0) ? true : false;
            InsertJobBtn.BackColor = (TitleTextBox.Text.Length > 0 && MinNumeric.Value > 0 && (float)MaxNumeric.Value > 0) ? SystemColors.Highlight : SystemColors.ActiveCaption;
        }

        private void InsertJobBtn_Click(object sender, EventArgs e)
        {
            job.JobTitle = TitleTextBox.Text;
            job.MinSalary = MinNumeric.Value;
            job.MaxSalary = MaxNumeric.Value;

            this.Close();
        }
    }
}
