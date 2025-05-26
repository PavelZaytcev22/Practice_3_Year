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
        public Client Client { get; set; } = null!;
        /// <summary>
        /// Внешний ключ по работникам
        /// </summary>
        public int EmployerId { get; set; }
        /// <summary>
        /// Навигационное свойство для внешнего ключа по работникам 
        /// </summary>
        public Employer Employer { get; set; } = null!;
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
    }
}
