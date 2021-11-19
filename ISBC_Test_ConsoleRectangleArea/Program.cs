using System;

/*
                                        Тестовое задание №2
Дана последовательность положительных чисел, каждое из которых представляет высоту колонки в гистограмме.
Ширина каждой колонки – единица.
Требуется найти площадь самого большого прямоугольника на этой гистограмме.
Например, на рисунке ниже площадь самого большого прямоугольника равна шести. 
*/

namespace ISBC_Test_ConsoleRectangleArea
{
    class Program
    {
        private const int COLUMN_WIDTH = 1;

        private static int[] s_columnsHeight = { 3, 4, 1, 5, 2 };
         
        static void Main(string[] args)
        {
            Console.WriteLine($"Площадь самого большого прямоугольника равна: {GetLargestRectangleArea()}");            
        }

        /// <summary>
        /// Метод перебирает последовательность чисел слева направо и возвращает самую большую площадь прямоугольника
        /// </summary>
        /// <returns></returns>
        private static int GetLargestRectangleArea()
        {
            int countColums, lastUseIndex, previousNumber, nextNumber, newArea, LargestRectangleArea = 0;

            // Перебираю последовательность чисел слева направо
            for (int i = 0; i <= s_columnsHeight.Length - 1; i++)
            {
                countColums = 1;
                lastUseIndex = i;

                previousNumber = s_columnsHeight[i];
                if (i + 1 == s_columnsHeight.Length)// если работаем с последним элементом последовательности
                {
                    nextNumber = s_columnsHeight[i];
                }
                else// Если работаем не с последним элементом последовательности
                {
                    nextNumber = s_columnsHeight[i + 1];
                }

                if (nextNumber >= previousNumber && (i + 1 != s_columnsHeight.Length))// Если следующее число больше предыдущего и непоследнее
                {
                    lastUseIndex++;
                    countColums++;
                    while ( (lastUseIndex + 1) < s_columnsHeight.Length && s_columnsHeight[lastUseIndex + 1] >= s_columnsHeight[i])// Работает пока следующее число больше предыдущего и непоследнее
                    {
                        lastUseIndex++;
                        countColums++;
                    }
                }

                newArea = countColums * COLUMN_WIDTH * previousNumber;
                if (newArea > LargestRectangleArea)// Определение самой большой площади
                {
                    LargestRectangleArea = newArea;
                }
            }

            return LargestRectangleArea;
        }
    }
}
