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
        public int CLIENT_ID { get; set;}
        public string PHONE_NUMBER { get; set; }
        public int DISCOUNT {get;set; }       

    }
}
