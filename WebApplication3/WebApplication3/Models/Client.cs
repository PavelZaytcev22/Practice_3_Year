using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Client
    {
        public int CLIENT_ID { get; set;}

        public string PHONE_NUMBER { get; set; }

        public int DISCOUNT {get;set; }

        public List<Cheque> Cheques { get; set; } = new List<Cheque>();

    }
}
