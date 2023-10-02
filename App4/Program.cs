using System;

namespace App4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            ComplexNumber firstA = new ComplexNumber(random.Next(-50, 50), random.NextDouble() * 2 * Math.PI);
            ComplexNumber secondB = new ComplexNumber(random.Next(-50, 50), random.NextDouble() * 2 * Math.PI);
            ComplexNumber thirdC = new ComplexNumber(random.Next(-50, 50), random.NextDouble() * 2 * Math.PI);
            ComplexNumber fourthD = new ComplexNumber(random.Next(-50, 50), random.NextDouble() * 2 * Math.PI);

            //Формула: R = b^3 + ((a + b)/(c - a)) * d ;
            ComplexNumber answerR = (secondB.Power(3)) + ((firstA + secondB) / (thirdC - firstA) * fourthD);
            answerR.AlgebraicForm();
        }
    }
}
