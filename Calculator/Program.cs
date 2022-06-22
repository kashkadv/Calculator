namespace Calculator
{
    public class Program
    {
        static void Main()
        {
            Tokenizer tokens = new Tokenizer("(2 +-2)* 2 + 2^2");
            List<string> test = tokens.Tokenize();
            var calculator = new Calculator(test);
            var result = calculator.Count();

            Console.WriteLine(result);
        }
    }
}