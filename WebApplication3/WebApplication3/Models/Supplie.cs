namespace WebApplication3.Models
{
    /// <summary>
    /// Модель поставки
    /// </summary>
    public class Supplie
    {
        /// <summary>
        /// Первичный ключ сущности
        /// </summary>
        public int SupplieId{ get; set; }
        /// <summary>
        /// Внешний ключ по поставщикам
        /// </summary>
        public int SupplierId { get; set; }
        /// <summary>
        /// Навигационное свойство по внешнему ключу 
        /// </summary>
        public Supplier Supplier { get; set; } = null!;
        /// <summary>
        /// Свойство сущности для даты 
        /// </summary>
        public string Date { get; set;  }
        /// <summary>
        /// Свойство сущности для полной суммы поставки
        /// </summary>
        public int TotalSum { get; set; }

        
    }
}
