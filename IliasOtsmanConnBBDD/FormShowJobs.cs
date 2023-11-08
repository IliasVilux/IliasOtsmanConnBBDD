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
using System.Xml.Linq;

namespace IliasOtsmanConnBBDD
{
    public partial class FormShowJobs : Form
    {
        SqlConnection conn;
        List<Job> jobs;
        private LinkToDDBBDataContext dc = new LinkToDDBBDataContext();
        public FormShowJobs(SqlConnection conn)
        {
            InitializeComponent();

            this.conn = conn;
            jobs = GetJobs();
            JobsListBox.Items.AddRange(jobs.ToArray());
        }

        private void JobsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DelJobBtn.Enabled = (JobsListBox.SelectedIndex > 0) ? true : false;
            DelJobBtn.BackColor = (JobsListBox.SelectedIndex > 0) ? System.Drawing.Color.Firebrick : System.Drawing.Color.IndianRed;

            UpdateJobBtn.Enabled = (JobsListBox.SelectedIndex > 0) ? true : false;
            UpdateJobBtn.BackColor = (JobsListBox.SelectedIndex > 0) ? SystemColors.Highlight : SystemColors.ActiveCaption;
        }

        private async void DelJobBtn_Click(object sender, EventArgs e)
        {
            Job jobSelected = (Job)JobsListBox.SelectedItem;
            DialogResult option = MessageBox.Show($"Seguro que quieres borrar el trabajo: {jobSelected.JobTitle}?", "Confirmation", MessageBoxButtons.OKCancel);

            if (option == DialogResult.OK)
            {
                DeleteJob2(jobSelected);
                jobs = GetJobs();

                JobsListBox.Items.Clear();
                JobsListBox.Items.AddRange(jobs.ToArray());

                InfoLabel.ForeColor = Color.Green;
                InfoLabel.Text = "Se ha eliminado correcamente.";
                await Task.Delay(2000);
                InfoLabel.Text = "";
            }
            else
            {
                InfoLabel.ForeColor = Color.Red;
                InfoLabel.Text = "No se ha podido eliminar correcamente :(";
            }

            JobsListBox.SelectedIndex = -1;
            InsertButtonOff();
        }

        private async void UpdateJobBtn_Click(object sender, EventArgs e)
        {
            Job jobSelected = (Job)JobsListBox.SelectedItem;
            FormInsertUpdateJob formUpdateJob = new FormInsertUpdateJob(conn, jobSelected, 1);
            if (formUpdateJob.ShowDialog() == DialogResult.OK)
            {
                UpdateJob2(jobSelected);
                jobs = GetJobs();

                JobsListBox.Items.Clear();
                JobsListBox.Items.AddRange(jobs.ToArray());
                JobsListBox.SelectedIndex = -1;

                InfoLabel.ForeColor = Color.Green;
                InfoLabel.Text = "Se ha modificado correcamente.";
                await Task.Delay(2000);
                InfoLabel.Text = "";
            }
            else
            {
                InfoLabel.ForeColor = Color.Red;
                InfoLabel.Text = "No se ha podido modificar :(";
            }
            InsertButtonOff();
        }

        private void InsertButtonOn()
        {
            DelJobBtn.Enabled = (JobsListBox.SelectedIndex > 0) ? true : false;
            DelJobBtn.BackColor = (JobsListBox.SelectedIndex > 0) ? System.Drawing.Color.Firebrick : System.Drawing.Color.IndianRed;

            UpdateJobBtn.Enabled = (JobsListBox.SelectedIndex > 0) ? true : false;
            UpdateJobBtn.BackColor = (JobsListBox.SelectedIndex > 0) ? SystemColors.Highlight : SystemColors.ActiveCaption;
        }

        private void InsertButtonOff()
        {
            DelJobBtn.Enabled = (JobsListBox.SelectedIndex > 0) ? true : false;
            DelJobBtn.BackColor = (JobsListBox.SelectedIndex > 0) ? System.Drawing.Color.Firebrick : System.Drawing.Color.IndianRed;

            UpdateJobBtn.Enabled = (JobsListBox.SelectedIndex > 0) ? true : false;
            UpdateJobBtn.BackColor = (JobsListBox.SelectedIndex > 0) ? SystemColors.Highlight : SystemColors.ActiveCaption;
        }





        private void GetJobs2()
        {
            var data = from j in dc.jobs
                       select j;

            foreach (jobs job in data)
            {
                JobsListBox.Items.Add(job);
            }
        }

        private List<Job> GetJobs()
        {
            List<Job> jobs = new List<Job>();

            string query = "SELECT * FROM jobs";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int jobId = reader.GetInt32(0);
                string titleJob = reader.GetString(1);
                decimal? minSal, maxSal;

                if (reader.IsDBNull(2))
                    minSal = null;
                else
                    minSal = reader.GetDecimal(2);
                if (reader.IsDBNull(3))
                    maxSal = null;
                else
                    maxSal = reader.GetDecimal(3);

                Job job = new Job(jobId, titleJob, minSal, maxSal);
                jobs.Add(job);
            }
            reader.Close();

            return jobs;
        }


        private void UpdateJob2(Job jSelected)
        {
            var data = from j in dc.jobs
                       where j.job_id == jSelected.JobId
                       select j;

            jobs changeJob = data.FirstOrDefault();
            changeJob.job_title = jSelected.JobTitle;
            changeJob.min_salary = jSelected.MinSalary;
            changeJob.max_salary = jSelected.MaxSalary;

            dc.SubmitChanges();
        }

        private void UpdateJob(Job j)
        {
            string query = $@"UPDATE jobs SET
                                job_title = @jobTitle,
                                min_salary = @salarioMin,
                                max_salary = @salarioMax
                                WHERE job_id = {j.JobId}";

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

                command.ExecuteScalar();
            }
        }


        private void DeleteJob2(Job jSelected)
        {
            var data = from j in dc.jobs
                       where j.job_id == jSelected.JobId
                       select j;

            dc.jobs.DeleteOnSubmit(data.FirstOrDefault());
            dc.SubmitChanges();
        }

        private void DeleteJob(Job j)
        {
            string query = $@"DELETE FROM jobs WHERE job_id = {j.JobId}";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.ExecuteNonQuery();
            }
        }

    }
}
