// метод для вывода запроса в консоль на ввод числа и чтение числа из консоли
int Input(string text){
    Console.WriteLine(text);
    return Convert.ToInt32(Console.ReadLine());
}

// метод для заполнения переденного массива случайными числами с возможностью вывода вещественных чисел с заданным округлением
void SetDimArray(int[,] matrix, int min_random = -10, int max_random = 10){
    Random random = new Random();
    for(int i = 0; i < matrix.GetLength(0); i++){
        for(int j = 0; j < matrix.GetLength(1); j++){
            matrix[i,j] = random.Next(min_random,max_random);
        }   
    }
}

// метод для вывода значений элементов массива в консоль
void PrintDimArray(int[,] matrix){
    for(int i = 0; i < matrix.GetLength(0); i++){
        for(int j = 0; j < matrix.GetLength(1); j++){
            Console.Write(matrix[i,j] + "\t");
        }
        Console.WriteLine();    
    }
}

// метод для вывода значений элементов массива в консоль
void PrintArray(int[] array){
    for(int i = 0; i < array.Length; i++)
        Console.Write(array[i] + " ");
        Console.WriteLine();
}

void Task54(){
    // Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
    int row = 6;
    int col = 5;

    int[,] matrix = new int[row,col];

    int minVal = 0;
    int maxVal = 20;

    SetDimArray(matrix,minVal,maxVal);
    PrintDimArray(matrix);
    Console.WriteLine();

    for(int i = 0; i < matrix.GetLength(0); i++){
        for(int j1 = 0; j1 < matrix.GetLength(1); j1++){
            for(int j2 = 0; j2 < matrix.GetLength(1)  - j1 - 1; j2++){
                if(matrix[i,j2] < matrix[i,j2+1])
                    (matrix[i,j2],matrix[i,j2+1]) = (matrix[i,j2+1],matrix[i,j2]);
            }
        }
    }

    PrintDimArray(matrix);
}

void Task56(){
    // Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
    int row = 3;
    int col = 6;

    int[,] matrix = new int[row,col];

    int minVal = 0;
    int maxVal = 5;

    SetDimArray(matrix,minVal,maxVal);
    PrintDimArray(matrix);
    Console.WriteLine();
    
    int num = 0;
    int sum = 0;

    for(int i = 0; i < matrix.GetLength(0); i++){
        int sum_new = 0;
        for(int j = 0; j < matrix.GetLength(1); j++){
            sum_new += matrix[i,j];
        }
        Console.WriteLine($"Cтрока {i + 1}. Сумма элементов - {sum_new}");
        if(i == 0)
            sum = sum_new;
        if(sum_new < sum){
            sum = sum_new;  
            num = i;
        }            
    }

    Console.WriteLine($"В строке {num + 1} наименьшая сумма элементов");
}

void Task58(){
    // Напишите программу, которая заполнит спирально массив 4 на 4.
    // 01 02 03 04
    // 12 13 14 05
    // 11 16 15 06
    // 10 09 08 07

    // 01 02 03 04 05
    // 16 17 18 19 06
    // 15 24 25 20 07
    // 14 23 22 21 08
    // 13 12 11 10 09

    int q = 4;

    int row = q;
    int col = q;

    int[,] matrix = new int[row,col];


    int num = 1;

    int x = 0;
    int y = 0;



    while(num < matrix.Length){
        matrix[y, x] = num;
        
        if((x < col - 1)  && (matrix[y,x+1] == 0)){
            x++;
            Console.Write($" 1 [{y},{x}]");
        }
        else if((x == col - 1) && (y < row - 1) && (matrix[y+1,x] == 0)){
            y++;
            Console.Write($" 2 [{y},{x}]");
        }
        else if((x <= col - 1) && (y == row - 1)  && (x > 0)){
            x--;
            Console.Write($" 3 [{y},{x}]");
        }
        else if( (y <= row - 2) && (matrix[y-1,x] == 0) ){
            y--;
            Console.Write($" 4 [{y},{x}]");
        }

        num++;
    }

        // for(x = 0; x < col; x++){
        //     matrix[0, x] = num;
        //     num++;
        // }
        // for(y = 1; y < row; y++){
        //     matrix[y, x - 1] = num;
        //     num++;
        // }
        // for(x = x - 2; x >= 0 ; x--){
        //     matrix[y - 1, x] = num;
        //     num++;
        // }
        // for(y = row - 2; y > 0; y--){
        //     matrix[y, x + 1] = num;
        //     num++;
        // }


    Console.WriteLine($" end [{y},{x}]");

    PrintDimArray(matrix);
}

// метод для вывода меню выбора задач
void Menu() {
    Console.WriteLine("1 - Задача 54");
    Console.WriteLine("2 - Задача 56");
    Console.WriteLine("3 - Задача 58");

    switch (Input("Введите номер задачи - ")){
        case 1:
            Task54();
            break;
        case 2:
            Task56();
            break;
        case 3:
            Task58();
            break;
        default:
            Console.WriteLine("Задачи с таким номером не существует");
            break;
    }
}

Task58();