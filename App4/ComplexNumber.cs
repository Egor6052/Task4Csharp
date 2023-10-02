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
            set { _module = value; }
        }

        /// <summary>
        /// Сеттер и геттер для поля Argument
        /// Выполняем проверку на нулевые числаю Если 0 тогда генерируем новое.
        /// </summary>
        public double Argument
        {
            get { return _argument; }
            set { _argument = value; }
        }
        
        /// <summary>
        /// Конструктор для комплексного числа в тригонометрической форме.
        /// Выполняем проверку на нулевые числаю Если 0 тогда генерируем новое.
        /// </summary>
        /// <param name="module">Модуль "р"</param>
        /// <param name="argument">Аргумент "ф"</param>
        public ComplexNumber(double module, double argument)
        {
            Random random = new Random();
            if (module == 0)
            {
                _module = random.Next(1, 100);
            }
            else
            {
                _module = module;
            }

            if (argument == 0)
            {
                _argument = random.Next(-100, 100);
            }
            else
            {
                _argument = argument;
            }
        }
        
        /// <summary>
        /// Перегрузка оператора сложения;
        /// </summary>
        /// <param name="module">Первое слогаемое</param>
        /// <param name="argument">Второе слогаемое</param>
        public static ComplexNumber operator +(ComplexNumber left, ComplexNumber right)
        {
            double realPart = left._module * Math.Cos(left._argument) + right._module * Math.Cos(right._argument);
            double imaginaryPart = left._module * Math.Sin(left._argument) + right._module * Math.Sin(right._argument);

            return new ComplexNumber(Math.Sqrt(realPart * realPart + imaginaryPart * imaginaryPart), Math.Atan2(imaginaryPart, realPart));
        }
        
        /// <summary>
        /// Перегрузка оператора вычитания;
        /// </summary>
        /// <param name="module">Первое вычитаемое</param>
        /// <param name="argument">Второе вычитаемое</param>
        public static ComplexNumber operator -(ComplexNumber left, ComplexNumber right)
        {
            double realPart = left._module * Math.Cos(left._argument) - right._module * Math.Cos(right._argument);
            double imaginaryPart = left._module * Math.Sin(left._argument) - right._module * Math.Sin(right._argument);

            return new ComplexNumber(Math.Sqrt(realPart * realPart + imaginaryPart * imaginaryPart), Math.Atan2(imaginaryPart, realPart));
        }

        /// <summary>
        /// Перегрузка оператора умножения;
        /// </summary>
        /// <param name="module">Первое умножаемое</param>
        /// <param name="argument">Второе умножаемое</param>
        public static ComplexNumber operator *(ComplexNumber left, ComplexNumber right)
        {
            double newModule = left._module * right._module;
            double newArgument = left._argument + right._argument;

            return new ComplexNumber(newModule, newArgument);
        }

        /// <summary>
        /// Перегрузка оператора деления;
        /// </summary>
        /// <param name="module">Первое делимоее</param>
        /// <param name="argument">Второе делимое</param>
        public static ComplexNumber operator /(ComplexNumber left, ComplexNumber right)
        {
            // Проверка деления на ноль. Если модуль b равен нулю, вернуть комплексное число с бесконечными значениями.
            if (right._module == 0)
            {
                return new ComplexNumber(double.PositiveInfinity, double.PositiveInfinity);
            }

            double newModule = left._module / right._module;
            double newArgument = left._argument - right._argument;

            return new ComplexNumber(newModule, newArgument);
        }

        /// Метод для возведения в степень модуля "p";
        public ComplexNumber Power(int exponent)
        {
            double newModule = Math.Pow(_module, exponent);
            double newArgument = _argument * exponent;

            return new ComplexNumber(newModule, newArgument);
        }

        /// <summary>
        /// Представляем комплексное число в тригонометрической форме, предоставляем значения его компонентов;
        /// </summary>
        /// <param name="module">Первое число</param>
        /// <param name="argument">Второе число</param>
        public string TrigonometricForm()
        {
            double realPart = _module * Math.Cos(_argument);
            double imaginaryPart = _module * Math.Sin(_argument);
        
            return $"Trigonometric Form: {realPart}; {imaginaryPart}i";
        }
            
        /// <summary>
        /// Представляем комплексное число в алгебраической форме, предоставляем значения его компонентов;
        /// </summary>
        /// <param name="module">Первое число</param>
        /// <param name="argument">Второе число</param>
        public string AlgebraicForm()
        {
            return $"Algebraic Form: {_module}; {_module}i";
        }

         public override string ToString()
         {
            return $"\n{_module}\n{_argument}";
        }
    }
}