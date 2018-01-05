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
    public partial class FormRedactAnswer : Form
    {
        private int questionId;
        private TableLayoutPanel table;
        private bool IsForRedact;

        public FormRedactAnswer(FormMain form, int questId, bool regime)
        {
            InitializeComponent();
            questionId = questId;
            IsForRedact = regime;
            table = new TableLayoutPanel();
            table.Parent = splitContainer2.Panel1;
            table.Dock = DockStyle.Fill;
            table.ColumnCount = 2;
            table.Padding = new Padding(20, 10, 10, 20);
            table.AutoScroll = true;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20));
            if (IsForRedact == false)
            {
                button2.Visible = false;
            }
            textBox1.ReadOnly = true;
        }

        private void FormRedactAnswer_Load(object sender, EventArgs e)
        {
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                textBox1.Text = db.Questions.Where(i => i.Id == questionId).FirstOrDefault().Challenge;
                var answers = db.Answers.Where(i => i.Question.Id == questionId).ToList();
                foreach(var a in answers)
                {
                    Control ctrl;
                    if (db.Questions.Where(i => i.Id == questionId).FirstOrDefault().MultiChoice == false)
                    {
                        ctrl = new RadioButton();
                        if (a.IsRight == true) ((RadioButton)ctrl).Checked = true;

                    }
                    else
                    {
                        ctrl = new CheckBox();
                        if (a.IsRight == true) ((CheckBox)ctrl).Checked = true;

                    }
                    ctrl.Parent = table;
                    TextBox t = new TextBox();
                    t.Parent = table;
                    t.Multiline = true;
                    t.WordWrap = true;
                    t.Size = new Size { Width = 250, Height = 50 };
                    t.Text = a.Challenge;
                    if (IsForRedact == false)
                    {
                        t.ReadOnly = true;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                var answers = db.Answers.Where(i => i.Question.Id == questionId).ToList();
                var texts = table.Controls.OfType<TextBox>().ToList();
                var radios = table.Controls.OfType<RadioButton>().ToList();
                var checks = table.Controls.OfType<CheckBox>().ToList();
                for (int i = 0; i < answers.Count; i++)
                {
                    TestAppLibrary.Answer ans = answers[i];
                    ans.Challenge = texts[i].Text;
                    ans.Question = db.Questions.Where(j => j.Id == questionId).FirstOrDefault();
                    ans.IsRight = (radios.Count != 0) ? radios[i].Checked : checks[i].Checked;
                }
                db.SaveChanges();
                this.Close();
            }
        }
    }
}
