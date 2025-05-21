namespace WebApplication3.Models
{
    /// <summary>
    /// Модель работника 
    /// </summary>
    public class Employer
    {
        public int EMPLOYER_ID { get; set; }

        public int POST_ID { get; set ;  }
        public Post Post { get; set; }

        public string FIO { get; set;}

        public string PHONE_NUMBER { get; set;  }


    }
}
