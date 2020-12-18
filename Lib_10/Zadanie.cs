﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_10
{ // Найти номер первого из ее столбцов, содержащих максимальное количество одинаковых элементов.
    public class Func
    {
        /// <summary>
        /// Cортировка массива
        /// </summary>
        /// <param name="mass">сортируемый массив</param>
        /// <param name="n">кол-во столбцов</param>
        /// <param name="m">кол-во строк</param>
        /// <returns></returns>
        public int[,] Sort(int[,] mass, int n, int m)
        {
            //цикл для обхода массива по строкам в столбце
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    //если эл-т строки массива больше следующего эллемента, 
                    //то эл-т массива записываем во вспомогательную переменную, 
                    //в эл-т массива записываем след.(меньший) эл-т, 
                    //в меньший эл-т массива записываем вспомогательную пременную с записанным в нее большим эл-том
                    if (mass[i, j] > mass[i + 1, j])
                    {
                        int sortedmass = mass[i, j];
                        mass[i, j] = mass[i + 1, j];
                        mass[i + 1, j] = sortedmass;
                    }
                }
            }
            return mass;//вывод отсортированного массива
        }

        /// <summary>
        /// Поиск первого столбца, содержащего максимальное кол-во одинаковых эл-тов
        /// </summary>
        /// <param name="mass">массив</param>
        /// <param name="n">кол-во столбцов</param>
        /// <param name="m">кол-во строк</param>
        /// <returns></returns>
        public int MaxColumn(int[,] mass, int n, int m)

        {
            int[] mas = new int[m];//создание вспомогательного одномерного массива
            //цикл для обхода массива по строкам в столбце
            for (int j = 0; j < m; j++)
            {
                int kol = 0;//сброс счетчика
                for (int i = 0; i < n - 1; i++)
                {
                    //если эл-т массива = след. эл-ту - счиатем кол-во одинаковых эл-тов
                    if (mass[i, j] == mass[i + 1, j]) kol++;
                    mas[j] = kol;//во вспомогательный массив записываем кол-во одинаковых эл-тов в столбце
                }
            }

            int max = mas[0];//во вспомогательную переменную записываем вспомогательный одномерный массив с индексом столбца 0(1 столбец)
            int maxcolumn = 0;//переменная отвечающая за номер столбца

            //цикл для проверки столбцов
            for (int j = 0; j < m; j++)
            {
                //сравниваем столбцы массива, если кол-во одинаковых эл-тов больше, записываем во вспомогательную переменную этот столбец массива, в переменную номера столбцов- столбец массива с большим кол-вом одинаковых эл-тов
                if (max < mas[j])
                {
                    max = mas[j];
                    maxcolumn = j;
                }
            }
            return maxcolumn;//выводим номер столбца
        }

    }
}
