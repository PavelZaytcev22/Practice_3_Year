namespace WebApplication3.Models
{
    /// <summary>
    /// Модель производителя
    /// </summary>
    public class Manufacturer
    {
        /// <summary>
        /// Первичный ключ для сущности 
        /// </summary>
        public int ManufacturerId { get; set; }
        /// <summary>
        /// Свойство для имени производителя 
        /// </summary>
        public string ManufacturerName { get; set; }       
    }
}
