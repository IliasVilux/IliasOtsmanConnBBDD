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
        SqlConnection conn;
        int opc;

        private Job job;
        private LinkToDDBBDataContext dc = new LinkToDDBBDataContext();

        public FormInsertUpdateJob(SqlConnection conn, Job j ,int opc)
        {
            InitializeComponent();

            this.conn = conn;
            this.job = j;
            this.opc = opc;
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
                MinNumeric.Value = (job.MinSalary == null) ? 0 : (decimal)job.MinSalary;
                MaxNumeric.Value = (job.MaxSalary == null) ? 0 : (decimal)job.MaxSalary;
            }
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckData();
        }

        private void MinNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (MaxNumeric.Value < MinNumeric.Value)
                MaxNumeric.Value = MinNumeric.Value;

            CheckData();
        }

        private void MaxNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (MaxNumeric.Value < MinNumeric.Value)
                MaxNumeric.Value = MinNumeric.Value;

            CheckData();
        }

        private void CheckData()
        {
            if (TitleTextBox.Text.Length > 0 && MaxNumeric.Value >= MinNumeric.Value)
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
            job.JobTitle = TitleTextBox.Text;
            job.MinSalary = (MinNumeric.Value > 0) ? MinNumeric.Value : (decimal?)null;
            job.MaxSalary = (MaxNumeric.Value > 0) ? MaxNumeric.Value : (decimal?)null;

            if (opc == 0)
                InsertJob2(job);

            DialogResult = DialogResult.OK;
            this.Close();
        }





        private void InsertJob2(Job j)
        {
            jobs newJob = new jobs
            {
                job_title = j.JobTitle,
                min_salary = j.MinSalary,
                max_salary = j.MaxSalary
            };

            dc.jobs.InsertOnSubmit(newJob);
            dc.SubmitChanges();
        }

        private void InsertJob(Job j)
        {
            string query = $@"INSERT INTO jobs (job_title, min_salary, max_salary)
                              VALUES (@jobTitle, @salarioMin, @salarioMax); SELECT CAST(SCOPE_IDENTITY() as INT)";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                SqlParameter jobTitle = new SqlParameter("@jobTitle", SqlDbType.VarChar, 35);
                jobTitle.Value = j.JobTitle;
                command.Parameters.Add(jobTitle);

                SqlParameter salarioMin = new SqlParameter("@salarioMin", SqlDbType.Decimal);
                salarioMin.Precision = 8;
                salarioMin.Scale = 2;

                SqlParameter salarioMax = new SqlParameter("@salarioMax", SqlDbType.Decimal);
                salarioMax.Precision = 8;
                salarioMax.Scale = 2;

                if (j.MinSalary == null)
                    salarioMin.Value = DBNull.Value;
                else
                    salarioMin.Value = j.MinSalary;
                command.Parameters.Add(salarioMin);


                if (j.MaxSalary == null)
                    salarioMax.Value = DBNull.Value;
                else
                    salarioMax.Value = j.MaxSalary;
                command.Parameters.Add(salarioMax);

                object id = command.ExecuteScalar();
                j.JobId = (int)id;
            }
        }
    }
}
