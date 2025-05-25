namespace WebApplication3.Models
{
    /// <summary>
    ///Модель поставщика
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Первичный ключ сущности
        /// </summary>
        public int SupplierId { get; set;  }
        /// <summary>
        /// Свойство для названия поставщика
        /// </summary>
        public string SupplierName { get; set; }
       
    }
}
