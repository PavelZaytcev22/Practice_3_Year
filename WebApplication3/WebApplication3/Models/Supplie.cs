namespace WebApplication3.Models
{
    /// <summary>
    /// Модель поставки
    /// </summary>
    public class Supplie
    {
        public int SupplieId{ get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;
        public string Date { get; set;  }
        public int TotalSum { get; set; }

        
    }
}
