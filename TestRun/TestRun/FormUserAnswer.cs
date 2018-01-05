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
    //Форма прохождения теста
    public partial class FormUserAnswer : Form
    {
        private int idExam;
        private int idUser;

        List<TestAppLibrary.Question> q = new List<TestAppLibrary.Question>();
        List<TestAppLibrary.Answer> ans = new List<TestAppLibrary.Answer>();
        private TestAppLibrary.Exam ex;
        private TestAppLibrary.User user;
        private int count = 0;
        private TableLayoutPanel table;
        private Timer t;
        private TimeSpan time;
        private bool IsAllFinished = false;
        private FormTestPass form;
        public FormUserAnswer(FormTestPass f, int idExam, int idUser)
        {
            InitializeComponent();
            this.idExam = idExam;
            this.idUser = idUser;
            form = f;
        }
        //При загрузке формы, создается коллекция вопросов, связанная с данным экзаменом и выводится первый вопрос на форму
        private void FormUserAnswer_Load(object sender, EventArgs e)
        {
            try
            {
                using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
                {
                    q = db.Questions.Where(i => i.Exam.Id == idExam).ToList();
                    ex = db.Exams.Where(i => i.Id == idExam).FirstOrDefault();
                    user = db.Users.Where(i => i.Id == idUser).FirstOrDefault();
                    TestAppLibrary.Question quest = q[count++];
                    textBox1.Text = quest.Challenge;
                    Control ctrl;
                    textBox1.ReadOnly = true;
                    table = new TableLayoutPanel();
                    table.Parent = splitContainer2.Panel1;
                    table.Dock = DockStyle.Fill;
                    table.ColumnCount = 2;
                    table.Padding = new Padding(20, 10, 10, 20);
                    table.AutoScroll = true;
                    int k = 0;
                    ans = db.Answers.Where(i => i.Question.Id == quest.Id).ToList();
                    for (int j = 0; j < quest.AnswersNumber && j < ans.Count; j++)
                    {
                        if (quest.MultiChoice == false)
                        {
                            ctrl = new RadioButton();
                        }
                        else
                        {
                            ctrl = new CheckBox();
                        }
                        ctrl.Parent = table;
                        TextBox t = new TextBox();
                        t.Parent = table;
                        t.Multiline = true;
                        t.WordWrap = true;
                        t.Size = new Size { Width = 250, Height = 50 };
                        t.Text = ans[k++].Challenge;
                    }
                    table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20));
                    //Инициализация и запуск таймера
                    t = new Timer();
                    t.Interval = 1000;
                    t.Tick += OnTimer;
                    time = new TimeSpan(ex.TimeToPass / 60, ex.TimeToPass % 60, 0);
                    t.Start();

                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        //Обработчик таймера
        private void OnTimer(object sender, EventArgs args)
        {
            time = time.Subtract(new TimeSpan(0, 0, 1));
            this.Text = time.ToString();
            if (TimeSpan.Compare(time, new TimeSpan(0, 0, 0)) == 0)
            {
                IsAllFinished = true;
                button2_Click(this, new EventArgs());
            }
        }
        //Обработка нажатия на кнопку "Следующий вопрос"
        private void button1_Click(object sender, EventArgs e)
        {
            //В начале происходит выборка предыдущих ответов пользователя. Результаты выбора пользователя заносятся в базу данных
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                TestAppLibrary.Question que = q[count-1];
                var answer = db.Answers.Where(i => i.Question.Id == que.Id).ToList();
                if (q[count - 1].MultiChoice == true)
                {
                    var boxes = table.Controls.OfType<CheckBox>();
                    int i = 0;
                    foreach (var box in boxes)
                    {
                        TestAppLibrary.UserAnswer uans = new TestAppLibrary.UserAnswer();
                        var user = db.Users.Where(l => l.Id == idUser).FirstOrDefault();
                        uans.User = user;
                        TestAppLibrary.Answer ans1 = answer[i++];
                        uans.Answer = ans1;
                        uans.IsPicked = box.Checked;
                        db.UserAnswers.Add(uans);
                    }
                }
                else
                {
                    var radios = table.Controls.OfType<RadioButton>();
                    int i = 0;
                    foreach (var radio in radios)
                    {
                        TestAppLibrary.UserAnswer uans = new TestAppLibrary.UserAnswer();
                        var user = db.Users.Where(l => l.Id == idUser).FirstOrDefault();
                        uans.User = user;
                        TestAppLibrary.Answer ans1 = answer[i++];
                        uans.Answer = ans1;
                        uans.IsPicked = radio.Checked;
                        db.UserAnswers.Add(uans);
                    }
                }
                //Выведение на форму следующего вопроса
                TestAppLibrary.Question quest = q[count++];
                textBox1.Text = quest.Challenge;
                Control ctrl;
                textBox1.ReadOnly = true;
                table = new TableLayoutPanel();
                table.Parent = splitContainer2.Panel1;
                table.Dock = DockStyle.Fill;
                table.ColumnCount = 2;
                table.Padding = new Padding(20, 10, 10, 20);
                table.AutoScroll = true;
                table.BringToFront();
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20));
                int k = 0;
                var ans = db.Answers.Where(i => i.Question.Id == quest.Id).ToList();
                for (int j = 0; j < quest.AnswersNumber && j < ans.Count; j++)
                {
                    if (quest.MultiChoice == false)
                    {
                        ctrl = new RadioButton();
                    }
                    else
                    {
                        ctrl = new CheckBox();
                    }
                    ctrl.Parent = table;
                    TextBox t = new TextBox();
                    t.Parent = table;
                    t.Multiline = true;
                    t.WordWrap = true;
                    t.Size = new Size { Width = 250, Height = 50 };
                    t.Text = ans[k++].Challenge;
                }
                //Если вопросов больше нет в коллекции сделать неактивной кнопку продолжения
                if (count == q.Count)
                {
                    button1.Enabled = false;
                }
                db.SaveChanges();
            }
        }
        //Обработка нажатия на кнопку "Завершить"
        private void button2_Click(object sender, EventArgs e)
        {
            t.Stop();
            int rAns = 0;
            // Выборка ответов пользователя на последний вопрос
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                TestAppLibrary.Question que = q[count-1];
                var answer = db.Answers.Where(i => i.Question.Id == que.Id).ToList();
                if (q[count - 1].MultiChoice == true)
                {
                    var boxes = table.Controls.OfType<CheckBox>();
                    int i = 0;
                    foreach (var box in boxes)
                    {
                        TestAppLibrary.UserAnswer uans = new TestAppLibrary.UserAnswer();
                        var user = db.Users.Where(l => l.Id == idUser).FirstOrDefault();
                        uans.User = user;
                        TestAppLibrary.Answer ans1 = answer[i++];
                        uans.Answer = ans1;
                        uans.IsPicked = box.Checked;
                        db.UserAnswers.Add(uans);
                    }
                }
                else
                {
                    var radios = table.Controls.OfType<RadioButton>();
                    int i = 0;
                    foreach (var radio in radios)
                    {
                        TestAppLibrary.UserAnswer uans = new TestAppLibrary.UserAnswer();
                        var user = db.Users.Where(l => l.Id == idUser).FirstOrDefault();
                        uans.User = user;
                        TestAppLibrary.Answer ans1 = answer[i++];
                        uans.Answer = ans1;
                        uans.IsPicked = radio.Checked;
                        db.UserAnswers.Add(uans);
                    }
                }
                db.SaveChanges();
                //В случае, если пользователь прервал экзамен до ответа на все вопросы,
                //создаются записи для соблюдения целостности базы
                if (IsAllFinished == false)
                {
                    for (int i = count; i < q.Count; i++)
                    {
                        TestAppLibrary.Question quest = q[i];
                        var answers = db.Answers.Where(j => j.Question.Id == quest.Id).ToList();
                        foreach (var a in answers)
                        {
                            TestAppLibrary.UserAnswer uans = new TestAppLibrary.UserAnswer();
                            var us = db.Users.Where(l => l.Id == idUser).FirstOrDefault();
                            uans.User = us;
                            TestAppLibrary.Answer ans1 = a;
                            uans.Answer = ans1;
                            uans.IsPicked = false;
                            db.UserAnswers.Add(uans);
                        }
                        
                    }
                    db.SaveChanges();
                }
                //Проверка ответов пользователя
                foreach (var q in db.Questions.Where(i => i.Exam.Id == idExam).ToList())
                {
                    var ans = db.Answers.Where(i => i.Question.Id == q.Id).ToList();
                    int questAns = 0;
                    foreach(var a in ans)
                    {
                        var ua = db.UserAnswers.Where(i => i.User.Id == idUser && i.Answer.Id == a.Id).FirstOrDefault();
                        if (ua != null)
                        {
                            if (ua.IsPicked == a.IsRight)
                            {
                                questAns += 0;
                            }
                            else
                            {
                                questAns += 1;
                            }
                        }
                    }
                    TestAppLibrary.UserQuestion uq = new TestAppLibrary.UserQuestion();
                    var user = db.Users.Where(l => l.Id == idUser).FirstOrDefault();
                    uq.User = user;
                    uq.Question = db.Questions.Where(i=>i.Id == q.Id).FirstOrDefault();
                    uq.IsRight = (questAns == 0) ? true : false;
                    if (uq.IsRight == true) rAns += 1;
                    db.UserQuestions.Add(uq);
                    db.SaveChanges();
                }
               
                TestAppLibrary.UserExams ue = db.UserExams.Where(i=>i.User.Id == idUser && i.Exam.Id == idExam).FirstOrDefault();
                ue.IsPassed = (ex.QuestionToPass > rAns) ? false : true;
                db.SaveChanges();
                //Вызов формы с финальным результатом теста
                FormExamResult fer = new FormExamResult(this, q.Count, ex.QuestionToPass, rAns);
                fer.ShowDialog();
                this.Close();
            }
        }

        private void FormUserAnswer_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Form.FillTreeView();
            form.Close();
        }
    }
}
