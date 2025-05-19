namespace WebApplication3.Models
{
    public class Supplie
    {
        public int SUPPLIE_ID{ get; set; }
        public int SUPPLIER_ID { get; set; }
        public Supplier SUPPLIER { get; set; } = null!;
        public string DATE { get; set;  }
        public int TOTAL_SUM { get; set; }

        public List<Supplie_Medicine> Suppl_Med = new List<Supplie_Medicine>();
    }
}
