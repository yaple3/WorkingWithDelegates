namespace WorkingWithDelegates
{
    public delegate double MyDelegate(double a, double b);

    public class MathSolutions
    {
        public double GetSum(double x, double y)
        {
            return x + y;
        }
        public double GetProduct(double a, double b)
        {
            return a * b;
        }
        public void GetSmaller(double a, double b)
        {
            if (a < b)
            {
                Console.WriteLine($" {a} is smaller than {b}");
            }
            else if (b < a)
            {
                Console.WriteLine($" {b} is smaller than {a}");
            }
            else
            {
                Console.WriteLine($" {b} is equal to {a}");
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            // create a class object
            MathSolutions answer = new();
            Random r = new();
            double num1 = Math.Round(r.NextDouble() * 100);
            double num2 = Math.Round(r.NextDouble() * 100);
            Console.WriteLine($" {num1} + {num2} = {answer.GetSum(num1, num2)}");
            Console.WriteLine($" {num1} + {num2} = {answer.GetProduct(num1, num2)}");
            answer.GetSmaller(num1, num2);

            Console.WriteLine("Action delegate called");
            // create an Action delegate
            Action<double, double> action = answer.GetSmaller;
            action(num1, num2);
            Console.WriteLine();
            Console.WriteLine("Func delegate called");
            // create a Func delegate
            Func<double, double, double> func = answer.GetSum;
            Console.WriteLine($" {num1} + {num2} = {func(num1, num2)}");
            Console.WriteLine();
            Console.WriteLine("Custom delegate called");
            // create a custom delegate
            Console.WriteLine("Enter two numbers to multiply");
            bool isNum3Valid = double.TryParse(Console.ReadLine(), out double num3);
            bool isNum4Valid = double.TryParse(Console.ReadLine(), out double num4);
            if (!isNum3Valid || !isNum4Valid)
            {
                Console.WriteLine("Invalid input, please enter numeric values.");
                return;
            }
            MyDelegate myDelegate = answer.GetProduct;
            Console.WriteLine($" {num3} * {num4} = {myDelegate(num3, num4)}");
        }
    }
}