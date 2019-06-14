using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TPS
{
    public partial class Form1 : Form
    {
        AbstractController MyController = new AbstractController();
                

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;

            
            dataGridView1.DataSource = MyController.GetTable();
            dataGridView1.Columns[6].Width += 73;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MyController.ClearForm(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, comboBox1.Text, textBox7.Text) == 1)
            {
                Clear();
            }
        }

        private void Clear()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox7.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            MyController.FindCarblank();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyController.FindCarblank(textBox6.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
