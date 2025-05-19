namespace WebApplication3.Models
{
    public class Employer
    {
        public int EMPLOYER_ID { get; set; }

        public int POST_ID { get; set ;  }
        public Post Post { get; set; }

        public string FIO { get; set;}

        public string PHONE_NUMBER { get; set;  }


        public List<Cheque> Cheques { get; set; } = new List<Cheque>();
    }
}
