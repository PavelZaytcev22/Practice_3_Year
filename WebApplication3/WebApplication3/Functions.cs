namespace WebApplication3
{
    /// <summary>
    /// класс функция для проекта
    /// </summary>
    public static class Functions
    {
        /// <summary>
        /// Функция для преобразования из Pascal_case в Upper_case 
        /// </summary>
        /// <param name="str">Исходная строка в Pascal_case</param>
        /// <returns>Cтрока в Upper_Case</returns>
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
