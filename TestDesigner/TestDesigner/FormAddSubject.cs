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

    public partial class FormAddSubject : Form
    {
        private FormMain form;
        public FormAddSubject(Form f)
        {
            InitializeComponent();
            form = (FormMain)f;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            using (TestAppLibrary.TestAppContext db = new TestAppLibrary.TestAppContext())
            {
                var temp = db.Subjects.Where(i => i.Name == textBox1.Text).FirstOrDefault();
                if (temp == null)
                {
                    TestAppLibrary.Subject sub = new TestAppLibrary.Subject { Name = textBox1.Text };
                    db.Subjects.Add(sub);
                    db.SaveChanges();
                    form.TreeViewFill();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Такой предмет уже есть");
                    return;
                }
            }
        }
    }
}
