using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibMas
{
    public class Massiv
    {
        //Объявление двухмерного массива
        private int[,] mass;

        //Конструктор для инициализации массива
        public Massiv(int n, int m)
        {
          mass = new int[n,m];
        }
   
        //Заполнение массива случайными числами 
        /// <summary>
        /// Заполняет массив случайными числами
        /// </summary>
        /// <param name="n">столбцы</param>
        /// <param name="m">строки</param>
        /// <returns></returns>
        public int[,] Rand(int n, int m)

        {
            Random rnd = new Random();//Создание объекта в памяти
            //Цикл для обхода всего массива
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; j++)
                {
                    //запись в ячейку массива случайного значения
                    mass[i, j] = rnd.Next(1,10);
                }
            }

            return mass;

        }
        //Очистка
        /// <summary>
        /// Очищает массив ( заполняет 0 )
        /// </summary>
        /// <param name="dataTable">Таблица массива</param>
        public void Clear(DataGridView dataTable)
        {
            //заполнение массива 0
            for (int i = 0; i < dataTable.ColumnCount; ++i)
            {
                for (int j = 0; j < dataTable.RowCount; j++) 
                {
                    mass[i, j] = 0;
                }
            }

        }
        //Вывод массива
        /// <summary>
        /// Выводит массив в таблицу
        /// </summary>
        /// <param name="dataTable">таблица массива</param>
        /// <param name="n">кол-во столбцов</param>
        /// <param name="m">кол-во строк</param>
        public void Print(DataGridView dataTable, int n, int m)
        {
            dataTable.ColumnCount = n;//кол-во столбцов = числу n
            dataTable.RowCount = m;//кол-во строк = числу m
            //вывод массива в таблицу на форме
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; j++)
                {
                    dataTable[i, j].Value = mass[i, j];
                }
            }
        }
        
       /// <summary>
       /// Сохранение двухмерного массива
       /// </summary>
       /// <param name="dataTable">таблица массива</param>
       /// <param name="path">путь к файлу</param>
        public static void Save(DataGridView dataTable,  string path)
        {
         
            //Создание потока для работы с файлом, на запись
            using (StreamWriter saveFile = new StreamWriter(path))
            {
                //Запись кол-во столбцов
                saveFile.WriteLine(dataTable.ColumnCount);
                //Запись кол-во строк
                saveFile.WriteLine(dataTable.RowCount);
                //Запись элемнтов массива
                for (int i = 0; i < dataTable.ColumnCount; i++)
                {
                    for (int j = 0; j < dataTable.RowCount; j++)
                    {
                        saveFile.WriteLine(dataTable[i, j].Value);
                    }
                }
            }

        }
        /// <summary>
        /// Открытие двумерного масиива из файла
        /// </summary>
       
        /// <param name="path">путь к файлу</param>
        public void Open(string path)
        {
            //Создание потока для работы с файлом, на чтение
            using (StreamReader readFile = new StreamReader(path))
            {
                //Чтение кол-во столбцов из файла
                int n = Convert.ToInt32(readFile.ReadLine());
                //Чтение кол-во строк из файла
                int m = Convert.ToInt32(readFile.ReadLine());
                mass = new int[m, n];
                //Чтение элементов из файла
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        mass[i, j] = Convert.ToInt32(readFile.ReadLine());
                    }
                }
                 

            }
        }


    }

}
