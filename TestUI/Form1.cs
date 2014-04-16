using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NICE.TaskProcessor;

namespace TestUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void runButton_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.Tasks = tasks.Text;
            Properties.Settings.Default.Dependencies = dependencies.Text;
            Properties.Settings.Default.Save();
            
            var tasksList = new TaskList(tasks.Text);
            var depsList = new DependencyList(dependencies.Text);

            var runner = new Scheduler();

            try
            {
                results.Text = runner.Run(tasksList, depsList);
                resultsLabel.ForeColor = SystemColors.WindowText;
            }

            catch (Exception ex)
            {
                results.Text = ex.Message;
                resultsLabel.ForeColor = Color.Red;
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tasks.Text = Properties.Settings.Default.Tasks;
            dependencies.Text = Properties.Settings.Default.Dependencies;
        }
    }
}
