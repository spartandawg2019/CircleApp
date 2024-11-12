using System;

namespace CircleApp
{
    class Circle
    {
        private double _circleRadius; // stores the radius of the circle

        public Circle(double initialRadius)
        {
            _circleRadius = initialRadius;
        }

        public double GetDiameter()
        {
            return 2 * _circleRadius;
        }

        public double GetCircumference()
        {
            return 2 * Math.PI * _circleRadius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(_circleRadius, 2);
        }

        public void DoubleRadius()
        {
            _circleRadius *= 2;
        }

        public double ShowRadius()
        {
            return _circleRadius;
        }
    }

    static class Validator
    {
        public static double PromptForValidRadius()
        {
            double radius;
            while (true)
            {
                Console.Write("Enter the radius: ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out radius) && radius > 0)
                {
                    return radius;
                }
                else
                {
                    Console.WriteLine("Please enter a positive number.");
                }
            }
        }

        public static bool AskIfCircleShouldGrow()
        {
            while (true)
            {
                Console.Write("Should the circle grow? (y/n): ");
                string response = Console.ReadLine().ToLower();

                if (response == "y") return true;
                if (response == "n") return false;

                Console.WriteLine("Enter 'y' for yes or 'n' for no.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Circle Tester");

            double radius = Validator.PromptForValidRadius();
            Circle userCircle = new Circle(radius);

            while (true)
            {
                Console.WriteLine($"Diameter: {userCircle.GetDiameter():F2}");
                Console.WriteLine($"Circumference: {userCircle.GetCircumference():F2}");
                Console.WriteLine($"Area: {userCircle.GetArea():F2}");

                if (!Validator.AskIfCircleShouldGrow())
                {
                    Console.WriteLine($"Goodbye. The circle’s final radius is {userCircle.ShowRadius():F2}");
                    break;
                }

                userCircle.DoubleRadius();
                Console.WriteLine("The circle has grown.");
            }
        }
    }
}