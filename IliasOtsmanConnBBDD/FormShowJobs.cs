using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
