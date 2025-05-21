namespace WebApplication3.Models
{
    /// <summary>
    /// Модель медикамента
    /// </summary>
    public class Medicine
    {
        public int MEDICINE_ID { get; set; }
        public int MUNUFACTURER_ID { get; set; }
        public Manufacturer MANUFACTURER { get; set; } = null!;
        public string MEDICINE_NAME { get; set; }
        public int PRICE_BUY_ONE { get; set;  }
        
    }
}
