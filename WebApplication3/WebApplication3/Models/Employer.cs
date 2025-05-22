namespace WebApplication3.Models
{
    /// <summary>
    /// Модель работника 
    /// </summary>
    public class Employer
    {
        public int EmployerId { get; set; }
        public int PostId { get; set ;  }
        public Post Post { get; set; }
        public string Fio { get; set;}
        public string PhoneNumber { get; set;  }
    }
}
