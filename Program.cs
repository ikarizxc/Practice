using System;

namespace test
{
    enum operators
    {
        add,
        subtract,
        multiply,
        divide,
        exponentiation,
        square_root
    }
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Task 1");
            matrix_1_to_N();
            Console.WriteLine("\nTask 2");
            square_matrix_0_1();
            Console.WriteLine("\nTask 3, 4");
            snake_matrix();

            Console.WriteLine("\nTask DoOperator");
            Console.WriteLine("Result of DoOperator 5 + 10 = {0}", do_operator(operators.add, 5, 10));
            Console.WriteLine("Result of DoOperator 5 - 10 = {0}", do_operator(operators.subtract, 5, 10));
            Console.WriteLine("Result of DoOperator 5 * 10 = {0}", do_operator(operators.multiply, 5, 10));
            Console.WriteLine("Result of DoOperator 5 / 10 = {0}", do_operator(operators.divide, 5, 10));
            Console.WriteLine("Result of DoOperator 5^10 = {0}", do_operator(operators.exponentiation, 5, 10));
            Console.WriteLine("Result of DoOperator sqrt(5) = {0:f3}", do_operator(operators.square_root, 5));
        }
        static void matrix_1_to_N() // Task 1
        {
            Console.Write("Set the height of matrix (int number): ");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.Write("Set the width of matrix (int number): ");
            int width = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[height, width];

            for (int i = 0, k = 1; i < height; i++)
                for (int j = 0; j < width; j++)
                    matrix[i, j] = k++;

            for (int i = height - 1; i > -1; i--)
            {
                for (int j = width - 1; j > -1; j--)
                    Console.Write($"{matrix[i, j]}\t");
                Console.WriteLine();
            }
        }
        static void square_matrix_0_1() // Task 2
        {
            Console.Write("Set the size of square matrix (int number): ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (i - j > 1)
                        matrix[i, j] = 0;
                    else
                        matrix[i, j] = 1;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write($"{matrix[i, j]}\t");
                Console.WriteLine();
            }
        }
        static void snake_matrix() // Task 3, 4
        {
            Console.Write("Set the height of matrix (int number): ");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.Write("Set the width of matrix (int number): ");
            int width = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[height, width];
            
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    matrix[i, j] = 0;

            double number_of_laps = Math.Min(height, width) - Math.Min(height, width) / 2;

            for (int lap = 0, num = 1; lap < number_of_laps; lap++)
            {
                for (int i = lap; i < width - lap; i++)
                    if (matrix[lap, i] == 0)
                        matrix[lap, i] = num++;
                for (int i = lap + 1; i < height - lap; i++)
                    if (matrix[i, width - (lap + 1)] == 0)
                        matrix[i, width - (lap + 1)] = num++;
                for (int i = width - lap - 2; i > lap - 1; i--)
                    if(matrix[height - (lap + 1), i] == 0)
                        matrix[height - (lap + 1), i] = num++;
                for (int i = height - lap - 2; i > lap; i--)
                    if (matrix[i, lap] == 0)
                        matrix[i, lap] = num++;
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                    Console.Write($"{matrix[i, j]}\t");
                Console.WriteLine();
            }
        }
        static double do_operator(operators op, int a, int b = 0) // doOperator task
        {
            return op switch
            {
                operators.add => a + b,
                operators.subtract => a - b,
                operators.multiply => a * b,
                operators.divide => Convert.ToDouble(a) / b,
                operators.exponentiation => Math.Pow(a, b),
                operators.square_root => Math.Sqrt(a),
                _ => throw new NotImplementedException(),
            };
    }
    }
}