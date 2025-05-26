namespace WebApplication3.Models
{
    /// <summary>
    /// Модель медикамента
    /// </summary>
    public class Medicine
    {
        /// <summary>
        /// Первичный ключ сущности 
        /// </summary>
        public int MedicineId { get; set; }
        /// <summary>
        /// Внешний ключ по производителю 
        /// </summary>
        public int ManufacturerId{ get; set; }
       /// <summary>
       /// Навигационное свойство по внешнему ключу 
       /// </summary>
        public Manufacturer Manufacturer { get; set; } = null!;
      /// <summary>
      /// Свойство с названием лекарства
      /// </summary>
        public string MedicineName { get; set; }        
    }
}
