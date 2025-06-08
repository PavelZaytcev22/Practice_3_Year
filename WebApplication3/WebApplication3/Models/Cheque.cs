using System.Text.Json.Serialization;
namespace WebApplication3.Models
{
    /// <summary>
    /// Модель чека
    /// </summary>
    public class Cheque
    {
        /// <summary>
        /// Первичный ключ сущности 
        /// </summary>
        public int ChequeId { get; set; }
        /// <summary>
        /// Внешний ключ сущности по клиентам 
        /// </summary>
        public int ClientId { get; set; }
        /// <summary>
        /// Навигационное свойство для внешнего ключа по клиентам
        /// </summary>
        [JsonIgnore]
        public Client? Client { get; set; } = null!;
        /// <summary>
        /// Внешний ключ по работникам
        /// </summary>
        public int EmployerId { get; set; }
        /// <summary>
        /// Навигационное свойство для внешнего ключа по работникам 
        /// </summary>
        [JsonIgnore]
        public Employer? Employer { get; set; } = null!;
        /// <summary>
        /// Свойство для даты проведения чека 
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Свойство для полной суммы чека всех продаж 
        /// </summary>
        public int TotalSum { get; set; }
        /// <summary>
        /// Свойство для полной суммы чека всех продаж по скидке
        /// </summary>
        public int SumDiscount { get; set; }
        /// <summary>
        /// Мето возвращает строку с данными чека о клиенте и дате
        /// </summary>
        /// <returns>Строка с данными о чеке</returns>
        /// <exception cref="ArgumentNullException">Навигационное свойство null</exception>
        public override string ToString()
        {
            if (Client==null) 
            {
                throw new ArgumentNullException();
            }
            return"("+ Client.PhoneNumber + ") | (" + Date+")";
        }
    }
}
