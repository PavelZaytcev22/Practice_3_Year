namespace WebApplication3.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Sale_Medicine
    {
        public int SALE_MEDICINE_ID { get; set; }
        public int MEDICINE_ID { get; set; }
        public Medicine MEDICINE { get; set; } = null!;
        public int CHEQUE_ID { get; set; }
        public Cheque CHEQUE { get; set; } = null!;
        public int COUNT { get; set; }
        public int PRICE_SELL_ONE { get; set;  }
    }
}
