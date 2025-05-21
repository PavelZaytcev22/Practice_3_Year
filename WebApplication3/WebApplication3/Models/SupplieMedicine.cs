namespace WebApplication3.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SupplieMedicine
    {
        public int SUPPL_MEDICINE_ID { get; set;  }
        public int SUPLIE_ID { get; set; }
        public Supplie SUPPLIE { get; set; } = null!;
        public int MEDICINE_ID { get; set; }
        public Medicine MEDICINE { get; set; } = null!;
        public int COUNT { get; set;  }
        public int PRICE_PAY_ONE { get; set; }
    }
}
