using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    /// <summary>
    /// Модель клиента
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Первичный ключ сущности
        /// </summary>
        public int ClientId { get; set;}
        /// <summary>
        /// Свойство для телефонного номера клиента 
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Свойство для общей скидки для клиента 
        /// </summary>
        public int Discount {get;set; }

        public override bool Equals(object? obj)
        {
            if (obj is Client ) 
            {
                Client obj2 = obj as Client;
                return PhoneNumber.Equals(obj2.PhoneNumber);
            }
            return false;
        }
    }
}
