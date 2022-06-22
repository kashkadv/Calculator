namespace Calculator
{
    internal class Operators
    {
        public int GetPriority(string _c)
        {
            int result = 0;
            if (_c.Length > 1)
            {
                return result;
            }

            char c = Convert.ToChar(_c);

            var priorityDictionary = new Dictionary<char, int>();

            priorityDictionary.Add('(', 0);
            priorityDictionary.Add('-', 1);
            priorityDictionary.Add('+', 1);
            priorityDictionary.Add('*', 2);
            priorityDictionary.Add('/', 2);
            priorityDictionary.Add('^', 3);

            if (priorityDictionary.ContainsKey(c))
            {
                result = priorityDictionary[c];
            }

            return result;
        }
    }
}
