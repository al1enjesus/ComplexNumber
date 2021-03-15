using System;
using System.Collections.Generic;
using System.Globalization;
using ComplexNumbers;

namespace ComplexNumbers {
    class Program {
        static void Main(string[] args) {
            try {
                List<ComplexNumber> nums = new List<ComplexNumber>();

                string answer = "Y";
                do {
                    Console.WriteLine("Вы хотите задать комплексное число? Y|N");
                    answer = Console.ReadLine();
                    if (answer == "Y") {
                        float realPart, imaginePart;
                        Console.WriteLine("Введите действительную часть");
                        realPart = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);
                        Console.WriteLine("Введите мнимую часть");
                        imaginePart = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);

                        ComplexNumber temp = new ComplexNumber(realPart, imaginePart);
                        nums.Add(temp);
                        Console.WriteLine("Новое число добавлено");
                    }
                } while(answer == "Y" || answer == "y");

                Console.WriteLine($"Количество заданных чисел: {nums.Count}");
                if (nums.Count != 0) {
                    Console.WriteLine("Заданные вами числа");
                    foreach(var number in nums) {
                        Console.WriteLine(number);
                    }
                }

                answer = "Y";
                do {
                    Console.WriteLine("Вы хотите использовать арифметическую операция к вашим числам? Y|N");
                    answer = Console.ReadLine();
                    if(answer == "Y") {
                        string operationType;
                        Console.WriteLine("Введите операцию '+', '-', '*', '/'");
                        operationType = Console.ReadLine();
                        Console.WriteLine($"Введите номер левого числа (индекс[1..{nums.Count}] , среди заданых вами чисел)");
                        int leftInd = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Введите номер правого числа (индекс[1..{nums.Count}], среди заданых вами чисел)");
                        int rightInd = int.Parse(Console.ReadLine());

                        Console.Write("Результат применения операции: ");
                        switch(operationType) {
                            case "+":
                                Console.WriteLine(nums[leftInd - 1] + nums[rightInd - 1]);
                                break;
                            case "-":
                                Console.WriteLine(nums[leftInd - 1] - nums[rightInd - 1]);
                                break;
                            case "*":
                                Console.WriteLine(nums[leftInd - 1] * nums[rightInd - 1]);
                                break;
                            case "/":
                                Console.WriteLine(nums[leftInd - 1] / nums[rightInd - 1]);
                                break;

                        }
                    }
                } while(answer == "Y" || answer == "y");

                answer = "Y";
                do {
                    Console.WriteLine("Вы хотите использовать операцию сравнения по модулю к вашим числам? Y|N");
                    answer = Console.ReadLine();
                    if(answer == "Y") {
                        string operationType;
                        Console.WriteLine("Введите операцию '>', '>=', '<', '<=', '==', '!='");
                        operationType = Console.ReadLine();
                        Console.WriteLine($"Введите номер левого числа (индекс[1..{nums.Count}] , среди заданых вами чисел)");
                        int leftInd = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Введите номер правого числа (индекс[1..{nums.Count}], среди заданых вами чисел)");
                        int rightInd = int.Parse(Console.ReadLine());

                        Console.Write("Результат применения операции: ");
                        switch(operationType) {
                            case ">":
                                Console.WriteLine(nums[leftInd - 1] > nums[rightInd - 1]);
                                break;
                            case "<":
                                Console.WriteLine(nums[leftInd - 1] < nums[rightInd - 1]);
                                break;
                            case ">=":
                                Console.WriteLine(nums[leftInd - 1] >= nums[rightInd - 1]);
                                break;
                            case "<=":
                                Console.WriteLine(nums[leftInd - 1] <= nums[rightInd - 1]);
                                break;
                            case "==":
                                Console.WriteLine(nums[leftInd - 1] == nums[rightInd - 1]);
                                break;
                            case "!=":
                                Console.WriteLine(nums[leftInd - 1] != nums[rightInd - 1]);
                                break;

                        }
                    }
                } while(answer == "Y" || answer == "y");

                Console.WriteLine("Программа завершила работу, спасибо за использование");
            }
            catch (Exception e){
                Console.WriteLine(e);
            }
        }
    }
}
