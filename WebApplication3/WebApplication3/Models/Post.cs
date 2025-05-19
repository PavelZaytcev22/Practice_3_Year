namespace WebApplication3.Models
{
    public class Post
    {
        public int POST_ID { get; set; }
        public string POST_NAME { get; set; }
        public int SALARY { get; set;  }

        public List<Employer> Employers = new List<Employer>();
    }
}
