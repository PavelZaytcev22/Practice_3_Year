namespace WebApplication3.Models
{
    /// <summary>
    /// Модель чека
    /// </summary>
    public class Cheque
    {
        public int ChequeId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
        public int EmployerId { get; set; }
        public Employer Employer { get; set; } = null!;
        public string Date { get; set; }
        public int Total_Sum { get; set; }
        public int SumDiscount { get; set; }        
    }
}
