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
    public partial class FormAddExam : Form
    {
        private FormMain form;
        TreeView tree;
        public FormAddExam(Form f, Control c)
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Parse("00:00:00");
            form = (FormMain)f;
            tree = (TreeView)c;
            this.Dock = DockStyle.Fill;
            Text = "Добавление нового экзамена";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAddExam_Load(object sender, EventArgs e)
        {
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                var subjs = db.Subjects.ToList();
                foreach (var i in subjs)
                {
                    comboBox1.Items.Add(i.Name);
                }
                comboBox1.SelectedItem = ((TestAppLibrary.Subject)tree.SelectedNode.Tag).Name;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                TestAppLibrary.Exam ex = new TestAppLibrary.Exam();
                ex.Name = textBox1.Text;
                if (numericUpDown1.Value < numericUpDown2.Value)
                {
                    MessageBox.Show("Количество вопросов не совпадает с количеством ответов");
                    return;
                }
                ex.QuestionNumber = (int)numericUpDown1.Value;
                ex.QuestionToPass = (int)numericUpDown2.Value;
                ex.TimeToPass = dateTimePicker1.Value.Hour * 60 + dateTimePicker1.Value.Minute;
                ex.Subject = db.Subjects.Where(i => i.Name == (string)comboBox1.SelectedItem).First();
                db.Exams.Add(ex);
                db.SaveChanges();
                form.TreeViewFill();
                this.Close();
            }
        }
    }
}
