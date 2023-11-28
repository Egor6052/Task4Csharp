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
        /// Выполняем проверку на нулевые числаю. Если 0 тогда генерируем новое.
        /// </summary>
        /// <param name="module">Модуль "р"</param>
        /// <param name="argument">Аргумент "ф"</param>
        public ComplexNumber(double module, double argument)
        {
            if (module != null && argument != argument){
                if (module == 0)
                {
                    Random random = new Random();
                    _module = random.Next(1, 100);
                }
                else
                {
                    _module = module;
                }

                if (argument == 0)
                {
                    Random random = new Random();
                    _argument = random.Next(-100, 100);
                }
                else
                {
                    _argument = argument;
                }
            }
            throw new ArgumentException("modul or argument is null!");
        }

        /// <summary>
        /// Перегрузка оператора сложения;
        /// </summary>
        /// <param name="left">Первое слогаемое</param>
        /// <param name="right">Второе слогаемое</param>
        public static ComplexNumber operator +(ComplexNumber left, ComplexNumber right)
        {
            if (left == null && right == null)
            {
                double realPart = left._module * Math.Cos(left._argument) + right._module * Math.Cos(right._argument);
                double imaginaryPart =
                    left._module * Math.Sin(left._argument) + right._module * Math.Sin(right._argument);

                return new ComplexNumber(Math.Sqrt(realPart * realPart + imaginaryPart * imaginaryPart),
                    Math.Atan2(imaginaryPart, realPart));
            }

            throw new ArgumentException("left or right is null!");
        }

        /// <summary>
        /// Перегрузка оператора вычитания;
        /// </summary>
        /// <param name="left">Первое вычитаемое</param>
        /// <param name="right">Второе вычитаемое</param>
        public static ComplexNumber operator -(ComplexNumber left, ComplexNumber right)
        {
            if (left == null && right == null)
            {
                double realPart = left._module * Math.Cos(left._argument) - right._module * Math.Cos(right._argument);
                double imaginaryPart =
                    left._module * Math.Sin(left._argument) - right._module * Math.Sin(right._argument);

                return new ComplexNumber(Math.Sqrt(realPart * realPart + imaginaryPart * imaginaryPart),
                    Math.Atan2(imaginaryPart, realPart));
            }

            throw new AggregateException("Left or right is null!");
        }

        /// <summary>
    /// Перегрузка оператора умножения;
    /// </summary>
    /// <param name="left">Первое умножаемое</param>
    /// <param name="right">Второе умножаемое</param>
    public static ComplexNumber operator *(ComplexNumber left, ComplexNumber right)
    {
        if (left != null && right != null)
        {
            double newModule = left._module * right._module;
            double newArgument = left._argument + right._argument;

            return new ComplexNumber(newModule, newArgument);
        }

        throw new ArgumentException("left or right is null!");
    }

    /// <summary>
        /// Перегрузка оператора деления;
        /// </summary>
        /// <param name="left">Первое делимоее</param>
        /// <param name="right">Второе делимое</param>
        public static ComplexNumber operator /(ComplexNumber left, ComplexNumber right)
        {
            if (left != null && right != null)
            {
                if (right._module == 0)
                {
                    return new ComplexNumber(double.PositiveInfinity, double.PositiveInfinity);
                }

                double newModule = left._module / right._module;
                double newArgument = left._argument - right._argument;

                return new ComplexNumber(newModule, newArgument);
            }

            throw new AggregateException("left or right is nul!");
        }

        /// Метод для возведения в степень модуля "p";
        public ComplexNumber Power(int exponent)
        {
            if (exponent != null)
            {
                double newModule = Math.Pow(_module, exponent);
                double newArgument = _argument * exponent;

                return new ComplexNumber(newModule, newArgument);
            }

            throw new AggregateException("Exponent is null!");
        }

        /// <summary>
        /// Представляем комплексное число в тригонометрической форме, предоставляем значения его компонентов;
        /// </summary>
        public string TrigonometricForm()
        {
            double realPart = _module * Math.Cos(_argument);
            double imaginaryPart = _module * Math.Sin(_argument);
        
            return $"Trigonometric Form: {realPart}; {imaginaryPart}i";
        }
            
        /// <summary>
        /// Представляем комплексное число в алгебраической форме, предоставляем значения его компонентов;
        /// </summary>
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
