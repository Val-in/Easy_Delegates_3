using System;
using System.Transactions;

namespace Easy_Delegates_3
{
    /*Задача 3: Комбинирование нескольких функций с помощью делегата
    Условие:
    Напишите программу, которая комбинирует две функции (например, сложение и умножение чисел) 
    с помощью делегата. */
    class Program
    {
        delegate double MyDelegate(double a, double b);
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            while (true)
            {
                Console.WriteLine("Enter first number");
                string firstNumberInput = Console.ReadLine();

                Console.WriteLine("Enter second number");
                string secondNumberInput = Console.ReadLine();

                if (double.TryParse(firstNumberInput, out double firstNumber) && double.TryParse(secondNumberInput, out double secondNumber))
                {
                    Console.WriteLine("Enter '+' for sum or '-' for subtraction");
                    string operation = Console.ReadLine();

                    MyDelegate myDelegate = null;

                    if (operation == "+")
                    {
                        myDelegate = calculator.Sum;
                    }
                    else if (operation == "-")
                    {
                        myDelegate = calculator.Subtract;
                    }
                    else
                    {
                        Console.WriteLine("Enter correct symbol");
                        continue;
                    }

                    if (myDelegate != null)
                    {
                        double result = myDelegate(firstNumber, secondNumber);
                        Console.WriteLine($"The result is: {result}");
                    }
                }
                else
                {
                    Console.WriteLine("Enter correct numbers!");
                }
            }
        }
        public class Calculator
        {
            public double Sum(double a, double b)
            {
                return a + b;
            }

            public double Subtract(double a, double b)
            {
                return a - b;
            }
        }
    }
}
