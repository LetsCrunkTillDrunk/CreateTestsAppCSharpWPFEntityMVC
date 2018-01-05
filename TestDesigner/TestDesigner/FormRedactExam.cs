using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDesigner
{
    public partial class FormRedactExam : Form
    {
        private FormMain form;
        private int id;
        public FormRedactExam(FormMain f, int id, bool regime)
        {
            InitializeComponent();
            form = f;
            this.id = id;
            Text = "Редактирование экзамена";
            if (regime == false)
            {
                numericUpDown1.ReadOnly = true;
                numericUpDown2.ReadOnly = true;
                dateTimePicker1.Enabled = false;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                Text = "Просмотр экзамена";
                button2.Visible = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                var exam = db.Exams.Where(i => i.Id == id).First();
                if (numericUpDown1.Value < numericUpDown2.Value)
                {
                    MessageBox.Show("Количество вопросов не совпадает с количеством ответов");
                    return;
                }
                exam.QuestionNumber = (int)numericUpDown1.Value;
                exam.QuestionToPass = (int)numericUpDown2.Value;
                exam.Name = textBox2.Text;
                exam.TimeToPass = dateTimePicker1.Value.Hour * 60 + dateTimePicker1.Value.Minute;
                db.SaveChanges();
                form.TreeViewFill();
                this.Close();

            }
        }

        private void FormRedactExam_Load(object sender, EventArgs e)
        {
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                var exam = db.Exams.Where(i => i.Id == id).First();
                db.Entry(exam).Reference(i => i.Subject).Load();
                numericUpDown1.Value = exam.QuestionNumber;
                numericUpDown2.Value = exam.QuestionToPass;
                textBox1.Text = exam.Subject.Name;
                textBox2.Text = exam.Name;
                dateTimePicker1.Value = DateTime.Parse((int)exam.TimeToPass / 60 + ":" + (int)exam.TimeToPass % 60);

            }
        }
    }
}
