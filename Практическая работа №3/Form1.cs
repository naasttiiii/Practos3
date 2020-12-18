using Lib_10;
using LibMas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практическая_работа__3
    // н, и - столбец - кольюмн, м, джи-строка-ров
    //в массиве - 1 строка, 2 столбец, в датагридвью - 1 столбец, 2 строка
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Кнопка заполнить 
        private void btnFill_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(txtColumn.Text);//кол-во стоблцов задается пользователем
            int m = Convert.ToInt32(txtRow.Text);//кол-во строк задается пользователем
            Massiv mas = new Massiv(n, m);//создание новго экземпляра класса для заполнения массива
            mas.Rand(n, m);//заполнение массива случайными числами
            mas.Print(TableMas, n, m);//вывод массива в таблицу 
        }

        //Кнопка очистить
        private void btnClear_Click(object sender, EventArgs e)
        {
            Massiv mas = new Massiv(TableMas.ColumnCount, TableMas.RowCount);//создание новго экземпляра класса для очистки массива
            mas.Clear(TableMas);//Массив из таблицы очищается(заполняется 0)
            mas.Print(TableMas,TableMas.ColumnCount,TableMas.RowCount);//Очищенный массив выводится в таблицу
        }

        //Кнопка сохранить
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Создание объекта диалогового окна для сохранения
            using (SaveFileDialog save = new SaveFileDialog
            {
                //Установка стандартных свойств
                DefaultExt = ".txt",
                Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt",
                FilterIndex = 2,
                Title = "Сохранение таблицы"
            })
            {
                //Если пользователь нажал ОК
                if (save.ShowDialog() == DialogResult.OK)
                {
                    Massiv.Save(TableMas, save.FileName);//массив из таблицы сохраняется в текстовый документ
                }
            }
        }

        //Кнопка открыть
        private void btnOpen_Click(object sender, EventArgs e)
        {
            //Создание объекта диалогового окна для открытия
            using (OpenFileDialog open = new OpenFileDialog
            {
                //Установка стандартных свойств
                DefaultExt = ".txt",
                Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt",
                FilterIndex = 2,
                Title = "Открытие таблицы"
            })
            {
                //Если пользователь нажал ОК
                if (open.ShowDialog() == DialogResult.OK)
                {
                    //Открыть массив
                    int n = TableMas.ColumnCount;//число n = кол-ву стоблцов массива
                    int m = TableMas.RowCount;//число m = кол-ву строк массива
                    Massiv mas = new Massiv(n, m);//создание новго экземпляра класса для открытия массива массива
                    mas.Open(open.FileName);//Чтение массива из док-та
                    mas.Print(TableMas, n, m);//Вывод массива в таблицу
                }
            }
        }

        //Кнопка найти
        private void btnFind_Click(object sender, EventArgs e)
        {
            int n = TableMas.ColumnCount;//число n = кол-ву столбцов из атблицы
            int m = TableMas.RowCount;//число m = кол-ву строк из таблицы
            int[,] mass = new int[m, n];//объявление массива с кол-вом элементов

            //цикл для обхода массива
            for (int i = 0; i < m; i++)
                for (int j = 0; j < m; j++)
                {
                    mass[i, j] = Convert.ToInt32(TableMas[j, i].Value);//элементы массива получааю значения из таблицы массивов 
                }
           
           Func func = new Func();//создание новго экземпляра класса функции
           string otvet = Convert.ToString(func.MaxColumn(mass, n, m)); //в строковую переменную записываем результат функции нахождения первого столбца массива с больим кол-вом олдиннаковых эл-тов
           mass = func.Sort(mass, m, n);// сортируем массив

            //цикл для обхода всего массива
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    TableMas[j, i].Value = mass[i, j];//в таблицу массива записываем отсортированный массив
                }

            MessageBox.Show(otvet, "Ответ", MessageBoxButtons.OK);//в окно сообщения выводим результат функции

        }

        //Кнопка о программе
        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Хужанова Анастасия ИСП-31\n" +
           "Практическая работа №3\n" +
           "Вариант 10\n" +
           "Дана целочисленная матрица размера M × N. Найти номер первого из ее столбцов, содержащих максимальное количество одинаковых элементов.\n", "О программе");
        }

        //Кнопка выход
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
