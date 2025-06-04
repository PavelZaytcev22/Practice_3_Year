using System.Text.Json.Serialization;

namespace WebApplication3.Models
{
    /// <summary>
    /// Модель работника 
    /// </summary>
    public class Employer
    {
        /// <summary>
        /// Первичный ключ сущности 
        /// </summary>
        public int EmployerId { get; set; }
        /// <summary>
        /// Внешний ключ по должностям 
        /// </summary>
        public int PostId { get; set ;  }
        /// <summary>
        /// Навигационное свойство по должностям 
        /// </summary>
        [JsonIgnore]
        public Post? Post { get; set; }
       /// <summary>
       /// Свойство для хранения ФИО
       /// </summary>
        public string Fio { get; set;}
        /// <summary>
        /// Свойство для телефонного номера работника 
        /// </summary>
        public string PhoneNumber { get; set;  }
    }
}
