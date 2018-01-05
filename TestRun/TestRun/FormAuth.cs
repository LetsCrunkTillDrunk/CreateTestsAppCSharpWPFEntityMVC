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
    //Форма авторизации
    public partial class FormAuth : Form
    {
        private FormMain form;
        public FormAuth(FormMain f)
        {
            InitializeComponent();
            form = f;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        //Если пользователя с данным логином нет в базе - предлагается его создать
        // Если данный логин есть в базе, но под другим паролем, выводится сообщение об ошибке
        private void button1_Click(object sender, EventArgs e)
        {
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                var users = db.Users.Where(i => i.Name == textBox1.Text && i.Password == textBox2.Text).FirstOrDefault();
                if (users != null)
                {
                    form.UserId = users.Id;
                }
                else
                {
                    var users2 = db.Users.Where(i => i.Name == textBox1.Text && i.Password != textBox2.Text).FirstOrDefault();
                    if (users2 != null)
                    {
                        MessageBox.Show("Пароль пользователя введен неверно");
                        return;
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Вы хотите создать нового пользователя?", "Создание нового пользователя", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            TestAppLibrary.User user = new TestAppLibrary.User { Name = textBox1.Text, Password = textBox2.Text };
                            db.Users.Add(user);
                            db.SaveChanges();
                        }
                        return;

                    }

                }
                
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
