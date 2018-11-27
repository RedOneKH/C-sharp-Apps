using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            list1.Items.Add(txtbox.Text);
            txtbox.Text="";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            list1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            list2.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // vers L1

            list1.Items.Add(list2.SelectedItem);
            list2.Items.RemoveAt( list2.SelectedIndex);
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // vers L2
            list2.Items.Add(list1.SelectedItem);
            list1.Items.RemoveAt(list1.SelectedIndex);

        }

        private void list1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void list2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
