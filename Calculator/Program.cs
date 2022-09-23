namespace Edu.Assignment.Calculator
{
    internal sealed class Program
    {
        private static int Main(String[] args)
        {
            var option = GetOption();
            while (option < 1 || option > 4)
            {
                Console.WriteLine("Please choose the correct options (Press any key to choose again)");
                _ = Console.ReadKey();
                Console.Clear();
                option = GetOption();
            }

            Console.WriteLine();

            var input = GetInput();
            while (input is null)
            {
                Console.WriteLine("Please enter correct input (Press any key to input again)");
                _ = Console.ReadKey();
                input = GetInput();
            }

            Console.WriteLine($"The result is : {CalculateResult(input, option)}");
            return 0;
        }

        private static uint GetOption()
        {
            Console.WriteLine("Enter the action to perform");
            Console.WriteLine("Press 1 for Addition");
            Console.WriteLine("Press 2 for Substraction");
            Console.WriteLine("Press 3 for Multiplication");
            Console.WriteLine("Press 4 for Division \n");
            Console.Write("Your choice is : ");
            _ = uint.TryParse(Console.ReadLine(), out uint options);
            return options;
        }

        private static Tuple<Double, Double>? GetInput()
        {
            Console.Write("Enter 1st input : ");
            if (!double.TryParse(Console.ReadLine(), out double firstInput))
                return default;

            Console.Write("Enter 2nd input : ");
            if (!double.TryParse(Console.ReadLine(), out double secondInput))
                return default;

            return Tuple.Create(firstInput, secondInput);
        }

        private static double CalculateResult(Tuple<double, double> input, uint options) =>
            options switch
            {
                1 => input.Item1 + input.Item2,
                2 => input.Item1 - input.Item2,
                3 => input.Item1 * input.Item2,
                4 => input.Item1 / input.Item2,
                _ => throw new IndexOutOfRangeException(),
            };
    }
}