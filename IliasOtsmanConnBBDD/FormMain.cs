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
            InfoLabel.Text = "";
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

                CloseBtn.Visible = true;
                ConnBtn.Visible = false;
                NewJobBtn.Visible = true;
                ShowJobBtn.Visible = true;

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

                CloseBtn.Visible = false;
                ConnBtn.Visible = true;
                NewJobBtn.Visible = false;
                ShowJobBtn.Visible = false;

                await Task.Delay(2000);
                InfoLabel.Text = "";
            } catch (SqlException ex)
            {
                InfoLabel.ForeColor = Color.Red;
                InfoLabel.Text = ex.Message;
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Job newJob = new Job(null, null, null);
            FormInsertUpdateJob formInsertJob = new FormInsertUpdateJob(newJob, 0);
            if (formInsertJob.ShowDialog() == DialogResult.OK)
                InsertJob(newJob);
        }

        private void ShowJobBtn_Click(object sender, EventArgs e)
        {
            FormShowJobs formShowJobs = new FormShowJobs(SelectJobs());
            formShowJobs.ShowDialog();

        }

        private async void InsertJob(Job j)
        {
            try
            {
                string query = $@"INSERT INTO jobs (job_title, min_salary, max_salary)
                              VALUES ('{j.JobTitle}', @salarioMin, @salarioMax); SELECT CAST(SCOPE_IDENTITY() as INT)";

                using (SqlCommand command = new SqlCommand(query, conn))
                {

                    if (j.MinSalary == null)
                        command.Parameters.AddWithValue("@salarioMin", SqlDbType.Decimal).Value = DBNull.Value;
                    else
                        command.Parameters.AddWithValue("@salarioMin", j.MinSalary);

                    if (j.MaxSalary == null)
                        command.Parameters.AddWithValue("@salarioMax", SqlDbType.Decimal).Value = DBNull.Value;
                    else
                        command.Parameters.AddWithValue("@salarioMax", j.MaxSalary);

                    object id = command.ExecuteScalar();
                    j.JobId = (int)id;
                }

                InfoLabel.ForeColor = Color.Green;
                InfoLabel.Text = "Se ha realizado el insert correcamente.";
                await Task.Delay(2000);
                InfoLabel.Text = "";
            }
            catch (Exception ex)
            {
                InfoLabel.ForeColor = Color.Red;
                InfoLabel.Text = ex.Message;
            }
        }

        private List<Job> SelectJobs()
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

                Job job = new Job(titleJob, minSal, maxSal);
                jobs.Add(job);
            }
            reader.Close();

            return jobs;
        }
    }
}
