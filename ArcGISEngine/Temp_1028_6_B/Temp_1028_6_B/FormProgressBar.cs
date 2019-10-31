using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temp_1028_6_B
{
    public partial class FormProgressBar : Form
    {
        public FormProgressBar(int count)
        {
            InitializeComponent();
            progressBar1.Maximum = count;
        }

        private void FormProgressBar_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
        }

        public void GO()
        {
            progressBar1.Value += 1;
        }

        public void OK()
        {
            progressBar1.Value = progressBar1.Maximum;
            this.Close();
        }

    }
}
