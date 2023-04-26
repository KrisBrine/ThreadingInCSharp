using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadingUpdateUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private List<Label> threadLabels = new List<Label>();


        private void btnGo_Click(object sender, EventArgs e)
        {
            if(threadLabels.Count < 100)
            {
                int.TryParse(textBox1.Text, out int iterationCount);
                int.TryParse(textBox2.Text, out int sleepDuration);

                Label l = new Label();
                l.Text = DateTime.Now.ToLongTimeString();
                threadLabels.Add(l);

                l.Top = (panel1.Controls.Count * l.Height + 20);
                l.Left = 5;

                this.panel1.Controls.Add(l);

                Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < iterationCount; i++)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            l.Text = i.ToString();
                        });

                        Thread.Sleep(sleepDuration);
                    }
                });
            }
        }

        private void btnGoNoThread_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out int iterationCount);
            int.TryParse(textBox2.Text, out int sleepDuration);

            btnGoNoThread.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;

            for (int i = 0; i <= iterationCount; i++)
            {
                lblCounter.Text = i.ToString();
                lblCounter.Refresh();
                Thread.Sleep(sleepDuration);
            }

            btnGoNoThread.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if()
        }
    }
}
