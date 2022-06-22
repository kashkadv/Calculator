namespace Calculator
{
    public class Tokenizer
    {
        public List<string> tokens = new List<string>();
        public string data;

        public Tokenizer(string _data)
        {
            data = _data;
        }

        public List<string> Tokenize()
        {
            char[] operators = { '+', '-', '*', '/', '^' };
            string tempNum = "";
            foreach (char c in data)
            {
                // Пропускаем пробел
                if (c == 32) {
                    continue;
                }
                // Если цифра - забрасываем во временный буфер
                if (c >= 48 && c <= 57)
                {
                    tempNum += c.ToString();
                    continue;
                }
                
                // Если буфер не пустой - забрасываем в список буфер
                if (tempNum.Length > 0 && CheckIsNumber(tempNum))
                {
                    tokens.Add(tempNum);
                    tempNum = "";
                }

                //
                if (c == 40 || c == 41)
                {
                    tokens.Add(c.ToString());
                    continue;
                }

                int n;
                if (tokens.Count() == 0 || !int.TryParse(tokens.Last(), out n))
                {
                    if (operators.Contains(c) && tokens.Last() != ")")
                    {
                        tempNum = c.ToString();
                        continue;
                    }
                }

                // Забрасываем в список символ
                tokens.Add(c.ToString());
                
            }
            // Если в буфере осталось число - забрасываем в список
            if (tempNum.Length > 0 && CheckIsNumber(tempNum))
            {
                tokens.Add(tempNum);
                tempNum = "";
            }

            if (operators.Contains(Convert.ToChar(tokens.Last())))
            {
                int index = tokens.Count();
                tokens.RemoveAt(index - 1);
            }

            // Возвращаем список
            return tokens;
        }

        public bool CheckIsNumber(string data)
        {
            int n;
            if (int.TryParse(data, out n))
            {
                return true;
            }
            return false;
        }
    }
}
