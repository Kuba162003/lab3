using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        string imie;
        string nazwisko;
        string wiek;
        string stanowisko;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            form1.dataGridView1.Rows.Add(new object[] {form1.employer_ID, imie, nazwisko, wiek, stanowisko});
            form1.employer_ID++;
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            imie = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            nazwisko = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            wiek = textBox3.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            stanowisko = comboBox1.SelectedItem.ToString();
        }
    }
}
