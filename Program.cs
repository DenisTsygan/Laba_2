using System;

namespace Laba_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TASK 192");
            Task_192();
            Console.WriteLine(" --------------------------------------------------------------");

            //Console.WriteLine("TASK 199");
            //Task_199();
            //Console.WriteLine(" --------------------------------------------------------------");

            //Console.WriteLine("TASK 8");
            //Task_8();
            //Console.WriteLine(" --------------------------------------------------------------");

            //Console.WriteLine("TASK 45");
            //Task_45();
            //Console.WriteLine(" --------------------------------------------------------------");

            //Console.WriteLine("TASK 106");
            //Task_106();
            //Console.WriteLine(" --------------------------------------------------------------");

        }
        /// <summary>
        /// Дан целочисленный массив А[n], среди элементов есть одинаковые. Создать массив из различных элементов А[n].
        /// </summary>
        private static void Task_192()
        {
            int sizeArray = RandomGenerator.getRandomIntegerValue();
            int[] array = RandomGenerator.getRandomIntegersArray(sizeArray,20,true,0);
            //int[] array = { 1, 2, 3, 3, 4, 5 };

            Console.WriteLine("Array before :");
            Console.WriteLine(String.Join(" ; ", array));
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        array[j]=-1;
                    }
                }
            }
            int[] uniqueArray = new int[array.Length];
            int indexUniqueArray = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != -1)
                {
                    uniqueArray[indexUniqueArray] = array[i];
                    indexUniqueArray++;
                }
            }
            Array.Resize(ref uniqueArray, indexUniqueArray);
            Console.WriteLine("Array after :");
            Console.WriteLine(String.Join(" ; ", uniqueArray));
        }
        /// <summary>
        /// Известно, что в массиве имеются элементы, большие 65 Определить:
        ///а) номер первого;
        ///б) номер последнего.
        ///В обеих задачах условную инструкцию не использовать.
        /// </summary>
        private static void Task_199()
        {
            int constValue = 65;
            int sizeArray = RandomGenerator.getRandomIntegerValue();
            int[] array = RandomGenerator.getRandomIntegersArray(sizeArray, 100,false, constValue);
            string str = "" ;
            Console.WriteLine("Array  :");
            Console.WriteLine(String.Join(" ; ", array));
            for (int i = 1; i <= array.Length; i++)
            {
                str += "/";
                int indexMoreThanConst = ((Math.Abs(array[i-1] - constValue) / (array[i-1] - constValue) + 1) / 2) *i;
                str += indexMoreThanConst;
                str += ";" ;
            }
            str = str.Replace("/0;", " ;");
            string[] arrrayTest = str.Split(";");
            int indexInFinalyArray = 0;
            int[] finalyArray = new int[sizeArray];
            for (int i = 0; i < arrrayTest.Length; i++ )
            {
                try
                {
                    finalyArray[indexInFinalyArray] = Int32.Parse(arrrayTest[i].Remove(0, 1));
                    indexInFinalyArray++;
                }
                catch
                {
                }
            }
            
            Array.Resize(ref finalyArray, indexInFinalyArray);
            Console.WriteLine($"a)Index first element more then CONSTVALUE ( {constValue} )= {(finalyArray[0]-1)}");
            Console.WriteLine($"б)Index last element more then CONSTVALUE ( {constValue} ) = {(finalyArray[indexInFinalyArray-1]-1)}");

        }
        /// <summary>
        /// Заполнить массив:
        ///а) десятью первыми членами арифметической прогрессии(первый член прогрессии — а, её разность — р);
        ///б) двадцатью первыми членами геометрической прогрессии(первый член прогрессии — а, её знаменатель — z);
        ///в) двенадцатью первыми членами последовательности Фибоначчи(последовательности, в которой первые два члена равны 1, а каждый следующий равен сумме двух предыдущих).
        /// </summary>
        private static void Task_8()
        {
            int sizeArithmeticProgression = 10;
            double[] arrayArithmeticProgression = new double[sizeArithmeticProgression];
            double firstNumberArithmeticProgression = RandomGenerator.getRandomIntegerValue();
            double differenceArithmeticProgression = RandomGenerator.getRandomIntegerValue();
            for (int i = 0; i < sizeArithmeticProgression; i++)
            {
                arrayArithmeticProgression[i] = firstNumberArithmeticProgression + differenceArithmeticProgression * i;
            }
            Console.WriteLine($"Array arithmetic progression(a={firstNumberArithmeticProgression};p={differenceArithmeticProgression}) :");
            Console.WriteLine(String.Join(" ; ", arrayArithmeticProgression));
            
            int sizeGeometricProgression = 20;
            double[] arrayGeometricProgression = new double[sizeGeometricProgression];
            double firstNumberGeometricProgression = RandomGenerator.getRandomIntegerValue();
            double denominatorGeometricProgression = RandomGenerator.getRandomIntegerValue();
            for (int i = 0; i < sizeGeometricProgression; i++)
            {
                arrayGeometricProgression[i] = firstNumberGeometricProgression * Math.Pow(denominatorGeometricProgression, i);
            }
            Console.WriteLine($"Array geometric progression(a={firstNumberGeometricProgression};z={denominatorGeometricProgression}):");
            Console.WriteLine(String.Join(" ; ", arrayGeometricProgression));

            int sizeFibonacciSequence = 12;
            double[] arrayFibonacciSequence = new double[sizeFibonacciSequence];
            for (int i = 0; i < sizeFibonacciSequence; i++)
            {
                if (i == 0)
                {
                    arrayFibonacciSequence[i] = i;
                    continue;
                }
                else if(i == 1)
                {
                    arrayFibonacciSequence[i] = i;
                    continue;
                }
                arrayFibonacciSequence[i] = arrayFibonacciSequence[i - 1] + arrayFibonacciSequence[i - 2];
            }
            Console.WriteLine("Array Fibonacci sequence:");
            Console.WriteLine(String.Join(" ; ", arrayFibonacciSequence));

            double[] array = new double[sizeArithmeticProgression+sizeGeometricProgression+sizeFibonacciSequence];
            Array.ConstrainedCopy(arrayArithmeticProgression,0, array, 0,sizeArithmeticProgression);
            Array.ConstrainedCopy(arrayGeometricProgression, 0, array, sizeArithmeticProgression , sizeGeometricProgression);
            Array.ConstrainedCopy(arrayFibonacciSequence, 0, array, sizeArithmeticProgression+sizeGeometricProgression, sizeFibonacciSequence);

            Console.WriteLine("Finaly array :");
            Console.WriteLine(String.Join(" ; ", array));

        }
        /// <summary>
        /// Задана последовательность из N вещественных чисел. Определить, сколько среди них чисел, меньших К, равных К и больших К.
        /// </summary>
        private static void Task_45()
        {
            int sizeArray = RandomGenerator.getRandomIntegerValue();
            Console.WriteLine("N="+sizeArray);
            
            float[] array = RandomGenerator.getRandomRealsArray(sizeArray);
            Console.WriteLine("Array:");
            Console.WriteLine(String.Join(" ; ", array));
            
            float constValue = RandomGenerator.getRandomRealValue();
            Console.WriteLine("K="+constValue);

            int countNumbersMoreConstValue =0, countNumbersEqualsConstValue=0;
            foreach (float number in array)
            {
                if (number > constValue)
                {
                    countNumbersMoreConstValue++;
                    continue;
                }else if (number == constValue)
                {
                    countNumbersEqualsConstValue++;
                }
            }
            int countNumbersLessConstValue = array.Length - countNumbersMoreConstValue - countNumbersEqualsConstValue;
            Console.WriteLine("Count numbers more than K:"+countNumbersMoreConstValue);
            Console.WriteLine("Count numbers less than K:" + countNumbersLessConstValue);
            Console.WriteLine("Count numbers equals K:" + countNumbersEqualsConstValue);
        }
        /// <summary>
        /// Удалить последний элемент массива вещественных чисел.
        /// </summary>
        private static void Task_106()
        {
            float[] array= RandomGenerator.getRandomRealsArray(10);
            Console.WriteLine("Array before:");
            Console.WriteLine(String.Join(" ; ", array));
            Array.Resize(ref array, array.Length - 1);
            Console.WriteLine("Array after:");
            Console.WriteLine(String.Join(" ; ", array));
        }
        private class RandomGenerator
        {
            private static Random random = new Random();
            /// <summary>
            /// Генерация массива с рандомными вещественными числами от 0 до 100
            /// </summary>
            /// <param name="size">количевство елементов в массиве</param>
            public static float[]  getRandomRealsArray(int size)
            {
                float[] arr = new float[size];
                for (int i = 0; i < size; i++)
                {
                    arr[i] =(float) random.NextDouble() * 100;
                }
                return arr;
            }
            /// <summary>
            /// Генерация массива с рандомными целочисленными числами (используется пераметр checkSameNumbers=true И moreThanValue=0 ИЛИ checkSameNumbers=false И moreThanValue=value)
            /// </summary>
            /// <param name="size">количевство елементов в массиве</param>
            /// <param name="maxValue">максимальное сгенерированное число  </param>
            /// <param name="checkSameNumbers"> вернуть массив где присутствуют одинаковые елементы </param>
            /// <param name="moreThanValue"> вернуть массив где присутствуют елементы больше єтого параметра </param>
            /// 
            public static int[] getRandomIntegersArray(int size,int maxValue,bool checkSameNumbers,int moreThanValue)
            {
                int[] arr = new int[size];
                if (checkSameNumbers)
                {
                    bool isCorectArr = false;
                    while (isCorectArr == false)
                    {
                        for (int i = 0; i < size; i++)
                        {
                            arr[i] = random.Next(maxValue);
                        }
                        for (int i = 0; i < arr.Length; i++)
                        {
                            for (int j = i + 1; j < arr.Length; j++)
                            {
                                if (arr[i] == arr[j])
                                {
                                    isCorectArr = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    bool isCorectArr = false;
                    while (isCorectArr == false)
                    {
                        for (int i = 0; i < size; i++)
                        {
                            int randomValue = random.Next(maxValue);
                            if(randomValue != moreThanValue)
                            {
                                arr[i] = randomValue;
                            }
                            else
                            {
                                arr[i] = randomValue+1;
                            }
                        }
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (arr[i] > moreThanValue)
                            {
                                isCorectArr = true;
                            }
                        }
                    }
                }
                return arr;
            }
            /// <summary>
            /// Генерация рандомного вещественного числа от 0 до 100
            /// </summary>
            /// <returns></returns>
            public static float getRandomRealValue()
            {
                return (float)random.NextDouble() * 100;
            }
            /// <summary>
            /// Генерация рандомного не отрицательного целочисленного числа от 1 до 20
            /// </summary>
            /// <returns></returns>
            public static int getRandomIntegerValue()
            {
                return random.Next(20)+1;
            }
        }
    }
}
