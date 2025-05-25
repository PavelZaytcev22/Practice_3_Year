namespace WebApplication3.Models
{
    /// <summary>
    /// Модель должности
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Первичный ключ сущности
        /// </summary>
        public int PostId { get; set; }
        /// <summary>
        /// Свойство с названием должности
        /// </summary>
        public string PostName { get; set; }
        /// <summary>
        /// Свойство зарплаты сущности 
        /// </summary>
        public int Salary { get; set;  }

    }
}
