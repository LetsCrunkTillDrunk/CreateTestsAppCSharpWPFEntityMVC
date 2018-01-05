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
    public partial class FormAddAnswers : Form
    {
        private FormMain form;
        private TextBox tb;
        private TreeView tree;
        private bool multiChoice;
        private int id;
        private TableLayoutPanel table;

        public FormAddAnswers(FormMain f, TreeView tr, Control c, int num, bool choice, int i)
        {
            InitializeComponent();

            id = i;
            tree = tr;
            form = f;
            multiChoice = choice;
            tb = (TextBox)c;
            Control ctrl;
            textBox1.ReadOnly = true;
            table = new TableLayoutPanel();
            table.Parent = splitContainer2.Panel1;
            table.Dock = DockStyle.Fill;
            table.ColumnCount = 2;
            table.Padding = new Padding(20, 10, 10, 20);
            table.AutoScroll = true;
            for (int j = 0; j < num; j++)
            {
                if (choice == false)
                {
                    ctrl = new RadioButton();
                }
                else
                {
                    ctrl = new CheckBox();
                }
                ctrl.Parent = table ;
                TextBox t = new TextBox();
                t.Parent = table;
                t.Multiline = true;
                t.WordWrap = true;
                t.Size = new Size { Width = 250, Height = 50 };        
            }
            this.AutoSize = true;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,20));
            Text = "Добавление ответов";
        }


        private void FormAddAnswers_Load(object sender, EventArgs e)
        {
            textBox1.Text = tb.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var c in table.Controls)
            {
                if (c.GetType().Name == "TextBox")
                {
                    if (((TextBox)c).Text == String.Empty)
                    {
                        MessageBox.Show("Заполните все поля");
                        return;
                    }
                }
            }

            var radios = table.Controls.OfType<RadioButton>().ToList();
            var checks = table.Controls.OfType<CheckBox>().ToList();
            var texts = table.Controls.OfType<TextBox>().ToList();
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                if (multiChoice == true)
                {
                    for (int i = 0; i < texts.Count; i++)
                    {
                        TestAppLibrary.Answer ans = new TestAppLibrary.Answer { Challenge = texts[i].Text, IsRight = checks[i].Checked, Question = db.Questions.Where(k => k.Id == id).First() };
                        db.Answers.Add(ans);
                    }
 
                }
                else if (multiChoice == false)
                {
                        for (int i = 0; i < texts.Count; i++)
                        {
                            TestAppLibrary.Answer ans = new TestAppLibrary.Answer { Challenge = texts[i].Text, IsRight = radios[i].Checked, Question = db.Questions.Where(k => k.Id == id).First() };
                            db.Answers.Add(ans);
                        }
       
                }
                
                db.SaveChanges();
                
                form.TreeViewFill();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
