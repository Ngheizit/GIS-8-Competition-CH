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
    public partial class FormSetName : Form
    {
        public FormSetName()
        {
            InitializeComponent();
        }

        public string name = "";

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.name = textBox1.Text;
        }
    }
}
