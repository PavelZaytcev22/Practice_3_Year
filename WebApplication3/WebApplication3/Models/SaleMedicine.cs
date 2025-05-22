namespace WebApplication3.Models
{
    /// <summary>
    /// модель продажи
    /// </summary>
    public class SaleMedicine
    {
        public int SaleMedecineId { get; set; }
        public int MedecineId { get; set; }
        public Medicine Medecine { get; set; } = null!;
        public int ChequeId { get; set; }
        public Cheque Cheque { get; set; } = null!;
        public int Count { get; set; }
        public int PriceSellOne { get; set;  }
    }
}
