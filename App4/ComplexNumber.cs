using System;

namespace App4
{
    public class ComplexNumber
    {
        private double _module;
        private double _argument;

        /// <summary>
        /// Сеттер и геттер для поля Module
        /// Выполняем проверку на нулевые числаю Если 0 тогда генерируем новое.
        /// </summary>
        public double Module
        {
            get { return _module; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Module не должен быть равен нулю.");
                }
                _module = value;
            }
        }

        /// <summary>
        /// Сеттер и геттер для поля Argument
        /// Выполняем проверку на нулевые числаю Если 0 тогда генерируем новое.
        /// </summary>
        public double Argument
        {
            get { return _argument; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Argument не должен быть равен нулю.");
                }
                _argument = value;
            }
        }
        
        /// <summary>
        /// Конструктор для комплексного числа в тригонометрической форме.
        /// </summary>
        /// <param name="module">Модуль "р"</param>
        /// <param name="argument">Аргумент "ф"</param>
        public ComplexNumber(double module, double argument)
        {
            Module = module;
            Argument = argument;
        }
        
        /// <summary>
        /// Перегрузка оператора сложения;
        /// </summary>
        /// <param name="module">Первое слогаемое</param>
        /// <param name="argument">Второе слогаемое</param>
        public static ComplexNumber operator +(ComplexNumber left, ComplexNumber right)
        {
            double realPart = left.Module * Math.Cos(left.Argument) + right.Module * Math.Cos(right.Argument);
            double imaginaryPart = left.Module * Math.Sin(left.Argument) + right.Module * Math.Sin(right.Argument);

            return new ComplexNumber(Math.Sqrt(realPart * realPart + imaginaryPart * imaginaryPart), Math.Atan2(imaginaryPart, realPart));
        }
        
        /// <summary>
        /// Перегрузка оператора вычитания;
        /// </summary>
        /// <param name="module">Первое вычитаемое</param>
        /// <param name="argument">Второе вычитаемое</param>
        public static ComplexNumber operator -(ComplexNumber left, ComplexNumber right)
        {
            double realPart = left.Module * Math.Cos(left.Argument) - right.Module * Math.Cos(right.Argument);
            double imaginaryPart = left.Module * Math.Sin(left.Argument) - right.Module * Math.Sin(right.Argument);

            return new ComplexNumber(Math.Sqrt(realPart * realPart + imaginaryPart * imaginaryPart), Math.Atan2(imaginaryPart, realPart));
        }

        /// <summary>
        /// Перегрузка оператора умножения;
        /// </summary>
        /// <param name="module">Первое умножаемое</param>
        /// <param name="argument">Второе умножаемое</param>
        public static ComplexNumber operator *(ComplexNumber left, ComplexNumber right)
        {
            double newModule = left.Module * right.Module;
            double newArgument = left.Argument + right.Argument;

            return new ComplexNumber(newModule, newArgument);
        }

        /// <summary>
        /// Перегрузка оператора деления;
        /// </summary>
        /// <param name="module">Первое делимоее</param>
        /// <param name="argument">Второе делимое</param>
        public static ComplexNumber operator /(ComplexNumber left, ComplexNumber right)
        {
            if (right.Module == 0)
            {
                throw new DivideByZeroException("Делить на ноль нельзя!");
            }
            else
            {
                double newModule = left.Module / right.Module;
                double newArgument = left.Argument - right.Argument;

                return new ComplexNumber(newModule, newArgument);   
            }
        }


        /// Метод для возведения в степень модуля "p";
        public ComplexNumber Power(int exponent)
        {
            double newModule = Math.Pow(Module, exponent);
            double newArgument = Argument * exponent;

            return new ComplexNumber(newModule, newArgument);
        }

        /// <summary>
        /// Представляем комплексное число в тригонометрической форме, предоставляем значения его компонентов;
        /// </summary>
        /// <param name="module">Первое число</param>
        /// <param name="argument">Второе число</param>
        public string TrigonometricForm()
        {
            double realPart = Module * Math.Cos(Argument);
            double imaginaryPart = Module * Math.Sin(Argument);

            // F3 - формат числа до 3 знаков после запятой;
            return $"Тригонометрическая форма: {realPart:F3}; {imaginaryPart:F3}i";
        }
            
        /// <summary>
        /// Представляем комплексное число в алгебраической форме, предоставляем значения его компонентов;
        /// </summary>
        /// <param name="module">Первое число</param>
        /// <param name="argument">Второе число</param>
        public string AlgebraicForm()
        {
            return $"Алгебраическая форма: {Module:F3}; {Argument:F3}i";
        }

        public override string ToString()
        {
            return $"\n{Module}\n{Argument}";
        }
    }
}
