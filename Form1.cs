using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _3_лабораторная_работа
{
    public partial class Form1 : Form
    {
        private string viborFunction = "x^2";
        public Form1()
        {
            InitializeComponent();
            Form1_Load(null, null);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            viborFunction = "sh(x)";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            viborFunction = "x^2";
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            viborFunction = "exp";
        }
        private void button1_Click(object sender, EventArgs e)
        {

            double x, y;
            if (!double.TryParse(textBox1.Text, out x) || !double.TryParse(textBox2.Text, out y))
            {
                MessageBox.Show("Ошибка ввода чисел");
                return;
            }
            textBox4.Text = "Результаты работы программы " + Environment.NewLine;
            textBox4.Text += "При X = " + textBox1.Text + Environment.NewLine;
            textBox4.Text += "При Y = " + textBox2.Text + Environment.NewLine;
            double af = 0;
            switch (viborFunction)
            {
                case "sh(x)":
                    if ((x * y) > 0)
                        af = Math.Pow(Math.Sinh(x) + y, 2) - Math.Sqrt((Math.Sinh(x)) * y);
                    else if ((x * y) < 0)
                        af = Math.Pow(Math.Sinh(x) + y, 2) + Math.Sqrt(Math.Abs(Math.Sinh(x)) * y);
                    else if ((x * y) == 0)
                        af = Math.Pow(Math.Sinh(x) + y, 2) + 1;
                    break;
                case "x^2":
                    if ((x * y) > 0)
                        af = Math.Pow((Math.Pow(x, 2)) + y, 2) - Math.Sqrt((Math.Pow(x, 2)) * y);
                    else if ((x * y) < 0)
                        af = Math.Pow((Math.Pow(x, 2)) + y, 2) + Math.Sqrt(Math.Abs((Math.Pow(x, 2)) * y));
                    else if ((x * y) == 0)
                        af = Math.Pow((Math.Pow(x, 2)) + y, 2) + 1;
                    break;
                case "exp":
                    if ((x * y) > 0)
                        af = Math.Pow((Math.Exp(x)) + y, 2) - Math.Sqrt((Math.Exp(x)) * y);
                    else if ((x * y) < 0)
                        af = Math.Pow((Math.Exp(x)) + y, 2) + Math.Sqrt((Math.Abs(Math.Exp(x))) * y);
                    else if ((x * y) == 0)
                        af = Math.Pow((Math.Exp(x)) + y, 2) + 1;
                    break;
                default:
                    MessageBox.Show("Не выбрана ни одна опция");
                    break;
            }
            textBox4.Text += "Результат: " + af.ToString() + Environment.NewLine;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "X = ";
            label2.Text = "Y = ";
            radioButton1.Text = "sh(x)";
            radioButton2.Text = "x^2";
            radioButton3.Text = "exp";
            textBox1.Text = "";
            textBox2.Text = "";
            button1.Text = "Выполнить";
            button1.Click += button1_Click;
            button2.Text = "Очистить";
            button2.Click += button2_Click;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox4.Text = " ";
        }
    }
}