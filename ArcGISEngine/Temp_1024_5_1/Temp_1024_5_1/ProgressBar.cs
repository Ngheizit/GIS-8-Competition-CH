using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temp_1024_5_1
{
    public partial class ProgressBar : Form
    {

        public ProgressBar(int maxLength)
        {
            InitializeComponent();
            progressBar1.Maximum = maxLength + 1;
        }

        private void ProgressBar_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 1;
        }

        public void GO()
        {
            if(progressBar1.Value < progressBar1.Maximum)
                progressBar1.Value += 1;
        }

        public void OK()
        {
            progressBar1.Value = progressBar1.Maximum;
            this.Close();
        }


    }
}
