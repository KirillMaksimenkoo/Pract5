using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pract5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      

        Students students = new Students();
        string path = "data.txt";

        public void show(DataGridView dg)
        {
            
            dg.Rows.Clear();
            foreach (Student s in students.students)
            {
                dg.Rows.Add(s.Name, s.Sname, s.Fname, s.Year, s.School);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var student = new Student(
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                Convert.ToInt32(textBox4.Text),
                textBox5.Text
                );
            students.add(student);
            dataGridView1.Rows.Add(
                students.students[students.students.Count - 1].Name,
                students.students[students.students.Count - 1].Sname,
                students.students[students.students.Count - 1].Fname,
                students.students[students.students.Count - 1].Year,
                students.students[students.students.Count - 1].School
                );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            students.writeFile(path);
            MessageBox.Show("Дані записані");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            students.readFile(path);
            show(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var i = dataGridView1.CurrentRow.Index;
            students.remove(i);
            show(dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            students.sort();
            show(dataGridView2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            students.students.Sort();
            dataGridView3.Rows.Clear();
            foreach (Student s in students.students)
            {
                if (s.School == textBox6.Text)
                    dataGridView3.Rows.Add(s.Name, s.Sname, s.Fname, s.Year, s.School);
            }
        }
    }
}
