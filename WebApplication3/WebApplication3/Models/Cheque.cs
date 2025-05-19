namespace WebApplication3.Models
{
    public class Cheque
    {
        public int CHEQUE_ID { get; set; }
        public int CLIENT_ID { get; set; }
        public Client CLIENT { get; set; } = null!;
        public int EMPLOYER_ID { get; set; }
        public Employer EMPLOEYER { get; set; } = null!;
        public string DATE { get; set; }
        public int TOTAL_SUM { get; set; }
        public int SUM_DISCUNT { get; set; }

        public List<Sale_Medicine> Sale_Medicines = new List<Sale_Medicine>();
    }
}
