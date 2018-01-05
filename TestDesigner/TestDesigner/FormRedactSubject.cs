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
    public partial class FormRedactSubject : Form
    {
        private int id;
        private FormMain form; 
        public FormRedactSubject(FormMain f, int id, bool regime)
        {
            InitializeComponent();
            this.id = id;
            form = f;
            Text = "Редактитрование предмета";
            if (regime == false)
            {
                textBox1.ReadOnly = true;
                button2.Visible = false;
                Text = "Просмотр предмета";
            }
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                var subject = db.Subjects.Where(i => i.Id == id).First();
                textBox1.Text = subject.Name;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                var subject = db.Subjects.Where(i => i.Id == id).First();
                if (textBox1.Text == String.Empty)
                {
                    MessageBox.Show("Введите название предмета");
                    return;
                }
                var temp = db.Subjects.Where(i => i.Name == textBox1.Text).FirstOrDefault();
                if (temp == null)
                {
                    subject.Name = textBox1.Text;
                    db.SaveChanges();
                    form.TreeViewFill();
                    this.Close();
                }

            }
        }
    }
}
