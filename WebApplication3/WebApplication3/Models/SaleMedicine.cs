

using System.Text.Json.Serialization;

namespace WebApplication3.Models
{
    /// <summary>
    /// Модель продажи
    /// </summary>
    public class SaleMedicine
    {
        /// <summary>
        /// Первичный ключ сущности
        /// </summary>
        public int SaleMedecineId { get; set; }
        /// <summary>
        /// Внешний ключ сущности по медикаментам 
        /// </summary>
        public int MedicineId { get; set; }
        /// <summary>
        /// Навигационное свойство по внешнему ключу 
        /// </summary>
        [JsonIgnore]
        public Medicine? Medicine { get; set; } = null!;
        /// <summary>
        ///  Внешний ключ сущности по чекам  
        /// </summary>
        public int ChequeId { get; set; }
        /// <summary>
        /// Навигационное свойство по внешнему ключу 
        /// </summary>
        [JsonIgnore]
        public Cheque? Cheque { get; set; } = null!;
        /// <summary>
        /// Свойство колличества проданных лекарств
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Свойство цены продажи за одну единицу 
        /// </summary>
        public int PriceSellOne { get; set;  }
    }
}
