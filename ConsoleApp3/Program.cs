//РЕШЕНИЕ ТРАНСПОРТНОЙ ЗАДАЧИ ДЕЛЬТА-МЕТОДОМ

//объявление переменных
int matrixSize, matrixSize2, reservInput, needsInput, inputType, okJ = 0, okI = 0;
int result = 0;
int result2 = 0;
int finResult = 0;
int[,] matrixArray;
int[] needsArray, reservArray, minStrokeArray, minStrokeArray2, minColumnArray, minColumnArray2;
Random random = new();

//меняем цвет текста и заднего фона
Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.Black;
Console.Clear();

//выбор метода ввода
while (true)
{
        Console.WriteLine("\nРешение транспортной задачи закрытого типа дельта-методом");
        Console.WriteLine("\nВыберите метод ввода данных (необходимо ввести цифру)\n" +
                           "1 - Автоматический\n" +
                           "2 - Ручной\n");
        Console.Write("Метод ввода: ");

    if (int.TryParse(Console.ReadLine(), out inputType))
    {
      if (inputType == 1 || inputType == 2)
        {
            switch (inputType)
            {
                case 1:
                    Console.WriteLine("\nВы выбрали автоматический тип ввода данных");
                    AutomaticType();
                    break;

                case 2:
                    Console.WriteLine("\nВы выбрали ручной тип ввода данных");
                    HandType();
                    break;
            }
            break;
        }
        else
        {
            Console.Clear();
            continue;
        }
    }
    Console.Clear();
}

void HandType()
{
    MatrixSize();
    minStrokeArray = new int[matrixArray.GetLength(0)];
    minColumnArray = new int[matrixArray.GetLength(1)];

    minStrokeArray2 = new int[matrixArray.GetLength(0)];
    minColumnArray2 = new int[matrixArray.GetLength(1)];

    InputData();
    OutData();
    MatrixTry();
}

void AutomaticType()
{
    MatrixSize();
    
    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize; j++)
        {
            matrixArray[i, j] = random.Next(0, 99);
            Console.Write(matrixArray[i, j] + " ");
        }
        Console.WriteLine();
    }
    Console.ReadKey();
}

//вводим размер матрицы
void MatrixSize()
{
    while (true)
    {
        Console.Write("\nВведите количество строк матрицы(число): ");
        if (int.TryParse(Console.ReadLine(), out matrixSize))
        {
            Console.Clear();
            break;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("\nНеобходимо ввести число!");
            continue;
        }
    }

    while (true)
    {
        Console.Write("\nВведите количество столбцов матрицы(число): ");
        if (int.TryParse(Console.ReadLine(), out matrixSize2))
        {
            Console.Clear();
            break;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("\nНеобходимо ввести число!");
            continue;
        }
    }
    matrixArray = new int[matrixSize, matrixSize2];
    needsArray = new int[matrixSize2];
    reservArray = new int[matrixSize];
}

//ввод данных в матрицу
void InputData()
{
    for (int i = 0; i < needsArray.Length; i++)
    {
        Console.WriteLine("\nРазмер матрицы: " + matrixSize + " строки " + matrixSize2 + " столбца" + "\n");

        while (true)
        {
            int qtyStore = i + 1;
            Console.Write("\nВведите потребность магазина " + qtyStore + ": ");
            if (int.TryParse(Console.ReadLine(), out needsArray[i]))
            {
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nНеобходимо ввести число!");
                continue;
            }
                
        }
        Console.Clear();
    }

    for (int i = 0; i < reservArray.Length; i++)
    {
        Console.WriteLine("\nРазмер матрицы: " + matrixSize + " строки " + matrixSize2 + " столбца" + "\n");

        while (true)
        {
            int qtyReserv = i + 1;
            Console.Write("\nВведите количество производимых товаров поставщиком " + qtyReserv + ": ");
            if (int.TryParse (Console.ReadLine(), out reservArray[i]))
            {
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nНеобходимо ввести число!");
                continue;
            }
        }
        Console.Clear();
    }

    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize2; j++)
        {
            Console.WriteLine("\nРазмер матрицы: " + matrixSize + " строки " + matrixSize2 + " столбца" + "\n");

            int column = i + 1;
            int stroke = j + 1;

            while (true)
            {
                Console.Write("\nЗаполнение матрицы стоимости [" + column + ";" + stroke + "]: ");
                if (int.TryParse(Console.ReadLine(), out matrixArray[i, j]))
                {
                    Console.Clear();
                    break;
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("\nНеобходимо ввести число!");
                }
            }
        }
    }
}

void OutData()
{
    Console.WriteLine("\nИтоговая матрица");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("\nЗеленым ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("цветом выделено количество производимых поставщиком товаров");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("\n\nЖелтым ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("цветом выделено потребление товаров магазином");
    Console.WriteLine("\n\nБелым цветом выделена стоимость перевозки\n");
    for (int i = 0; i < matrixSize; i++)
    {
        Console.Write(" ");
        for (int j = 0; j < matrixSize2; j++)
        {
            Console.Write(matrixArray[i, j] + " ");
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(reservArray[i]);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
    }

    Console.Write(" ");
    for (int i = 0; i < needsArray.Length; i++)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.Write(needsArray[i] + " ");
        Console.ForegroundColor = ConsoleColor.White;
    }
}

void MatrixTry()
{
    Console.WriteLine("\n");

    for (int i = 0; i < matrixArray.GetLength(0); i++)
    {
        int minLine = matrixArray[i, 0];
        for (int j = 0; j < matrixArray.GetLength(1); j++)
        {
            if (matrixArray[i, j] < minLine)
            {
                minLine = matrixArray[i, j];

            }
        }

        minStrokeArray[i] = minLine;
    }

    Console.WriteLine(" ");

    for (int i = 0; i < minStrokeArray.Length; i++)
    {
        Console.WriteLine("Минимальные элементы по строкам: " + minStrokeArray[i]);
    }

    for (int i = 0; (i < matrixArray.GetLength(0)); i++)
    {
        for (int j = 0; j < matrixArray.GetLength(1); j++)
        {
            matrixArray[i, j] = matrixArray[i, j] - minStrokeArray[i];
        }
    }


    for (int i = 0; i < matrixArray.GetLength(0); i++)
    {
        Console.WriteLine(" ");
        for (int j = 0; j < matrixArray.GetLength(1); j++)
        {
            Console.Write(" " + matrixArray[i, j]);
        }
    }

    for (int i = 0; i < matrixArray.GetLength(1); i++)
    {
        int minLine = matrixArray[0, i];
        for (int j = 0; j < matrixArray.GetLength(0); j++)
        {
            if (matrixArray[j, i] < minLine)
            {
                minLine = matrixArray[j, i];
            }
        }
        minColumnArray[i] = minLine;
    }

    Console.WriteLine("\n");

    for (int i = 0; i < minColumnArray.Length; i++)
    {
        Console.WriteLine("Минимальные элементы по столбцам: " + minColumnArray[i]);
    }


    for (int i = 0; (i < matrixArray.GetLength(1)); i++)
    {
        for (int j = 0; j < matrixArray.GetLength(0); j++)
        {
            matrixArray[j, i] = matrixArray[j, i] - minColumnArray[i];
        }
    }

    for (int i = 0; i < matrixArray.GetLength(0); i++)
    {
        Console.WriteLine(" ");
        for (int j = 0; j < matrixArray.GetLength(1); j++)
        {
            Console.Write(" " + matrixArray[i, j]);
        }
    }

    int c0 = 0;

    for (int i = 0; i < reservArray.Length; i++)
    {
        c0 += (reservArray[i] * minStrokeArray[i]);
    }
    for (int i = 0; i < needsArray.Length; i++)
    {
        c0 += (needsArray[i] * minColumnArray[i]);
    }

    Console.WriteLine("\n\nC0 = " + c0);

    int count_nul = 0;
    int index_i = 0;
    int index_j = 0;

    //1 - по строкам
    //2 - по столбцам
    int checkCS = 0;

    for (int i = 0; i < matrixArray.GetLength(0); i++)
    {
        for (int j = 0; j < matrixArray.GetLength(1); j++)
        {
            try
            {
                if (matrixArray[i, j] == 0)
                {
                    count_nul++;
                    index_i = i;
                    index_j = j;
                }
            }
            catch
            {
                Console.WriteLine("Нет индексов");
            }
        }
        if (count_nul == 1)
        {
            okI = index_i;
            okJ = index_j;
            Console.WriteLine($"\nЕдинственный ноль был найден по строкам. Во {index_i + 1} строке, в {index_j + 1} столбце");
            checkCS = 1;
            break;
        }
        count_nul = 0;
    }

    count_nul = 0;
    index_i = 0;
    index_j = 0;

    for (int i = 0; i < matrixArray.GetLength(1); i++)
    {
        for (int j = 0; j < matrixArray.GetLength(0); j++)
        {
            try
            {
                if (matrixArray[j, i] == 0)
                {
                    count_nul++;
                    index_i = j;
                    index_j = i;
                }
            }
            catch
            {
                Console.WriteLine("Нет индексов");
            }
        }
        if (count_nul == 1)
        {
            okI = index_i;
            okJ = index_j;
            Console.WriteLine($"\nЕдинственный ноль был найден по столбцам. Во {index_i + 1} строке, в {index_j + 1} столбце");
            checkCS = 2;
            break;
        }
        count_nul = 0;
    }

    int newIndexJ = 0;
    int newIndexI = 0;
    int minimal = 0;
    switch (checkCS)
    {
        case 1:
            for (int i = 0; i < 1; i++)
            {
                int minLine = int.MaxValue;
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    if (matrixArray[i, j] < minLine && matrixArray[i, j] != 0)
                    {
                        minLine = matrixArray[i, j];
                        minimal = minLine;
                        newIndexI = i;
                        newIndexJ = j;
                    }
                }
            }
            Console.WriteLine($"\nНайден минимальный элемент после нуля в строке - {minimal}. Индекс: {newIndexI + 1} строка, {newIndexJ + 1} столбец\n");

            for (int i = 0; i < matrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    if (i == okI)
                    {
                        matrixArray[i, j] += minimal;
                    }
                }
            }

            Console.WriteLine("\nВыполняем вредное действие");

            for (int i = 0; i < matrixArray.GetLength(0); i++)
            {
                Console.WriteLine(" ");
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    Console.Write(" " + matrixArray[i, j]);
                }
            }

            Console.WriteLine("\n\nВыполняем полезное действие");

            for (int i = 0; i < matrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    if (j == okJ)
                    {
                        matrixArray[i, j] -= minimal;
                    }
                }
            }

            for (int i = 0; i < matrixArray.GetLength(0); i++)
            {
                Console.WriteLine(" ");
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    Console.Write(" " + matrixArray[i, j]);
                }
            }

            for (int i = 0; i < minStrokeArray2.Length; i++)
            {
                if (i == index_i)
                {
                    minStrokeArray2[i] = minimal;
                }
                else
                {
                    minStrokeArray2[i] = 0;
                }
            }

            for (int i = 0; i < minColumnArray2.Length; i++)
            {
                if (i == index_j)
                {
                    minColumnArray2[i] = minimal;
                }
                else
                {
                    minColumnArray2[i] = 0;
                }
            }

            result = 0;
            result2 = 0;

            for (int i = 0; i < minStrokeArray2.Length; i++)
            {
                result += (reservArray[i] * minStrokeArray2[i]);
            }

            for (int i = 0; i < minColumnArray2.Length; i++)
            {
                result2 += (needsArray[i] * minColumnArray2[i]);
            }

            finResult = result2 - result;

            Console.WriteLine($"\n\nРезультат преобразования - {finResult}");

            break;
        case 2:
            for (int i = 0; i < matrixArray.GetLength(1); i++)
            {
                int minLine = int.MaxValue;
                minimal = 0;
                for (int j = 0; j < matrixArray.GetLength(0); j++)
                {
                    if (matrixArray[j, i] < minLine && matrixArray[j, i] != 0)
                    {
                        minLine = matrixArray[j, i];
                        minimal = minLine;
                        newIndexI = j;
                        newIndexI = i;
                    }
                }
            }
            Console.WriteLine($"\nНайден минимальный элемент после нуля в столбце - {minimal}. Индекс: {newIndexJ + 1} строка, {newIndexI + 1} столбец");

            for (int i = 0; i < matrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    if (i == index_i)
                    {
                        matrixArray[i, j] += minimal;
                    }
                }
            }

            Console.WriteLine("\nВыполняем вредное действие");

            for (int i = 0; i < matrixArray.GetLength(0); i++)
            {
                Console.WriteLine(" ");
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    Console.Write(" " + matrixArray[i, j]);
                }
            }

            Console.WriteLine("\n\nВыполняем полезное действие");

            for (int i = 0; i < matrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    if (j == index_j)
                    {
                        matrixArray[i, j] -= minimal;
                    }
                }
            }

            for (int i = 0; i < matrixArray.GetLength(0); i++)
            {
                Console.WriteLine(" ");
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    Console.Write(" " + matrixArray[i, j]);
                }
            }

            for (int i = 0; i < minStrokeArray2.Length; i++)
            {
                if (i == index_i)
                {
                    minStrokeArray2[i] = minimal;
                }
                else
                {
                    minStrokeArray2[i] = 0;
                }
            }

            for (int i = 0; i < minColumnArray2.Length; i++)
            {
                if (i == index_j)
                {
                    minColumnArray2[i] = minimal;
                }
                else
                {
                    minColumnArray2[i] = 0;
                }
            }

            for (int i = 0; i < minStrokeArray2.Length; i++)
            {
                result += (reservArray[i] * minStrokeArray2[i]);
            }

            for (int i = 0; i < minColumnArray2.Length; i++)
            {
                result2 += (needsArray[i] * minColumnArray2[i]);
            }

            finResult = result2 - result;

            Console.WriteLine($"\n\nРезультат преобразования - {finResult}");
            break;
    }
}