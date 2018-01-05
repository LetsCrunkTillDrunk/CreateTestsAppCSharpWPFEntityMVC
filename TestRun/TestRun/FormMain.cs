using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestAppLibrary;
namespace TestRun
{
    public partial class FormMain : Form
    {
        public int UserId { get; set; }
        public FormMain()
        {
            InitializeComponent();
            toolStripButton1.Enabled = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //При загрузке основного окна, вызывается форма аутентификации пользователя
            FormAuth fa = new FormAuth(this);
            DialogResult result = fa.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                this.Close();
            }
            Text = "Прохождение тестов";
            FillTreeView();


        }
        //Заполнение TreeView
        public void FillTreeView()
        {
            treeView1.Nodes.Clear();
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                var user = db.Users.Where(i => i.Id == UserId).FirstOrDefault();
                //Выборка предметов, которые будут корневыми узалми дерева
                foreach (var sub in db.Subjects.ToList())
                {
                    TreeNode root = new TreeNode(sub.Name, 1, 1);
                    root.Tag = sub;
                    foreach (var item in db.Exams.ToList())
                    {
                        //Привязка экзаменов к каждому конкретному предмету
                        if (sub.Id == item.Subject.Id)
                        {

                            var userExams = db.UserExams.Where(i => i.User.Id == user.Id && i.Exam.Id == item.Id).FirstOrDefault();
                            TreeNode node;
                            //Если был добавлен новый экзамен, создается запись связывающая текущего пользователя с новым экзаменом 
                            if (userExams == null)
                            {
                                UserExams ue = new UserExams();
                                ue.IsPassed = null;
                                ue.Exam = item;
                                ue.User = user;
                                db.UserExams.Add(ue);
                                db.SaveChanges();
                            }
                            var userExams2 = db.UserExams.Where(i => i.User.Id == user.Id && i.Exam.Id == item.Id).FirstOrDefault();
                            //Сданные экзамены выделяются специальной иконкой
                            if (userExams2 != null)
                            {
                                if (userExams2.IsPassed == true)
                                {
                                    node = new TreeNode(item.Name, 0, 0);
                                }
                                else if (userExams2.IsPassed == false)
                                {
                                    node = new TreeNode(item.Name, 3, 3);
                                }
                                else
                                {
                                    node = new TreeNode(item.Name, 2, 2);
                                }
                            }
                            else
                            {
                                node = new TreeNode(item.Name, 2, 2);
                            }
                            node.Tag = item;
                            //Для всех пройденных экзаменов добавляются узлы вопросов, где отмечены правильные и неправильные ответы
                            var uExams = db.UserExams.Where(i => i.Exam.Id == item.Id && i.IsPassed != null && i.User.Id == UserId).FirstOrDefault();
                            if (uExams != null)
                            {
                                int i = 0;
                                foreach (var q in db.Questions.Where(k => k.Exam.Id == item.Id).ToList())
                                {
                                    TreeNode questNode;
                                    var userQ = db.UserQuestions.Where(j => j.Question.Id == q.Id && j.User.Id == UserId).FirstOrDefault();
                                    if (userQ != null)
                                    {
                                        if (userQ.IsRight == true)
                                        {
                                            questNode = new TreeNode("Вопрос № " + i++, 0, 0);
                                        }
                                        else
                                        {
                                            questNode = new TreeNode("Вопрос № " + i++, 3, 3);

                                        }
                                    }
                                    else
                                    {
                                        questNode = new TreeNode("Ошибка базы");
                                    }
                                    questNode.Tag = q;
                                    node.Nodes.Add(questNode);
                                }
                            }
                            root.Nodes.Add(node);
                        }
                    }
                    treeView1.Nodes.Add(root);
                }
            }
            }
        //Управление включением кнопок панели управления и меню, исходя из выбранного узла дерева
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int level = treeView1.SelectedNode.Level;
            if (level == 0)
            {
                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = false;
                tsmiLaunch.Enabled = false;
                tsmiPreview.Enabled = false;
            }
            else if (level == 1)
            {
                int idEx = ((TestAppLibrary.Exam)treeView1.SelectedNode.Tag).Id;
                using (TestAppLibrary.TestAppContext db = new TestAppContext())
                {
                    //Пройденные экзамены нельзя перепройти
                    var user = db.UserExams.Where(i => i.Exam.Id == idEx && i.User.Id == UserId).FirstOrDefault();
                    if (user != null)
                    {
                        if (user.IsPassed == null)
                        {
                            toolStripButton1.Enabled = true;
                            tsmiLaunch.Enabled = true;
                        }
                        else
                        {
                            toolStripButton1.Enabled = false;
                            tsmiLaunch.Enabled = false;
                        }
                    }
                    toolStripButton2.Enabled = false;
                    tsmiPreview.Enabled = false;
                }
            }
            else if (level == 2)
            {
                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = true;
                tsmiLaunch.Enabled = false;
                tsmiPreview.Enabled = true;
            }
        }
        //Запуск прохождения теста
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormTestPass ftp = new FormTestPass(this, ((Exam)treeView1.SelectedNode.Tag).Id, UserId);
            ftp.MdiParent = this;
            ftp.Show();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
          
        }
        //Запуск режима просмотра ответов пользователя на пройденные вопросы
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FormQuestResult fqe = new FormQuestResult(((TestAppLibrary.Question)treeView1.SelectedNode.Tag).Id, UserId);
            fqe.MdiParent = this;
            fqe.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
