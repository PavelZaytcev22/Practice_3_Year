namespace WebApplication3.Models
{
    /// <summary>
    /// Модель медикамента
    /// </summary>
    public class Medicine
    {
        public int MedicineId { get; set; }
        public int ManufacturerId{ get; set; }
        public Manufacturer Manufacturer { get; set; } = null!;
        public string MedicineName { get; set; }
        public int PriceBuyOne { get; set;  }
        
    }
}
