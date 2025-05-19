namespace WebApplication3.Models
{
    public class Supplier
    {
        public int SUPPLIER_ID { get; set;  }

        public string SUPPLIER_NAME { get; set; }

        public List<Supplie> Supplies = new List<Supplie>();
    }
}
