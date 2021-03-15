using System;
using ComplexNumbers;

namespace ComplexNumbers {
    class Program {
        static void Main(string[] args) {
            ComplexNumber a = new ComplexNumber(realPart: 2);
            Console.WriteLine(a);

            ComplexNumber b = new ComplexNumber(realPart: -2);
            Console.WriteLine(b);

            ComplexNumber Num = new ComplexNumber();
            Console.WriteLine(Num);

            Console.WriteLine(new ComplexNumber(8, 1) / new ComplexNumber(2, -3));
            Console.WriteLine(new ComplexNumber(7, -3) * new ComplexNumber(7, 3));
        }
    }
}
