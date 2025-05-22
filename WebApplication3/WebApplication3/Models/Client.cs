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
        public int ClientId { get; set;}
        public string PhoneNumber { get; set; }
        public int Discount {get;set; }       

    }
}
