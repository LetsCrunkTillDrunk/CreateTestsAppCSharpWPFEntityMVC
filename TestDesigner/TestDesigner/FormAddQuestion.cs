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
    public partial class FormAddQuestion : Form
    {
        private FormMain form;
        private TreeView tree;
        private int id;
        public FormAddQuestion(FormMain f, TreeView tr, int i)
        {
            InitializeComponent();
            form = f;
            tree = tr;
            id = i;
            this.Dock = DockStyle.Fill;
            Text = "Добавление вопроса";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Необходимо ввести название вопроса");
                return;
            }
            TestAppLibrary.Question q = new TestAppLibrary.Question();
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                q.Challenge = textBox1.Text;
                q.AnswersNumber = (int)numericUpDown1.Value;
                q.MultiChoice = radioButton1.Checked;
                q.Exam = db.Exams.Where(i => i.Id == id).First();
                db.Questions.Add(q);
                db.SaveChanges();


                FormAddAnswers fa = new FormAddAnswers(form, tree, textBox1, (int)numericUpDown1.Value, radioButton1.Checked, q.Id);
                DialogResult result = fa.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    db.Questions.Remove(q);
                    db.SaveChanges();
                }
            }
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
