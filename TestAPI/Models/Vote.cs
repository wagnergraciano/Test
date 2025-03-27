namespace LegislatorAPI.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public Bill Bill { get; set; }
    }
}