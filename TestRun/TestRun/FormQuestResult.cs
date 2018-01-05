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
    //Форма просмотра ответов на вопрос
    //Правильные ответы выделяются цветом
    //Ответы пользователя выделяются в виде проставленных галочек на элементах управления CheckBox или RadioButton
    public partial class FormQuestResult : Form
    {
        private int questId;
        private int userId;
        private TableLayoutPanel table;
        public FormQuestResult(int qId, int uId)
        {
            InitializeComponent();
            questId = qId;
            userId = uId;
            table = new TableLayoutPanel();
            table.Parent = splitContainer2.Panel1;
            table.Dock = DockStyle.Fill;
            table.ColumnCount = 2;
            table.Padding = new Padding(20, 10, 10, 20);
            table.AutoScroll = true;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20));
            Text = "Ответ на вопрос";
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void FormQuestResult_Load(object sender, EventArgs e)
        {
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                textBox1.Text = db.Questions.Where(i => i.Id == questId).FirstOrDefault().Challenge;
                var answers = db.Answers.Where(i => i.Question.Id == questId).ToList();
                foreach (var a in answers)
                {
                    Control ctrl;
                    TestAppLibrary.UserAnswer ua = new TestAppLibrary.UserAnswer();
                    ua = db.UserAnswers.Where(i => i.Answer.Id == a.Id && i.User.Id == userId).FirstOrDefault();
                    if (db.Questions.Where(i => i.Id == questId).FirstOrDefault().MultiChoice == false)
                    {
                        ctrl = new RadioButton();
                        if (ua.IsPicked == true) ((RadioButton)ctrl).Checked = true;

                    }
                    else
                    {
                        ctrl = new CheckBox();
                        if (ua.IsPicked == true) ((CheckBox)ctrl).Checked = true;

                    }
                    ctrl.Parent = table;
                    TextBox t = new TextBox();
                    t.Parent = table;
                    t.Multiline = true;
                    t.WordWrap = true;
                    t.Size = new Size { Width = 250, Height = 50 };
                    t.Text = a.Challenge;
                    if (a.IsRight == true)
                    {
                        t.ForeColor = Color.Green;
                    }
                    else
                    {
                        t.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

