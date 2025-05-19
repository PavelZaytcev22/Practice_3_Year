namespace WebApplication3.Models
{
    public class Manufacturer
    {
        public int MUNUFACTURER_ID { get; set; }
        public string MUNUFACTURER_NAME { get; set; }

        public List<Medicine> Medicines = new List<Medicine>();
    }
}
