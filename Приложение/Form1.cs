using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SQL3;

namespace SQL3
{
    public partial class Form1 : Form
    {
        bd t = new bd();
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void AddColumns(DataGridView gred, string name, string heder)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = name;
            col.DataPropertyName = name;
            col.HeaderText = heder;
            col.Visible = true;
            gred.Columns.Add(col);
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)//кнопка добавить студента
        {
            //подключаю функцию генерации ID
            int ID = genID();
            while(t.GetID(ID))
            {
                ID = genID();
            }
            //заполняю данные
            string SURNAME = maskedTextBox2.Text;
            string NAME = maskedTextBox3.Text;
            int STIPEND;
            if (Int32.TryParse(maskedTextBox4.Text, out STIPEND) == true)
            {

            }
            int KURS = (int)comboBox3.SelectedValue;
            string CITY = (string)comboBox2.SelectedValue;
            DateTime BIRTHDAY;
            if (DateTime.TryParse(dateTimePicker1.Text, out BIRTHDAY) == true)
            {

            }
            int UNIV_ID = (int)comboBox1.SelectedValue;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = t.ADD_STUDENT(ID, SURNAME, NAME, STIPEND, KURS, CITY, BIRTHDAY, UNIV_ID); //подключаю функцию с запросом
            dataGridView1.DataSource = t.GetStudentsListUniver();//обновляю таблицу
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private int genID()//генерация уникального ID
        {
            Random rnd = new Random();
            return rnd.Next(0, 10000);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //выпадающий список
            comboBox1.DataSource = t.GetUniver();//отображаемый столбец
            comboBox1.ValueMember = "UNIV_ID";//столбец, содержащий данные
            comboBox1.DisplayMember = "UNIV_NAME";//источник данных

            comboBox2.DataSource = t.GetUniver();//отображаемый столбец
            comboBox2.ValueMember = "CITY";//столбец, содержащий данные
            comboBox2.DisplayMember = "CITY";//источник данных

            comboBox3.DataSource = t.GetStudents();//отображаемый столбец
            comboBox3.ValueMember = "KURS";//столбец, содержащий данные
            comboBox3.DisplayMember = "KURS";//источник данных

            dataGridView1.DataSource = t.GetStudentsListUniver();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)//кнопка удаления
        {
                //выбираем строку и удаляем ее
                if (dataGridView1.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Индекс за пределами диапазона. Индекс должен быть положительным числом, а его размер не должен превышать размер коллекции.");
                    return;
                }
                if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                correntrow = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                t.DELETE_STUDENTS(correntrow);
                dataGridView1.DataSource = t.GetStudents();//обновляем таблицу
                }
        }
        int correntrow = 0;
        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//кнопка редактирования записи о студенте
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Индекс за пределами диапазона. Индекс должен быть положительным числом, а его размер не должен превышать размер коллекции.");
                return;
            }
            int ID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

            //заполняю данные
            string SURNAME = maskedTextBox2.Text;
            string NAME = maskedTextBox3.Text;
            int STIPEND;
            if (Int32.TryParse(maskedTextBox4.Text, out STIPEND) == true)
            {

            }
            int KURS = (int)comboBox3.SelectedValue;
            string CITY = (string)comboBox2.SelectedValue;
            DateTime BIRTHDAY;
            if (DateTime.TryParse(dateTimePicker1.Text, out BIRTHDAY) == true)
            {

            }
            int UNIV_ID = (int)comboBox1.SelectedValue;
            dataGridView1.Columns.Clear();
            t.UPDATE_STUDENTS(ID, SURNAME, NAME, STIPEND, KURS, CITY, BIRTHDAY, UNIV_ID);//подключаю функцию с запросом
            dataGridView1.DataSource = t.GetStudentsListUniver();//обновляю таблицу
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();//закрываю приложение
            }
        }
    }
}

