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
    public partial class FormShowJobs : Form
    {
        List<Job> jobs;
        SqlConnection conn;
        public FormShowJobs(List<Job> jobs, SqlConnection conn)
        {
            InitializeComponent();
            this.jobs = jobs;
            this.conn = conn;
            JobsListBox.Items.AddRange(this.jobs.ToArray());
        }

        private void JobsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DelJobBtn.Enabled = (JobsListBox.SelectedIndex > 0) ? true : false;
            DelJobBtn.BackColor = (JobsListBox.SelectedIndex > 0) ? System.Drawing.Color.Firebrick : System.Drawing.Color.IndianRed;

            UpdateJobBtn.Enabled = (JobsListBox.SelectedIndex > 0) ? true : false;
            UpdateJobBtn.BackColor = (JobsListBox.SelectedIndex > 0) ? SystemColors.Highlight : SystemColors.ActiveCaption;
        }

        private void DelJobBtn_Click(object sender, EventArgs e)
        {
            Job jobSelected = (Job)JobsListBox.SelectedItem;
            DialogResult option = MessageBox.Show($"Seguro que quieres borrar el trabajo: {jobSelected.JobTitle}?", "Confirmation", MessageBoxButtons.OKCancel);

            if (option == DialogResult.OK)
                DeleteJob(jobSelected);
            JobsListBox.SelectedIndex = -1;
        }

        private void UpdateJobBtn_Click(object sender, EventArgs e)
        {
            Job jobSelected = (Job)JobsListBox.SelectedItem;
            FormInsertUpdateJob formUpdateJob = new FormInsertUpdateJob(jobSelected, 1);
            if (formUpdateJob.ShowDialog() == DialogResult.OK)
                UpdateJob(jobSelected);
            JobsListBox.SelectedIndex = -1;
        }

        private async void DeleteJob(Job j)
        {
            try
            {
                // CODE for update

                InfoLabel.ForeColor = Color.Green;
                InfoLabel.Text = "Se ha eliminado correcamente.";
                await Task.Delay(2000);
                InfoLabel.Text = "";
            }
            catch (Exception ex)
            {
                InfoLabel.ForeColor = Color.Red;
                InfoLabel.Text = ex.Message;
            }
        }

        private async void UpdateJob(Job j)
        {
            try
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

                    JobsListBox.Items.Clear();
                    JobsListBox.Items.AddRange(this.jobs.ToArray());
                }

                InfoLabel.ForeColor = Color.Green;
                InfoLabel.Text = "Se ha modificado correcamente.";
                await Task.Delay(2000);
                InfoLabel.Text = "";
            }
            catch (Exception ex)
            {
                InfoLabel.ForeColor = Color.Red;
                InfoLabel.Text = ex.Message;
            }
        }
    }
}
