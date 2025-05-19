namespace WebApplication3.Models
{
    public class Medicine
    {
        public int MEDICINE_ID { get; set; }
        public int MUNUFACTURER_ID { get; set; }

        public Manufacturer MANUFACTURER { get; set; } = null!;
        public string MEDICINE_NAME { get; set; }
        public int PRICE_BUY_ONE { get; set;  }


        public List<Supplie_Medicine> Suppl_Med = new List<Supplie_Medicine>();

        public List<Sale_Medicine> Sale_Med = new List<Sale_Medicine>();
    }
}
