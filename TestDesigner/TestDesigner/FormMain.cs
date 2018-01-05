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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            tsBtnAddQuestion.Enabled = false;
            tsBtnAddExam.Enabled = false;
            tsBtnRedact.Enabled = false;
            tsBtnPreview.Enabled = false;
            tsBtnDelete.Enabled = false;
            tsmiConnect.Enabled = false;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
        }
        //Метод заполнения дерева
        public void TreeViewFill()
        {
            treeView1.Nodes.Clear();
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                foreach (var item in db.Subjects.ToList())
                {
                    int imageIndex = 0;
                    if (item.Name.ToLower().Contains("html"))
                    {
                        imageIndex = 0;
                    }
                    else if (item.Name.ToLower().Contains("script"))
                    {
                        imageIndex = 1;
                    }
                    else if (item.Name.ToLower().Contains("python"))
                    {
                        imageIndex = 2;
                    }
                    else if (item.Name.ToLower().Contains("php"))
                    {
                        imageIndex = 3;
                    }
                    else if (item.Name.ToLower().Contains("react"))
                    {
                        imageIndex = 4;
                    }
                    else if (item.Name.ToLower().Contains("ruby"))
                    {
                        imageIndex = 5;
                    }
                    else if (item.Name.ToLower().Contains("sass"))
                    {
                        imageIndex = 6;
                    }
                    else if (item.Name.ToLower().Contains("c++"))
                    {
                        imageIndex = 7;
                    }
                    else if (item.Name.ToLower().Contains("c#"))
                    {
                        imageIndex = 8;
                    }
                    else if (item.Name.ToLower().Contains("git"))
                    {
                        imageIndex = 9;
                    }
                    else if (item.Name.ToLower().Contains("java"))
                    {
                        imageIndex = 10;
                    }
                    else if (item.Name.ToLower().Contains("win"))
                    {
                        imageIndex = 11;
                    }
                    else if (item.Name.ToLower().Contains("anjular"))
                    {
                        imageIndex = 12;
                    }
                    else if (item.Name.ToLower().Contains("android"))
                    {
                        imageIndex = 13;
                    }
                    else if (item.Name.ToLower().Contains("sql"))
                    {
                        imageIndex = 14;
                    }
                    else if (item.Name.ToLower().Contains("c"))
                    {
                        imageIndex = 15;
                    }
                    else
                    {
                        imageIndex = 11;
                    }
                    TreeNode node = new TreeNode(item.Name, imageIndex, imageIndex);
                    node.Tag = item;
                    foreach (var examItem in db.Exams.ToList())
                    {
                        if (examItem.Subject.Id == item.Id)
                        {
                            TreeNode examNode = new TreeNode(examItem.Name,15,15);
                            examNode.Tag = examItem;
                            int i = 1;
                            foreach (var question in db.Questions.ToList())
                            {
                                if (question.Exam.Id == examItem.Id)
                                {
                                    TreeNode qNode = new TreeNode("Вопрос №" + i, 16,16);
                                    i++;
                                    qNode.Tag = question;
                                    examNode.Nodes.Add(qNode);
                                }

                            }
                            node.Nodes.Add(examNode);
                        }
                        
                    }
                    treeView1.Nodes.Add(node);

                }
            }
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            TreeViewFill();
        }
        //Обработка добавления нового предмета
        private void tsBtnAddSub_Click(object sender, EventArgs e)
        {
            FormAddSubject f = new FormAddSubject(this);
            f.MdiParent = this;
            f.Text = "Добавление нового предмета";
            f.Show();
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
        }
        //Управление доступом к пунктам меню и панели управления
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int level = treeView1.SelectedNode.Level;
            if (level == 0)
            {
                tsBtnAddQuestion.Enabled = false;
                tsBtnAddExam.Enabled = true;
                tsBtnRedact.Enabled = true;
                tsBtnDelete.Enabled = true;
                tsBtnPreview.Enabled = true;
                tsmiAddEx.Enabled = true;
                tsmiAddSub.Enabled = true;
                tsmiAddQuest.Enabled = false;
                tsmiDelEx.Enabled = false;
                tsmiDelSub.Enabled = true;
                tsmiDelQuest.Enabled = false;
                tsmiEditEx.Enabled = false;
                tsmiEditQuest.Enabled = false;
                tsmiEditSub.Enabled = true;
                tsmiViewSub.Enabled = true;
                tsmiViewQuest.Enabled = false;
                tsmiViewEx.Enabled = false;

            }
            else if (level == 1)
            {
                tsBtnAddExam.Enabled = false;
                tsBtnAddQuestion.Enabled = true;
                tsBtnRedact.Enabled = true;
                tsmiAddEx.Enabled = false;
                tsmiAddSub.Enabled = true;
                tsmiAddQuest.Enabled = true;
                tsmiDelEx.Enabled = true;
                tsmiDelSub.Enabled = false;
                tsmiDelQuest.Enabled = false;
                tsmiEditEx.Enabled = true;
                tsmiEditQuest.Enabled = false;
                tsmiEditSub.Enabled = false;
                tsmiViewSub.Enabled = false;
                tsmiViewQuest.Enabled = false;
                tsmiViewEx.Enabled = true;
                try
                {
                    using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
                    {
                        int count = db.Questions.Where(i => i.Exam.Id == ((TestAppLibrary.Exam)treeView1.SelectedNode.Tag).Id).Count();
                        if (count == ((TestAppLibrary.Exam)treeView1.SelectedNode.Tag).QuestionNumber)
                        {
                            tsBtnAddQuestion.Enabled = false;
                        }
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }

            }
            else if (level == 2)
            {
                tsBtnAddExam.Enabled = false;
                tsBtnAddQuestion.Enabled = false;
                tsBtnRedact.Enabled = true;
                tsmiAddEx.Enabled = true;
                tsmiAddSub.Enabled = false;
                tsmiAddQuest.Enabled = false;
                tsmiDelEx.Enabled = true;
                tsmiDelSub.Enabled = false;
                tsmiDelQuest.Enabled = false;
                tsmiEditEx.Enabled = false;
                tsmiEditQuest.Enabled = true;
                tsmiEditSub.Enabled = false;
                tsmiViewSub.Enabled = false;
                tsmiViewQuest.Enabled = true;
                tsmiViewEx.Enabled = false;

            }
            PropertyGrid prop = new PropertyGrid();
            prop.SelectedObject = treeView1.SelectedNode.Tag;
            prop.Parent = splitContainer1.Panel2;
            prop.Dock = DockStyle.Fill;
            prop.BringToFront();

        }
        //Добавление экзамена
        private void tsBtnAddExam_Click(object sender, EventArgs e)
        {
            FormAddExam f = new FormAddExam(this, treeView1);
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.Text = "Добавление нового предмета";
            f.Show();
        }
        //Добавление нового вопроса
        private void tsBtnAddQuestion_Click(object sender, EventArgs e)
        {
            FormAddQuestion fq = new FormAddQuestion(this, treeView1, ((TestAppLibrary.Exam)treeView1.SelectedNode.Tag).Id);
            fq.MdiParent = this;
            fq.Dock = DockStyle.Fill;
            fq.Show();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
         
        }
        //Редактирование различных узлов дерева
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int level = treeView1.SelectedNode.Level;
            if (level == 0)
            {
                tsBtnAddQuestion.Enabled = false;
                tsBtnAddExam.Enabled = true;
                FormRedactSubject frs = new FormRedactSubject(this, ((TestAppLibrary.Subject)treeView1.SelectedNode.Tag).Id, true);
                frs.MdiParent = this;
                frs.Show();
            }
            else if (level == 1)
            {
                tsBtnAddExam.Enabled = false;
                tsBtnAddQuestion.Enabled = true;
                FormRedactExam fre = new FormRedactExam(this, ((TestAppLibrary.Exam)treeView1.SelectedNode.Tag).Id, true);
                fre.MdiParent = this;
                fre.Show();

            }
            else if (level == 2)
            {
                tsBtnAddExam.Enabled = false;
                tsBtnAddQuestion.Enabled = false;
                FormRedactAnswer fra = new FormRedactAnswer(this, ((TestAppLibrary.Question)treeView1.SelectedNode.Tag).Id, true);
                fra.MdiParent = this;
                fra.Show();


            }
        }
        //Просмотр различных узлов
        private void tsBtnPreview_Click(object sender, EventArgs e)
        {
            int level = treeView1.SelectedNode.Level;
            if (level == 0)
            {
                FormRedactSubject frs = new FormRedactSubject(this, ((TestAppLibrary.Subject)treeView1.SelectedNode.Tag).Id, false);
                frs.MdiParent = this;
                frs.Show();
            }
            if (level == 1)
            {
                FormRedactExam fre = new FormRedactExam(this, ((TestAppLibrary.Exam)treeView1.SelectedNode.Tag).Id, false);
                fre.MdiParent = this;
                fre.Show();
            }
            if (level == 2)
            {
                FormRedactAnswer frq = new FormRedactAnswer(this, ((TestAppLibrary.Question)treeView1.SelectedNode.Tag).Id, false);
                frq.MdiParent = this;
                frq.Show();
            }
        }
        //Удаление узлов
        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
                {
                    int level = treeView1.SelectedNode.Level;
                    if (level == 0)
                    {
                        var subject = db.Subjects.Where(i => i.Id == ((TestAppLibrary.Subject)treeView1.SelectedNode.Tag).Id).FirstOrDefault();
                        if (subject != null)
                        {
                            var exams = db.Exams.Where(i => i.Subject.Id == subject.Id).ToList();
                            foreach (var ex in exams)
                            {
                                foreach (var q in db.Questions.Where(i => i.Exam.Id == ex.Id).ToList())
                                {
                                    foreach (var ans in db.Answers.Where(i => i.Question.Id == q.Id).ToList())
                                    {
                                        foreach (var ua in db.UserAnswers.Where(i => i.Answer.Id == ans.Id).ToList())
                                        {
                                            db.UserAnswers.Remove(ua);
                                        }
                                        db.Answers.Remove(ans);
                                    }
                                    foreach (var uq in db.UserQuestions.Where(i => i.Question.Id == q.Id).ToList())
                                    {
                                        db.UserQuestions.Remove(uq);
                                    }
                                    db.Questions.Remove(q);
                                }
                                foreach(var ue in db.UserExams.Where(i=> i.Exam.Id == ex.Id).ToList())
                                {
                                    db.UserExams.Remove(ue);
                                }
                                db.Exams.Remove(ex);
                            }
                            db.Subjects.Remove(subject);
                            db.SaveChanges();
                            TreeViewFill();
                        }
                    }
                    else if (level == 1)
                    {
                        var exam = db.Exams.Where(i => i.Id == ((TestAppLibrary.Exam)treeView1.SelectedNode.Tag).Id).FirstOrDefault();
                        if (exam != null)
                        {
                            foreach (var q in db.Questions.Where(i => i.Exam.Id == exam.Id).ToList())
                            {

                                foreach (var ans in db.Answers.Where(i => i.Question.Id == q.Id).ToList())
                                {
                                    foreach (var ua in db.UserAnswers.Where(i => i.Answer.Id == ans.Id).ToList())
                                    {
                                        db.UserAnswers.Remove(ua);
                                    }
                                    db.Answers.Remove(ans);

                                }
                                foreach (var uq in db.UserQuestions.Where(i => i.Question.Id == q.Id).ToList())
                                {
                                    db.UserQuestions.Remove(uq);
                                }
                                db.Questions.Remove(q);

                            }
                            foreach (var ue in db.UserExams.Where(i => i.Exam.Id == exam.Id).ToList())
                            {
                                db.UserExams.Remove(ue);
                            }
                            db.Exams.Remove(exam);
                            db.SaveChanges();
                            TreeViewFill();
                        }

                    }
                    else if (level == 2)
                    {
                        var question = db.Questions.Where(i => i.Id == ((TestAppLibrary.Question)treeView1.SelectedNode.Tag).Id).FirstOrDefault();
                        if (question != null)
                        {
                            foreach (var ans in db.Answers.Where(i => i.Question.Id == question.Id).ToList())
                            {
                                foreach (var ua in db.UserAnswers.Where(i => i.Answer.Id == ans.Id).ToList())
                                {
                                    db.UserAnswers.Remove(ua);
                                }
                                db.Answers.Remove(ans);
                            }
                            foreach (var que in db.UserQuestions.Where(i => i.Question.Id == question.Id).ToList())
                            {
                                db.UserQuestions.Remove(que);
                            }
                            db.Questions.Remove(question);
                            db.SaveChanges();
                            TreeViewFill();
                        }
                    }

                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        //Обработка двойного клика по дереву. Редактирование названий предметов
        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
                {
                    if (e.Node.Level == 0)
                    {
                        var sub = db.Subjects.Where(i => i.Id == ((TestAppLibrary.Subject)e.Node.Tag).Id).FirstOrDefault();
                        if (sub != null)
                        {
                            if (e.Label != null)
                                sub.Name = e.Label;
                        }
                    }
                    else if (e.Node.Level == 1)
                    {
                        var ex = db.Exams.Where(i => i.Id == ((TestAppLibrary.Exam)e.Node.Tag).Id).FirstOrDefault();
                        if (ex != null)
                        {
                            if (e.Label != null)
                                ex.Name = e.Label;

                        }
                    }

                    db.SaveChanges();
                }
                e.Node.EndEdit(false);
                TreeViewFill();
            }
        }
        //Запуск обработки двойного клика по дереву
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                e.Node.BeginEdit();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
