using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pract2_20191122_WinForms_Game_TableShulte
{
    public partial class Form1 : Form
    {
        Random rnd;
        List<Button> button;
        ButtonComparer btnCmp;
        int pos = 0;
        Timer t;
        int hour, minute;
        string strHour, strMinute;
        int firstTimeNewGame = 0;

        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
            button = new List<Button>();
            btnCmp = new ButtonComparer();
            button.Add(button1);
            button.Add(button2);
            button.Add(button3);
            button.Add(button4);
            button.Add(button5);
            button.Add(button6);
            button.Add(button7);
            button.Add(button8);
            button.Add(button9);
            button.Add(button10);
            button.Add(button11);
            button.Add(button12);
            button.Add(button13);
            button.Add(button14);
            button.Add(button15);
            button.Add(button16);

            foreach (var item in button)
            {
                item.Click += button1_Click;
            }
            
            progressBar1.Value = progressBar1.Minimum;
            
            t = new Timer();
            t.Interval = 1000;
            t.Tick += (s, e) =>
            {
                if (progressBar1.Value < progressBar1.Maximum)
                {
                    progressBar1.Value++;

                    hour = progressBar1.Value / 60;
                    minute = progressBar1.Value % 60;

                    if (hour < 10)
                        strHour = "0" + hour.ToString();
                    else
                        strHour = hour.ToString();
                    if (minute < 10)
                        strMinute = "0" + minute.ToString();
                    else
                        strMinute = minute.ToString();

                    this.Text = strHour + ":" + strMinute;
                }
                
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    t.Stop();                    
                }
                if (pos < 16 && progressBar1.Value == progressBar1.Maximum)
                {
                    MessageBox.Show("Вы проиграли!!!");
                }
            };
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            firstTimeNewGame++;
            progressBar1.Maximum = (int)numericUpDown1.Value;
            progressBar1.Value = progressBar1.Minimum;
            this.Text = "00:00";
            t.Start();
            pos = 0;
            listBox1.Items.Clear();           

            for (int i = 0; i < 16; i++)
            {
                button[i].Enabled = true;

                button[i].Text = rnd.Next(0, 101).ToString();
                for (int j = 0; j < i; j++)
                {
                    if (button[i].Text == button[j].Text)
                    {
                        i--;
                    }
                }
            }
            button.Sort(btnCmp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            if (pos < button.Count && button[pos].Text == btn.Text && firstTimeNewGame > 0)
            {
                listBox1.Items.Add(button[pos].Text);
                button[pos].Enabled = false;
                pos++;                
            }

            if (pos == 16)
            {
                t.Stop();
                MessageBox.Show("Вы победитель!!!");
            }
        }
    }
}
