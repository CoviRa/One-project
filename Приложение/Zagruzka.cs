using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL3
{
    public partial class Zagruzka : Form
    {
        public Zagruzka()
        {
            InitializeComponent();
            prograssbar1.Value = 0;//начальное значение равно 0
        }

        private void timer1_Tick(object sender, EventArgs e)//настройка загрузки
        {
            prograssbar1.Value += 1;//прогресс загрузки увеличивается на 1
            prograssbar1.Text = prograssbar1.Value.ToString() + "%";//добавляем к загрузке %
            if(prograssbar1.Value == 100)//если загрузка достигла 100, то запускаем нашу главную форму
            {
                timer1.Enabled = false;
                //открываю основную форму
                Form1 one = new Form1();
                one.Show();
                //эту форму прячу
                this.Hide();
            }
        }
    }
}
