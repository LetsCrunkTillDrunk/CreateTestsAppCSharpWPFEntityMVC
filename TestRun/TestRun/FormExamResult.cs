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
    public partial class FormExamResult : Form
    {
        private FormUserAnswer form;
        private int totalQuestions;
        private int numToPass;
        private int numRightAnswers;
        public FormExamResult(FormUserAnswer fua, int total, int toPass, int answered)
        {
            InitializeComponent();
            form = fua;
            totalQuestions = total;
            numToPass = toPass;
            numRightAnswers = answered;
            Text = "Итоговый результат";
            label1.Text = "Количество вопросов: " + total ;
            label2.Text = "Количество ответов для прохождения: " + numToPass;
            label3.Text = "Количество правильных ответов: " + numRightAnswers;
            if (numToPass > numRightAnswers)
            {
                label4.Text = "ТЕСТ НЕ ПРОЙДЕН!";
                label4.ForeColor = Color.Red;
            }
            else
            {
                label4.Text = "ТЕСТ ПРОЙДЕН!";
                label4.ForeColor = Color.Green;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.Close();
            this.Close();
        }
    }
}
