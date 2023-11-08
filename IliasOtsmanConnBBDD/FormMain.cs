using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IliasOtsmanConnBBDD
{
    public partial class FormMain : Form
    {
        private SqlConnection conn;
        public FormMain()
        {
            InitializeComponent();
        }

        private async void ConnBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string user = "sa";
                string passwrd = "123456789";
                conn = new SqlConnection($@"Data Source = 79.143.90.12,54321;
                                         Initial Catalog = IliasEmployees; Persist Security Info = true;
                                         User ID = {user}; Password = {passwrd};");
                conn.Open();

                InfoLabel.ForeColor = Color.Green;
                InfoLabel.Text = "La conexión se ha realizado correcamente.";

                // Show add and list jobs buttons
                CloseBtn.Visible = true;
                ConnBtn.Visible = false;
                NewJobBtn.Visible = true;
                ShowJobBtn.Visible = true;
                ShowEmployeesBtn.Visible = true;

                await Task.Delay(2000);
                InfoLabel.Text = "";
            } catch (SqlException ex)
            {
                InfoLabel.ForeColor = Color.Red;
                InfoLabel.Text = ex.Message;
            }
        }

        private async void CloseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                InfoLabel.ForeColor = Color.Green;
                InfoLabel.Text = "La conexión se ha cerrado correcamente.";

                // Hide add and list jobs buttons
                CloseBtn.Visible = false;
                ConnBtn.Visible = true;
                NewJobBtn.Visible = false;
                ShowJobBtn.Visible = false;
                ShowEmployeesBtn.Visible = false;

                await Task.Delay(2000);
                InfoLabel.Text = "";
            } catch (SqlException ex)
            {
                InfoLabel.ForeColor = Color.Red;
                InfoLabel.Text = ex.Message;
            }
        }
        

        private async void AddJobBtn_Click(object sender, EventArgs e)
        {
            Job job = new Job(null, null, null);
            FormInsertUpdateJob formInsertJob = new FormInsertUpdateJob(conn, job, 0);
            if (formInsertJob.ShowDialog() == DialogResult.OK)
            {
                InfoLabel.ForeColor = Color.Green;
                InfoLabel.Text = "Se ha realizado el insert correcamente.";
                await Task.Delay(2000);
                InfoLabel.Text = "";
            } else
            {
                InfoLabel.ForeColor = Color.Red;
                InfoLabel.Text = "No se ha podido realizar el insert :(";
            }
        }

        private void ShowJobsBtn_Click(object sender, EventArgs e)
        {
            FormShowJobs formShowJobs = new FormShowJobs(conn);
            formShowJobs.ShowDialog();

        }

        private void ShowEmployeesBtn_Click(object sender, EventArgs e)
        {
            FormShowEmployees formShowEmployees = new FormShowEmployees(conn);
            formShowEmployees.ShowDialog();
        }
    }
}
