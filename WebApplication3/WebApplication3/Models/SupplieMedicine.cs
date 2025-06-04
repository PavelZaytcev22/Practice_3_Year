using System.Text.Json.Serialization;

namespace WebApplication3.Models
{
    /// <summary>
    /// Модель части поставки
    /// </summary>
    public class SupplieMedicine
    {
        /// <summary>
        /// Первичный ключ сущности 
        /// </summary>
        public int SuplieMedicineId { get; set;  }
        /// <summary>
        /// Внешний ключ по поставке 
        /// </summary>
        public int SuplieId { get; set; }
        /// <summary>
        /// Навигационное свойство по внешнему ключу 
        /// </summary>
        [JsonIgnore]
        public Supplie? Suplie { get; set; } = null!;
        /// <summary>
        /// Внешний ключ по лекарствам 
        /// </summary>
        public int MedicineId { get; set; }
        /// <summary>
        /// Навигационное свойство по внешнему ключу 
        /// </summary>
        [JsonIgnore]
        public Medicine? Medicine { get; set; } = null!;
        /// <summary>
        /// Свойство для количества медикаментов 
        /// </summary>
        public int Count { get; set;  }
        /// <summary>
        /// Свойство  для хранения для закупки медикамента за 1 единицу  
        /// </summary>
        public int PricePayOne { get; set; }
    }
}
