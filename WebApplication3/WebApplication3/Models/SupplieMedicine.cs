namespace WebApplication3.Models
{
    /// <summary>
    /// Модель части поставки
    /// </summary>
    public class SupplieMedicine
    {
        public int SuplieMedicineId { get; set;  }
        public int SuplieId { get; set; }
        public Supplie Suplie { get; set; } = null!;
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = null!;
        public int Count { get; set;  }
        public int PricePayOne { get; set; }
    }
}
