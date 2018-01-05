using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestRun
{
    //Стартовая форма при начале прохождения теста. Выводится информация о тесте.
    public partial class FormTestPass : Form
    {
        private int idExam;
        private int idUser;
        List<TestAppLibrary.Question> q = new List<TestAppLibrary.Question>();
        List<TestAppLibrary.Answer> ans = new List<TestAppLibrary.Answer>();
        private TestAppLibrary.Exam ex;
        private TestAppLibrary.User user;
        public FormMain Form { get; set; }

        public FormTestPass(FormMain form, int idExam, int idUser)
        {
            InitializeComponent();
            this.idExam = idExam;
            this.idUser = idUser;
            Form = form;
        }

        private void FormTestPass_Load(object sender, EventArgs e)
        {
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                q = db.Questions.Where(i => i.Exam.Id == idExam).ToList();
                ex = db.Exams.Where(i => i.Id == idExam).FirstOrDefault();
                user = db.Users.Where(i => i.Id == idUser).FirstOrDefault();

            }
            textBox1.Text = ex.Name;
            textBox2.Text = ex.QuestionNumber.ToString();
            textBox3.Text = new TimeSpan(ex.TimeToPass / 60, ex.TimeToPass % 60, 0).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormUserAnswer fua = new FormUserAnswer(this, idExam, idUser);
            this.Visible = false;
            fua.MdiParent = Form;
            fua.Dock = DockStyle.Fill;
            fua.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormTestPass_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form.FillTreeView();
        }
    }
}
