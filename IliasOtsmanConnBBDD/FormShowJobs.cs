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
        public FormShowJobs(List<Job> jobs)
        {
            InitializeComponent();
            this.jobs = jobs;
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
                // CODE for update

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
