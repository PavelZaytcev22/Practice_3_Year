namespace WebApplication3
{
    public static class Functions
    {
        public static string PascalCaseToUpperCase(string str)
        {
            string buff = "";
            if (str.Length != 0)
            {
                buff += str[0];
                for (int i = 1; i < str.Length; i++)
                {
                    if (char.IsUpper(str[i]))
                    {
                        buff += '_';
                        buff += str[i];
                    }
                    else
                    {
                        buff += char.ToUpper(str[i]);
                    }
                }
            }
            return buff;
        }
    }
}
