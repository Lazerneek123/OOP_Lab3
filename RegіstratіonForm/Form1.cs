using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegіstratіonForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Label lb1 = new Label();
                lb1.Location = new Point(1, 1);
                lb1.Size = new Size(140, 125);
                lb1.Name = "labelll";
                lb1.TabIndex = 2;
                lb1.Text = "PІN2";
                groupBox1.Controls.Add(lb1);
                TextBox txt = new TextBox();
                txt.Location = new Point(150, 96);
                txt.Size = new Size(184, 20);
                txt.Name = "textboxx";
                txt.TabIndex = 1;
                txt.Text = "";
                txt.KeyPress += new KeyPressEventHandler(textBox2_KeyPress);
                groupBox1.Controls.Add(txt);
            }
            else
            {
                int lcv;
                lcv = groupBox1.Controls.Count;   //визначається кількість
                while (lcv > 4)
                {
                    groupBox1.Controls.RemoveAt(lcv - 1); lcv -= 1;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Поле Name не може містити цифри");
                errorProvider1.SetError(textBox1, "Must be letter");
            }
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Поле PІN не може містити букви");
            }*/
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == "")
            {
                e.Cancel = false;
            }
            else
            {
                try
                {
                    double.Parse(textBox2.Text); e.Cancel = false;
                }
                catch
                {

                    e.Cancel = true;
                    MessageBox.Show("Поле PІN не може містити букви");
                }
            }
        }
    }
}
