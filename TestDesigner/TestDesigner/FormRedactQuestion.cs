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
    public partial class FormRedactQuestion : Form
    {
        private FormMain form;
        private int id;
        public FormRedactQuestion(FormMain f, int id)
        {
            InitializeComponent();
            form = f;
            this.id = id;
            this.AutoScroll = true;
            this.AutoSize = true;
        }

        private void FormRedactQuestion_Load(object sender, EventArgs e)
        {
            try
            {
                using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
                {
                    var quest = db.Questions.Where(i => i.Id == id).FirstOrDefault();
                    if (quest != null)
                    {
                        textBox1.Text = quest.Challenge;
                        numericUpDown1.Value = quest.AnswersNumber;
                        if (quest.MultiChoice == true) radioButton1.Checked = true;
                        radioButton2.Checked = true;
                        var answers = db.Answers.Where(i => i.Question.Id == quest.Id).ToList();
                        Control ctrl;
                        for (int j = 0; j < answers.Count; j++)
                        {
                            if (quest.MultiChoice == false)
                            {
                                ctrl = new RadioButton();
                            }
                            else
                            {
                                ctrl = new CheckBox();
                            }
                            ctrl.Location = new Point { X = 30, Y = 200 * (j + 1) };
                            TextBox t = new TextBox();
                            t.Location = new Point { X = 30, Y = 200 * (j + 1) + 30 };
                            t.Size = new Size { Width = 200, Height = 50 };
                            t.Multiline = true;
                            t.WordWrap = true;
                            t.Text = answers[j].Challenge;
                            if (answers[j].IsRight == true)
                            {
                                if (quest.MultiChoice == false)
                                    ((RadioButton)ctrl).Checked = true;
                                else
                                    ((CheckBox)ctrl).Checked = true;
                            }

                            this.Controls.Add(ctrl);
                            this.Controls.Add(t);
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
