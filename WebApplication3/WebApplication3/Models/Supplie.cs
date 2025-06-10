using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public Supplier? Supplier { get; set; }
        /// <summary>
        /// Свойство сущности для даты 
        /// </summary>
        public string Date { get; set;  }
        /// <summary>
        /// Свойство сущности для полной суммы поставки
        /// </summary>
        public int TotalSum { get; set; }
        /// <summary>
        /// Метод для представления класса в виде строки 
        /// </summary>
        /// <returns>Строка с данными класса</returns>
        /// <exception cref="ArgumentNullException">Навигационное свойство равно нулю</exception>
        public override string ToString()
        {
            //if (this.Supplier== null) { throw new ArgumentNullException(); }
            return this.SupplieId+" | "+Date + " | " /*+ Supplier.SupplierName*/;
        }
    }
}
