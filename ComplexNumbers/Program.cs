using System;
using ComplexNumbers;

namespace ComplexNumbers {
    class Program {
        static void Main(string[] args) {
            try {

                string answer = "Y";
                do {
                    Console.WriteLine("Здравствуйте, вы хотите задать вещественное число? Y|N");
                    answer = Console.ReadLine();
                    if (answer == "Y") {
                        Console.WriteLine("Здравствуйте, вы хотите задать вещественное число? Y|N");
                    }
                } while(answer != "N");
                
            }
            catch (Exception e){
                Console.WriteLine(e);
            }
        }
    }
}
